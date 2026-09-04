// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************

using BarcodeGenerator.Entities;
using System.Runtime.Versioning;

// ReSharper disable InvalidXmlDocComment

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality for rendering barcode labels using a one-by-three label template.
/// </summary>
/// <remarks>
/// This class implements the <see cref="ILabelRenderer{RenderedBarcodeLabel}"/> interface to render barcode labels
/// with a one-by-three layout. It utilizes the <see cref="LabelTemplateType.VinylBarcode"/> template type
/// and provides methods to render the label onto a graphical surface within specified bounds.
/// </remarks>
[SupportedOSPlatform("windows")]
public class VinylBarcodeLabelRenderer : ILabelRenderer {
    /// <summary>
    /// Gets the type of label template used by the renderer.
    /// </summary>
    /// <value>
    /// A <see cref="LabelTemplateType"/> value representing the template type
    /// for rendering labels, such as <see cref="LabelTemplateType.VinylBarcode"/>.
    /// </value>
    /// <remarks>
    /// This property specifies the template type that the renderer is designed to support.
    /// It is used to ensure compatibility between the renderer and the label template.
    /// </remarks>
    public LabelTemplateType TemplateType => LabelTemplateType.VinylBarcode;

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
    public void Render(IPrintableLabel label, Graphics graphics, Rectangle bounds) {
        ArgumentNullException.ThrowIfNull(label);
        ArgumentNullException.ThrowIfNull(graphics);

        if (label is not RenderedBarcodeLabel barcodeLabel) {
            throw new ArgumentException($"{nameof(VinylBarcodeLabelRenderer)} requires a " +
                                        $"{nameof(RenderedBarcodeLabel)}.",
                nameof(label));
        }

        RenderBarcodeLabel(graphics, bounds, barcodeLabel);
    }

    /// <summary>
    /// Renders a barcode label onto the specified graphics surface within the given bounds.
    /// </summary>
    /// <param name="graphics">The <see cref="Graphics"/> object used for rendering the label.</param>
    /// <param name="bounds">The <see cref="Rectangle"/> defining the area where the label will be rendered.</param>
    /// <param name="barcodeLabel">The <see cref="RenderedBarcodeLabel"/> containing the barcode image and associated data to render.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="graphics"/> or <paramref name="barcodeLabel"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the <paramref name="bounds"/> has a width or height less than or equal to zero.
    /// </exception>
    /// <remarks>
    /// This method clears the graphics surface, applies rendering settings, and draws the barcode image,
    /// label text, and additional information within the specified bounds.
    /// </remarks>
    private static void RenderBarcodeLabel(Graphics graphics, Rectangle bounds, RenderedBarcodeLabel barcodeLabel) {
        if (bounds.Width <= 0 || bounds.Height <= 0) {
            throw new ArgumentException("Bounds must have a positive width and height.", nameof(bounds));
        }

        graphics.Clear(Color.White);

        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;

        var paddingX = (int)Math.Round(bounds.Width * 0.06);
        //var top = (int)Math.Round(bounds.Height * 0.35);

        using var lotFont = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point);
        using var barcodeTextFont = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point);
        using var textBrush = new SolidBrush(Color.Black);

        using var stringFormat = new StringFormat();
        stringFormat.Alignment = StringAlignment.Center;
        stringFormat.LineAlignment = StringAlignment.Center;

        var lotText = $"Lot: {barcodeLabel.Label.DatePurchased}";
        var lotBounds = new Rectangle(
            bounds.Left + paddingX,
            bounds.Top,
            bounds.Width - (paddingX * 2),
            (int)Math.Round(bounds.Height * 0.25));

        graphics.DrawString(lotText, lotFont, textBrush, lotBounds, stringFormat);

        var barcodeTop =
            bounds.Top + (int)Math.Round(bounds.Height * 0.30);

        var barcodeHeight =
            (int)Math.Round(bounds.Height * 0.45);

        var barcodeBounds = new Rectangle(
            bounds.Left + paddingX,
            barcodeTop,
            bounds.Width - (paddingX * 2),
            barcodeHeight);

        graphics.DrawImage(
            barcodeLabel.BarcodeImage,
            barcodeBounds,
            new Rectangle(0, 0, barcodeLabel.BarcodeImage.Width,
                barcodeLabel.BarcodeImage.Height), GraphicsUnit.Pixel);

        var barcodeTextBounds = new Rectangle(
            bounds.Left + paddingX,
            barcodeBounds.Bottom,
            bounds.Width - (paddingX * 2),
            (int)Math.Round(bounds.Height * 0.20));

        graphics.DrawString(
            barcodeLabel.DisplayText,
            barcodeTextFont,
            textBrush,
            barcodeTextBounds,
            stringFormat);
    }
}