// ***********************************************************************
// Assembly          : BarcodeGenerator.Data.Repositories.Results
// Author            : Robert Eberhart
// Created           : 08-29-2026
// ***********************************************************************
namespace BarcodeGenerator.Data.Repositories.Results;

/// <summary>
/// Represents the result of an inventory import operation, providing details about the number of records added, processed, and skipped.
/// </summary>
public sealed class InventoryImportResult {
    /// <summary>
    /// Gets or sets the number of records that already existed in the system
    /// prior to the inventory import operation.
    /// </summary>
    public int ExistingRecords { get; set; }

    /// <summary>
    /// Gets or sets the number of items that are potential candidates for relisting
    /// during the inventory import process.
    /// </summary>
    /// <value>
    /// The count of items identified as possible relists.
    /// </value>
    public int PossibleRelists { get; set; }

    /// <summary>
    /// Gets or sets the number of records successfully added during the inventory import operation.
    /// </summary>
    public int RecordsAdded { get; set; }

    /// <summary>
    /// Gets or sets the total number of records that were processed during the inventory import operation.
    /// </summary>
    public int RecordsProcessed { get; set; }

    /// <summary>
    /// Gets or sets the number of records that were skipped during the inventory import operation.
    /// </summary>
    /// <value>
    /// The total count of records that were not processed, typically due to validation errors or duplicates.
    /// </value>
    public int RecordsSkipped { get; set; }

    /// <summary>
    /// Gets or sets the number of source conflicts encountered during the inventory import process.
    /// </summary>
    /// <remarks>
    /// Source conflicts typically occur when there are discrepancies or duplicate entries in the source data.
    /// </remarks>
    public int SourceConflicts { get; set; }
}