// ***********************************************************************
// Assembly          : BarcodeGenerator.Reporting.Contracts
// Author            : Robert Eberhart
// Created           : 09-10-2026
// ***********************************************************************

namespace BarcodeGenerator.Reporting.Contracts.Enumerations;

/// <summary>
/// Specifies the data type of a column in an Excel file.
/// </summary>
/// <summary>
/// Represents textual data.
/// </summary>
/// <summary>
/// Represents numeric data.
/// </summary>
/// <summary>
/// Represents date and time data.
/// </summary>
public enum ExcelColumnDataType {
    Text,
    Number,
    DateTime,
    Boolean,
    Error,
    TimeSpan
}