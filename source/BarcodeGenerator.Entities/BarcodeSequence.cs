// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************
// <copyright file="BarcodeSequence.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a sequence of barcodes with tracking for the last generated number.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and is used to manage
/// barcode sequences, including their identifiers, the last generated number, and the source code.
/// </remarks>
public class BarcodeSequence {
    /// <summary>
    /// Gets or sets the unique identifier for the barcode sequence.
    /// </summary>
    /// <value>
    /// An integer representing the unique identifier of the barcode sequence.
    /// </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the last generated number in the barcode sequence.
    /// </summary>
    /// <value>
    /// The last number that was generated in the sequence.
    /// </value>
    /// <remarks>
    /// This property is used to track the most recently generated number in the barcode sequence,
    /// allowing for sequential barcode generation.
    /// </remarks>
    public int LastNumber { get; set; }

    /// <summary>
    /// Gets or sets the source code associated with the barcode sequence.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the source code of the barcode sequence.
    /// </value>
    /// <remarks>
    /// The source code typically identifies the origin or context of the barcode sequence.
    /// </remarks>
    public string SourceCode { get; set; } = string.Empty;
}