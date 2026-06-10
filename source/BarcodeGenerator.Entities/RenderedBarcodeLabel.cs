// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************
// <copyright file="RenderedBarcodeLabel.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Drawing;

#pragma warning disable CA1416

namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a rendered barcode label, including its associated barcode label details and generated barcode image.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and provides functionality for managing
/// rendered barcode labels. It implements the <see cref="IDisposable"/> interface to ensure proper resource management.
/// </remarks>
public class RenderedBarcodeLabel : IDisposable {
    /// <summary>
    /// Gets or sets the generated barcode image associated with the rendered barcode label.
    /// </summary>
    /// <value>
    /// A <see cref="Bitmap"/> object representing the visual representation of the barcode.
    /// </value>
    /// <remarks>
    /// This property holds the generated barcode image, which is rendered based on the details of the associated
    /// <see cref="BarcodeLabel"/>. It is required to ensure the barcode label is complete with its visual representation.
    /// </remarks>
    public Bitmap BarcodeImage { get; set; } = null!;

    /// <summary>
    /// Gets or sets the barcode label associated with the rendered barcode.
    /// </summary>
    /// <value>
    /// An instance of <see cref="BarcodeLabel"/> that contains details about the barcode label,
    /// including its barcode value, purchase date, label index, and source code.
    /// </value>
    /// <remarks>
    /// This property is required and must be set to ensure proper functionality of the <see cref="RenderedBarcodeLabel"/> class.
    /// </remarks>
    public BarcodeLabel Label { get; set; } = null!;

    /// <summary>
    /// Releases all resources used by the <see cref="RenderedBarcodeLabel"/> instance.
    /// </summary>
    /// <remarks>
    /// This method disposes of the <see cref="BarcodeImage"/> to free up unmanaged resources.
    /// It should be called when the rendered barcode label is no longer needed.
    /// </remarks>
    public void Dispose() {
        BarcodeImage.Dispose();
        BarcodeImage = null;
    }
}