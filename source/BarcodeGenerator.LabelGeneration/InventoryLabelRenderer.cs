// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 09-04-2026
// ***********************************************************************

using BarcodeGenerator.Entities;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

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
    private readonly IBarcodeImageGenerator _barcodeImageGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryLabelRenderer"/> class.
    /// </summary>
    /// <param name="barcodeImageGenerator">
    /// An implementation of the <see cref="IBarcodeImageGenerator"/> interface used to generate barcode images.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="barcodeImageGenerator"/> is <c>null</c>.
    /// </exception>
    public InventoryLabelRenderer(IBarcodeImageGenerator barcodeImageGenerator) {
        _barcodeImageGenerator = barcodeImageGenerator ?? throw new ArgumentNullException(nameof(barcodeImageGenerator));
    }

    /// <summary>
    /// Gets the template type used by the <see cref="InventoryLabelRenderer"/> for rendering inventory labels.
    /// </summary>
    /// <value>
    /// The <see cref="LabelTemplateType.Inventory"/> template type, which ensures proper formatting and layout
    /// for inventory barcode labels.
    /// </value>
    /// <remarks>
    /// This property indicates the specific label template type that the <see cref="InventoryLabelRenderer"/>
    /// is designed to handle. It is primarily used to ensure compatibility with the inventory label rendering process.
    /// </remarks>
    public LabelTemplateType TemplateType => LabelTemplateType.Inventory;

    /// <summary>
    /// Renders an inventory label onto the specified graphics surface within the given bounds.
    /// </summary>
    /// <param name="label">
    /// The label to be rendered. Must implement <see cref="BarcodeGenerator.Entities.IPrintableLabel"/>.
    /// </param>
    /// <param name="graphics">
    /// The <see cref="Graphics"/> object used for rendering.
    /// </param>
    /// <param name="bounds">
    /// The <see cref="Rectangle"/> that defines the area where the label will be rendered.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="label"/> or <paramref name="graphics"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if the <paramref name="bounds"/> has a width or height less than or equal to zero.
    /// </exception>
    public void Render(IPrintableLabel label, Graphics graphics, Rectangle bounds) {
        ArgumentNullException.ThrowIfNull(label);
        ArgumentNullException.ThrowIfNull(graphics);

        if (label is not RenderedInventoryLabel inventoryLabel) {
            throw new ArgumentException($"Expected {nameof(RenderedInventoryLabel)}", nameof(label));
        }

        if (bounds.Width <= 0 || bounds.Height <= 0) {
            throw new ArgumentException("Bounds must have a positive width and height.", nameof(bounds));
        }

        graphics.Clear(Color.White);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        graphics.PixelOffsetMode = PixelOffsetMode.Half;
        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        var horizontalPadding = bounds.Width * 0.04f;
        var verticalPadding = bounds.Height * 0.06f;

        var contentLeft = bounds.Left + horizontalPadding;
        var contentTop = bounds.Top + verticalPadding;
        var contentWidth = bounds.Width - (horizontalPadding * 2);
        var contentHeight = bounds.Height - (verticalPadding * 2);

        var priceBounds = new RectangleF(
            bounds.Left + 2f,
            contentTop,
            contentWidth * 0.25f,
            contentHeight * 0.28f);

        var barcodeBounds = new RectangleF(
            contentLeft + (contentWidth * 0.27f),
            contentTop,
            contentWidth * 0.71f,
            contentHeight * 0.22f);

        var targetBarcodeWidth = ToPixelsX(graphics, barcodeBounds.Width);
        var targetBarcodeHeight = ToPixelsY(graphics, barcodeBounds.Height);

        using var barcodeImage = _barcodeImageGenerator.GenerateCode128(inventoryLabel.Label.Sku, targetBarcodeWidth, targetBarcodeHeight);

        var skuHorizontalPadding = 6f;

        var skuBounds = new RectangleF(
            barcodeBounds.Left - skuHorizontalPadding,
            barcodeBounds.Bottom + 3f,
            barcodeBounds.Width + (skuHorizontalPadding * 2),
            contentHeight * 0.16f);

        var titleBounds = new RectangleF(
            bounds.Left + 2f,
            contentTop + (contentHeight * 0.38f),
            bounds.Width - 14f,
            contentHeight * 0.60f);

        var priceText = $"{inventoryLabel.Label.Price:C}";

        var availablePriceWidth = priceBounds.Width - 4f;

        using var priceFont =
            GetPriceFont(graphics, priceText, priceBounds);

        using var priceFormat = new StringFormat();
        priceFormat.Alignment = StringAlignment.Near;
        priceFormat.LineAlignment = StringAlignment.Near;
        priceFormat.FormatFlags = StringFormatFlags.NoWrap;
        priceFormat.Trimming = StringTrimming.None;

        DrawBarcode(graphics, barcodeImage, barcodeBounds);

        graphics.DrawString(
            priceText,
            priceFont,
            Brushes.Black,
            priceBounds,
            priceFormat);

        using var skuFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point);

        using var skuFormat = new StringFormat();
        skuFormat.Alignment = StringAlignment.Center;
        skuFormat.LineAlignment = StringAlignment.Near;
        skuFormat.FormatFlags = StringFormatFlags.NoWrap;
        skuFormat.Trimming = StringTrimming.None;

        graphics.DrawString($"SKU: {inventoryLabel.Label.Sku}", skuFont, Brushes.Black, skuBounds, skuFormat);

        using var titleFont = new Font("Arial", 8f, FontStyle.Bold, GraphicsUnit.Point);

        using var titleFormat = new StringFormat();
        titleFormat.Alignment = StringAlignment.Near;
        titleFormat.LineAlignment = StringAlignment.Center;
        titleFormat.Trimming = StringTrimming.Word;

        graphics.DrawString(inventoryLabel.Label.Title, titleFont, Brushes.Black, titleBounds, titleFormat);
    }

    /// <summary>
    /// Draws a barcode image onto the specified graphics surface within the given bounds.
    /// </summary>
    /// <param name="graphics">
    /// The <see cref="Graphics"/> object used to render the barcode.
    /// This parameter cannot be <c>null</c>.
    /// </param>
    /// <param name="barcode">
    /// The <see cref="Image"/> representing the barcode to be drawn.
    /// This parameter cannot be <c>null</c>.
    /// </param>
    /// <param name="bounds">
    /// A <see cref="RectangleF"/> structure specifying the area where the barcode should be rendered.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="graphics"/> or <paramref name="barcode"/> is <c>null</c>.
    /// </exception>
    private static void DrawBarcode(
        Graphics graphics,
        Image barcode,
        RectangleF bounds) {
        var state = graphics.Save();

        try {
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.None;
            graphics.CompositingQuality = CompositingQuality.HighSpeed;

            var destination = Rectangle.Round(bounds);

            graphics.DrawImage(
                barcode,
                destination,
                0,
                0,
                barcode.Width,
                barcode.Height,
                GraphicsUnit.Pixel);
        } finally {
            graphics.Restore(state);
        }
    }

    /// <summary>
    /// Converts a specified <see cref="GraphicsUnit"/> to its corresponding number of pixels per unit,
    /// based on the provided DPI (dots per inch).
    /// </summary>
    /// <param name="unit">The <see cref="GraphicsUnit"/> to convert.</param>
    /// <param name="dpi">The DPI (dots per inch) value used for the conversion.</param>
    /// <returns>The number of pixels per unit for the specified <paramref name="unit"/>.</returns>
    /// <exception cref="NotSupportedException">
    /// Thrown when the specified <paramref name="unit"/> is not supported.
    /// </exception>
    private static float GetPixelsPerUnit(GraphicsUnit unit, float dpi) {
        return unit switch {
            GraphicsUnit.Pixel => 1f,
            GraphicsUnit.Inch => dpi,
            GraphicsUnit.Millimeter => dpi / 25.4f,
            GraphicsUnit.Point => dpi / 72f,
            GraphicsUnit.Document => dpi / 300f,
            GraphicsUnit.Display => dpi / 100f,
            _ => throw new NotSupportedException(
                $"Unsupported graphics unit: {unit}")
        };
    }

    private static Font GetPriceFont(
                Graphics graphics,
        string priceText,
        RectangleF bounds) {
        const float maxFontSize = 12f;
        const float minFontSize = 8f;
        const float safetyPadding = 4f;

        var availableWidth = bounds.Width - safetyPadding;

        for (var size = maxFontSize; size >= minFontSize; size -= 0.5f) {
            var font = new Font(
                "Arial",
                size,
                FontStyle.Bold,
                GraphicsUnit.Point);

            if (graphics.MeasureString(priceText, font).Width <= availableWidth) {
                return font;
            }

            font.Dispose();
        }

        return new Font(
            "Arial",
            minFontSize,
            FontStyle.Bold,
            GraphicsUnit.Point);
    }

    /// <summary>
    /// Converts a specified value in the horizontal coordinate system to pixels,
    /// based on the current graphics context and its DPI settings.
    /// </summary>
    /// <param name="graphics">The <see cref="Graphics"/> context used to determine the DPI and unit scaling.</param>
    /// <param name="value">The horizontal value to be converted to pixels.</param>
    /// <returns>The equivalent pixel value of the specified horizontal coordinate.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="graphics"/> is <c>null</c>.</exception>
    private static int ToPixelsX(Graphics graphics, float value) {
        return (int)Math.Round(
            value * GetPixelsPerUnit(graphics.PageUnit, graphics.DpiX));
    }

    /// <summary>
    /// Converts a vertical measurement from the specified unit to pixels, based on the graphics context.
    /// </summary>
    /// <param name="graphics">The <see cref="Graphics"/> object used to determine the DPI and unit scaling.</param>
    /// <param name="value">The vertical measurement to convert, in the unit specified by <see cref="Graphics.PageUnit"/>.</param>
    /// <returns>The equivalent vertical measurement in pixels, rounded to the nearest integer.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="graphics"/> is <c>null</c>.</exception>
    /// <remarks>
    /// This method calculates the pixel equivalent of a vertical measurement by considering the DPI
    /// (dots per inch) and the current page unit of the provided <see cref="Graphics"/> context.
    /// </remarks>
    private static int ToPixelsY(Graphics graphics, float value) {
        return (int)Math.Round(
            value * GetPixelsPerUnit(graphics.PageUnit, graphics.DpiY));
    }
}