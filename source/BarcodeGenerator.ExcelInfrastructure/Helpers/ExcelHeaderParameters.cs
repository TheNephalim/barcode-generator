// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Represents the parameters required for configuring Excel headers in a workbook.
/// </summary>
/// <typeparam name="TAttribute">
/// The type of the attribute used to define header properties.
/// </typeparam>
/// <remarks>
/// This record is used to encapsulate the configuration details for adding headers to an Excel worksheet,
/// including workbook reference, worksheet number, header styles, and header attributes.
/// </remarks>
public record ExcelHeaderParameters<TAttribute> {
    /// <summary>
    /// Gets or sets the workbook associated with the Excel header parameters.
    /// </summary>
    /// <value>
    /// The workbook instance of type <see cref="IXLWorkbook"/>.
    /// </value>
    public required IXLWorkbook Workbook { get; set; }

    /// <summary>
    /// Gets or sets the worksheet number within the workbook.
    /// </summary>
    /// <value>
    /// The worksheet number to be used for operations within the workbook.
    /// </value>
    public int WorksheetNumber { get; set; }

    /// <summary>
    /// Gets or sets the starting row number for the header in the Excel worksheet.
    /// </summary>
    /// <value>
    /// The row number where the header starts.
    /// </value>
    public int HeaderRowStart { get; set; }

    /// <summary>
    /// Gets or sets the color of the label in the Excel header.
    /// </summary>
    /// <value>
    /// The color of the label, represented as an <see cref="XLColor"/>.
    /// </value>
    public XLColor LabelColor { get; set; } = XLColor.Gray;

    /// <summary>
    /// Gets or sets the height of the header row in the Excel worksheet.
    /// </summary>
    /// <value>
    /// The height of the header row, in points. The default value is 24.
    /// </value>
    public double HeaderRowHeight { get; set; } = 24D;

    /// <summary>
    /// Gets or sets the font size for the header cells in the Excel worksheet.
    /// </summary>
    /// <value>
    /// The font size to be used for the header cells. The default value is 12.
    /// </value>
    public double FontSize { get; set; } = 12D;

    /// <summary>
    /// Gets or sets the name of the font to be used for the header cells.
    /// </summary>
    /// <value>
    /// The name of the font as a string. Default is <see cref="FontNameConstants.TimesNewRoman"/>.
    /// </value>
    public string FontName { get; set; } = FontNameConstants.TimesNewRoman;

    /// <summary>
    /// Gets or sets the headers for the Excel worksheet.
    /// </summary>
    /// <value>
    /// An array of <typeparamref name="TAttribute"/> representing the headers.
    /// </value>
    public required TAttribute[] Headers { get; set; }
}