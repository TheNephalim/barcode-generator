// ***********************************************************************
// Assembly          : BarcodeGenerator.Data.Database
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************
// <copyright file="SqliteConnectionFactory.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using Microsoft.Data.Sqlite;
using System.Data;

namespace BarcodeGenerator.Data.Database;

/// <summary>
/// Provides a factory for creating SQLite database connections.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IDbConnectionFactory"/> interface to provide a mechanism
/// for creating instances of <see cref="IDbConnection"/> specifically for SQLite databases.
/// It uses a connection string to configure and establish the database connections.
/// </remarks>
public class SqliteConnectionFactory : IDbConnectionFactory {
    private readonly string _connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="SqliteConnectionFactory"/> class with the specified connection string.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string used to establish connections to the SQLite database.
    /// </param>
    /// <remarks>
    /// This constructor sets up the factory with the provided connection string, which will be used
    /// when creating new instances of <see cref="IDbConnection"/>.
    /// </remarks>
    public SqliteConnectionFactory(string connectionString) {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Creates and returns a new instance of <see cref="IDbConnection"/> configured for SQLite.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IDbConnection"/> representing a connection to the SQLite database.
    /// </returns>
    /// <remarks>
    /// The connection is created using the connection string provided during the initialization
    /// of the <see cref="SqliteConnectionFactory"/>. The returned connection is not opened by default,
    /// and it is the caller's responsibility to open and manage its lifecycle.
    /// </remarks>
    public IDbConnection CreateConnection() {
        return new SqliteConnection(_connectionString);
    }
}