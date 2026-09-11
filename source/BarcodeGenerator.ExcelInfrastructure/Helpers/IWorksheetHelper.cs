// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.Reporting.Contracts.Attributes;
using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Interface IWorksheetHelper
/// </summary>
public interface IWorksheetHelper {

    /// <summary>
    /// Adds the headers to spreadsheet.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
    /// <param name="excelHeaderParameters">The excel header parameters.</param>
    void AddHeadersToSpreadsheet<TAttribute>(ExcelHeaderParameters<TAttribute> excelHeaderParameters) where TAttribute : IExcelColumnAttribute;

    /// <summary>
    /// Adds simple data to the specified Excel worksheet.
    /// </summary>
    /// <typeparam name="T">The type of the data to output.</typeparam>
    /// <typeparam name="TAttribute">The type of the attribute used for column definitions.</typeparam>
    /// <param name="dataToOutput">An array of data items to be written to the worksheet.</param>
    /// <param name="headers">An array of headers defining the column structure and metadata.</param>
    /// <param name="worksheet">The target worksheet where the data will be added.</param>
    /// <param name="closedXmlParameters">The parameters for configuring the worksheet, such as styling and formatting.</param>
    void AddSimpleDataToWorksheet<T, TAttribute>(T[] dataToOutput,
        TAttribute[] headers,
        IXLWorksheet worksheet, ClosedXmlParameters closedXmlParameters)
        where T : class
        where TAttribute : IExcelColumnAttribute;
}