// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;
using System.Drawing;

// ReSharper disable ClassNeverInstantiated.Global

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Represents the parameters used for configuring ClosedXML-related settings,
/// such as font, colors, and row height, when working with Excel worksheets.
/// </summary>
public class ClosedXmlParameters {
    /// <summary>
    /// Gets or sets the color of the background.
    /// </summary>
    /// <value>The color of the background.</value>
    public Color BackgroundColor { get; set; } = Color.White;

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