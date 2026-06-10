// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************
// <copyright file="IBarcodeLabelGenerator.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

public interface IBarcodeLabelGenerator {
    IList<BarcodeLabel> Generate(int startIndex, int endIndex, string sourceCode, DateTime datePurchased);
}