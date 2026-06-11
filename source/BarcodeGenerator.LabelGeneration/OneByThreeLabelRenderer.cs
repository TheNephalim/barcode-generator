// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
// <copyright file="OneByThreeLabelRenderer.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;
using System.Drawing;
using System.Runtime.Versioning;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality for rendering barcode labels using a one-by-three label template.
/// </summary>
/// <remarks>
/// This class implements the <see cref="ILabelRenderer"/> interface to render barcode labels
/// with a one-by-three layout. It utilizes the <see cref="LabelTemplateType.OneByThree"/> template type
/// and provides methods to render the label onto a graphical surface within specified bounds.
/// </remarks>
[SupportedOSPlatform("windows")]
public class OneByThreeLabelRenderer : ILabelRenderer {
    /// <summary>
    /// Gets the type of label template used by the renderer.
    /// </summary>
    /// <value>
    /// A <see cref="LabelTemplateType"/> value representing the template type
    /// for rendering labels, such as <see cref="LabelTemplateType.OneByThree"/>.
    /// </value>
    /// <remarks>
    /// This property specifies the template type that the renderer is designed to support.
    /// It is used to ensure compatibility between the renderer and the label template.
    /// </remarks>
    public LabelTemplateType TemplateType => LabelTemplateType.OneByThree;

    /// <summary>
    /// Renders a one-by-three label using the specified barcode label, graphics context, and bounding rectangle.
    /// </summary>
    /// <param name="label">
    /// The <see cref="RenderedBarcodeLabel"/> containing the barcode image and label details to be rendered.
    /// </param>
    /// <param name="graphics">
    /// The <see cref="Graphics"/> context used for rendering the label.
    /// </param>
    /// <param name="bounds">
    /// The <see cref="Rectangle"/> defining the area within which the label should be rendered.
    /// </param>
    /// <remarks>
    /// This method is responsible for rendering a one-by-three label layout. It utilizes the provided
    /// <paramref name="label"/>, <paramref name="graphics"/>, and <paramref name="bounds"/> to draw the label
    /// appropriately within the specified area.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="label"/> or <paramref name="graphics"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="bounds"/> is not a valid rectangle.
    /// </exception>
    public void Render(RenderedBarcodeLabel label, Graphics graphics, Rectangle bounds) {
        ArgumentNullException.ThrowIfNull(label);
        ArgumentNullException.ThrowIfNull(graphics);

        if (bounds.Width <= 0 || bounds.Height <= 0) {
            throw new ArgumentException("Bounds must have a positive width and height.", nameof(bounds));
        }

        using var font = new Font("Arial", 10, FontStyle.Regular);

        graphics.Clear(Color.White);
        const int padding = 8;

        var textBounds = new Rectangle(
            bounds.Left,
            bounds.Bottom - 24,
            bounds.Width,
            20
        );

        using var format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        var barcodeBounds = new Rectangle(
            bounds.Left + padding,
            bounds.Top + padding,
            bounds.Width - (padding * 2),
            bounds.Height - (padding * 20)
        );

        graphics.DrawImage(label.BarcodeImage, barcodeBounds);

        graphics.DrawString(label.DisplayText, font, Brushes.Black, textBounds, format);
    }
}