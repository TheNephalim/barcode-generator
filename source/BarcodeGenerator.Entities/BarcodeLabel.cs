// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 06-09-2026
// ***********************************************************************
// <copyright file="BarcodeLabel.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
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
    /// Gets or sets the date when the barcode label was purchased.
    /// </summary>
    /// <value>
    /// A string representing the purchase date of the barcode label.
    /// </value>
    /// <remarks>
    /// The <see cref="DatePurchased"/> property is used to store the date of purchase for tracking and record-keeping purposes.
    /// </remarks>
    public string DatePurchased { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the barcode label.
    /// </summary>
    /// <value>
    /// A <see cref="Guid"/> representing the unique identifier of the barcode label.
    /// </value>
    public Guid Id { get; set; }

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
    public string SourceCode { get; set; }
}