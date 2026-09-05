// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;
using System.Drawing;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Represents the parameters required for configuring and formatting an Excel cell.
/// </summary>
/// <remarks>
/// This class provides properties to define various aspects of an Excel cell, such as its value,
/// formatting, dimensions, and position within a worksheet. It is used in conjunction with helpers
/// to apply consistent formatting and data representation in Excel sheets.
/// </remarks>
public class ExcelCellValueParameters {
    /// <summary>
    /// Gets or sets the color of the background.
    /// </summary>
    /// <value>The color of the background.</value>
    public Color BackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the width of the cell.
    /// </summary>
    /// <value>The width of the cell.</value>
    public double CellWidth { get; set; }

    /// <summary>
    /// Gets or sets the column number.
    /// </summary>
    /// <value>The column number.</value>
    public int ColumnNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the data.
    /// </summary>
    /// <value>The type of the data.</value>
    public XLDataType DataType { get; set; }

    /// <summary>
    /// Gets or sets the color of the font.
    /// </summary>
    /// <value>The color of the font.</value>
    public XLColor? FontColor { get; set; } = XLColor.Black;

    /// <summary>
    /// Gets or sets the name of the font.
    /// </summary>
    /// <value>The name of the font.</value>
    public string FontName { get; set; } = FontNameConstants.TimesNewRoman;

    /// <summary>
    /// Gets or sets the size of the font.
    /// </summary>
    /// <value>The size of the font.</value>
    public double FontSize { get; set; } = 12D;

    /// <summary>
    /// Gets or sets the formula a1.
    /// </summary>
    /// <value>The formula a1.</value>
    public string? FormulaA1 { get; set; }

    /// <summary>
    /// Gets or sets the previous cell address.
    /// </summary>
    /// <value>The previous cell address.</value>
    public IXLAddress? PreviousCellAddress { get; set; }

    /// <summary>
    /// Gets or sets the row number.
    /// </summary>
    /// <value>The row number.</value>
    public int RowNumber { get; set; }

    /// <summary>
    /// Gets or sets the string format.
    /// </summary>
    /// <value>The string format.</value>
    public string StringFormat { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    public object? Value { get; set; }

    /// <summary>
    /// Gets or sets the worksheet.
    /// </summary>
    /// <value>The worksheet.</value>
    public IXLWorksheet? Worksheet { get; set; }
}