// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities.ClassMaps
// Author            : Robert Eberhart
// Created           : 08-28-2026
// ***********************************************************************

using CsvHelper.Configuration;

// ReSharper disable ClassNeverInstantiated.Global

namespace BarcodeGenerator.Entities.ClassMaps;

/// <summary>
/// Provides a CSV mapping configuration for the <see cref="BarcodeGenerator.Entities.InventoryItem"/> class.
/// </summary>
/// <remarks>
/// This class is used to define the mapping between the properties of the <see cref="BarcodeGenerator.Entities.InventoryItem"/> class
/// and the corresponding column names in a CSV file. It ensures that data is correctly parsed and written when working with CSV files.
/// </remarks>
public sealed class FlipwiseInventoryItemClassMap : ClassMap<InventoryItem> {

    /// <summary>
    /// Initializes a new instance of the <see cref="FlipwiseInventoryItemClassMap"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor defines the mapping between the properties of the <see cref="InventoryItem"/> class
    /// and their corresponding column names in a CSV file. It ensures that the data is correctly aligned
    /// for reading from or writing to CSV files.
    /// </remarks>
    public FlipwiseInventoryItemClassMap() {
        Map(x => x.Cost).Name("Cost");
        Map(x => x.CustomSku).Name("Custom SKU");
        Map(x => x.Product).Name("Product");
        Map(x => x.DiscardedOn).Name("Discarded on");
        Map(x => x.DonatedOn).Name("Donated on");
        Map(x => x.EndDate).Name("End date");
        Map(x => x.StorageLocation).Name("Storage location");
        Map(x => x.SourceRecordId).Name("eBay Item ID");
        Map(x => x.QuantityListed).Name("Quantity listed");
        Map(x => x.QuantityPurchased).Name("Quantity purchased");
        Map(x => x.QuantitySold).Name("Quantity sold");
        Map(x => x.QuantityRemaining).Name("Quantity remaining");
        Map(x => x.Notes).Name("Notes");
        Map(x => x.ListDate).Name("List date");
        Map(x => x.ListedFor).Name("Listed for");
        Map(x => x.ScheduledDate).Name("Scheduled date");
        Map(x => x.ListingPrice).Name("List price");
        Map(x => x.ListingType).Name("Listing type");
        Map(x => x.PurchasedAt).Name("Purchased at");
        Map(x => x.PurchaseDate).Name("Purchase date");
    }
}