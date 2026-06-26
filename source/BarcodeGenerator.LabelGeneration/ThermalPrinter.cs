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
/// Represents a thermal printer for generating and printing barcode labels.
/// </summary>
/// <remarks>
/// This class is designed to handle the printing of barcode labels using a thermal printer. It supports label printing jobs
/// and integrates with a renderer factory to generate the appropriate label renderers based on the template type.
/// </remarks>
/// <example>
/// Example usage:
/// <code>
/// var rendererFactory = new CustomRendererFactory();
/// var printer = new ThermalPrinter(rendererFactory);
/// var labelPrintJob = new LabelPrintJob
/// {
///     Labels = new List<RenderedBarcodeLabel> { /* Add labels here */ },
///     TemplateType = TemplateType.OneByThree,
///     LabelSize = new Size(300, 100) // Width and Height in hundredths of an inch
/// };
/// printer.Print(labelPrintJob);
/// </code>
/// </example>
/// <seealso cref="IRendererFactory"/>
/// <seealso cref="ILabelPrinter"/>
[SupportedOSPlatform("windows")]
public sealed class ThermalPrinter(IRendererFactory rendererFactory) : ILabelPrinter {
    private int _currentLabelIndex = 0;
    private ILabelRenderer? _labelRenderer;
    private IList<RenderedBarcodeLabel> _labelsToPrint = [];

    /// <summary>
    /// Prints the barcode labels specified in the provided <see cref="LabelPrintJob"/>.
    /// </summary>
    /// <param name="labelPrintJob">
    /// An instance of <see cref="LabelPrintJob"/> containing the labels to print, the number of copies,
    /// the label size, and the printer name.
    /// </param>
    /// <remarks>
    /// This method initializes the printing process for 1x3 barcode labels. It configures the
    /// <see cref="System.Drawing.Printing.PrintDocument"/> with the appropriate paper size and margins,
    /// and handles the printing of each label using the <see cref="PrintLabelsHandler"/> event.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="labelPrintJob"/> or its <see cref="LabelPrintJob.Labels"/> property is <c>null</c>.
    /// </exception>
    /// <example>
    /// <code>
    /// var labelPrintJob = new LabelPrintJob {
    ///     Labels = new List<RenderedBarcodeLabel> { label1, label2 },
    ///     Copies = 2,
    ///     PrinterName = "MyPrinter"
    /// };
    /// var printer = new ThermalPrinter();
    /// printer.Print(labelPrintJob);
    /// </code>
    /// </example>
    public void Print(LabelPrintJob labelPrintJob) {
        ArgumentNullException.ThrowIfNull(labelPrintJob);
        ArgumentNullException.ThrowIfNull(labelPrintJob.Labels);

        if (labelPrintJob.Labels.Count == 0) return;
        _labelRenderer = rendererFactory.GetLabelRenderer(labelPrintJob.TemplateType);

        _labelsToPrint = labelPrintJob.Labels;
        _currentLabelIndex = 0;

        using var printDocument = new PrintDocument();

        printDocument.DefaultPageSettings.PaperSize = new PaperSize("OneByThreeLabel", labelPrintJob.LabelSize.Width, labelPrintJob.LabelSize.Height);
        printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
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

        _labelRenderer.Render(labelToPrint, e.Graphics!, bounds);

        _currentLabelIndex++;

        e.HasMorePages = _currentLabelIndex < _labelsToPrint.Count;
    }

}