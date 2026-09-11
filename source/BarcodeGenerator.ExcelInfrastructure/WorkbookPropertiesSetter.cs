// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure.Exceptions;
using ClosedXML.Excel;
using System.ComponentModel;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

// ReSharper disable ClassNeverInstantiated.Global

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Provides functionality for setting properties of an Excel workbook, such as application ID, author, company, creation date, and more.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IWorkbookPropertiesSetter"/> interface and is responsible for configuring various workbook-level properties.
/// It also allows adding worksheets and setting their properties through the provided methods.
/// </remarks>
/// <seealso cref="IWorkbookPropertiesSetter" />
public sealed class WorkbookPropertiesSetter : IWorkbookPropertiesSetter {
    private readonly IWorksheetPropertiesSetter _worksheetPropertiesSetter;

    private string _author = "";
    private string _company = "";
    private string _reportName;
    private IXLWorkbook _workbook;
    private DateTime _workbookCreateDate;
    private WorksheetProperties[] _worksheetsProperties = [
        new() {
            FreezeRow = 1,
            RowsToRepeat = Tuple.Create(1,1),
            ShouldRepeatRows = true,
            WorksheetTitle = "Worksheet Title"
        }
    ];

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkbookPropertiesSetter"/> class.
    /// </summary>
    /// <param name="worksheetPropertiesSetter">
    /// An implementation of the <see cref="IWorksheetPropertiesSetter"/> interface,
    /// responsible for setting properties of individual worksheets within the workbook.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="worksheetPropertiesSetter"/> is <c>null</c>.
    /// </exception>
    public WorkbookPropertiesSetter(IWorksheetPropertiesSetter worksheetPropertiesSetter) {
        _worksheetPropertiesSetter = worksheetPropertiesSetter ?? throw new ArgumentNullException(nameof(worksheetPropertiesSetter));
        _workbook = new XLWorkbook();
    }

    /// <summary>
    /// Adds an author to the workbook properties.
    /// </summary>
    /// <param name="author">The name of the author to be added. Must not be null, empty, or whitespace.</param>
    /// <returns>The current instance of <see cref="WorkbookPropertiesSetter"/> to allow method chaining.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="author"/> is null, empty, or consists only of whitespace.
    /// </exception>
    public WorkbookPropertiesSetter AddAuthor(string author) {
        ArgumentException.ThrowIfNullOrEmpty(author);
        ArgumentException.ThrowIfNullOrWhiteSpace(author);

        _author = author;

        return this;
    }

    /// <summary>
    /// Sets the company name for the workbook properties.
    /// </summary>
    /// <param name="company">The name of the company to set. Must not be null, empty, or whitespace.</param>
    /// <returns>The current instance of <see cref="WorkbookPropertiesSetter"/> to allow method chaining.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="company"/> is null, empty, or consists only of whitespace.</exception>
    public WorkbookPropertiesSetter AddCompany(string company) {
        ArgumentException.ThrowIfNullOrEmpty(company);
        ArgumentException.ThrowIfNullOrWhiteSpace(company);

        _company = company;

        return this;
    }

    /// <summary>
    /// Sets the creation date for the workbook.
    /// </summary>
    /// <param name="workbookCreationDate">The date when the workbook was created.</param>
    /// <returns>The current instance of <see cref="WorkbookPropertiesSetter"/> to allow method chaining.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="workbookCreationDate"/> is the default value.</exception>
    public WorkbookPropertiesSetter AddDate(DateTime workbookCreationDate) {
        if (workbookCreationDate == default) {
            throw new ArgumentException("Cannot be default value", nameof(workbookCreationDate));
        }
        _workbookCreateDate = workbookCreationDate;
        return this;
    }

    /// <summary>
    /// Adds the report name to the workbook properties.
    /// </summary>
    /// <param name="reportName">The report name to be added.</param>
    /// <returns>The current instance of <see cref="WorkbookPropertiesSetter"/>.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when <paramref name="reportName"/> is <see cref="string.None"/>.</exception>
    public WorkbookPropertiesSetter AddReportName(string reportName) {
        if (string.IsNullOrWhiteSpace(reportName)) {
            throw new InvalidEnumArgumentException("reportName cannot be None");
        }

        _reportName = reportName;

        return this;
    }

    /// <summary>
    /// Adds an existing workbook to the current instance of <see cref="WorkbookPropertiesSetter"/>.
    /// </summary>
    /// <param name="workbook">The workbook to be added. Must not be <c>null</c>.</param>
    /// <returns>The current instance of <see cref="WorkbookPropertiesSetter"/> to allow method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="workbook"/> is <c>null</c>.</exception>
    public WorkbookPropertiesSetter AddWorkbook(IXLWorkbook workbook) {
        ArgumentNullException.ThrowIfNull(workbook);

        _workbook = workbook;

        return this;
    }

    /// <summary>
    /// Adds a worksheet to the workbook with the specified properties.
    /// </summary>
    /// <param name="worksheetProperties">
    /// The properties of the worksheet to be added, including settings such as freezing rows,
    /// repeating rows, and the worksheet title.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="WorkbookPropertiesSetter"/>, allowing for method chaining.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="worksheetProperties"/> is <c>null</c>.
    /// </exception>
    public WorkbookPropertiesSetter AddWorksheet(WorksheetProperties worksheetProperties) {
        ArgumentNullException.ThrowIfNull(worksheetProperties);

        _worksheetsProperties = [worksheetProperties];

        return this;
    }

    /// <summary>
    /// Adds multiple worksheets to the workbook with the specified properties.
    /// </summary>
    /// <param name="worksheetProperties">
    /// An array of <see cref="WorksheetProperties"/> objects that define the properties of each worksheet to be added.
    /// </param>
    /// <returns>
    /// The current instance of <see cref="WorkbookPropertiesSetter"/>, allowing for method chaining.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="worksheetProperties"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="worksheetProperties"/> is an empty array.
    /// </exception>
    public WorkbookPropertiesSetter AddWorksheet(WorksheetProperties[] worksheetProperties) {
        ArgumentNullException.ThrowIfNull(worksheetProperties);
        ArgumentOutOfRangeException.ThrowIfEqual(0, worksheetProperties.Length);

        _worksheetsProperties = worksheetProperties;

        return this;
    }

    /// <summary>
    /// Configures and returns the workbook with the specified properties.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="XLWorkbook"/> with the configured properties.
    /// </returns>
    /// <exception cref="WorkbookCannotBeNullException">
    /// Thrown when the workbook instance is null.
    /// </exception>
    public XLWorkbook Set() {
        if (_workbook == null) {
            throw new WorkbookCannotBeNullException();
        }

        SetAuthor();
        AddWorksheet();
        AddHeadersAndFooters();
        SetCreationDate();
        SetCompany();

        return _workbook as XLWorkbook ?? new XLWorkbook();
    }

    /// <summary>
    /// Adds headers and footers to all worksheets in the workbook.
    /// </summary>
    /// <remarks>
    /// This method iterates through all worksheets in the workbook and applies headers and footers
    /// using the <see cref="IWorksheetPropertiesSetter"/> implementation. The headers and footers
    /// are configured based on the report name and worksheet properties.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the workbook contains no worksheets.
    /// </exception>
    private void AddHeadersAndFooters() {
        if (_workbook.Worksheets.Count < 0) return;

        for (var i = 1; i <= _workbook.Worksheets.Count; i++) {
            _worksheetPropertiesSetter.Set(_workbook.Worksheet(i), _reportName,
                _worksheetsProperties[i - 1]);
        }
    }

    /// <summary>
    /// Adds worksheets to the workbook based on the predefined worksheet properties.
    /// </summary>
    /// <remarks>
    /// This method iterates through the collection of worksheet properties and adds a worksheet
    /// to the workbook for each entry. The title of each worksheet is set according to the
    /// <see cref="WorksheetProperties.WorksheetTitle"/> property.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the workbook instance is <c>null</c>.
    /// </exception>
    private void AddWorksheet() {
        foreach (var worksheetParameter in _worksheetsProperties) {
            _workbook?.AddWorksheet(worksheetParameter.WorksheetTitle);
        }
    }

    /// <summary>
    /// Sets the author property of the workbook to the specified value.
    /// </summary>
    /// <remarks>
    /// This method assigns the value of the private <c>_author</c> field to the <c>Author</c> property
    /// of the workbook's metadata. The value of <c>_author</c> must be set prior to calling this method.
    /// </remarks>
    private void SetAuthor() {
        _workbook.Properties.Author = _author;
    }

    /// <summary>
    /// Sets the company property of the workbook to the specified value.
    /// </summary>
    /// <remarks>
    /// This method updates the <see cref="IXLWorkbook.Properties.Company"/> property
    /// with the value stored in the <c>_company</c> field.
    /// </remarks>
    private void SetCompany() {
        _workbook.Properties.Company = _company;
    }

    /// <summary>
    /// Sets the creation date of the workbook to the specified date.
    /// </summary>
    /// <remarks>
    /// This method assigns the value of the private field <c>_workbookCreateDate</c>
    /// to the <see cref="IXLWorkbook.Properties.Created"/> property of the workbook.
    /// </remarks>
    private void SetCreationDate() {
        _workbook.Properties.Created = _workbookCreateDate;
    }
}