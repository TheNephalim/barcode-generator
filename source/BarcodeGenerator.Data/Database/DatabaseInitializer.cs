// ***********************************************************************
// Assembly          : BarcodeGenerator.Data.Database
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************

using Dapper;
using System.Data;

namespace BarcodeGenerator.Data.Database;

/// <summary>
/// Provides functionality to initialize the database by creating necessary tables and seeding initial data.
/// </summary>
/// <remarks>
/// This class is responsible for ensuring that the database schema is properly set up and ready for use.
/// It uses an <see cref="IDbConnectionFactory"/> to manage database connections and execute initialization tasks.
/// </remarks>
public sealed class DatabaseInitializer {
    private readonly IDbConnectionFactory _dbConnectionFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseInitializer"/> class.
    /// </summary>
    /// <param name="dbConnectionFactory">
    /// An instance of <see cref="IDbConnectionFactory"/> used to create database connections.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="dbConnectionFactory"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This constructor ensures that a valid <see cref="IDbConnectionFactory"/> is provided
    /// for managing database connectivity during the initialization process.
    /// </remarks>
    public DatabaseInitializer(IDbConnectionFactory dbConnectionFactory) {
        _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
    }

    /// <summary>
    /// Asynchronously initializes the database by creating necessary tables if they do not already exist.
    /// </summary>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown if there is an error during the execution of the database initialization SQL commands.
    /// </exception>
    /// <remarks>
    /// This method ensures that the database schema is prepared for use by creating the required tables,
    /// such as <c>InventorySource</c> and <c>BarcodeSequence</c>, if they do not already exist.
    /// </remarks>
    public void Initialize() {
        using var connection = _dbConnectionFactory.CreateConnection();

        CreateDatabaseTables(connection);
        SeedInventorySources(connection);
    }

    /// <summary>
    /// Creates the necessary database tables if they do not already exist.
    /// </summary>
    /// <param name="connection">
    /// An open <see cref="IDbConnection"/> used to execute the SQL commands for creating the tables.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="connection"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="Exception">
    /// Thrown if there is an error during the execution of the SQL commands.
    /// </exception>
    /// <remarks>
    /// This method ensures that the database schema includes the required tables, such as <c>InventorySource</c>
    /// and <c>BarcodeSequence</c>. It uses SQL commands to create these tables if they do not already exist.
    /// </remarks>
    private static void CreateDatabaseTables(IDbConnection connection) {
        const string sql = """
                           CREATE TABLE IF NOT EXISTS InventorySource
                           (
                               Id INTEGER PRIMARY KEY AUTOINCREMENT,
                               Code TEXT NOT NULL UNIQUE,
                               Name TEXT NOT NULL,
                               IsActive INTEGER NOT NULL DEFAULT 1,
                               LastPrintedNumber INTEGER NOT NULL DEFAULT 0,
                               LastPurchaseDate TEXT NULL
                           );

                           CREATE TABLE IF NOT EXISTS BarcodeSequence (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            SourceCode TEXT NOT NULL UNIQUE,
                            LastNumber INTEGER NOT NULL DEFAULT 0
                           );

                           CREATE TABLE IF NOT EXISTS InventoryItem
                           (
                               Id INTEGER PRIMARY KEY AUTOINCREMENT,
                               Sku TEXT NOT NULL UNIQUE,
                               Title TEXT NOT NULL,
                               Price REAL,
                               AcquisitionCost REAL,
                               AcquisitionDate TEXT,
                               AcquisitionSource TEXT,
                               StorageLocation TEXT,
                               SourceSystem TEXT,
                               SourceRecordId TEXT,
                               SourceDataJson TEXT,
                               ImportedAt TEXT NOT NULL,
                               CreatedAt TEXT NOT NULL,
                               ModifiedAt TEXT NOT NULL,
                               Quantity INTEGER NOT NULL DEFAULT 1,
                               LabelPrintedAt Text
                           );
                           """;

        connection.Execute(sql);
    }

    /// <summary>
    /// Seeds the initial inventory sources into the database if they do not already exist.
    /// </summary>
    /// <param name="connection">
    /// The database connection to be used for seeding inventory sources. Must not be <c>null</c>.
    /// </param>
    /// <remarks>
    /// This method ensures that predefined inventory sources are available in the database.
    /// If an inventory source with the same code already exists, it will not be duplicated.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="connection"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the database connection cannot be established.
    /// </exception>
    private void SeedInventorySources(IDbConnection? connection) {
        if (connection == null) {
            throw new ArgumentNullException(nameof(connection));
        }

        // Define initial inventory sources to seed
        var initialInventorySources = new[] {
            new { Code = "ETA", Name = "Early Times Auction", IsActive = 1 },
            new { Code = "ES", Name = "Estate Sale", IsActive = 1 },
            new { Code = "FB", Name = "Facebook Marketplace", IsActive = 1 },
            new { Code = "FGS", Name = "Fredericksburg Garage Sale", IsActive = 1 },
            new { Code = "FM", Name = "Fred Melby", IsActive = 1 },
            new { Code = "GW", Name = "Goodwill", IsActive = 1 },
            new { Code = "JW", Name = "Jim Wood", IsActive = 1 },
            new { Code = "LH", Name = "Linda Hirschberg", IsActive = 1 },
            new { Code = "MF", Name = "Massaponax Flea Market", IsActive = 1 },
            new { Code = "MNDO", Name = "Mondo", IsActive = 1 },
            new { Code = "NBC", Name = "Newbury Comic Shop", IsActive = 1 },
            new { Code = "OR", Name = "Otto Richter", IsActive = 1 },
            new { Code = "OT", Name = "Other", IsActive = 1 },
            new { Code = "PC", Name = "Personal Collection", IsActive = 1 },
            new { Code = "RA", Name = "Rasmus Auctions", IsActive = 1 },
            new { Code = "TS", Name = "Taylor Swift", IsActive = 1 },
            new { Code = "VCV", Name = "VC Vinyl", IsActive = 1 }
        };

        // SQL to insert inventory sources if they don't exist
        const string insertSql = """
                                 INSERT OR IGNORE INTO InventorySource (Code, Name, IsActive)
                                 VALUES (@Code, @Name, @IsActive);
                                 """;

        // Execute the seeding operations
        connection.Execute(insertSql, initialInventorySources);
    }
}