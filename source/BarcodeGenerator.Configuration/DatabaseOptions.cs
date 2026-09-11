// ***********************************************************************
// Assembly          : BarcodeGenerator.Configuration
// Author            : Robert Eberhart
// Created           : 09-11-2026
// ***********************************************************************
namespace BarcodeGenerator.Configuration;

/// <summary>
/// Represents the configuration options for database connectivity in the BarcodeGenerator application.
/// </summary>
/// <remarks>
/// This class is used to define and manage settings related to database connections, such as the connection string.
/// </remarks>
public sealed class DatabaseOptions {
    /// <summary>
    /// Gets or sets the connection string used to establish a connection to the database.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the connection string for the database.
    /// </value>
    /// <remarks>
    /// This property is essential for configuring database connectivity in the BarcodeGenerator application.
    /// Ensure that the connection string is properly formatted and contains the necessary credentials and parameters.
    /// </remarks>
    public string ConnectionString { get; set; } = string.Empty;
}