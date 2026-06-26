// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************
// <copyright file="IBarcodeLabelGenerator.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Defines the contract for generating barcode labels within a specified range.
/// </summary>
/// <remarks>
/// Implementations of this interface are responsible for creating instances of <see cref="BarcodeGenerator.Entities.BarcodeLabel"/>
/// based on the provided parameters, such as range, source code, purchase date, and other options.
/// </remarks>
public interface IBarcodeLabelGenerator {

    /// <summary>
    /// Generates a collection of barcode labels within the specified range.
    /// </summary>
    /// <param name="startIndex">The starting index of the barcode labels to generate.</param>
    /// <param name="endIndex">The ending index of the barcode labels to generate.</param>
    /// <param name="sourceCode">The source code associated with the barcode labels.</param>
    /// <param name="datePurchased">The purchase date to associate with the barcode labels.</param>
    /// <param name="numberOfCopies">The number of copies to generate for each barcode label.</param>
    /// <param name="isCollated">
    /// A value indicating whether the generated barcode labels should be collated.
    /// If <c>true</c>, the labels will be collated; otherwise, they will not.
    /// </param>
    /// <returns>A list of <see cref="BarcodeGenerator.Entities.BarcodeLabel"/> objects representing the generated barcode labels.</returns>
    /// <remarks>
    /// This method is responsible for creating barcode labels based on the provided parameters.
    /// The generated labels include details such as the source code, purchase date, and label index.
    /// </remarks>
    IList<BarcodeLabel> Generate(int startIndex, int endIndex, string sourceCode, DateTime datePurchased, int numberOfCopies, bool isCollated = false);
}