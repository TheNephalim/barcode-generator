// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************

namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents the history of label printing, including details such as barcode value, sequence number,
/// lot date, print timestamp, and the number of copies printed.
/// </summary>
public class LabelPrintHistory {
    /// <summary>
    /// Gets or sets the barcode value associated with the label print history.
    /// </summary>
    public string BarcodeValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the number of copies printed for the label.
    /// </summary>
    public int CopyCount { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the label print history entry.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the lot date associated with the label print history.
    /// </summary>
    /// <remarks>
    /// The lot date typically represents the production or batch date of the item.
    /// </remarks>
    public string LotDate { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the timestamp indicating when the label was printed.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the date and time the label was printed.
    /// </value>
    public string PrintedAt { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the sequence number associated with the label print history.
    /// This number represents the order or position of the label in the printing sequence.
    /// </summary>
    public int SequenceNumber { get; set; }
}