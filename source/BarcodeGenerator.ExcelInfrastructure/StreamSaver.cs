// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Provides functionality to save Excel workbooks to a stream.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IStreamSaver"/> interface and utilizes the ClosedXML library
/// to handle Excel workbook operations.
/// </remarks>
public sealed class StreamSaver : IStreamSaver {

    /// <summary>
    /// Saves the specified Excel workbook to a memory stream.
    /// </summary>
    /// <param name="workbook">The Excel workbook to save. Must not be <c>null</c>.</param>
    /// <returns>A <see cref="Stream"/> containing the saved workbook data.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="workbook"/> is <c>null</c>.</exception>
    public Stream SaveToStream(IXLWorkbook workbook) {
        ArgumentNullException.ThrowIfNull(workbook);

        var stream = new MemoryStream();
        workbook.SaveAs(stream);

        return stream;
    }
}