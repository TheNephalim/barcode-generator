// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 08-06-2026
// ***********************************************************************

using BarcodeGenerator.Entities;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality for rendering one-inch round pricing labels.
/// </summary>
/// <remarks>
/// This class is a specific implementation of the <see cref="ILabelRenderer{TLabel}"/> interface,
/// designed to render pricing labels using the <see cref="LabelTemplateType.Pricing"/> template.
/// It encapsulates the logic required to draw the label onto a graphical surface within defined bounds.
/// </remarks>
public sealed class PricingLabelRenderer : ILabelRenderer {
    /// <summary>
    /// Gets the template type of the label rendered by the <see cref="PricingLabelRenderer"/>.
    /// </summary>
    /// <value>
    /// A <see cref="LabelTemplateType"/> value indicating the specific template type used for rendering.
    /// </value>
    /// <remarks>
    /// This property returns <see cref="LabelTemplateType.Pricing"/>, which represents a label template
    /// designed for one-inch round pricing labels.
    /// </remarks>
    public LabelTemplateType TemplateType => LabelTemplateType.Pricing;

    /// <summary>
    /// Renders a one-inch round pricing label onto the specified graphical surface within the given bounds.
    /// </summary>
    /// <param name="label">
    /// The label to be rendered. Must be of type <see cref="PricingLabel"/>.
    /// </param>
    /// <param name="graphics">
    /// The <see cref="Graphics"/> object used to render the label.
    /// </param>
    /// <param name="bounds">
    /// The <see cref="Rectangle"/> defining the area where the label should be rendered.
    /// Must have positive width and height.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="label"/> or <paramref name="graphics"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="label"/> is not of type <see cref="PricingLabel"/>,
    /// or if <paramref name="bounds"/> has non-positive dimensions.
    /// </exception>
    /// <remarks>
    /// This method clears the graphical surface, applies anti-aliasing and text rendering settings,
    /// and draws the pricing label's price and condition text within safe bounds.
    /// </remarks>
    public void Render(IPrintableLabel label, Graphics graphics, Rectangle bounds) {
        ArgumentNullException.ThrowIfNull(label);
        ArgumentNullException.ThrowIfNull(graphics);

        if (label is not PricingLabel pricingLabel) {
            throw new ArgumentException(
                $"{nameof(PricingLabelRenderer)} requires a {nameof(PricingLabel)}",
                nameof(label)
            );
        }

        if (bounds.Width <= 0 || bounds.Height <= 0) {
            throw new ArgumentException("Bounds must have a positive width and height.", nameof(bounds));
        }

        graphics.Clear(Color.White);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        var horizontalInset = (int)Math.Round(bounds.Width * 0.14);
        var verticalInset = (int)Math.Round(bounds.Height * 0.12);

        var safeBounds = Rectangle.Inflate(bounds, -horizontalInset, -verticalInset);
        var priceText = pricingLabel.Price.HasValue ? pricingLabel.Price.Value.ToString("$0") : string.Empty;
        var conditionText = BuildConditionText(pricingLabel);

        using var priceFont = new Font(
            "Arial",
            18f,
            FontStyle.Bold,
            GraphicsUnit.Point);

        using var conditionFont = new Font(
            "Arial",
            8f,
            FontStyle.Bold,
            GraphicsUnit.Point);

        using var brush = new SolidBrush(Color.Black);
        using var format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        if (string.IsNullOrWhiteSpace(conditionText)) {
            var priceOnlyBounds = new RectangleF(
                safeBounds.Left - (bounds.Width * 0.05f),
                safeBounds.Top + (bounds.Height * 0.035f),
                safeBounds.Width,
                safeBounds.Height);

            graphics.DrawString(priceText, priceFont, brush, priceOnlyBounds, format);
            return;
        }

        var priceBounds = new RectangleF(
            safeBounds.Left - (bounds.Width * 0.05f),
            safeBounds.Top + (bounds.Height * 0.035f),
            safeBounds.Width,
            safeBounds.Height);

        const float conditionHorizontalOffset = 0.07f;

        var conditionBounds = new RectangleF(
            safeBounds.Left - (bounds.Width * 0.04f),
            safeBounds.Top + (safeBounds.Height * 0.70f),
            safeBounds.Width,
            safeBounds.Height * 0.25f);

        graphics.DrawString(priceText, priceFont, brush, priceBounds, format);
        graphics.DrawString(conditionText, conditionFont, brush, conditionBounds, format);
    }

    /// <summary>
    /// Constructs the condition text for a pricing label based on its vinyl and sleeve conditions.
    /// </summary>
    /// <param name="pricingLabel">
    /// The <see cref="PricingLabel"/> instance containing the condition details.
    /// </param>
    /// <returns>
    /// A string representing the combined vinyl and sleeve conditions in the format "VinylCondition/SleeveCondition",
    /// or an empty string if the conditions are not included or are invalid.
    /// </returns>
    /// <remarks>
    /// This method checks the <see cref="PricingLabel.IncludeCondition"/> property to determine whether
    /// the condition text should be included. If either the vinyl or sleeve condition is null or empty,
    /// an empty string is returned.
    /// </remarks>
    private string BuildConditionText(PricingLabel pricingLabel) {
        if (!pricingLabel.IncludeCondition) return "";

        if (string.IsNullOrEmpty(pricingLabel.SleeveCondition) || string.IsNullOrEmpty(pricingLabel.VinylCondition)) {
            return string.Empty;
        }

        return $"{pricingLabel.VinylCondition}/{pricingLabel.SleeveCondition}";
    }
}