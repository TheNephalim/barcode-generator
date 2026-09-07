// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 09-05-2026
// ***********************************************************************
// <copyright file="IInventorySkuRepository.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

namespace BarcodeGenerator.Data.Repositories;

/// <summary>
/// Represents a repository for managing inventory SKU sequences.
/// </summary>
/// <remarks>
/// This interface provides methods for interacting with inventory SKU data,
/// such as retrieving the last assigned SKU number for a specific prefix and inventory source.
/// </remarks>
public interface IInventorySkuRepository {

    /// <summary>
    /// Asynchronously retrieves the last assigned SKU number for a specific prefix and inventory source.
    /// </summary>
    /// <param name="prefix">The prefix associated with the SKU sequence.</param>
    /// <param name="inventorySourceId">The identifier of the inventory source.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the last assigned SKU number,
    /// or <c>null</c> if no record is found.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="prefix"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method is intended to query the database for the last assigned SKU number corresponding to the
    /// specified prefix and inventory source. If no matching record exists, the method returns <c>null</c>.
    /// </remarks>
    Task<int?> GetLastAssignedSkuNumberAsync(string prefix, long inventorySourceId);
}