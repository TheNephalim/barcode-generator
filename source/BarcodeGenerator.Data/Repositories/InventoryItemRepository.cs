// ***********************************************************************
// Assembly          : BarcodeGenerator.Data.Repositories
// Author            : Robert Eberhart
// Created           : 08-29-2026
// ***********************************************************************

using BarcodeGenerator.Data.Database;
using BarcodeGenerator.Data.Repositories.Results;
using BarcodeGenerator.Entities;
using Dapper;
using System.Data;

namespace BarcodeGenerator.Data.Repositories;

/// <summary>
/// Provides methods for managing and interacting with inventory items in the database.
/// </summary>
/// <remarks>
/// This repository is responsible for performing CRUD operations and other database interactions
/// related to <see cref="BarcodeGenerator.Entities.InventoryItem"/> objects. It utilizes an
/// <see cref="BarcodeGenerator.Data.Database.IDbConnectionFactory"/> to establish database connections.
/// </remarks>
public sealed class InventoryItemRepository : IInventoryItemRepository {
    private readonly IDbConnectionFactory _dbConnectionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItemRepository"/> class.
    /// </summary>
    /// <param name="dbConnectionFactory">
    /// An instance of <see cref="IDbConnectionFactory"/> used to create database connections.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="dbConnectionFactory"/> is <c>null</c>.
    /// </exception>
    public InventoryItemRepository(IDbConnectionFactory dbConnectionFactory) {
        _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
    }

    /// <summary>
    /// Adds a new inventory item to the database asynchronously.
    /// </summary>
    /// <param name="inventoryItem">
    /// The <see cref="BarcodeGenerator.Entities.InventoryItem"/> object representing the inventory item to be added.
    /// </param>
    /// <param name="connection">
    /// The <see cref="System.Data.IDbConnection"/> instance used to execute the database operation.
    /// </param>
    /// <param name="transaction">
    /// The <see cref="System.Data.IDbTransaction"/> instance representing the transaction within which the operation is executed.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="inventoryItem"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method inserts a new record into the <c>InventoryItem</c> table in the database.
    /// It ensures that the provided inventory item is not <c>null</c> and uses the provided database connection and transaction.
    /// </remarks>
    /// <returns>
    /// A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.
    /// </returns>
    public async Task AddInventoryItemAsync(InventoryItem inventoryItem, IDbConnection connection, IDbTransaction transaction) {
        ArgumentNullException.ThrowIfNull(inventoryItem);
        ArgumentNullException.ThrowIfNull(connection);
        ArgumentNullException.ThrowIfNull(transaction);

        const string sql = """
                           INSERT INTO InventoryItem (
                               Sku, Title, Price, AcquisitionCost, AcquisitionDate,
                               AcquisitionSource, StorageLocation, SourceSystem,
                               SourceRecordId, ImportedAt,
                               CreatedAt, ModifiedAt, Quantity
                           ) VALUES(
                             @CustomSku, @Product, @ListingPrice, @Cost,
                             @PurchaseDate, @PurchasedAt, @StorageLocation, @SourceSystem,
                             @SourceRecordId, datetime('now'), datetime('now'),
                             datetime('now'), @QuantityRemaining
                           );
                           """;

        var result = await connection.ExecuteAsync(sql, inventoryItem);
    }

    /// <summary>
    /// Deletes all inventory items from the database.
    /// </summary>
    /// <remarks>
    /// This method removes all records from the InventoryItem table.
    /// Use with caution as it will result in the loss of all inventory data.
    /// </remarks>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ClearAllInventory() {
        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        const string sql = """
                           DELETE FROM InventoryItem;
                           """;

        await connection.ExecuteAsync(sql);
    }

    /// <summary>
    /// Retrieves all inventory items from the database.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of
    /// <see cref="BarcodeGenerator.Entities.InventoryLabelRow"/> objects representing the inventory items.
    /// </returns>
    /// <remarks>
    /// This method executes a query to fetch all inventory items and maps the results to
    /// <see cref="BarcodeGenerator.Entities.InventoryLabelRow"/> objects. It utilizes a database connection
    /// created by the <see cref="BarcodeGenerator.Data.Database.IDbConnectionFactory"/>.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    /// Thrown if the database connection cannot be established.
    /// </exception>
    /// <exception cref="System.Data.SqlClient.SqlException">
    /// Thrown if there is an error executing the SQL query.
    /// </exception>
    public async Task<IList<InventoryLabelRow>> GetAll() {
        const string sql = """
                           SELECT Id, Sku, Title, Price, ImportedAt, Quantity, Quantity As Copies, LabelPrintedAt
                           FROM InventoryItem
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        var inventoryItems = await connection.QueryAsync<InventoryLabelRow>(sql);
        return [.. inventoryItems];
    }

    /// <summary>
    /// Retrieves a set of existing record identifiers from the inventory database.
    /// </summary>
    /// <returns>
    /// A <see cref="HashSet{T}"/> containing unique identifiers of existing records.
    /// </returns>
    /// <remarks>
    /// This method queries the database for non-null values in the <c>SourceRecordId</c> column
    /// of the <c>InventoryItem</c> table. It ensures that only distinct identifiers are returned.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the database connection could not be established.
    /// </exception>
    /// <exception cref="SqlException">
    /// Thrown if an error occurs while executing the SQL query.
    /// </exception>
    public async Task<HashSet<string>> GetExistingRecordIdentifiers() {
        const string sql = """
                           SELECT SourceRecordId
                           FROM InventoryItem
                           WHERE SourceRecordId IS NOT NULL;
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        return [.. await connection.QueryAsync<string>(sql)];
    }

    /// <summary>
    /// Retrieves a set of existing SKUs from the inventory.
    /// </summary>
    /// <returns>
    /// A <see cref="HashSet{T}"/> containing the SKUs that currently exist in the inventory.
    /// </returns>
    /// <remarks>
    /// This method queries the database for all non-null SKUs in the <c>InventoryItem</c> table.
    /// It establishes a database connection using the <see cref="IDbConnectionFactory"/> and ensures
    /// that the connection is properly opened before executing the query.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the database connection cannot be established or the query execution fails.
    /// </exception>
    /// <example>
    /// <code>
    /// var repository = new InventoryItemRepository(dbConnectionFactory);
    /// HashSet<string> existingSkus = await repository.GetExistingSkus();
    /// </code>
    /// </example>
    public async Task<HashSet<string>> GetExistingSkus() {
        const string sql = """
                           SELECT Sku
                           FROM InventoryItem
                           WHERE Sku IS NOT NULL;
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        return [.. await connection.QueryAsync<string>(sql)];
    }

    /// <summary>
    /// Adds a collection of <see cref="InventoryItem"/> objects to the database asynchronously.
    /// </summary>
    /// <param name="inventoryItems">
    /// A collection of <see cref="InventoryItem"/> objects to be added to the database.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    /// <remarks>
    /// This method processes the provided collection of inventory items and adds them to the database
    /// within a single transaction. If any error occurs during the operation, the transaction is rolled back.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="inventoryItems"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="Exception">
    /// Thrown when an error occurs during the database operation.
    /// </exception>
    public async Task<InventoryImportResult> ImportAsync(IEnumerable<InventoryItem> inventoryItems) {
        ArgumentNullException.ThrowIfNull(inventoryItems);

        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();
        var results = new InventoryImportResult();

        try {
            foreach (var item in inventoryItems) {
                results.RecordsProcessed++;

                var ebayIdExists = await SourceRecordExistsAsync(item.SourceSystem,
                    item.SourceRecordId,
                    connection,
                    transaction);

                var skuExists = await SkuExistsAsync(item.CustomSku, connection, transaction);

                if (ebayIdExists && skuExists) {
                    results.ExistingRecords++;
                    results.RecordsSkipped++;
                    continue;
                }

                if (skuExists) {
                    // Log probable relist.
                    // Potentially update the item's SourceRecordId later.
                    results.RecordsSkipped++;
                    results.PossibleRelists++;
                    continue;
                }

                if (ebayIdExists) {
                    // Log conflicting source ID / SKU.
                    results.SourceConflicts++;
                    results.RecordsSkipped++;
                    continue;
                }

                await AddInventoryItemAsync(item, connection, transaction);
                results.RecordsAdded++;
            }

            transaction.Commit();
        } catch {
            transaction.Rollback();
            throw;
        }

        return results;
    }

    /// <summary>
    /// Marks the specified inventory items as having their labels printed by updating their last label print date.
    /// </summary>
    /// <param name="inventoryItemIds">An array of inventory item IDs to update. Cannot be <c>null</c>.</param>
    /// <param name="printedDate">The date and time when the labels were printed.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="inventoryItemIds"/> is <c>null</c>.</exception>
    /// <remarks>
    /// This method ensures that the provided inventory item IDs are distinct and processes them in chunks of 500
    /// to optimize database updates. The operation is performed within a database transaction to ensure consistency.
    /// </remarks>
    public async Task MarkLabelsPrintedAsync(int[] inventoryItemIds, DateTime printedDate) {
        ArgumentNullException.ThrowIfNull(inventoryItemIds);

        var ids = inventoryItemIds.Distinct().ToArray();

        if (ids.Length == 0) {
            return;
        }

        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        const string sql = """
                           UPDATE InventoryItem
                           SET LabelPrintedAt = @PrintedDate
                           WHERE Id in @IDs;
                           """;

        try {
            foreach (var chunk in ids.Chunk(500)) {
                await connection.ExecuteAsync(sql, new { IDs = chunk, PrintedDate = printedDate }, transaction);
            }

            transaction.Commit();
        } catch (Exception exception) {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>
    /// Checks whether an inventory item with the specified SKU exists in the database.
    /// </summary>
    /// <param name="sku">
    /// The SKU of the inventory item to check for. Can be <c>null</c>.
    /// </param>
    /// <param name="connection">
    /// An open database connection to be used for the query.
    /// </param>
    /// <param name="transaction">
    /// An optional database transaction to be used for the query. Can be <c>null</c>.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains
    /// <c>true</c> if an inventory item with the specified SKU exists; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="connection"/> is <c>null</c>.
    /// </exception>
    public async Task<bool> SkuExistsAsync(string? sku, IDbConnection connection,
                IDbTransaction? transaction = null) {
        ArgumentNullException.ThrowIfNull(connection);
        const string sql = """
                           SELECT COUNT(*)
                           FROM InventoryItem
                           WHERE Sku = @Sku
                           """;

        var parameters = new Dictionary<string, object> {
            { "Sku", sku }
        };

        var commandDefinition = new CommandDefinition(sql, parameters, transaction, null, CommandType.Text,
            CommandFlags.None, CancellationToken.None);

        var result = await connection.ExecuteScalarAsync(commandDefinition);
        return result != null && Convert.ToInt32(result) > 0;
    }

    /// <summary>
    /// Checks if an inventory item exists in the database based on the specified source platform and source ID.
    /// </summary>
    /// <param name="sourcePlatform">
    /// The platform or system from which the inventory item originates. Can be <c>null</c>.
    /// </param>
    /// <param name="sourceId">
    /// The unique identifier of the inventory item in the source platform. Can be <c>null</c>.
    /// </param>
    /// <param name="connection">
    /// An open database connection to be used for the query.
    /// </param>
    /// <param name="transaction">
    /// An optional database transaction to be used for the query. Defaults to <c>null</c>.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains
    /// <c>true</c> if the inventory item exists; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="connection"/> is <c>null</c>.
    /// </exception>
    public async Task<bool> SourceRecordExistsAsync(string? sourcePlatform, string? sourceId, IDbConnection connection,
            IDbTransaction? transaction = null) {
        ArgumentNullException.ThrowIfNull(connection);
        const string sql = """
                           SELECT COUNT(*)
                           FROM InventoryItem
                           WHERE SourceSystem = @SourceSystem
                             AND SourceRecordId = @SourceRecordId;
                           """;

        var parameters = new Dictionary<string, object> {
            { "SourceSystem", sourcePlatform }, { "SourceRecordId", sourceId }
        };

        var commandDefinition = new CommandDefinition(sql, parameters, transaction, null, CommandType.Text,
            CommandFlags.None, CancellationToken.None);

        var result = await connection.ExecuteScalarAsync(commandDefinition);
        return result != null && Convert.ToInt32(result) > 0;
    }
}