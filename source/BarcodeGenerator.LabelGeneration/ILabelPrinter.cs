// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
// <copyright file="ILabelPrinter.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Defines the contract for a label printer that handles the printing of barcode labels.
/// </summary>
/// <remarks>
/// This interface is part of the <c>BarcodeGenerator.LabelGeneration</c> namespace and provides
/// the necessary method(s) for implementing label printing functionality. Implementations of this
/// interface are expected to handle the specifics of printing barcode labels, such as formatting
/// and interacting with printing hardware or software.
/// </remarks>
/// <seealso cref="BarcodeGenerator.Entities.LabelPrintJob"/>
public interface ILabelPrinter {

    /// <summary>
    /// Prints the specified barcode label print job.
    /// </summary>
    /// <param name="printJob">
    /// An instance of <see cref="BarcodeGenerator.Entities.LabelPrintJob"/> that contains the details
    /// of the print job, such as the labels to be printed, the number of copies, the label size,
    /// and the printer name.
    /// </param>
    /// <remarks>
    /// Implementations of this method are responsible for processing the provided <paramref name="printJob"/>
    /// and handling the specifics of printing, including interacting with the printer hardware or software.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="printJob"/> is <c>null</c>.
    /// </exception>
    void Print(LabelPrintJob printJob);
}