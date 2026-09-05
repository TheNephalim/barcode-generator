// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Interface IStreamSaver
/// </summary>
public interface IStreamSaver {

    /// <summary>
    /// Saves to stream.
    /// </summary>
    /// <param name="workbook">The workbook.</param>
    /// <returns>Stream.</returns>
    Stream SaveToStream(IXLWorkbook workbook);
}