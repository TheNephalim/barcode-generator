// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;
using System.ComponentModel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Interface IWorkbookPropertiesSetter
/// </summary>
public interface IWorkbookPropertiesSetter {

    /// <summary>
    /// Adds the application identifier to the workbook properties.
    /// </summary>
    /// <param name="applicationId">The application identifier.</param>
    /// <returns>The current instance of <see cref="WorkbookPropertiesSetter"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="applicationId"/> is an empty GUID.</exception>
    WorkbookPropertiesSetter AddApplicationId(Guid applicationId);

    /// <summary>
    /// Adds the author.
    /// </summary>
    /// <param name="author">The author.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    WorkbookPropertiesSetter AddAuthor(string author);

    /// <summary>
    /// Adds the company.
    /// </summary>
    /// <param name="company">The company.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    WorkbookPropertiesSetter AddCompany(string company);

    /// <summary>
    /// Adds the date.
    /// </summary>
    /// <param name="workbookCreationDate">The workbook creation date.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    WorkbookPropertiesSetter AddDate(DateTime workbookCreationDate);

    /// <summary>
    /// Adds the report name to the workbook properties.
    /// </summary>
    /// <param name="reportName">The report name to be added.</param>
    /// <returns>The current instance of <see cref="WorkbookPropertiesSetter"/>.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when <paramref name="reportName"/> is <see cref="string.None"/>.</exception>
    WorkbookPropertiesSetter AddReportName(string reportName);

    /// <summary>
    /// Adds the workbook.
    /// </summary>
    /// <param name="workbook">The workbook.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    WorkbookPropertiesSetter AddWorkbook(IXLWorkbook workbook);

    /// <summary>
    /// Adds the worksheet.
    /// </summary>
    /// <param name="worksheetProperties">The worksheet properties.</param>
    /// <returns>WorkbookPropertiesSetter.</returns>
    WorkbookPropertiesSetter AddWorksheet(WorksheetProperties worksheetProperties);

    /// <summary>
    /// Builds this instance.
    /// </summary>
    /// <returns>IXLWorkbook.</returns>
    IXLWorkbook Set();
}