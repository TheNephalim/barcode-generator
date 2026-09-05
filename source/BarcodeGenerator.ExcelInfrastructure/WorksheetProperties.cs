// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Represents the properties of an Excel worksheet, including settings for freezing rows,
/// repeating rows, and worksheet title.
/// </summary>
public class WorksheetProperties {
    /// <summary>
    /// Gets or sets the row index to freeze in the worksheet.
    /// </summary>
    /// <value>
    /// The index of the row to freeze. A value of 0 or less indicates that no rows are frozen.
    /// </value>
    /// <remarks>
    /// Freezing a row ensures that it remains visible while scrolling through the worksheet.
    /// </remarks>
    public int FreezeRow { get; set; }

    /// <summary>
    /// Gets or sets the range of rows to repeat at the top of each printed page.
    /// </summary>
    /// <value>
    /// A <see cref="Tuple{T1, T2}"/> representing the start and end row indices to repeat,
    /// or <c>null</c> if no rows are set to repeat.
    /// </value>
    /// <remarks>
    /// This property is used in conjunction with <see cref="ShouldRepeatRows"/> to determine
    /// whether specific rows should be repeated on each printed page of the worksheet.
    /// </remarks>
    public Tuple<int, int>? RowsToRepeat { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether specific rows should be repeated
    /// at the top of each printed page of the worksheet.
    /// </summary>
    /// <value>
    /// <c>true</c> if rows specified in <see cref="RowsToRepeat"/> should be repeated;
    /// otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// This property works in conjunction with <see cref="RowsToRepeat"/> to define
    /// the behavior for repeating rows on printed pages.
    /// </remarks>
    public bool ShouldRepeatRows { get; set; }

    /// <summary>
    /// Gets or sets the title of the worksheet.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the title of the worksheet.
    /// This title is used when adding the worksheet to the workbook.
    /// </value>
    public string? WorksheetTitle { get; set; }
}