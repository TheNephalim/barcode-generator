// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 08-04-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a pricing label with details about price, vinyl condition, and sleeve condition.
/// </summary>
/// <remarks>
/// This record is immutable and provides a concise way to encapsulate pricing and condition details
/// for a product, such as a vinyl record.
/// </remarks>
public sealed class PricingLabel : IPrintableLabel {
    /// <summary>
    /// Gets a value indicating whether the condition details (such as sleeve and vinyl condition)
    /// should be included on the pricing label.
    /// </summary>
    /// <value>
    /// <c>true</c> if the condition details should be included; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// This property allows customization of the label's content by including or excluding
    /// condition details based on the specified value.
    /// </remarks>
    public bool IncludeCondition { get; init; } = true;

    /// <summary>
    /// Gets the price associated with the pricing label.
    /// </summary>
    /// <value>
    /// The price of the product, or <c>null</c> if the price is not specified.
    /// </value>
    /// <remarks>
    /// This property is optional and can be used to represent the monetary value of a product.
    /// </remarks>
    public decimal? Price { get; init; }

    /// <summary>
    /// Gets the condition of the sleeve associated with the pricing label.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the condition of the sleeve, or <c>null</c> if not specified.
    /// </value>
    /// <remarks>
    /// This property is typically used to describe the physical condition of the sleeve for items such as vinyl records.
    /// </remarks>
    public string? SleeveCondition { get; init; }

    /// <summary>
    /// Gets the condition of the vinyl record.
    /// </summary>
    /// <value>
    /// A string representing the condition of the vinyl record, such as "Mint", "Good", or "Poor".
    /// </value>
    /// <remarks>
    /// This property is optional and may be <c>null</c> if the condition is not specified.
    /// </remarks>
    public string? VinylCondition { get; init; }
}