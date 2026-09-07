// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 09-05-2026
// ***********************************************************************
// <copyright file="IRenderedInventoryLabelGenerator.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Defines a contract for generating rendered inventory labels.
/// </summary>
/// <remarks>
/// This interface is part of the <c>BarcodeGenerator.LabelGeneration</c> namespace and provides
/// functionality for creating instances of <see cref="BarcodeGenerator.Entities.RenderedInventoryLabel"/>
/// based on inventory label data.
/// </remarks>
public interface IRenderedInventoryLabelGenerator {

    /// <summary>
    /// Generates a rendered inventory label based on the provided inventory label data.
    /// </summary>
    /// <param name="label">The <see cref="BarcodeGenerator.Entities.InventoryLabel"/> containing the details of the inventory item to be rendered.</param>
    /// <returns>
    /// A <see cref="BarcodeGenerator.Entities.RenderedInventoryLabel"/> instance that encapsulates the visual and textual representation
    /// of the inventory label, including its barcode image and metadata.
    /// </returns>
    /// <remarks>
    /// This method is part of the <see cref="BarcodeGenerator.LabelGeneration.IRenderedInventoryLabelGenerator"/> interface
    /// and is used to create a fully rendered label for inventory items.
    /// </remarks>
    RenderedInventoryLabel Generate(InventoryLabel label);
}