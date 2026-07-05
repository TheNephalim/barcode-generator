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
                           SELECT Id, Code, Name, IsActive
                           FROM InventorySource
                           ORDER BY NAME ASC
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<InventorySource>(sql);
        return result.ToList().AsReadOnly();
    }
}