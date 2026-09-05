// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Interface ICellHelper
/// </summary>
public interface ICellHelper {

    /// <summary>
    /// Applies the color of the background.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyBackgroundColor(XLColor color);

    /// <summary>
    /// Applies the bottom border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyBottomBorderStyle(XLColor color, XLBorderStyleValues borderStyle);

    /// <summary>
    /// Applies the font bold.
    /// </summary>
    /// <param name="isFontBold">if set to <c>true</c> [is font bold].</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyFontBold(bool isFontBold);

    /// <summary>
    /// Applies the name of the font.
    /// </summary>
    /// <param name="fontName">Name of the font.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyFontName(string fontName);

    /// <summary>
    /// Applies the size of the font.
    /// </summary>
    /// <param name="fontSize">Size of the font.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyFontSize(double fontSize);

    /// <summary>
    /// Applies the indent.
    /// </summary>
    /// <param name="indent">The indent.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyIndent(int indent);

    /// <summary>
    /// Applies the left border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyLeftBorderStyle(XLColor color, XLBorderStyleValues borderStyle);

    /// <summary>
    /// Applies the right border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyRightBorderStyle(XLColor color, XLBorderStyleValues borderStyle);

    /// <summary>
    /// Applies the text wrap.
    /// </summary>
    /// <param name="cellTextShouldWrap">if set to <c>true</c> [cell text should wrap].</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyTextWrap(bool cellTextShouldWrap);

    /// <summary>
    /// Applies the top border style.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyTopBorderStyle(XLColor color, XLBorderStyleValues borderStyle);

    /// <summary>
    /// Applies the vertical alignment.
    /// </summary>
    /// <param name="alignment">The alignment.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyVerticalAlignment(XLAlignmentVerticalValues alignment);

    /// <summary>
    /// Applies the width.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper ApplyWidth(double width);

    /// <summary>
    /// Formats this instance.
    /// </summary>
    /// <returns>IXLCell.</returns>
    IXLCell? Format();

    /// <summary>
    /// Formats the cell.
    /// </summary>
    /// <param name="cell">The cell.</param>
    /// <returns>ICellHelper.</returns>
    ICellHelper FormatCell(IXLCell cell);
}