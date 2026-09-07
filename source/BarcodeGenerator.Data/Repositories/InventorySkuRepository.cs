// ***********************************************************************
// Assembly          : BarcodeGenerator.Data.Repositories
// Author            : Robert Eberhart
// Created           : 09-05-2026
// ***********************************************************************
// <copyright file="InventorySkuRepository.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Data.Database;
using Dapper;

namespace BarcodeGenerator.Data.Repositories;

/// <summary>
/// Provides an implementation of the <see cref="IInventorySkuRepository"/> interface for managing inventory SKU sequences.
/// </summary>
/// <remarks>
/// This class interacts with the underlying database to perform operations related to inventory SKU sequences,
/// such as retrieving the last assigned SKU number for a specific prefix and inventory source.
/// It utilizes a database connection factory (<see cref="IDbConnectionFactory"/>) to manage database connectivity.
/// </remarks>
public sealed class InventorySkuRepository : IInventorySkuRepository {
    private readonly IDbConnectionFactory _dbConnectionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventorySkuRepository"/> class.
    /// </summary>
    /// <param name="dbConnectionFactory">
    /// The factory used to create database connections. This parameter cannot be <c>null</c>.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="dbConnectionFactory"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This constructor sets up the repository with the necessary database connection factory,
    /// enabling interaction with the underlying database for inventory SKU operations.
    /// </remarks>
    public InventorySkuRepository(IDbConnectionFactory dbConnectionFactory) {
        _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
    }

    /// <summary>
    /// Retrieves the last assigned SKU number for a specific prefix and inventory source.
    /// </summary>
    /// <param name="prefix">The prefix associated with the SKU sequence.</param>
    /// <param name="inventorySourceId">The identifier of the inventory source.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the last assigned SKU number.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="prefix"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method queries the database to fetch the last assigned SKU number for the specified prefix and inventory source.
    /// If no record is found, the method returns a default value.
    /// </remarks>
    public async Task<int?> GetLastAssignedSkuNumberAsync(string prefix, long inventorySourceId) {
        const string sql = """
                           SELECT LastAssignedNumber
                           FROM InventorySkuSequence
                           WHERE Prefix = @Prefix AND InventorySourceId = @InventorySourceId
                           """;

        using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        return await connection.QuerySingleOrDefaultAsync<int?>(sql,
            new { Prefix = prefix, InventorySourceId = inventorySourceId });
    }
}