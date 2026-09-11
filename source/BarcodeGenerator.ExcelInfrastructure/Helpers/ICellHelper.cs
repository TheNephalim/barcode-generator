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
    /// Applies a background color to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the background color will be applied. Must not be <c>null</c>.</param>
    /// <param name="color">The background color to apply to the cell.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the applied background color.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="cell"/> is <c>null</c>.</exception>
    IXLCell ApplyBackgroundColor(IXLCell cell, XLColor color);

    /// <summary>
    /// Applies the bottom border style.
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="color">The color.</param>
    /// <param name="borderStyle">The border style.</param>
    /// <returns>ICellHelper.</returns>
    IXLCell ApplyBottomBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle);

    /// <summary>
    /// Applies the font bold.
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="isFontBold">if set to <c>true</c> [is font bold].</param>
    /// <returns>ICellHelper.</returns>
    IXLCell ApplyFontBold(IXLCell cell, bool isFontBold);

    /// <summary>
    /// Applies the name of the font.
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="fontName">Name of the font.</param>
    /// <returns>ICellHelper.</returns>
    IXLCell ApplyFontName(IXLCell cell, string fontName);

    /// <summary>
    /// Applies the size of the font.
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="fontSize">Size of the font.</param>
    /// <returns>ICellHelper.</returns>
    IXLCell ApplyFontSize(IXLCell cell, double fontSize);

    /// <summary>
    /// Applies the indent.
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="indent">The indent.</param>
    /// <returns>ICellHelper.</returns>
    IXLCell ApplyIndent(IXLCell cell, int indent);

    /// <summary>
    /// Applies a left border style to the specified cell.
    /// </summary>
    /// <param name="cell">The cell to which the left border style will be applied. Cannot be <c>null</c>.</param>
    /// <param name="color">The color of the left border.</param>
    /// <param name="borderStyle">The style of the left border.</param>
    /// <returns>The modified <see cref="IXLCell"/> with the applied left border style.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="cell"/> is <c>null</c>.</exception>
    IXLCell ApplyLeftBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle);

    /// <summary>
    /// Applies text wrapping to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which text wrapping will be applied. Must not be <c>null</c>.</param>
    /// <param name="cellTextShouldWrap">
    /// A boolean value indicating whether the text in the cell should wrap.
    /// Set to <c>true</c> to enable text wrapping; otherwise, <c>false</c>.
    /// </param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the applied text wrapping setting.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="cell"/> parameter is <c>null</c>.</exception>
    /// <remarks>
    /// This method adjusts the cell's alignment settings to enable or disable text wrapping based on the provided value.
    /// </remarks>
    IXLCell ApplyTextWrap(IXLCell cell, bool cellTextShouldWrap);

    /// <summary>
    /// Applies a top border style to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the top border style will be applied. Must not be <c>null</c>.</param>
    /// <param name="color">The color of the top border.</param>
    /// <param name="borderStyle">The style of the top border, as defined by <see cref="XLBorderStyleValues"/>.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the applied top border style.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="cell"/> parameter is <c>null</c>.</exception>
    /// <remarks>
    /// This method modifies the top border of the provided cell using the specified color and style.
    /// </remarks>
    IXLCell ApplyTopBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle);

    /// <summary>
    /// Applies the specified vertical alignment to the given Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the vertical alignment will be applied. Must not be <c>null</c>.</param>
    /// <param name="alignment">The vertical alignment to apply, as defined by <see cref="XLAlignmentVerticalValues"/>.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the applied vertical alignment.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="cell"/> parameter is <c>null</c>.</exception>
    /// <remarks>
    /// This method sets the vertical alignment of the provided cell to the specified value.
    /// </remarks>
    IXLCell ApplyVerticalAlignment(IXLCell cell, XLAlignmentVerticalValues alignment);

    /// <summary>
    /// Sets the width of the specified Excel cell's column.
    /// </summary>
    /// <param name="cell">The <see cref="IXLCell"/> whose column width is to be set. Cannot be <c>null</c>.</param>
    /// <param name="width">The desired width to apply to the column. Must be a positive value.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="cell"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="width"/> is less than or equal to zero.</exception>
    IXLCell ApplyWidth(IXLCell cell, double width);

    /// <summary>
    /// Applies a right border style to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the right border style will be applied. Must not be <c>null</c>.</param>
    /// <param name="color">The <see cref="XLColor"/> representing the color of the right border.</param>
    /// <param name="borderStyle">The <see cref="XLBorderStyleValues"/> representing the style of the right border.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the applied right border style.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="cell"/> is <c>null</c>.</exception>
    /// <remarks>
    /// This method sets the right border color and style for the provided Excel cell.
    /// </remarks>
    IXLCell ApplyRightBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle);
}