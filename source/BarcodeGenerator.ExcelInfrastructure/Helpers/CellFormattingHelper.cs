// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure.Exceptions;
using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Provides helper methods for formatting cells in Excel worksheets.
/// </summary>
/// <remarks>
/// This class implements the <see cref="ICellFormattingHelper"/> interface and provides functionality
/// to format label and value cells with specific styles, such as background color, font properties,
/// alignment, borders, and more.
/// </remarks>
/// <seealso cref="ICellFormattingHelper" />
public sealed class CellFormattingHelper : ICellFormattingHelper {
    private readonly ICellHelper _cellHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CellFormattingHelper"/> class.
    /// </summary>
    /// <param name="cellHelper">
    /// An implementation of the <see cref="ICellHelper"/> interface that provides methods
    /// for applying various styles and formatting to Excel cells. This parameter cannot be <c>null</c>.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="cellHelper"/> parameter is <c>null</c>.
    /// </exception>
    public CellFormattingHelper(ICellHelper cellHelper) {
        ArgumentNullException.ThrowIfNull(cellHelper);

        _cellHelper = cellHelper;
    }

    /// <summary>
    /// Formats the label cells in an Excel worksheet with specified styles and properties.
    /// </summary>
    /// <param name="parameters">
    /// The parameters containing the details for formatting the label cells, such as background color,
    /// font properties, alignment, borders, and dimensions.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="parameters"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="CellIsNullException">
    /// Thrown when the worksheet cell specified in <paramref name="parameters"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method applies various styles to the specified cell, including background color, font size,
    /// font name, font boldness, alignment, borders, and dimensions. It also sets the cell's value
    /// to the provided label text.
    /// </remarks>
    public void FormatLabelCells(ExcelCellLabelParameters parameters) {
        ArgumentNullException.ThrowIfNull(parameters);

        var cell = parameters.Worksheet?.Cell(parameters.RowNumber, parameters.ColumnNumber) ?? throw new CellIsNullException("Worksheet cell is null");

        cell = _cellHelper.ApplyBackgroundColor(cell, parameters.BackgroundColor);
        cell = _cellHelper.ApplyVerticalAlignment(cell, XLAlignmentVerticalValues.Center);
        cell = _cellHelper.ApplyTopBorderStyle(cell, XLColor.Black, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyLeftBorderStyle(cell, XLColor.Black, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyRightBorderStyle(cell, XLColor.Black, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyBottomBorderStyle(cell, XLColor.Black, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyIndent(cell, 2);
        cell = _cellHelper.ApplyFontBold(cell, true);
        cell = _cellHelper.ApplyWidth(cell, parameters.CellWidth);
        cell = _cellHelper.ApplyFontSize(cell, parameters.FontSize);
        cell = _cellHelper.ApplyFontName(cell, parameters.FontName);

        cell.Style.Font.FontColor = parameters.FontColor;
        cell.WorksheetRow().Height = parameters.RowHeight;

        cell.SetValue(parameters.LabelText);
    }

    /// <summary>
    /// Formats the value cells in an Excel worksheet with the specified parameters.
    /// </summary>
    /// <param name="parameters">
    /// The parameters used to configure the formatting of the value cells, including background color,
    /// font properties, alignment, borders, and other cell-specific settings.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="parameters"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="WorksheetCannotBeNullException">
    /// Thrown when the <see cref="ExcelCellValueParameters.Worksheet"/> property of <paramref name="parameters"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method applies a variety of formatting options to the specified cell, such as:
    /// <list type="bullet">
    /// <item>Setting background color.</item>
    /// <item>Applying borders (top, bottom, left, right).</item>
    /// <item>Adjusting alignment and indentation.</item>
    /// <item>Configuring font size, font name, and font color.</item>
    /// <item>Setting cell width and enabling text wrapping.</item>
    /// <item>Applying number or date formatting if applicable.</item>
    /// <item>Setting the cell value or formula.</item>
    /// </list>
    /// </remarks>
    public void FormatValueCells(ExcelCellValueParameters parameters) {
        ArgumentNullException.ThrowIfNull(parameters);

        if (parameters.Worksheet == null) {
            throw new WorksheetCannotBeNullException();
        }

        var cell = parameters.Worksheet.Cell(parameters.RowNumber, parameters.ColumnNumber);

        cell = _cellHelper.ApplyVerticalAlignment(cell, XLAlignmentVerticalValues.Center);
        cell = _cellHelper.ApplyBackgroundColor(cell, XLColor.FromColor(parameters.BackgroundColor));
        cell = _cellHelper.ApplyBottomBorderStyle(cell, XLColor.Amethyst, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyLeftBorderStyle(cell, XLColor.Amethyst, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyRightBorderStyle(cell, XLColor.Amethyst, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyTopBorderStyle(cell, XLColor.Amethyst, XLBorderStyleValues.Thin);
        cell = _cellHelper.ApplyIndent(cell, 2);
        cell = _cellHelper.ApplyWidth(cell, parameters.CellWidth);
        cell = _cellHelper.ApplyTextWrap(cell, true);
        cell = _cellHelper.ApplyFontSize(cell, parameters.FontSize);
        cell = _cellHelper.ApplyFontName(cell, parameters.FontName);

        cell.Style.Font.FontColor = parameters.FontColor;
        var dataType = ColumnDataTypeConverter.ToClosedXmlDataType(parameters.DataType);

        if (dataType == XLDataType.Number) {
            cell.FormulaA1 = parameters.FormulaA1;
        }

        if (dataType is XLDataType.DateTime or XLDataType.Number) {
            cell.Style.NumberFormat.Format = parameters.StringFormat;
        }

        cell.SetValue(XLCellValue.FromObject(parameters.Value));
    }
}