// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************

namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents the types of label templates available for barcode generation.
/// </summary>
/// <summary>
/// A label template with dimensions of 1x3.
/// </summary>
public enum LabelTemplateType {
    OneByThree,
    OneInchRound
}