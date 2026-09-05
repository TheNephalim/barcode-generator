// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

/// <summary>
/// Specifies the types of column information processors used in the Excel infrastructure.
/// </summary>
/// <summary>
/// Represents the absence of a column information processor.
/// </summary>
/// <summary>
/// Represents the default column information processor.
/// </summary>
public enum ColumnInfoProcessorTypes {
    /// <summary>
    /// Represents the default processor type, indicating that no specific processor is selected.
    /// </summary>
    None = 0,

    /// <summary>
    /// The default column information processor type.
    /// </summary>
    Default = 2
}