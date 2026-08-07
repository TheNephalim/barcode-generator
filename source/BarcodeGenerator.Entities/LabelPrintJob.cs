// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************

namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a job for printing barcode labels, including details such as the number of copies,
/// the labels to be printed, the label size, and the printer name.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and is used to encapsulate
/// the necessary information for printing barcode labels. It includes properties for specifying
/// the number of copies, the list of rendered barcode labels, the size of the labels, and the printer
/// to be used for the print job.
/// </remarks>
public class LabelPrintJob {
    /// <summary>
    /// Gets or sets the number of copies to be printed for the label print job.
    /// </summary>
    /// <value>
    /// The number of copies to be printed. The default value is <c>1</c>.
    /// </value>
    /// <remarks>
    /// This property specifies how many copies of each label in the print job should be printed.
    /// </remarks>
    public int Copies { get; set; } = 1;

    /// <summary>
    /// Gets or sets the collection of rendered barcode labels to be printed in the label print job.
    /// </summary>
    /// <value>
    /// A list of <see cref="RenderedBarcodeLabel"/> objects representing the barcode labels to be printed.
    /// </value>
    /// <remarks>
    /// Each <see cref="RenderedBarcodeLabel"/> in the collection contains the details of the barcode label
    /// and its associated generated barcode image. This property is used to specify the labels included
    /// in the print job.
    /// </remarks>
    public IReadOnlyList<IPrintableLabel> Labels { get; set; } = [];

    /// <summary>
    /// Gets or sets the size of the label to be printed.
    /// </summary>
    /// <value>
    /// An instance of <see cref="LabelSize"/> that specifies the dimensions of the label, including its length and width.
    /// </value>
    /// <remarks>
    /// This property is used to define the size of the labels for the print job. It ensures that the labels are printed
    /// with the correct dimensions as specified.
    /// </remarks>
    public LabelSize LabelSize { get; set; } = new();

    /// <summary>
    /// Gets or sets the name of the printer to be used for the label printing job.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the name of the printer. Defaults to "DefaultPrinter".
    /// </value>
    /// <remarks>
    /// This property specifies the printer that will handle the label printing job.
    /// It is essential to ensure that the specified printer is correctly configured and accessible.
    /// </remarks>
    public string PrinterName { get; set; } = "DefaultPrinter";

    /// <summary>
    /// Gets or sets the type of label template to be used for the print job.
    /// </summary>
    /// <remarks>
    /// This property specifies the template type for the labels being printed,
    /// which determines the layout and dimensions of the labels.
    /// </remarks>
    public LabelTemplateType TemplateType { get; set; }
}