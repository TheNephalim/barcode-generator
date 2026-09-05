// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Defines a contract for saving Excel workbooks to files.
/// </summary>
/// <remarks>
/// Implementations of this interface are responsible for persisting Excel workbooks
/// to a specified file location, leveraging libraries such as ClosedXML for handling
/// workbook operations.
/// </remarks>
public interface IFileSaver {

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
    /// This method is responsible for persisting the provided Excel workbook to the specified file location.
    /// Implementations may leverage libraries such as ClosedXML for handling workbook operations.
    /// </remarks>
    void SaveToFile(IXLWorkbook workbook, string filename);
}