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
public class StreamSaver : IStreamSaver {

    /// <summary>
    /// Saves to stream.
    /// </summary>
    /// <param name="workbook">The workbook.</param>
    /// <returns>Stream.</returns>
    public Stream SaveToStream(IXLWorkbook workbook) {
        ArgumentNullException.ThrowIfNull(workbook);

        var stream = new MemoryStream();
        workbook.SaveAs(stream);

        return stream;
    }
}