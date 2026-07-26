// ***********************************************************************
// Assembly          : BarcodeGenerator.Data.Repositories
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************

using BarcodeGenerator.Data.Database;
using BarcodeGenerator.Entities;
using Dapper;

namespace BarcodeGenerator.Data.Repositories;

public class InventorySourceRepository : IInventorySourceRepository {
    private readonly IDbConnectionFactory _dbConnectionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventorySourceRepository"/> class.
    /// </summary>
    /// <param name="dbConnectionFactory">
    /// An instance of <see cref="IDbConnectionFactory"/> used to create database connections.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="dbConnectionFactory"/> is <c>null</c>.
    /// </exception>
    public InventorySourceRepository(IDbConnectionFactory dbConnectionFactory) {
        _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
    }

    /// <summary>
    /// Adds a new inventory source to the database.
    /// </summary>
    /// <param name="source">
    /// An instance of <see cref="InventorySource"/> representing the inventory source to be added.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the operation does not affect exactly one row in the database.
    /// </exception>
    public async Task AddSourceAsync(InventorySource source) {
        const string sql = """
                           INSERT INTO InventorySource(Code, Name, IsActive, LastPrintedNumber, LastPurchaseDate)
                           VALUES(@Code, @Name, @IsActive, @LastPrintedNumber, @LastPurchaseDate);
                           """;
        using var connection = _dbConnectionFactory.CreateConnection();
        var rowsAffected = await connection.ExecuteAsync(sql, source);

        if (rowsAffected != 1) {
            throw new InvalidOperationException($"Expected to add one inventory source, but updated {rowsAffected}");
        }
    }

    /// <summary>
    /// Retrieves all inventory sources from the database.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a read-only list of
    /// <see cref="InventorySource"/> objects, ordered by their names in ascending order.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if there is an issue with the database connection or query execution.
    /// </exception>
    public async Task<IReadOnlyList<InventorySource>> GetAllAsync() {
        const string sql = """
                           SELECT Id, Code, Name, IsActive, LastPrintedNumber, LastPurchaseDate
                           FROM InventorySource
                           ORDER BY NAME ASC
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<InventorySource>(sql);
        return result.ToList().AsReadOnly();
    }

    /// <summary>
    /// Retrieves an <see cref="InventorySource"/> entity by its unique code.
    /// </summary>
    /// <param name="code">
    /// The unique code of the inventory source to retrieve.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the
    /// <see cref="InventorySource"/> entity associated with the specified code.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no inventory source is found for the specified code.
    /// </exception>
    /// <remarks>
    /// This method queries the database for an inventory source with the given code.
    /// If no matching entity is found, an exception is thrown.
    /// </remarks>
    public async Task<InventorySource> GetById(string code) {
        const string sql = """
                           SELECT Id, Code, Name, IsActive, LastPrintedNumber, LastPurchaseDate
                           FROM InventorySource
                           Where Code = @code
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.ExecuteScalarAsync<InventorySource>(sql, code);

        return result ?? throw new InvalidOperationException($"Expected to update one inventory source.");
    }

    /// <summary>
    /// Updates the specified inventory source in the database.
    /// </summary>
    /// <param name="source">
    /// An instance of <see cref="InventorySource"/> containing the updated data for the inventory source.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the update operation does not affect exactly one record in the database.
    /// </exception>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task UpdateSourceAsync(InventorySource source) {
        const string sql = """
                           UPDATE InventorySource
                           SET
                            Code = @Code,
                            Name = @Name,
                            IsActive = @IsActive,
                            LastPrintedNumber = @LastPrintedNumber,
                            LastPurchaseDate = @LastPurchaseDate
                           WHERE ID = @Id;
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        var rowsAffected = await connection.ExecuteAsync(sql, source);

        if (rowsAffected != 1) {
            throw new InvalidOperationException($"Expected to update one inventory source, but updated {rowsAffected}");
        }
    }
}