// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 08-28-2026
// ***********************************************************************
// <copyright file="InventoryItem.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents an inventory item with various properties related to its listing, purchase, and storage.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and is designed to encapsulate
/// details about an inventory item, including its cost, SKU, listing information, purchase details,
/// and storage location.
/// </remarks>
public sealed class InventoryItem {
    /// <summary>
    /// Gets or sets the cost of the inventory item.
    /// </summary>
    /// <value>
    /// The cost of the item as a nullable <see cref="decimal"/>.
    /// A <c>null</c> value indicates that the cost is not specified.
    /// </value>
    public decimal? Cost { get; set; }

    /// <summary>
    /// Gets or sets the custom SKU (Stock Keeping Unit) associated with the inventory item.
    /// </summary>
    /// <value>
    /// A string representing the custom SKU, which can be used for tracking or categorizing the item.
    /// </value>
    /// <remarks>
    /// This property allows for the assignment of a user-defined SKU, providing flexibility
    /// in managing inventory items beyond standard SKU conventions.
    /// </remarks>
    public string? CustomSku { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the inventory item was discarded.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> representing the date and time the item was discarded, or <c>null</c> if the item has not been discarded.
    /// </value>
    /// <remarks>
    /// This property is used to track when an inventory item is no longer in use or has been removed from storage.
    /// </remarks>
    public DateTime? DiscardedOn { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the inventory item was donated.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> representing the donation date of the inventory item, or <c>null</c> if the item has not been donated.
    /// </value>
    public DateTime? DonatedOn { get; set; }

    /// <summary>
    /// Gets or sets the end date associated with the inventory item.
    /// </summary>
    /// <value>
    /// A string representing the end date, which may indicate the conclusion of a listing or another relevant event.
    /// </value>
    public string? EndDate { get; set; }

    /// <summary>
    /// Gets or sets the date when the inventory item was listed.
    /// </summary>
    /// <value>
    /// The date the item was listed, or <c>null</c> if the item has not been listed.
    /// </value>
    /// <remarks>
    /// This property represents the date an inventory item was made available for sale or display.
    /// </remarks>
    public DateTime? ListDate { get; set; }

    /// <summary>
    /// Gets or sets the platform or marketplace where the inventory item is listed for sale.
    /// </summary>
    /// <value>
    /// A string representing the name of the platform or marketplace (e.g., eBay, Amazon, etc.).
    /// </value>
    /// <remarks>
    /// This property is used to identify where the inventory item is currently available for purchase.
    /// </remarks>
    public string? ListedFor { get; set; }

    /// <summary>
    /// Gets or sets the listing price of the inventory item.
    /// </summary>
    /// <value>
    /// The price at which the inventory item is listed for sale.
    /// This value is nullable to accommodate scenarios where the listing price is not set.
    /// </value>
    public decimal? ListingPrice { get; set; }

    /// <summary>
    /// Gets or sets the type of listing associated with the inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the listing type, such as "Auction" or "Buy It Now".
    /// </value>
    /// <remarks>
    /// This property is used to specify the format or category of the item's listing
    /// on a sales platform.
    /// </remarks>
    public string? ListingType { get; set; }

    /// <summary>
    /// Gets or sets additional notes or comments associated with the inventory item.
    /// </summary>
    /// <value>
    /// A string containing notes or comments about the inventory item. This value can be <c>null</c>.
    /// </value>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the product name or identifier associated with the inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the product name or identifier.
    /// This value may be <c>null</c> if the product is not specified.
    /// </value>
    /// <remarks>
    /// This property is used to store the name or unique identifier of the product
    /// that the inventory item represents. It can be used for display, search, or
    /// categorization purposes.
    /// </remarks>
    public string? Product { get; set; }

    /// <summary>
    /// Gets or sets the name or identifier of the location where the inventory item was purchased.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the purchase location of the inventory item.
    /// </value>
    /// <remarks>
    /// This property is optional and may be <c>null</c> if the purchase location is not specified.
    /// </remarks>
    public string? PurchasedAt { get; set; }

    /// <summary>
    /// Gets or sets the date when the inventory item was purchased.
    /// </summary>
    /// <value>
    /// The date of purchase, or <see langword="null"/> if the purchase date is not specified.
    /// </value>
    /// <remarks>
    /// This property is used to track when the item was acquired for inventory purposes.
    /// </remarks>
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the inventory item that has been listed for sale.
    /// </summary>
    /// <value>
    /// The number of units of the inventory item currently listed.
    /// </value>
    /// <remarks>
    /// This property represents the total count of the item available for sale in listings.
    /// </remarks>
    public int QuantityListed { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the inventory item that was purchased.
    /// </summary>
    /// <value>
    /// The total number of units purchased for this inventory item.
    /// </value>
    /// <remarks>
    /// This property represents the amount of the item acquired during purchase and is used to track inventory levels.
    /// </remarks>
    public int QuantityPurchased { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the inventory item that remains available.
    /// </summary>
    /// <value>
    /// The number of items still in stock after accounting for sold and discarded quantities.
    /// </value>
    /// <remarks>
    /// This property represents the current stock level of the inventory item.
    /// It is calculated by subtracting the quantities sold and discarded from the total quantity purchased.
    /// </remarks>
    public int QuantityRemaining { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the inventory item that has been sold.
    /// </summary>
    /// <value>
    /// The number of units of the inventory item that have been sold.
    /// </value>
    /// <remarks>
    /// This property tracks the total quantity of the item that has been sold,
    /// which can be used for inventory management and sales reporting.
    /// </remarks>
    public int QuantitySold { get; set; }

    /// <summary>
    /// Gets or sets the scheduled date associated with the inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the scheduled date, which can be used for planning or tracking purposes.
    /// </value>
    public string? ScheduledDate { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the eBay listing associated with this inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the eBay item ID. This value may be <c>null</c> if the item is not listed on eBay.
    /// </value>
    public string? SourceRecordId { get; set; }

    /// <summary>
    /// Gets or sets the name of the system from which the inventory item originated.
    /// </summary>
    /// <value>
    /// A string representing the source system, such as "Flipwise/Ebay".
    /// </value>
    public string? SourceSystem { get; set; } = "Flipwise/Ebay";

    /// <summary>
    /// Gets or sets the storage location of the inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the physical or designated location where the inventory item is stored.
    /// </value>
    /// <remarks>
    /// This property is used to track and manage the storage details of the inventory item.
    /// </remarks>
    public string? StorageLocation { get; set; }
}