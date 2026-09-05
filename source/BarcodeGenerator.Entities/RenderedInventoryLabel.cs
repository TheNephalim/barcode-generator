// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 09-04-2026
// ***********************************************************************
using System.Drawing;

namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a rendered inventory label that includes a barcode image, display text, and associated inventory label details.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and is designed to encapsulate
/// the visual and textual representation of an inventory label, including its barcode image and metadata.
/// It implements the <see cref="IPrintableLabel"/> interface to support printing functionality and
/// <see cref="IDisposable"/> to ensure proper resource management.
/// </remarks>
public sealed class RenderedInventoryLabel : IPrintableLabel, IDisposable {
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
    public Bitmap BarcodeImage { get; set; } = new Bitmap(1, 1);

    /// <summary>
    /// Gets or sets the display text associated with the rendered barcode label.
    /// </summary>
    /// <remarks>
    /// This text is typically displayed alongside the barcode image to provide additional context or information.
    /// It is rendered using the <see cref="TwoByOneLabelRenderer"/> or similar rendering implementations.
    /// </remarks>
    public string? DisplayText { get; set; }

    /// <summary>
    /// Gets or sets the inventory label associated with the rendered barcode.
    /// </summary>
    /// <remarks>
    /// This property represents the underlying inventory label containing details such as SKU, title, and price.
    /// It is used to provide metadata and additional information for the rendered barcode image and display text.
    /// </remarks>
    public InventoryLabel Label { get; set; } = new();

    /// <summary>
    /// Releases all resources used by the <see cref="RenderedInventoryLabel"/> instance.
    /// </summary>
    /// <remarks>
    /// This method ensures that unmanaged resources, such as the <see cref="BarcodeImage"/>,
    /// are properly released. It should be called when the instance is no longer needed
    /// to prevent resource leaks.
    /// </remarks>
    public void Dispose() {
        BarcodeImage.Dispose();
    }
}