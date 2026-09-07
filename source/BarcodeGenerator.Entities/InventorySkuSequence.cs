// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 09-05-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a sequence used for generating SKU (Stock Keeping Unit) numbers
/// for inventory items, including a prefix and the last assigned number.
/// </summary>
/// <remarks>
/// This class is designed to manage SKU sequences for inventory sources,
/// ensuring unique identifiers are generated consistently.
/// </remarks>
public sealed class InventorySkuSequence {
    /// <summary>
    /// Gets or sets the unique identifier for the SKU sequence.
    /// </summary>
    /// <value>
    /// An integer representing the unique identifier of the SKU sequence.
    /// </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the inventory source associated with this SKU sequence.
    /// </summary>
    /// <value>
    /// The unique identifier of the inventory source.
    /// </value>
    /// <remarks>
    /// This property links the SKU sequence to a specific inventory source,
    /// ensuring that SKUs are generated uniquely for each source.
    /// </remarks>
    public int InventorySourceId { get; set; }

    /// <summary>
    /// Gets or sets the last assigned number in the SKU sequence.
    /// </summary>
    /// <remarks>
    /// This property is used to track the most recently generated SKU number
    /// for the associated inventory source. It ensures that subsequent SKUs
    /// are assigned unique and sequential numbers.
    /// </remarks>
    public int LastAssignedNumber { get; set; }

    /// <summary>
    /// Gets or sets the prefix used in the SKU (Stock Keeping Unit) sequence.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the prefix that precedes the numeric part of the SKU.
    /// </value>
    /// <remarks>
    /// The prefix is used to distinguish SKU sequences for different inventory sources or categories.
    /// </remarks>
    public string Prefix { get; set; } = string.Empty;
}