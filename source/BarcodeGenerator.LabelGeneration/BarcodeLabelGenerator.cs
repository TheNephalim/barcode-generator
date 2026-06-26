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
    /// <param name="numberOfCopies">
    /// The number of copies to generate for each barcode label. Defaults to 1.
    /// </param>
    /// <param name="isCollated">
    /// A boolean value indicating whether the generated barcode labels should be collated. Defaults to <c>false</c>.
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
    public IList<BarcodeLabel> Generate(int startIndex, int endIndex, string sourceCode, DateTime datePurchased, int numberOfCopies = 1, bool isCollated = false) {
        var barcodes = new List<BarcodeLabel>();

        if (startIndex > endIndex) {
            throw new ArgumentException("Start index must be less than or equal to end index.", nameof(startIndex));
        }

        if (numberOfCopies < 1) {
            throw new ArgumentOutOfRangeException(nameof(numberOfCopies), numberOfCopies, "Number of copies must be at least 1.");
        }

        if (string.IsNullOrWhiteSpace(sourceCode)) {
            throw new ArgumentException("Source code is required.", nameof(sourceCode));
        }

        if (isCollated) {
            GenerateCollatedCopies(startIndex, endIndex, sourceCode, datePurchased, numberOfCopies, barcodes);
            return barcodes;
        }

        GenerateNonCollatedCopies(startIndex, endIndex, sourceCode, datePurchased, numberOfCopies, barcodes);
        return barcodes;
    }

    /// <summary>
    /// Generates a single barcode label entry and adds it to the provided list of barcode labels.
    /// </summary>
    /// <param name="sourceCode">The source code associated with the barcode label.</param>
    /// <param name="datePurchased">The date the item was purchased, used for the barcode label.</param>
    /// <param name="i">The index of the barcode label within the specified range.</param>
    /// <param name="barcodes">The list to which the generated barcode label will be added.</param>
    /// <remarks>
    /// This method utilizes the <see cref="BarcodeLabelBuilder"/> to construct an instance of <see cref="BarcodeLabel"/>
    /// with the provided parameters and appends it to the given list.
    /// </remarks>
    private static void GenerateBarcodeLabelEntry(string sourceCode, DateTime datePurchased, int i, List<BarcodeLabel> barcodes) {
        var barcodeLabel = new BarcodeLabelBuilder()
            .WithDatePurchased(datePurchased)
            .WithIndex(i)
            .WithSource(sourceCode)
            .Build();

        barcodes.Add(barcodeLabel);
    }

    /// <summary>
    /// Generates collated copies of barcode labels within a specified range.
    /// </summary>
    /// <param name="startIndex">The starting index of the barcode labels to generate.</param>
    /// <param name="endIndex">The ending index of the barcode labels to generate.</param>
    /// <param name="sourceCode">The source code associated with the barcode labels.</param>
    /// <param name="datePurchased">The purchase date to associate with the barcode labels.</param>
    /// <param name="numberOfCopies">The number of collated copies to generate for each barcode label.</param>
    /// <param name="barcodes">The list to which the generated barcode labels will be added.</param>
    /// <remarks>
    /// This method generates barcode labels in a collated manner, where each copy of the entire range is generated sequentially.
    /// </remarks>
    private static void GenerateCollatedCopies(int startIndex, int endIndex, string sourceCode, DateTime datePurchased,
            int numberOfCopies, List<BarcodeLabel> barcodes) {
        for (var j = 1; j <= numberOfCopies; j++) {
            for (var i = startIndex; i <= endIndex; i++) {
                GenerateBarcodeLabelEntry(sourceCode, datePurchased, i, barcodes);
            }
        }
    }

    /// <summary>
    /// Generates non-collated copies of barcode labels for a specified range of indices.
    /// </summary>
    /// <param name="startIndex">
    /// The starting index of the barcode labels to generate.
    /// </param>
    /// <param name="endIndex">
    /// The ending index of the barcode labels to generate.
    /// </param>
    /// <param name="sourceCode">
    /// The source code associated with the barcode labels.
    /// </param>
    /// <param name="datePurchased">
    /// The date when the barcode labels were purchased.
    /// </param>
    /// <param name="numberOfCopies">
    /// The number of copies to generate for each barcode label.
    /// </param>
    /// <param name="barcodes">
    /// A list to which the generated barcode labels will be added.
    /// </param>
    /// <remarks>
    /// This method generates barcode labels in a non-collated manner, meaning that all copies of a single label
    /// are generated consecutively before moving to the next label in the range.
    /// </remarks>
    private static void GenerateNonCollatedCopies(int startIndex, int endIndex, string sourceCode, DateTime datePurchased,
        int numberOfCopies, List<BarcodeLabel> barcodes) {
        for (var i = startIndex; i <= endIndex; i++) {
            for (var j = 1; j <= numberOfCopies; j++) {
                GenerateBarcodeLabelEntry(sourceCode, datePurchased, i, barcodes);
            }
        }
    }
}