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
public sealed class CellHelper : ICellHelper {

    /// <summary>
    /// Applies a background color to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the background color will be applied.</param>
    /// <param name="color">The <see cref="XLColor"/> representing the background color to apply.</param>
    /// <returns>An instance of <see cref="ICellHelper"/> to allow method chaining.</returns>
    /// <remarks>
    /// This method modifies the background color of the provided cell using the specified color.
    /// </remarks>
    public IXLCell ApplyBackgroundColor(IXLCell cell, XLColor color) {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Fill.BackgroundColor = color;

        return cell;
    }

    /// <summary>
    /// Applies a bottom border style to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the bottom border style will be applied. Must not be <c>null</c>.</param>
    /// <param name="color">The color of the bottom border.</param>
    /// <param name="borderStyle">The style of the bottom border, as defined by <see cref="XLBorderStyleValues"/>.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the applied bottom border style.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="cell"/> parameter is <c>null</c>.</exception>
    public IXLCell ApplyBottomBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle) {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Border.BottomBorderColor = color;
        cell.Style.Border.BottomBorder = borderStyle;

        return cell;
    }

    /// <summary>
    /// Sets the font bold style for the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the font bold style will be applied.</param>
    /// <param name="isFontBold">
    /// A boolean value indicating whether the font should be bold.
    /// Pass <c>true</c> to apply bold styling; otherwise, <c>false</c>.
    /// </param>
    /// <returns>
    /// The modified <see cref="IXLCell"/> instance with the updated font bold style.
    /// </returns>
    public IXLCell ApplyFontBold(IXLCell cell, bool isFontBold) {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Font.Bold = isFontBold;

        return cell;
    }

    /// <summary>
    /// Sets the font name for the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the font name will be applied. Must not be <c>null</c>.</param>
    /// <param name="fontName">The name of the font to apply to the cell.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the updated font name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="cell"/> is <c>null</c>.</exception>
    public IXLCell ApplyFontName(IXLCell cell, string fontName) {
        ArgumentNullException.ThrowIfNull(cell);
        cell.Style.Font.FontName = fontName;

        return cell;
    }

    /// <summary>
    /// Sets the font size for the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the font size will be applied. Cannot be <c>null</c>.</param>
    /// <param name="fontSize">The font size to apply to the cell.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the updated font size.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="cell"/> parameter is <c>null</c>.</exception>
    public IXLCell ApplyFontSize(IXLCell cell, double fontSize) {
        ArgumentNullException.ThrowIfNull(cell);
        cell.Style.Font.FontSize = fontSize;

        return cell;
    }

    /// <summary>
    /// Applies an indentation level to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the indentation will be applied. Must not be <c>null</c>.</param>
    /// <param name="indent">The level of indentation to apply. A non-negative integer value.</param>
    /// <returns>The modified <see cref="IXLCell"/> with the applied indentation.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="cell"/> parameter is <c>null</c>.</exception>
    public IXLCell ApplyIndent(IXLCell cell, int indent) {
        ArgumentNullException.ThrowIfNull(cell);
        cell.Style.Alignment.Indent = indent;

        return cell;
    }

    /// <summary>
    /// Applies a left border style to the specified cell.
    /// </summary>
    /// <param name="cell">The cell to which the left border style will be applied. Cannot be <c>null</c>.</param>
    /// <param name="color">The color of the left border.</param>
    /// <param name="borderStyle">The style of the left border.</param>
    /// <returns>The modified <see cref="IXLCell"/> with the applied left border style.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="cell"/> is <c>null</c>.</exception>
    public IXLCell ApplyLeftBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle) {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Border.LeftBorderColor = color;
        cell.Style.Border.LeftBorder = borderStyle;

        return cell;
    }

    /// <summary>
    /// Applies a right border style to the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell to which the right border style will be applied.</param>
    /// <param name="color">The <see cref="XLColor"/> representing the color of the right border.</param>
    /// <param name="borderStyle">The <see cref="XLBorderStyleValues"/> representing the style of the right border.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the applied right border style.</returns>
    /// <remarks>
    /// This method sets the right border color and style for the provided Excel cell.
    /// </remarks>
    public IXLCell ApplyRightBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle) {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Border.RightBorderColor = color;
        cell.Style.Border.RightBorder = borderStyle;

        return cell;
    }

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
    public IXLCell ApplyTextWrap(IXLCell cell, bool cellTextShouldWrap) {
        ArgumentNullException.ThrowIfNull(cell);
        cell.Style.Alignment.WrapText = cellTextShouldWrap;

        return cell;
    }

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
    public IXLCell ApplyTopBorderStyle(IXLCell cell, XLColor color, XLBorderStyleValues borderStyle) {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Border.TopBorderColor = color;
        cell.Style.Border.TopBorder = borderStyle;

        return cell;
    }

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
    public IXLCell ApplyVerticalAlignment(IXLCell cell, XLAlignmentVerticalValues alignment) {
        ArgumentNullException.ThrowIfNull(cell);

        cell.Style.Alignment.Vertical = alignment;

        return cell;
    }

    /// <summary>
    /// Sets the width of the column containing the specified Excel cell.
    /// </summary>
    /// <param name="cell">The Excel cell whose column width will be adjusted. Must not be <c>null</c>.</param>
    /// <param name="width">The desired width of the column.</param>
    /// <returns>The modified <see cref="IXLCell"/> instance with the updated column width.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="cell"/> parameter is <c>null</c>.</exception>
    /// <remarks>
    /// This method adjusts the width of the entire column that contains the specified cell.
    /// </remarks>
    public IXLCell ApplyWidth(IXLCell cell, double width) {
        ArgumentNullException.ThrowIfNull(cell);

        cell
            .WorksheetColumn()
            .Width = width;

        return cell;
    }
}