// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 09-02-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents an inventory label containing details such as SKU, title, and price.
/// </summary>
/// <remarks>
/// This class is a part of the <c>BarcodeGenerator.Entities</c> namespace and is designed to encapsulate
/// the essential properties of an inventory label.
/// </remarks>
public sealed class InventoryLabel {
    /// <summary>
    /// Gets or sets the unique identifier for the inventory item associated with this label.
    /// </summary>
    /// <value>
    /// An integer representing the unique identifier of the inventory item.
    /// </value>
    public int InventoryItemId { get; set; }

    /// <summary>
    /// Gets or sets the price of the inventory item.
    /// </summary>
    /// <value>
    /// The price of the inventory item represented as a decimal.
    /// </value>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the Stock Keeping Unit (SKU) associated with the inventory label.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the unique identifier for the inventory item.
    /// </value>
    /// <remarks>
    /// The SKU is used to uniquely identify and track inventory items within a system.
    /// </remarks>
    public string Sku { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the inventory label.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the title associated with the inventory label.
    /// </value>
    /// <remarks>
    /// The title typically provides a descriptive name or identifier for the inventory item.
    /// </remarks>
    public string Title { get; set; } = string.Empty;
}