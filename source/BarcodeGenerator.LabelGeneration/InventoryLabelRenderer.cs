// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 09-04-2026
// ***********************************************************************
// <copyright file="InventoryLabelRenderer.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

public sealed class InventoryLabelRenderer : ILabelRenderer {
    public LabelTemplateType TemplateType => LabelTemplateType.Inventory;

    public void Render(IPrintableLabel label, Graphics graphics, Rectangle bounds) {
        if (label is not RenderedInventoryLabel inventoryLabel) {
            throw new ArgumentException($"Expected {nameof(RenderedInventoryLabel)}", nameof(label));
        }
    }
}