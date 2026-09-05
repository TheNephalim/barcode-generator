// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Represents a set of parameters required for generating an Excel workbook.
/// </summary>
/// <typeparam name="T">The type of the data associated with the workbook.</typeparam>
/// <remarks>
/// This class provides properties to define metadata and content for an Excel workbook,
/// including author information, company details, creation date, file name, subject,
/// and worksheet-specific properties.
/// </remarks>
public class WorkbookParameters<T> : IWorkbookParameters<T> {
    /// <summary>
    /// Gets or sets the unique identifier for the application associated with the workbook.
    /// </summary>
    /// <value>
    /// The unique identifier for the application.
    /// </value>
    public Guid ApplicationId { get; set; }

    /// <summary>
    /// Gets or sets the author.
    /// </summary>
    /// <value>The author.</value>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the company.
    /// </summary>
    /// <value>The company.</value>
    public string Company { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the workbook was created.
    /// </summary>
    /// <value>
    /// The creation date of the workbook.
    /// </value>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    /// <value>The name of the file.</value>
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the spreadsheet data.
    /// </summary>
    /// <value>The spreadsheet data.</value>
    public T? SpreadsheetData { get; set; } = default(T);

    /// <summary>
    /// Gets or sets the subject.
    /// </summary>
    /// <value>The subject.</value>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the worksheets properties.
    /// </summary>
    /// <value>The worksheets properties.</value>
    public WorksheetProperties[] WorksheetsProperties { get; set; } = [];
}