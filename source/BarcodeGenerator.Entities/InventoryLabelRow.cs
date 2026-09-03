// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 08-30-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a row in an inventory label, containing details about an inventory item.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and is used to encapsulate
/// information related to inventory items, such as their quantity, title, and other properties.
/// </remarks>
public sealed class InventoryLabelRow {
    /// <summary>
    /// Gets or sets the number of copies of the inventory label to be generated.
    /// </summary>
    /// <value>
    /// The number of copies to generate for this inventory label row.
    /// </value>
    /// <remarks>
    /// This property specifies how many labels should be printed for the associated inventory item.
    /// </remarks>
    public int Copies { get; set; }

    /// <summary>
    /// Gets or sets the date when the inventory label was imported.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> value representing the import date, or <c>null</c> if the date is not specified.
    /// </value>
    /// <remarks>
    /// This property is used to track the source or origin date of the inventory label data.
    /// </remarks>
    public DateTime? ImportedAt { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the inventory item associated with this label row.
    /// </summary>
    /// <value>
    /// An <see cref="int"/> representing the unique identifier of the inventory item.
    /// </value>
    /// <remarks>
    /// This property is used to link the label row to a specific inventory item in the system.
    /// </remarks>
    public int InventoryItemId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the inventory label row is selected.
    /// </summary>
    /// <value>
    /// <c>true</c> if the inventory label row is selected; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// This property is typically used to track the selection state of an inventory label row
    /// in user interfaces or processing logic.
    /// </remarks>
    public bool IsSelected { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the inventory item.
    /// </summary>
    /// <value>
    /// The quantity of the inventory item represented by this row.
    /// </value>
    /// <remarks>
    /// This property indicates the number of units available or required for the inventory item.
    /// </remarks>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the custom SKU (Stock Keeping Unit) associated with the inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the custom SKU of the inventory item.
    /// </value>
    /// <remarks>
    /// The custom SKU is used to uniquely identify or categorize the inventory item
    /// based on custom business logic or requirements.
    /// </remarks>
    public string Sku { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the source information associated with the inventory label row.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the source of the inventory item, such as its origin or reference.
    /// </value>
    /// <remarks>
    /// This property is used to store additional context or metadata about the inventory item.
    /// </remarks>
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the inventory item.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the title or name of the inventory item.
    /// </value>
    /// <remarks>
    /// This property is used to store the descriptive name of the inventory item
    /// and is part of the <see cref="InventoryLabelRow"/> class.
    /// </remarks>
    public string Title { get; set; } = string.Empty;
}