// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 07-17-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents the definition of a grid column, including its property name, header text, width, and read-only status.
/// </summary>
public sealed record GridColumnDefinition(
    string PropertyName,
    string HeaderText,
    int Width,
    bool ReadOnly = true
);