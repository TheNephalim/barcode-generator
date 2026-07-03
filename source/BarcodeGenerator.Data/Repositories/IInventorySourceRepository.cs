// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************
// <copyright file="IInventorySourceRepository.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.Data.Repositories;

/// <summary>
/// Defines a repository interface for managing and retrieving inventory source data.
/// </summary>
/// <remarks>
/// This interface is part of the <c>BarcodeGenerator.Data.Repositories</c> namespace and provides
/// methods for interacting with inventory source entities stored in the database.
/// </remarks>
public interface IInventorySourceRepository {

    /// <summary>
    /// Retrieves all inventory sources from the database.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a read-only list of
    /// <see cref="InventorySource"/> objects, ordered by their names in ascending order.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if there is an issue with the database connection or query execution.
    /// </exception>
    Task<IReadOnlyList<InventorySource>> GetAllAsync();
}