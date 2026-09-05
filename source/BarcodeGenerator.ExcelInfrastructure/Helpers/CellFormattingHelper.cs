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
public class CellFormattingHelper : ICellFormattingHelper {
    private readonly ICellHelper _cellHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CellFormattingHelper" /> class.
    /// </summary>
    /// <param name="cellHelper">The cell helper.</param>
    public CellFormattingHelper(ICellHelper cellHelper) {
        ArgumentNullException.ThrowIfNull(cellHelper);

        _cellHelper = cellHelper;
    }

    /// <summary>
    /// Formats the contract header cells.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    public void FormatLabelCells(ExcelCellLabelParameters parameters) {
        ArgumentNullException.ThrowIfNull(parameters);

        var cell = parameters.Worksheet?.Cell(parameters.RowNumber, parameters.ColumnNumber) ?? throw new CellIsNullException("Worksheet cell is null");

        cell = _cellHelper
            .FormatCell(cell)
            .ApplyBackgroundColor(parameters.BackgroundColor)
            .ApplyVerticalAlignment(XLAlignmentVerticalValues.Center)
            .ApplyTopBorderStyle(XLColor.Black, XLBorderStyleValues.Thin)
            .ApplyLeftBorderStyle(XLColor.Black, XLBorderStyleValues.Thin)
            .ApplyRightBorderStyle(XLColor.Black, XLBorderStyleValues.Thin)
            .ApplyBottomBorderStyle(XLColor.Black, XLBorderStyleValues.Thin)
            .ApplyIndent(2)
            .ApplyFontBold(true)
            .ApplyWidth(parameters.CellWidth)
            .ApplyFontSize(parameters.FontSize)
            .ApplyFontName(parameters.FontName)
            .Format();

        if (cell == null) return;

        cell.Style.Font.FontColor = parameters.FontColor;
        cell.WorksheetRow().Height = parameters.RowHeight;

        cell.SetValue(parameters.LabelText);
    }

    /// <summary>
    /// Formats the value cells.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    public void FormatValueCells(ExcelCellValueParameters parameters) {
        ArgumentNullException.ThrowIfNull(parameters);

        if (parameters.Worksheet == null) {
            throw new WorksheetCannotBeNullException();
        }

        var cell = parameters.Worksheet.Cell(parameters.RowNumber, parameters.ColumnNumber);

        cell = _cellHelper
            .FormatCell(cell)
            .ApplyVerticalAlignment(XLAlignmentVerticalValues.Center)
            .ApplyBackgroundColor(XLColor.FromColor(parameters.BackgroundColor))
            .ApplyBottomBorderStyle(XLColor.Amethyst, XLBorderStyleValues.Thin)
            .ApplyLeftBorderStyle(XLColor.Amethyst, XLBorderStyleValues.Thin)
            .ApplyRightBorderStyle(XLColor.Amethyst, XLBorderStyleValues.Thin)
            .ApplyTopBorderStyle(XLColor.Amethyst, XLBorderStyleValues.Thin)
            .ApplyIndent(2)
            .ApplyWidth(parameters.CellWidth)
            .ApplyTextWrap(true)
            .ApplyFontSize(parameters.FontSize)
            .ApplyFontName(parameters.FontName)
            .Format();

        if (cell == null) return;

        cell.Style.Font.FontColor = parameters.FontColor;

        if (parameters.DataType == XLDataType.Number) {
            cell.FormulaA1 = parameters.FormulaA1;
        }

        if (parameters.DataType is XLDataType.DateTime or XLDataType.Number) {
            cell.Style.NumberFormat.Format = parameters.StringFormat;
        }

        cell.Value = parameters.Value != null ? XLCellValue.FromObject(parameters.Value) : Blank.Value;
    }
}