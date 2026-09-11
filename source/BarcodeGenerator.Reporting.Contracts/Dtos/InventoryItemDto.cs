// ***********************************************************************
// Assembly          : BarcodeGenerator.ExcelReports.Dtos
// Author            : Robert Eberhart
// Created           : 09-09-2026
// ***********************************************************************

using BarcodeGenerator.Reporting.Contracts.Attributes;
using BarcodeGenerator.Reporting.Contracts.Enumerations;

namespace BarcodeGenerator.Reporting.Contracts.Dtos;

/// <summary>
/// Represents a data transfer object for inventory items, used for generating Excel reports.
/// </summary>
public sealed class InventoryItemDto {
    /// <summary>
    /// Gets or sets the cost of the inventory item.
    /// </summary>
    /// <remarks>
    /// This property is used for generating Excel reports and is formatted as currency.
    /// </remarks>
    [DefaultColumn("Cost", nameof(Cost), 7, 11D, StyleFormat.CurrencyFormat, ExcelColumnDataType.Number)]
    public decimal? Cost { get; set; }

    /// <summary>
    /// Gets or sets the custom SKU (Stock Keeping Unit) for the inventory item.
    /// This property is used to uniquely identify the item in the inventory
    /// and is displayed in the "Sku" column of the generated Excel report.
    /// </summary>
    [DefaultColumn("Sku", nameof(CustomSku), 1, 11D, StyleFormat.EmptyFormat, ExcelColumnDataType.Text)]
    public string? CustomSku { get; set; }

    /// <summary>
    /// Gets or sets the listing price of the inventory item.
    /// </summary>
    /// <remarks>
    /// This property is used to represent the price at which the inventory item is listed for sale.
    /// It is formatted as currency in the generated Excel report.
    /// </remarks>
    [DefaultColumn("List Price", nameof(ListingPrice), 8, 11D, StyleFormat.CurrencyFormat, ExcelColumnDataType.Number)]
    public decimal? ListingPrice { get; set; }

    /// <summary>
    /// Gets or sets the name of the product associated with the inventory item.
    /// </summary>
    /// <remarks>
    /// This property is used for generating Excel reports and is displayed in the "Product" column.
    /// </remarks>
    [DefaultColumn("Product", nameof(Product), 2, 11D, StyleFormat.EmptyFormat, ExcelColumnDataType.Text)]
    public string? Product { get; set; }

    /// <summary>
    /// Gets or sets the location where the inventory item was purchased.
    /// </summary>
    /// <remarks>
    /// This property is used for generating Excel reports and is displayed in the "Purchased At" column.
    /// </remarks>
    [DefaultColumn("Purchased At", nameof(PurchasedAt), 5, 11D, StyleFormat.EmptyFormat, ExcelColumnDataType.Text)]
    public string? PurchasedAt { get; set; }

    /// <summary>
    /// Gets or sets the date when the inventory item was purchased.
    /// </summary>
    /// <remarks>
    /// This property is used for generating Excel reports and is formatted as a date
    /// using the "mm/dd/yyyy" format.
    /// </remarks>
    [DefaultColumn("Purchase Date", nameof(PurchaseDate), 6, 11D, StyleFormat.DateFormatSlash, ExcelColumnDataType.DateTime)]
    public DateTime? PurchaseDate { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the source record from which the inventory item originates.
    /// </summary>
    /// <remarks>
    /// This property is used to track the original record in the source system for reference purposes.
    /// </remarks>
    [DefaultColumn("Source Record Id", nameof(SourceRecordId), 4, 11D, StyleFormat.EmptyFormat, ExcelColumnDataType.Text)]
    public string? SourceRecordId { get; set; }

    /// <summary>
    /// Gets or sets the name of the system from which the inventory item originates.
    /// </summary>
    /// <remarks>
    /// This property is used to identify the source system for the inventory item
    /// and is displayed in the "Sourced System" column of the generated Excel report.
    /// </remarks>
    [DefaultColumn("Sourced System", nameof(SourceSystem), 3, 11D, StyleFormat.EmptyFormat, ExcelColumnDataType.Text)]
    public string? SourceSystem { get; set; }
}