// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
// <copyright file="ILabelPrinterFactory.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

public interface ILabelPrinterFactory {
    /// <summary>
    /// Retrieves the appropriate <see cref="ILabelPrinter"/> instance for the specified <see cref="LabelTemplateType"/>.
    /// </summary>
    /// <param name="templateType">
    /// The <see cref="LabelTemplateType"/> for which the corresponding <see cref="ILabelPrinter"/> is required.
    /// </param>
    /// <returns>
    /// An instance of <see cref="ILabelPrinter"/> that matches the specified <paramref name="templateType"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if no printer is found for the specified <paramref name="templateType"/>.
    /// </exception>
    /// <remarks>
    /// This method ensures that the correct label printer implementation is retrieved based on the provided template type.
    /// </remarks>
    /// <example>
    /// The following example demonstrates how to retrieve and use a label printer:
    /// <code>
    /// var printers = new List&lt;ILabelPrinter&gt; { new CustomLabelPrinter() };
    /// var factory = new LabelPrinterFactory(printers);
    /// var printer = factory.GetPrinter(LabelTemplateType.OneByThree);
    /// printer.Print(new LabelPrintJob { Copies = 2, PrinterName = "MyPrinter" });
    /// </code>
    /// </example>
    ILabelPrinter GetPrinter(LabelTemplateType templateType);
}