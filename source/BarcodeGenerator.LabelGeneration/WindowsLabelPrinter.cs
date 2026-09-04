// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************

using BarcodeGenerator.Entities;
using System.Drawing.Printing;
using System.Runtime.Versioning;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Represents a label printer specifically designed for Windows platforms.
/// </summary>
/// <remarks>
/// This class is responsible for printing labels using a specified renderer factory.
/// It supports label printing jobs with customizable templates and label sizes.
/// </remarks>
/// <example>
/// To use this class, ensure that the application is running on a Windows platform.
/// Instantiate the class with an implementation of <see cref="IRendererFactory"/> and call the <c>Print</c> method with a valid <c>LabelPrintJob</c>.
/// </example>
/// <seealso cref="IRendererFactory"/>
/// <seealso cref="ILabelPrinter"/>
[SupportedOSPlatform("windows")]
public sealed class WindowsLabelPrinter(IRendererFactory rendererFactory) : ILabelPrinter {
    private int _currentLabelIndex = 0;
    private ILabelRenderer? _labelRenderer;
    private IList<IPrintableLabel> _labelsToPrint = [];

    /// <summary>
    /// Prints the labels specified in the provided <see cref="LabelPrintJob"/>.
    /// </summary>
    /// <param name="labelPrintJob">
    /// The <see cref="LabelPrintJob"/> containing the labels to be printed, along with their template type and size.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="labelPrintJob"/> or its <c>Labels</c> property is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when a label renderer cannot be obtained for the specified template type.
    /// </exception>
    /// <remarks>
    /// This method configures a print document with the specified label size and invokes the print dialog.
    /// If the user confirms the print operation, the labels are rendered and sent to the printer.
    /// </remarks>
    public void Print(LabelPrintJob labelPrintJob) {
        ArgumentNullException.ThrowIfNull(labelPrintJob);
        ArgumentNullException.ThrowIfNull(labelPrintJob.Labels);

        if (labelPrintJob.Labels.Count == 0) return;

        if (labelPrintJob.Copies <= 0) {
            throw new ArgumentOutOfRangeException(nameof(labelPrintJob), labelPrintJob.Copies,
                "The copy count must be greater than zero.");
        }

        _labelRenderer = rendererFactory.GetLabelRenderer(labelPrintJob.TemplateType);

        _labelsToPrint = ExpandCopies(labelPrintJob.Labels, labelPrintJob.Copies);
        _currentLabelIndex = 0;

        using var printDocument = new PrintDocument();

        printDocument.DefaultPageSettings.PaperSize = new PaperSize(GetPaperName(labelPrintJob.TemplateType),
            labelPrintJob.LabelSize.Width,
            labelPrintJob.LabelSize.Height);
        printDocument.DefaultPageSettings.Margins = new Margins(0,
            0,
            0,
            0);
        printDocument.OriginAtMargins = false;
        printDocument.DefaultPageSettings.Landscape = false;

        printDocument.PrintPage += PrintLabelsHandler;

        using var printDialog = new PrintDialog();
        printDialog.Document = printDocument;
        printDialog.UseEXDialog = true;

        if (printDialog.ShowDialog() != DialogResult.OK) return;

        printDocument.Print();
    }

    /// <summary>
    /// Expands the provided list of labels by duplicating each label a specified number of times.
    /// </summary>
    /// <param name="labels">The list of labels to be expanded. Each label in this list will be duplicated.</param>
    /// <param name="copies">The number of copies to create for each label.</param>
    /// <returns>A new list of labels where each label is repeated the specified number of times.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="labels"/> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method is used to prepare a collection of labels for printing when multiple copies of each label are required.
    /// </remarks>
    private static IList<IPrintableLabel> ExpandCopies(IReadOnlyList<IPrintableLabel> labels, int copies) {
        return labels.SelectMany(label => Enumerable.Repeat(label, copies)).ToList();
    }

    /// <summary>
    /// Retrieves the paper name corresponding to the specified label template type.
    /// </summary>
    /// <param name="templateType">The type of label template for which the paper name is required.</param>
    /// <returns>
    /// A string representing the paper name associated with the given <paramref name="templateType"/>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the provided <paramref name="templateType"/> is not supported.
    /// </exception>
    /// <remarks>
    /// This method maps specific <see cref="LabelTemplateType"/> values to predefined paper names.
    /// </remarks>
    /// <example>
    /// For example:
    /// <code>
    /// var paperName = WindowsLabelPrinter.GetPaperName(LabelTemplateType.OneByThree);
    /// Console.WriteLine(paperName); // Outputs: "OneByThreeLabel"
    /// </code>
    /// </example>
    private static string GetPaperName(LabelTemplateType templateType) {
        return templateType switch {
            LabelTemplateType.VinylBarcode => "OneByThreeLabel",
            LabelTemplateType.Pricing => "OneInchRoundLabel",
            _ => throw new ArgumentOutOfRangeException(nameof(templateType), templateType,
                "Unsupported label template.")
        };
    }

    /// <summary>
    /// Handles the printing of individual labels during the printing process.
    /// </summary>
    /// <param name="sender">
    /// The source of the event, typically the <see cref="System.Drawing.Printing.PrintDocument"/> instance.
    /// </param>
    /// <param name="e">
    /// A <see cref="System.Drawing.Printing.PrintPageEventArgs"/> that contains the event data, including graphics context
    /// and page settings.
    /// </param>
    /// <remarks>
    /// This method is invoked for each page during the printing process. It retrieves the current label to print
    /// from the list of labels and renders it onto the page using the provided graphics context.
    /// </remarks>
    /// <example>
    /// This method is automatically called by the <see cref="System.Drawing.Printing.PrintDocument"/> during the
    /// printing process. It is not intended to be called directly.
    /// </example>
    /// <seealso cref="System.Drawing.Printing.PrintPageEventArgs"/>
    /// <seealso cref="System.Drawing.Printing.PrintDocument"/>
    private void PrintLabelsHandler(object sender, PrintPageEventArgs e) {
        var labelToPrint = _labelsToPrint[_currentLabelIndex];
        var bounds = new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height);

        if (_labelRenderer == null) {
            throw new InvalidOperationException($"{nameof(_labelRenderer)} is null.");
        }

        if (e.Graphics == null) {
            throw new InvalidOperationException("The graphics property cannot be null.");
        }

        _labelRenderer.Render(labelToPrint, e.Graphics, bounds);

        _currentLabelIndex++;

        e.HasMorePages = _currentLabelIndex < _labelsToPrint.Count;
    }
}