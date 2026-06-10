// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************
// <copyright file="IRenderedBarcodeLabelGenerator.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

public interface IRenderedBarcodeLabelGenerator {
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
    IList<RenderedBarcodeLabel> Generate(IEnumerable<BarcodeLabel> labels);
}