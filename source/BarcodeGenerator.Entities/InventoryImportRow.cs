// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 09-05-2026
// ***********************************************************************
// <copyright file="InventoryImportRow.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a row in the inventory import process.
/// </summary>
/// <remarks>
/// This class encapsulates the details of an inventory import row, including its selection status,
/// associated inventory item, proposed SKU, and the current status of the import operation.
/// </remarks>
public sealed class InventoryImportRow {
    public string? CustomSku => Item.CustomSku;
    /// <summary>
    /// Gets or sets the code representing the source of the inventory import.
    /// </summary>
    /// <remarks>
    /// This property identifies the origin of the inventory data, which can be used to
    /// track or categorize the source of the imported inventory records.
    /// </remarks>
    public string? InventorySourceCode { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the source of the inventory import.
    /// </summary>
    /// <value>
    /// The unique identifier associated with the inventory source, or <c>null</c> if not assigned.
    /// </value>
    /// <remarks>
    /// This property is used to link the inventory import row to its originating source.
    /// </remarks>
    public long? InventorySourceId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the inventory import row is selected for processing.
    /// </summary>
    /// <value>
    /// <c>true</c> if the row is selected; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// This property is used to determine whether the current inventory import row
    /// should be included in the import operation.
    /// </remarks>
    public bool IsSelected { get; set; }

    /// <summary>
    /// Gets or sets the inventory item associated with this import row.
    /// </summary>
    /// <value>
    /// An instance of <see cref="InventoryItem"/> representing the inventory item details,
    /// such as cost, SKU, listing information, purchase details, and storage location.
    /// </value>
    /// <remarks>
    /// This property is used to encapsulate the details of the inventory item being imported.
    /// </remarks>
    public InventoryItem Item { get; set; } = new InventoryItem();

    //
    // Convenience properties for DataGridView binding.
    //
    /// <summary>
    /// Gets the product name or description associated with the inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the product name or description, or <c>null</c> if not set.
    /// </value>
    /// <remarks>
    /// This property provides a convenient way to access the <c>Product</c> property of the associated
    /// <see cref="InventoryItem"/>.
    /// </remarks>
    public string? Product => Item.Product;

    /// <summary>
    /// Gets or sets the proposed SKU (Stock Keeping Unit) for the inventory item during the import process.
    /// </summary>
    /// <remarks>
    /// This property represents the SKU suggested for the inventory item being imported.
    /// It may be null if no SKU has been proposed.
    /// </remarks>
    public string? ProposedSku { get; set; }

    /// <summary>
    /// Gets the location where the inventory item was purchased.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the purchase location of the inventory item, or <c>null</c> if not specified.
    /// </value>
    /// <remarks>
    /// This property provides a convenient way to access the <see cref="InventoryItem.PurchasedAt"/> value
    /// associated with the current inventory import row.
    /// </remarks>
    public string? PurchasedAt => Item.PurchasedAt;

    /// <summary>
    /// Gets the identifier of the source record associated with the inventory item.
    /// </summary>
    /// <remarks>
    /// This property provides a reference to the original source record from which the inventory item was imported.
    /// It is retrieved from the <see cref="InventoryItem.SourceRecordId"/> property.
    /// </remarks>
    public string? SourceRecordId => Item.SourceRecordId;

    /// <summary>
    /// Gets or sets the current status of the inventory import operation.
    /// </summary>
    /// <value>
    /// One of the <see cref="InventoryImportStatus"/> values indicating the status of the import process.
    /// </value>
    /// <remarks>
    /// The status provides information about the progress or issues encountered during the inventory import,
    /// such as readiness, duplicate records, SKU conflicts, or unassigned sources.
    /// </remarks>
    public InventoryImportStatus Status { get; set; }
}