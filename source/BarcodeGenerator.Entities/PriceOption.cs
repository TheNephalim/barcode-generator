// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 08-07-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a pricing option with associated display text and value.
/// </summary>
/// <remarks>
/// This class is immutable and designed to encapsulate a pricing option
/// for use within the barcode generation system.
/// </remarks>
public sealed class PriceOption {
    /// <summary>
    /// Gets the display text associated with the pricing option.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the text to be displayed for this pricing option.
    /// </value>
    /// <remarks>
    /// This property is immutable and is intended to provide a user-friendly representation
    /// of the pricing option within the barcode generation system.
    /// </remarks>
    public string DisplayText { get; init; } = string.Empty;

    /// <summary>
    /// Gets the numeric value associated with the pricing option.
    /// </summary>
    /// <value>
    /// A nullable <see cref="decimal"/> representing the value of the pricing option,
    /// or <c>null</c> if no value is assigned.
    /// </value>
    /// <remarks>
    /// This property is immutable and can only be set during object initialization.
    /// </remarks>
    public decimal? Value { get; init; }
}