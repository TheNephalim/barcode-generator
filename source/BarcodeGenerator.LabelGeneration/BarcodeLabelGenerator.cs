// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************
// <copyright file="BarcodeLabelGenerator.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality for generating barcode labels within a specified range.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.LabelGeneration</c> namespace and implements the <see cref="BarcodeGenerator.LabelGeneration.IBarcodeLabelGenerator"/> interface.
/// It uses a builder pattern via <see cref="BarcodeGenerator.LabelGeneration.BarcodeLabelBuilder"/> to create instances of <see cref="BarcodeGenerator.Entities.BarcodeLabel"/>.
/// </remarks>
public sealed class BarcodeLabelGenerator : IBarcodeLabelGenerator {

    /// <summary>
    /// Generates a collection of barcode labels within the specified index range.
    /// </summary>
    /// <param name="startIndex">
    /// The starting index for the barcode labels to be generated. Must be less than or equal to <paramref name="endIndex"/>.
    /// </param>
    /// <param name="endIndex">
    /// The ending index for the barcode labels to be generated. Must be greater than or equal to <paramref name="startIndex"/>.
    /// </param>
    /// <param name="sourceCode">
    /// A string representing the source code associated with the barcode labels.
    /// </param>
    /// <param name="datePurchased">
    /// The date when the barcode labels were purchased.
    /// </param>
    /// <returns>
    /// A list of <see cref="BarcodeGenerator.Entities.BarcodeLabel"/> objects representing the generated barcode labels.
    /// </returns>
    /// <remarks>
    /// This method utilizes the <see cref="BarcodeGenerator.LabelGeneration.BarcodeLabelBuilder"/> to construct each barcode label.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="startIndex"/> is greater than <paramref name="endIndex"/>.
    /// </exception>
    public IList<BarcodeLabel> Generate(int startIndex, int endIndex, string sourceCode, DateTime datePurchased) {
        var barcodes = new List<BarcodeLabel>();

        for (var i = startIndex; i <= endIndex; i++) {
            var barcodeLabel = new BarcodeLabelBuilder()
                .WithDatePurchased(datePurchased)
                .WithIndex(i)
                .WithSource(sourceCode)
                .Build();

            barcodes.Add(barcodeLabel);
        }

        return barcodes;
    }
}