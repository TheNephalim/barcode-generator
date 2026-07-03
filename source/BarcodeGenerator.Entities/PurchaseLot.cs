// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 07-03-2026
// ***********************************************************************
// <copyright file="PurchaseLot.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************
namespace BarcodeGenerator.Entities;

public class PurchaseLot {
    public string Description { get; set; }
    public string EstimatedItemCount { get; set; }
    public int Id { get; set; }
    public string LotDate { get; set; }
    public string SourceCode { get; set; }
    public decimal TotalCost { get; set; }
}