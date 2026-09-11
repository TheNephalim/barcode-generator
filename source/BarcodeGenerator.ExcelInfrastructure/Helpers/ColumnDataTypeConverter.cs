// ***********************************************************************
// Assembly          : BarcodeGenerator.ExcelInfrastructure.Helpers
// Author            : Robert Eberhart
// Created           : 09-11-2026
// ***********************************************************************
using BarcodeGenerator.Reporting.Contracts.Enumerations;
using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Provides utility methods for converting column data types within the Excel infrastructure.
/// </summary>
public static class ColumnDataTypeConverter {

    /// <summary>
    /// Converts an <see cref="ExcelColumnDataType"/> to the corresponding <see cref="XLDataType"/>.
    /// </summary>
    /// <param name="dataType">The <see cref="ExcelColumnDataType"/> to convert.</param>
    /// <returns>
    /// The corresponding <see cref="XLDataType"/> value for the specified <paramref name="dataType"/>.
    /// If the <paramref name="dataType"/> is not recognized, <see cref="XLDataType.Blank"/> is returned.
    /// </returns>
    public static XLDataType ToClosedXmlDataType(ExcelColumnDataType dataType) {
        return dataType switch {
            ExcelColumnDataType.DateTime => XLDataType.DateTime,
            ExcelColumnDataType.Boolean => XLDataType.Boolean,
            ExcelColumnDataType.Error => XLDataType.Error,
            ExcelColumnDataType.TimeSpan => XLDataType.TimeSpan,
            ExcelColumnDataType.Number => XLDataType.Number,
            ExcelColumnDataType.Text => XLDataType.Text,
            _ => XLDataType.Blank
        };
    }
}