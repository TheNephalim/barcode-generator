// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Provides a collection of constant values representing commonly used font names.
/// </summary>
/// <remarks>
/// This static class serves as a centralized repository for font name constants, ensuring consistency
/// across the application when specifying font names. These constants are utilized in various classes
/// and components, such as <see cref="ExcelCellValueParameters"/>, <see cref="ClosedXmlParameters"/>,
/// <see cref="ExcelCellLabelParameters"/>, and <see cref="ExcelHeaderParameters{TAttribute}"/>, to
/// define font-related properties.
/// </remarks>
public static class FontNameConstants {
    /// <summary>
    /// The arial
    /// </summary>
    public const string Arial = "Arial";

    /// <summary>
    /// The calibri
    /// </summary>
    public const string Calibri = "Calibri";

    /// <summary>
    /// The courier new
    /// </summary>
    public const string CourierNew = "Courier New";

    /// <summary>
    /// The times new roman
    /// </summary>
    public const string TimesNewRoman = "Times New Roman";
}