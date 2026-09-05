// ***********************************************************************
// Assembly          : BarcodeGenerator.Data
// Author            : Robert Eberhart
// Created           : 08-29-2026
// ***********************************************************************

using BarcodeGenerator.Data.Database;
using BarcodeGenerator.Data.Repositories.Results;
using BarcodeGenerator.Entities;
using System.Data;

namespace BarcodeGenerator.Data.Repositories;

/// <summary>
/// Represents a repository interface for managing inventory items in the database.
/// </summary>
/// <remarks>
/// This interface defines methods for performing CRUD operations and other database interactions
/// related to inventory items. It is intended to be implemented by classes that handle the actual
/// database logic.
/// </remarks>
public interface IInventoryItemRepository {

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
    Task AddInventoryItemAsync(InventoryItem inventoryItem, IDbConnection connection, IDbTransaction transaction);

    /// <summary>
    /// Clears all inventory items from the database.
    /// </summary>
    /// <remarks>
    /// This method removes all records from the inventory storage.
    /// It is intended to be used with caution as it will delete all inventory data.
    /// </remarks>
    /// <exception cref="System.Exception">
    /// Thrown if an error occurs during the operation.
    /// </exception>
    /// <returns>
    /// A <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.
    /// </returns>
    Task ClearAllInventory();

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
    Task<IList<InventoryLabelRow>> GetAll();

    Task<HashSet<string>> GetExistingRecordIdentifiers();

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
    Task<HashSet<string>> GetExistingSkus();

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
    Task<InventoryImportResult> ImportAsync(IEnumerable<InventoryItem> inventoryItems);

    /// <summary>
    /// Marks the specified inventory items as having their labels printed.
    /// </summary>
    /// <param name="inventoryItemIds">An array of inventory item IDs whose labels have been printed.</param>
    /// <param name="now">The current date and time when the labels were printed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// This method updates the database to indicate that the labels for the specified inventory items
    /// have been printed. It is typically called after a successful label printing operation.
    /// </remarks>
    Task MarkLabelsPrintedAsync(int[] inventoryItemIds, DateTime now);

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
    Task<bool> SkuExistsAsync(string? sku, IDbConnection connection,
        IDbTransaction? transaction = null);

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
    Task<bool> SourceRecordExistsAsync(string? sourcePlatform, string? sourceId, IDbConnection connection,
        IDbTransaction? transaction = null);
}