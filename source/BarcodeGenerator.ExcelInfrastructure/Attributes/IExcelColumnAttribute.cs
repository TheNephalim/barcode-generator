// ***********************************************************************
// Assembly         : BarcodeGenerator.Common
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Attributes;

/// <summary>
/// Interface IExcelColumnAttribute
/// </summary>
public interface IExcelColumnAttribute {
    /// <summary>
    /// Gets the column order.
    /// </summary>
    /// <value>The column order.</value>
    int ColumnOrder { get; }

    /// <summary>
    /// The width of the Excel column in points.
    /// </summary>
    /// <value>The width of the Excel column.</value>
    double ColumnWidth { get; }

    /// <summary>
    /// Gets the display text.
    /// </summary>
    /// <value>The display text.</value>
    string DisplayText { get; }

    /// <summary>
    /// Gets the type of the excel data.
    /// </summary>
    /// <value>The type of the excel data.</value>
    XLDataType ExcelDataType { get; }

    /// <summary>
    /// Gets the format style.
    /// </summary>
    /// <value>The format style.</value>
    string FormatStyle { get; }

    /// <summary>
    /// Gets the name of the property.
    /// </summary>
    /// <value>The name of the property.</value>
    string PropertyName { get; }
}