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
public interface IWorkbookParameters<T> {
    /// <summary>
    /// Gets or sets the unique identifier for the application associated with the workbook.
    /// </summary>
    /// <value>
    /// The unique identifier for the application.
    /// </value>
    Guid ApplicationId { get; set; }

    /// <summary>
    /// Gets or sets the author.
    /// </summary>
    /// <value>The author.</value>
    string Author { get; set; }

    /// <summary>
    /// Gets or sets the company.
    /// </summary>
    /// <value>The company.</value>
    string Company { get; set; }

    /// <summary>
    /// Gets or sets the create date.
    /// </summary>
    /// <value>The create date.</value>
    DateTime CreateDate { get; set; }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    /// <value>The name of the file.</value>
    string FileName { get; set; }

    /// <summary>
    /// Gets or sets the spreadsheet data.
    /// </summary>
    /// <value>The spreadsheet data.</value>
    T? SpreadsheetData { get; set; }

    /// <summary>
    /// Gets or sets the subject.
    /// </summary>
    /// <value>The subject.</value>
    string Subject { get; set; }

    /// <summary>
    /// Gets or sets the worksheets properties.
    /// </summary>
    /// <value>The worksheets properties.</value>
    WorksheetProperties[] WorksheetsProperties { get; set; }
}