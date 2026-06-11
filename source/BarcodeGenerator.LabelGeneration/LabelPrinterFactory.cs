// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
// <copyright file="LabelPrinterFactory.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using Autofac.Features.Indexed;
using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Factory class responsible for creating and managing instances of <see cref="ILabelPrinter"/>.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.LabelGeneration</c> namespace and provides functionality
/// to retrieve the appropriate label printer based on the specified <see cref="LabelTemplateType"/>.
/// It ensures that the correct printer implementation is used for generating barcode labels
/// according to the template type.
/// </remarks>
/// <example>
/// The following example demonstrates how to use the <c>LabelPrinterFactory</c>:
/// <code>
/// var printers = new List&lt;ILabelPrinter&gt; { new CustomLabelPrinter() };
/// var factory = new LabelPrinterFactory(printers);
/// var printer = factory.GetPrinter(LabelTemplateType.OneByThree);
/// printer.Print(new LabelPrintJob { Copies = 2, PrinterName = "MyPrinter" });
/// </code>
/// </example>
/// <exception cref="ArgumentException">
/// Thrown by <see cref="GetPrinter"/> if no printer is found for the specified <see cref="LabelTemplateType"/>.
/// </exception>
/// <seealso cref="ILabelPrinter"/>
/// <seealso cref="LabelTemplateType"/>
public class LabelPrinterFactory : ILabelPrinterFactory {
    private readonly IIndex<LabelTemplateType, ILabelPrinter> _printers;

    /// <summary>
    /// Initializes a new instance of the <see cref="LabelPrinterFactory"/> class.
    /// </summary>
    /// <param name="printers">
    /// A collection of <see cref="ILabelPrinter"/> instances used to map each printer to its corresponding
    /// <see cref="LabelTemplateType"/>.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="printers"/> parameter is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="printers"/> collection contains duplicate <see cref="LabelTemplateType"/> values.
    /// </exception>
    /// <remarks>
    /// This constructor creates a dictionary mapping each <see cref="LabelTemplateType"/> to its respective
    /// <see cref="ILabelPrinter"/> implementation, ensuring that the correct printer is available for each template type.
    /// </remarks>
    public LabelPrinterFactory(IIndex<LabelTemplateType, ILabelPrinter> printers) {
        _printers = printers ?? throw new ArgumentNullException(nameof(printers));
    }

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
    public ILabelPrinter GetPrinter(LabelTemplateType templateType) {
        if (_printers.TryGetValue(templateType, out var printer)) {
            return printer;
        }

        throw new ArgumentOutOfRangeException(nameof(templateType), templateType,
            $"No label printer is registered for template type '{templateType}'.");
    }
}