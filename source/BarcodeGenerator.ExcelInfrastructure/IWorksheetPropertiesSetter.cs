// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Defines the contract for setting properties of an Excel worksheet.
/// </summary>
/// <remarks>
/// Implementations of this interface are responsible for configuring various properties
/// of a worksheet, such as headers, footers, page setup, and other related settings.
/// </remarks>
public interface IWorksheetPropertiesSetter {

    /// <summary>
    /// Sets the specified worksheet.
    /// </summary>
    /// <param name="worksheet">The worksheet.</param>
    /// <param name="reportName"></param>
    /// <param name="worksheetProperties">The worksheet properties.</param>
    void Set(IXLWorksheet worksheet, string reportName,
        WorksheetProperties worksheetProperties);
}