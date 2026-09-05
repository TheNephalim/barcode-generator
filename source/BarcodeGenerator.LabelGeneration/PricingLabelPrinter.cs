// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 08-06-2026
// ***********************************************************************

using BarcodeGenerator.Entities;
using System.Drawing.Printing;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Represents a printer specifically designed for printing pricing labels.
/// </summary>
/// <remarks>
/// This class is responsible for rendering and printing <see cref="PricingLabel"/> objects using a specified
/// <see cref="ILabelRenderer{PricingLabel}"/> and print job configuration.
/// </remarks>
public sealed class PricingLabelPrinter : ILabelPrinter {
    private readonly ILabelRenderer _pricingLabelRenderer;

    /// <summary>
    /// Initializes a new instance of the <see cref="PricingLabelPrinter"/> class.
    /// </summary>
    /// <param name="pricingLabelRenderer">
    /// The renderer responsible for rendering <see cref="PricingLabel"/> objects onto a graphical surface.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="pricingLabelRenderer"/> is <c>null</c>.
    /// </exception>
    public PricingLabelPrinter(ILabelRenderer pricingLabelRenderer) {
        _pricingLabelRenderer = pricingLabelRenderer;
    }

    /// <summary>
    /// Prints pricing labels using the specified print job configuration.
    /// </summary>
    /// <param name="printJob">
    /// The <see cref="LabelPrintJob"/> containing the labels to print and printer settings.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="printJob"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the printer name in <paramref name="printJob"/> is <c>null</c>, empty, or consists only of white-space characters.
    /// </exception>
    /// <remarks>
    /// This method configures a <see cref="System.Drawing.Printing.PrintDocument"/> to print the labels.
    /// Each label is rendered using the associated label renderer.
    /// </remarks>
    public void Print(LabelPrintJob printJob) {
        ArgumentNullException.ThrowIfNull(printJob);

        if (printJob.Labels.Count == 0) {
            return;
        }

        if (string.IsNullOrWhiteSpace(printJob.PrinterName)) {
            throw new ArgumentException(
                "A printer name is required.",
                nameof(printJob.PrinterName));
        }

        var labelIndex = 0;

        using var document = new PrintDocument();

        document.PrinterSettings.PrinterName = printJob.PrinterName;
        document.DefaultPageSettings.PaperSize =
            new PaperSize(
                "1 x 1 Round Pricing Label",
                100,
                100);

        document.DefaultPageSettings.Margins =
            new Margins(0, 0, 0, 0);

        document.OriginAtMargins = false;

        document.PrintPage += (_, args) => {
            var bounds = args.PageBounds;

            _pricingLabelRenderer.Render(
                printJob.Labels[labelIndex],
                args.Graphics,
                bounds);

            labelIndex++;
            args.HasMorePages = labelIndex < printJob.Labels.Count;
        };

        document.Print();
    }
}