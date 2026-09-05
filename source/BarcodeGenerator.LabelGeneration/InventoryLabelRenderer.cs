// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 09-04-2026
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality to render inventory barcode labels onto a graphical surface.
/// </summary>
/// <remarks>
/// This class is a specific implementation of the <see cref="ILabelRenderer"/> interface, designed
/// to handle the rendering of inventory labels. It utilizes the <see cref="LabelTemplateType.Inventory"/>
/// template type to ensure proper formatting and layout of inventory labels.
/// </remarks>
public sealed class InventoryLabelRenderer : ILabelRenderer {
    public LabelTemplateType TemplateType => LabelTemplateType.Inventory;

    public void Render(IPrintableLabel label, Graphics graphics, Rectangle bounds) {
        if (label is not RenderedInventoryLabel inventoryLabel) {
            throw new ArgumentException($"Expected {nameof(RenderedInventoryLabel)}", nameof(label));
        }
    }
}