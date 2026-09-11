// ***********************************************************************
// Assembly          : BarcodeGenerator.Configuration
// Author            : Robert Eberhart
// Created           : 09-11-2026
// ***********************************************************************
namespace BarcodeGenerator.Configuration;

/// <summary>
/// Represents the main configuration for the BarcodeGenerator application.
/// </summary>
/// <remarks>
/// This class aggregates various configuration options, including database connectivity,
/// label printing, and report generation settings.
/// </remarks>
public sealed class BarcodeGeneratorConfiguration {
    /// <summary>
    /// Gets the name of the configuration section used for the BarcodeGenerator application.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the section name in the configuration file.
    /// </value>
    /// <remarks>
    /// This property is used to identify the configuration section in appsettings or other configuration sources.
    /// </remarks>
    public static string SectionName => "BarcodeGeneratorConfiguration";

    /// <summary>
    /// Gets or sets the configuration options for database connectivity.
    /// </summary>
    /// <value>
    /// An instance of <see cref="DatabaseOptions"/> that defines and manages settings
    /// related to database connections, such as the connection string.
    /// </value>
    /// <remarks>
    /// This property is used to configure the database connectivity settings for the BarcodeGenerator application.
    /// </remarks>
    public DatabaseOptions Database { get; set; } = new();

    /// <summary>
    /// Gets or sets the configuration options for label printing in the BarcodeGenerator application.
    /// </summary>
    /// <value>
    /// An instance of <see cref="LabelPrintingOptions"/> that specifies the default printer and template
    /// used for label printing.
    /// </value>
    /// <remarks>
    /// This property allows customization of label printing settings, such as specifying the printer
    /// and template to be used for generating labels.
    /// </remarks>
    public LabelPrintingOptions LabelPrinting { get; set; } = new();

    /// <summary>
    /// Gets or sets the configuration options for generating reports in the BarcodeGenerator application.
    /// </summary>
    /// <value>
    /// An instance of <see cref="BarcodeGenerator.Configuration.ReportConfigurationOptions"/> that specifies metadata
    /// such as the author and company associated with the report.
    /// </value>
    public ReportConfigurationOptions ReportConfiguration { get; set; } = new();
}