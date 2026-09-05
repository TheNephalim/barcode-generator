// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Provides helper methods for formatting and styling Excel cells using the ClosedXML library.
/// </summary>
/// <remarks>
/// This class implements the <see cref="ICellHelper"/> interface and offers various methods
/// to apply styles, borders, alignment, and other formatting options to Excel cells.
/// </remarks>
public class CellHelper : ICellHelper {
    private IXLCell? _cell;

    /// <summary>
    /// Applies the color of the background.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyBackgroundColor(XLColor color) {
        if (_cell != null) _cell.Style.Fill.BackgroundColor = color;

        return this;
    }

    /// <summary>
    /// Applies the bottom border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyBottomBorderStyle(XLColor color, XLBorderStyleValues borderStyle) {
        if (_cell == null) return this;
        _cell.Style.Border.BottomBorderColor = color;
        _cell.Style.Border.BottomBorder = borderStyle;

        return this;
    }

    /// <summary>
    /// Applies the font bold.
    /// </summary>
    /// <param name="isFontBold">if set to <c>true</c> [is font bold].</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyFontBold(bool isFontBold) {
        if (_cell != null) _cell.Style.Font.Bold = isFontBold;

        return this;
    }

    /// <summary>
    /// Applies the name of the font.
    /// </summary>
    /// <param name="fontName">Name of the font.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyFontName(string fontName) {
        if (_cell != null) _cell.Style.Font.FontName = fontName;

        return this;
    }

    /// <summary>
    /// Applies the size of the font.
    /// </summary>
    /// <param name="fontSize">Size of the font.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyFontSize(double fontSize) {
        if (_cell != null) _cell.Style.Font.FontSize = fontSize;

        return this;
    }

    /// <summary>
    /// Applies the indent.
    /// </summary>
    /// <param name="indent">The indent.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyIndent(int indent) {
        if (_cell != null) _cell.Style.Alignment.Indent = indent;

        return this;
    }

    /// <summary>
    /// Applies the left border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyLeftBorderStyle(XLColor color, XLBorderStyleValues borderStyle) {
        if (_cell == null) return this;

        _cell.Style.Border.LeftBorderColor = color;
        _cell.Style.Border.LeftBorder = borderStyle;

        return this;
    }

    /// <summary>
    /// Applies the right border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyRightBorderStyle(XLColor color, XLBorderStyleValues borderStyle) {
        if (_cell == null) return this;

        _cell.Style.Border.RightBorderColor = color;
        _cell.Style.Border.RightBorder = borderStyle;

        return this;
    }

    /// <summary>
    /// Applies the text wrap.
    /// </summary>
    /// <param name="cellTextShouldWrap">if set to <c>true</c> [cell text should wrap].</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyTextWrap(bool cellTextShouldWrap) {
        if (_cell != null) _cell.Style.Alignment.WrapText = cellTextShouldWrap;

        return this;
    }

    /// <summary>
    /// Applies the top border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyTopBorderStyle(XLColor color, XLBorderStyleValues borderStyle) {
        if (_cell == null) return this;

        _cell.Style.Border.TopBorderColor = color;
        _cell.Style.Border.TopBorder = borderStyle;

        return this;
    }

    /// <summary>
    /// Applies the vertical alignment.
    /// </summary>
    /// <param name="alignment">The alignment.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyVerticalAlignment(XLAlignmentVerticalValues alignment) {
        if (_cell != null) _cell.Style.Alignment.Vertical = alignment;

        return this;
    }

    /// <summary>
    /// Applies the width.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper ApplyWidth(double width) {
        if (_cell == null) return this;

        _cell
            .WorksheetColumn()
            .Width = width;

        return this;
    }

    /// <summary>
    /// Formats this instance.
    /// </summary>
    /// <returns>IXLCell.</returns>
    public IXLCell? Format() {
        return _cell;
    }

    /// <summary>
    /// Formats the cell.
    /// </summary>
    /// <param name="cell">The cell.</param>
    /// <returns>ICellHelper.</returns>
    public ICellHelper FormatCell(IXLCell? cell) {
        if (cell == null) return this;

        _cell = cell;
        return this;
    }
}