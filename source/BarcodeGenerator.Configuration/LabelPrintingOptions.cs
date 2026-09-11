// ***********************************************************************
// Assembly          : BarcodeGenerator.Configuration
// Author            : Robert Eberhart
// Created           : 09-11-2026
// ***********************************************************************
namespace BarcodeGenerator.Configuration;

/// <summary>
/// Represents the configuration options for label printing in the Barcode Generator application.
/// </summary>
/// <remarks>
/// This class provides properties to specify the default printer and template used for label printing.
/// </remarks>
public sealed class LabelPrintingOptions {
    /// <summary>
    /// Gets or sets the name of the default printer to be used for label printing.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the name of the default printer.
    /// Defaults to an empty string if not specified.
    /// </value>
    /// <remarks>
    /// This property allows specifying the printer that should be used by default
    /// when printing labels. It can be overridden by user preferences or specific
    /// printing configurations.
    /// </remarks>
    public string DefaultPrinter { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the default template used for label printing.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the default template name or path.
    /// </value>
    /// <remarks>
    /// This property specifies the template that will be used by default when printing labels.
    /// It can be overridden by specifying a different template at runtime.
    /// </remarks>
    public string DefaultTemplate { get; set; } = string.Empty;
}