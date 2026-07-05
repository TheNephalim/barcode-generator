// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a purchase lot entity containing details about a specific lot of purchased items.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and provides properties
/// to store information such as the description, estimated item count, lot date, source code,
/// total cost, and an identifier for the purchase lot.
/// </remarks>
public class PurchaseLot {
    /// <summary>
    /// Gets or sets the description of the purchase lot.
    /// </summary>
    /// <value>
    /// A string representing the description of the purchase lot, providing details or notes about the lot.
    /// </value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the estimated number of items in the purchase lot.
    /// </summary>
    /// <value>
    /// A string representing the estimated count of items.
    /// </value>
    /// <remarks>
    /// This property provides an estimation of the total items included in the purchase lot.
    /// The value is stored as a string, which may include additional formatting or units.
    /// </remarks>
    public string EstimatedItemCount { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the purchase lot.
    /// </summary>
    /// <value>
    /// The unique identifier represented as an integer.
    /// </value>
    /// <remarks>
    /// This property is used to uniquely identify a specific purchase lot within the system.
    /// </remarks>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the date associated with the purchase lot.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the date of the lot.
    /// </value>
    /// <remarks>
    /// This property stores the date information for the purchase lot, which may be used for
    /// tracking and record-keeping purposes.
    /// </remarks>
    public string LotDate { get; set; }

    /// <summary>
    /// Gets or sets the source code associated with the purchase lot.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the source code that identifies the origin or source of the purchase lot.
    /// </value>
    public string SourceCode { get; set; }

    /// <summary>
    /// Gets or sets the total cost associated with the purchase lot.
    /// </summary>
    /// <value>
    /// The total cost of the purchase lot, represented as a decimal value.
    /// </value>
    /// <remarks>
    /// This property represents the monetary value of the entire purchase lot.
    /// </remarks>
    public decimal TotalCost { get; set; }
}