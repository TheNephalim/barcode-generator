// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Represents the parameters required for formatting and labeling an Excel cell.
/// </summary>
public record ExcelCellLabelParameters {
    /// <summary>
    /// Gets or sets the color of the background.
    /// </summary>
    /// <value>The color of the background.</value>
    public required XLColor BackgroundColor { get; set; }

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
    /// Gets or sets the color of the font.
    /// </summary>
    /// <value>The color of the font.</value>
    public XLColor FontColor { get; set; } = XLColor.Black;

    /// <summary>
    /// Gets or sets the name of the font.
    /// </summary>
    /// <value>The name of the font.</value>
    public string FontName { get; set; } = FontNameConstants.TimesNewRoman;

    /// <summary>
    /// Gets or sets the label text.
    /// </summary>
    /// <value>The label text.</value>
    public string LabelText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the row number.
    /// </summary>
    /// <value>The row number.</value>
    public int RowNumber { get; set; }

    /// <summary>
    /// Gets or sets the worksheet.
    /// </summary>
    /// <value>The worksheet.</value>
    public IXLWorksheet? Worksheet { get; set; }

    /// <summary>
    /// Gets or sets the size of the font.
    /// </summary>
    /// <value>The size of the font.</value>
    public double FontSize { get; set; } = 12D;

    /// <summary>
    /// Gets or sets the height of the row.
    /// </summary>
    /// <value>The height of the row.</value>
    public double RowHeight { get; set; } = 24D;
}