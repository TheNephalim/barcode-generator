// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Interface IExcelWorkbookGenerator
/// </summary>
/// <typeparam name="TResultsDto">The type of the t results dto.</typeparam>
public interface IExcelWorkbookGenerator<TResultsDto> {

    /// <summary>
    /// Generates the report to file.
    /// </summary>
    /// <param name="workbookParameters">The worksheet parameters.</param>
    Task GenerateReportToFileAsync(IWorkbookParameters<TResultsDto> workbookParameters);

    /// <summary>
    /// Generates the report to stream.
    /// </summary>
    /// <param name="workbookParameters">The worksheet parameters.</param>
    /// <returns>MemoryStream.</returns>
    Task<Stream> GenerateReportToStreamAsync(IWorkbookParameters<TResultsDto> workbookParameters);
}