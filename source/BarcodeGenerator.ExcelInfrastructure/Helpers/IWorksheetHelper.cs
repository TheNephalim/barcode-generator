// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure.Attributes;
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
    /// Adds the simple data to worksheet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
    /// <param name="dataToOutput">The data to output.</param>
    /// <param name="headers">The headers.</param>
    /// <param name="worksheet">The worksheet.</param>
    /// <param name="closedXmlParameters">The closed XML parameters.</param>
    Task AddSimpleDataToWorksheetAsync<T, TAttribute>(T[] dataToOutput,
        TAttribute[] headers,
        IXLWorksheet worksheet, ClosedXmlParameters closedXmlParameters)
        where T : class
        where TAttribute : IExcelColumnAttribute;
}