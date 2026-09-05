// ***********************************************************************
// Assembly         : BarcodeGenerator.Common
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************
namespace BarcodeGenerator.ExcelInfrastructure.Enumerations;

/// <summary>
/// Provides a collection of predefined style formats for use in Excel-related operations.
/// </summary>
/// <remarks>
/// This class contains constants representing various formatting styles, such as currency, date, and integer formats.
/// These formats can be used to standardize the appearance of data in Excel sheets.
/// </remarks>
public static class StyleFormat {
    /// <summary>
    /// Gets the currency format.
    /// </summary>
    /// <value>The currency format.</value>
    public const string CurrencyFormat = "[$$-409]#,##0.00;[RED]-[$$-409]#,##0.00";

    /// <summary>
    /// Gets the date format.
    /// </summary>
    /// <value>The date format.</value>
    public const string DateFormat = "dd-mmm-yy";

    /// <summary>
    /// The date format mm/dd/yyyy
    /// </summary>
    public const string DateFormatSlash = "mm/dd/yyyy";

    /// <summary>
    /// The empty format
    /// </summary>
    public const string EmptyFormat = "";

    /// <summary>
    /// The integer format
    /// </summary>
    public const string IntegerFormat = "#,##0";

    /// <summary>
    /// The integer percent
    /// </summary>
    public const string IntegerPercent = "0%";

    /// <summary>
    /// The number display as is
    /// </summary>
    public const string NumberDisplayAsIs = "0";
}