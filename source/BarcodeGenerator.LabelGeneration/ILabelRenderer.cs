// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
// <copyright file="ILabelRenderer.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;
using System.Drawing;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Defines the contract for rendering barcode labels onto a graphical surface.
/// </summary>
/// <remarks>
/// Implementations of this interface are responsible for rendering barcode labels
/// using a specified template type and rendering context. The rendering process
/// involves drawing the label onto a provided graphics object within defined bounds.
/// </remarks>
public interface ILabelRenderer {
    /// <summary>
    /// Gets the type of label template used for rendering barcode labels.
    /// </summary>
    /// <value>
    /// A <see cref="LabelTemplateType"/> enumeration value representing the template type.
    /// </value>
    /// <remarks>
    /// The <see cref="TemplateType"/> property specifies the layout and dimensions of the label template
    /// that will be used during the rendering process. This property is essential for determining
    /// how the barcode label is formatted and displayed.
    /// </remarks>
    LabelTemplateType TemplateType { get; }

    /// <summary>
    /// Renders a barcode label onto a graphical surface within specified bounds.
    /// </summary>
    /// <param name="label">
    /// The <see cref="RenderedBarcodeLabel"/> instance containing the barcode image and associated label details to be rendered.
    /// </param>
    /// <param name="graphics">
    /// The <see cref="Graphics"/> object used as the rendering surface.
    /// </param>
    /// <param name="bounds">
    /// A <see cref="Rectangle"/> defining the area within which the barcode label should be rendered.
    /// </param>
    /// <remarks>
    /// This method is responsible for drawing the barcode label onto the provided graphics surface.
    /// Implementations should ensure that the rendering respects the specified bounds and utilizes
    /// the label's template type.
    /// </remarks>
    void Render(RenderedBarcodeLabel label, Graphics graphics, Rectangle bounds);
}