// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Interface IWorksheetPageSetupPropertySetter
/// </summary>
public interface IWorksheetPageSetupPropertySetter {

    /// <summary>
    /// Sets the specified worksheet.
    /// </summary>
    /// <param name="worksheet">The worksheet.</param>
    /// <param name="worksheetProperties">The worksheet properties.</param>
    void Set(IXLWorksheet worksheet, WorksheetProperties worksheetProperties);
}