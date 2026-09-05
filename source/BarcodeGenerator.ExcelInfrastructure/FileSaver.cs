// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Provides functionality for saving Excel workbooks to files.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IFileSaver"/> interface and utilizes the ClosedXML library
/// to handle Excel workbook operations.
/// </remarks>
public class FileSaver : IFileSaver {

    /// <summary>
    /// Saves the specified Excel workbook to a file.
    /// </summary>
    /// <param name="workbook">The Excel workbook to be saved. Must not be <c>null</c>.</param>
    /// <param name="filename">The name of the file to save the workbook to. Must not be <c>null</c>, empty, or consist only of whitespace.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="workbook"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="filename"/> is <c>null</c>, empty, or consists only of whitespace.
    /// </exception>
    /// <remarks>
    /// This method uses the ClosedXML library to save the workbook to the specified file.
    /// </remarks>
    public void SaveToFile(IXLWorkbook workbook, string filename) {
        ArgumentNullException.ThrowIfNull(workbook);
        ArgumentException.ThrowIfNullOrEmpty(filename);
        ArgumentException.ThrowIfNullOrWhiteSpace(filename);

        workbook.SaveAs(filename);
    }
}