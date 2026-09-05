// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure.Exceptions;
using ClosedXML.Excel;
using System.ComponentModel;

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
public class WorkbookPropertiesSetter : IWorkbookPropertiesSetter {
    /// <summary>
    /// The worksheet properties setter
    /// </summary>
    private readonly IWorksheetPropertiesSetter _worksheetPropertiesSetter;

    private Guid _applicationId;
    /// <summary>
    /// The author
    /// </summary>
    private string _author = "";

    /// <summary>
    /// The company
    /// </summary>
    private string _company = "";

    /// <summary>
    /// The application identifier
    /// </summary>
    private string _reportName;

    /// <summary>
    /// The workbook
    /// </summary>
    private IXLWorkbook _workbook;

    /// <summary>
    /// The workbook create date
    /// </summary>
    private DateTime _workbookCreateDate;

    /// <summary>
    /// The worksheet parameters
    /// </summary>
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
    /// <param name="worksheetPropertiesSetter">The worksheet properties setter.</param>
    public WorkbookPropertiesSetter(IWorksheetPropertiesSetter worksheetPropertiesSetter) {
        _worksheetPropertiesSetter = worksheetPropertiesSetter ?? throw new ArgumentNullException(nameof(worksheetPropertiesSetter));
        _workbook = new XLWorkbook();
    }

    /// <summary>
    /// Adds the application identifier.
    /// </summary>
    /// <param name="applicationId">The application identifier.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    public WorkbookPropertiesSetter AddApplicationId(Guid applicationId) {
        if (applicationId == Guid.Empty) {
            throw new ArgumentException("reportId cannot be empty guid", nameof(applicationId));
        }

        _applicationId = applicationId;

        return this;
    }

    /// <summary>
    /// Adds the author.
    /// </summary>
    /// <param name="author">The author.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    public WorkbookPropertiesSetter AddAuthor(string author) {
        ArgumentException.ThrowIfNullOrEmpty(author);
        ArgumentException.ThrowIfNullOrWhiteSpace(author);

        _author = author;

        return this;
    }

    /// <summary>
    /// Adds the company.
    /// </summary>
    /// <param name="company">The company.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    public WorkbookPropertiesSetter AddCompany(string company) {
        ArgumentException.ThrowIfNullOrEmpty(company);
        ArgumentException.ThrowIfNullOrWhiteSpace(company);

        _company = company;

        return this;
    }

    /// <summary>
    /// Adds the date.
    /// </summary>
    /// <param name="workbookCreationDate">The workbook creation date.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
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
    /// Adds the workbook.
    /// </summary>
    /// <param name="workbook">The workbook.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    public WorkbookPropertiesSetter AddWorkbook(IXLWorkbook workbook) {
        ArgumentNullException.ThrowIfNull(workbook);

        _workbook = workbook;

        return this;
    }

    /// <summary>
    /// Adds the worksheet.
    /// </summary>
    /// <param name="worksheetProperties">The worksheet properties.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    public WorkbookPropertiesSetter AddWorksheet(WorksheetProperties worksheetProperties) {
        ArgumentNullException.ThrowIfNull(worksheetProperties);

        _worksheetsProperties = [worksheetProperties];

        return this;
    }

    /// <summary>
    /// Adds the worksheet.
    /// </summary>
    /// <param name="worksheetProperties">The worksheet properties.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    public WorkbookPropertiesSetter AddWorksheet(WorksheetProperties[] worksheetProperties) {
        ArgumentNullException.ThrowIfNull(worksheetProperties);
        ArgumentOutOfRangeException.ThrowIfEqual(0, worksheetProperties.Length);

        _worksheetsProperties = worksheetProperties;

        return this;
    }

    /// <summary>
    /// Builds this instance.
    /// </summary>
    /// <returns>IXLWorkbook.</returns>
    public IXLWorkbook Set() {
        if (_workbook == null) {
            throw new WorkbookCannotBeNullException();
        }

        SetAuthor();
        AddWorksheet();
        AddHeadersAndFooters();
        SetCreationDate();
        SetCompany();

        return _workbook;
    }

    /// <summary>
    /// Adds the headers and footers.
    /// </summary>
    private void AddHeadersAndFooters() {
        if (_workbook.Worksheets.Count < 0) return;

        for (var i = 1; i <= _workbook.Worksheets.Count; i++) {
            _worksheetPropertiesSetter.Set(_workbook.Worksheet(i), _reportName,
                _worksheetsProperties[i - 1]);
        }
    }

    /// <summary>
    /// Adds the worksheet.
    /// </summary>
    private void AddWorksheet() {
        foreach (var worksheetParameter in _worksheetsProperties) {
            _workbook?.AddWorksheet(worksheetParameter.WorksheetTitle);
        }
    }

    /// <summary>
    /// Sets the author.
    /// </summary>
    private void SetAuthor() {
        _workbook.Properties.Author = _author;
    }

    /// <summary>
    /// Sets the company.
    /// </summary>
    private void SetCompany() {
        _workbook.Properties.Company = _company;
    }

    /// <summary>
    /// Sets the creation date.
    /// </summary>
    private void SetCreationDate() {
        _workbook.Properties.Created = _workbookCreateDate;
    }
}