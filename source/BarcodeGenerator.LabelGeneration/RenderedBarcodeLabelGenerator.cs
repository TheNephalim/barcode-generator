// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************
// <copyright file="RenderedBarcodeLabelGenerator.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality to generate rendered barcode labels by combining barcode images
/// with their corresponding label data.
/// </summary>
/// <remarks>
/// This class utilizes an implementation of the <see cref="IBarcodeImageGenerator"/> interface
/// to generate barcode images for the provided barcode labels. The generated barcode images
/// are then combined with the label data to produce rendered barcode labels.
/// </remarks>
public class RenderedBarcodeLabelGenerator : IRenderedBarcodeLabelGenerator {
    private readonly IBarcodeImageGenerator _barcodeImageGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="RenderedBarcodeLabelGenerator"/> class.
    /// </summary>
    /// <param name="barcodeImageGenerator">
    /// An implementation of the <see cref="IBarcodeImageGenerator"/> interface used to generate barcode images.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="barcodeImageGenerator"/> parameter is <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// This constructor sets up the <see cref="RenderedBarcodeLabelGenerator"/> with the specified barcode image generator,
    /// which is used to create barcode images for rendering.
    /// </remarks>
    public RenderedBarcodeLabelGenerator(IBarcodeImageGenerator barcodeImageGenerator) {
        _barcodeImageGenerator = barcodeImageGenerator ?? throw new ArgumentNullException(nameof(barcodeImageGenerator));
    }

    /// <summary>
    /// Generates a list of rendered barcode labels from the provided collection of barcode labels.
    /// </summary>
    /// <param name="labels">
    /// A collection of <see cref="BarcodeLabel"/> instances to be rendered into barcode labels.
    /// </param>
    /// <returns>
    /// A list of <see cref="RenderedBarcodeLabel"/> instances, each containing the original barcode label
    /// and its corresponding generated barcode image.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="labels"/> parameter is <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// This method iterates through the provided barcode labels, generates a Code 128 barcode image
    /// for each label using the <see cref="IBarcodeImageGenerator"/> implementation, and returns
    /// a list of rendered barcode labels.
    /// </remarks>
    public IList<RenderedBarcodeLabel> Generate(IEnumerable<BarcodeLabel> labels) {
        return labels
            .Select(label => new RenderedBarcodeLabel() {
                Label = label,
                BarcodeImage = _barcodeImageGenerator.GenerateCode128(label.BarcodeValue)
            }).ToList();
    }
}