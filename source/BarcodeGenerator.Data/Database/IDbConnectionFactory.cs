// ***********************************************************************
// Assembly          : BarcodeGenerator.Data.Database
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************

using System.Data;

namespace BarcodeGenerator.Data.Database;

/// <summary>
/// Represents a factory for creating instances of <see cref="IDbConnection"/>.
/// </summary>
/// <remarks>
/// This interface is designed to provide a mechanism for obtaining database connections,
/// ensuring a consistent and centralized way to manage database connectivity.
/// </remarks>
public interface IDbConnectionFactory {

    /// <summary>
    /// Creates and returns a new instance of <see cref="IDbConnection"/>.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IDbConnection"/> representing a connection to the database.
    /// </returns>
    /// <remarks>
    /// The returned connection is not opened by default. It is the caller's responsibility
    /// to open and manage the lifecycle of the connection.
    /// </remarks>
    IDbConnection CreateConnection();
}