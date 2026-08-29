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
                               CreatedAt, ModifiedAt
                           ) VALUES(
                             @CustomSku, @Product, @ListingPrice, @Cost,
                             @PurchaseDate, @PurchasedAt, @StorageLocation, @SourceSystem,
                             @SourceRecordId, datetime('now'), datetime('now'),
                             datetime('now')
                           );
                           """;

        var result = await connection.ExecuteAsync(sql, inventoryItem);
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
    public async Task<bool> ExistsAsync(string? sourcePlatform, string? sourceId, IDbConnection connection,
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

                var exists = await ExistsAsync(item.SourceSystem,
                    item.SourceRecordId,
                    connection,
                    transaction);

                if (exists) {
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
}