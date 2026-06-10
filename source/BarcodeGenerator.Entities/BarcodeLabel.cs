// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 06-09-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a barcode label entity with properties for identification, purchase date, label index, and source code.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and is used to encapsulate details about a barcode label.
/// </remarks>
public class BarcodeLabel {
    /// <summary>
    /// Gets the generated barcode value, which is a combination of the source code,
    /// purchase date, and label index.
    /// </summary>
    /// <value>
    /// A string representing the barcode value in the format:
    /// <c>{SourceCode}-{DatePurchased}-{LabelIndex}</c>.
    /// </value>
    /// <remarks>
    /// The <see cref="BarcodeValue"/> property dynamically constructs the barcode value
    /// based on the <see cref="SourceCode"/>, <see cref="DatePurchased"/>, and <see cref="LabelIndex"/> properties.
    /// </remarks>
    public string BarcodeValue => $"{SourceCode}-{DatePurchased}-{LabelIndex}";

    /// <summary>
    /// Gets or sets the date when the barcode label was purchased.
    /// </summary>
    /// <value>
    /// A string representing the purchase date of the barcode label.
    /// </value>
    /// <remarks>
    /// The <see cref="DatePurchased"/> property is used to store the date of purchase for tracking and record-keeping purposes.
    /// </remarks>
    public string DatePurchased { get; set; } = DateTime.Now.ToString("yyyyMMdd");

    /// <summary>
    /// Gets or sets the index of the label.
    /// </summary>
    /// <value>
    /// The index of the label, which is used to uniquely identify the position or order of the label.
    /// </value>
    public string LabelIndex { get; set; } = "00000";

    /// <summary>
    /// Gets or sets the source code associated with the barcode label.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the source code of the barcode label.
    /// </value>
    /// <remarks>
    /// This property is used to store additional information or metadata related to the barcode label.
    /// </remarks>
    public string SourceCode { get; set; } = "None";
}