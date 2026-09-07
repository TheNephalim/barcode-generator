// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 09-05-2026
// ***********************************************************************
// <copyright file="InventoryImportStatus.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents the status of an inventory import operation.
/// </summary>
/// <summary>
/// Indicates that the inventory import is ready to be processed.
/// </summary>
/// <summary>
/// Indicates that the inventory import contains a duplicate source record.
/// </summary>
/// <summary>
/// Indicates that there is a conflict with the SKU during the inventory import.
/// </summary>
/// <summary>
/// Indicates that the source of the inventory import is unassigned.
/// </summary>
public enum InventoryImportStatus {
    Ready,
    DuplicateSourceRecord,
    SkuConflict,
    SourceUnassigned
}