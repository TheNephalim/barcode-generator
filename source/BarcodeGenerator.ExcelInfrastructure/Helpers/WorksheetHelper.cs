// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure.Attributes;
using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Provides helper methods for working with Excel worksheets, including adding headers and data.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IWorksheetHelper"/> interface and provides functionality
/// for manipulating Excel worksheets using the ClosedXML library.
/// </remarks>
/// <seealso cref="IWorksheetHelper"/>
public class WorksheetHelper : IWorksheetHelper {
    private readonly ICellFormattingHelper _cellFormattingHelper;
    private readonly object _lockObject = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="WorksheetHelper" /> class.
    /// </summary>
    /// <param name="cellFormattingHelper">The cell formatting helper.</param>
    public WorksheetHelper(ICellFormattingHelper cellFormattingHelper) {
        ArgumentNullException.ThrowIfNull(cellFormattingHelper);

        _cellFormattingHelper = cellFormattingHelper;
    }

    /// <summary>
    /// Adds the headers to spreadsheet.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
    public void AddHeadersToSpreadsheet<TAttribute>(ExcelHeaderParameters<TAttribute> excelHeaderParameters) where TAttribute : IExcelColumnAttribute {
        ArgumentNullException.ThrowIfNull(excelHeaderParameters);

        var worksheet = excelHeaderParameters.Workbook.Worksheet(excelHeaderParameters.WorksheetNumber);
        var filteredColumns = excelHeaderParameters.Headers.OrderBy(x => x.ColumnOrder).ToList();
        const int columnOffset = 0;

        for (var i = 1; i <= filteredColumns.Count; i++) {
            var offset = i - 1;

            lock (_lockObject) {
                _cellFormattingHelper.FormatLabelCells(new ExcelCellLabelParameters {
                    Worksheet = worksheet,
                    CellWidth = filteredColumns[offset].ColumnWidth,
                    RowNumber = excelHeaderParameters.HeaderRowStart,
                    ColumnNumber = i - columnOffset,
                    LabelText = filteredColumns[offset].DisplayText,
                    FontColor = XLColor.White,
                    FontSize = excelHeaderParameters.FontSize,
                    FontName = excelHeaderParameters.FontName,
                    BackgroundColor = excelHeaderParameters.LabelColor
                });
            }
        }

        worksheet.Row(excelHeaderParameters.HeaderRowStart).Height = excelHeaderParameters.HeaderRowHeight;
    }

    /// <summary>
    /// Adds the simple data to worksheet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
    /// <param name="dataToOutput">The data to output.</param>
    /// <param name="headers">The headers.</param>
    /// <param name="worksheet">The worksheet.</param>
    /// <param name="closedXmlParameters">The closed XML parameters.</param>
    public async Task AddSimpleDataToWorksheetAsync<T, TAttribute>(T[] dataToOutput,
        TAttribute[] headers,
        IXLWorksheet worksheet,
        ClosedXmlParameters closedXmlParameters)
        where T : class
        where TAttribute : IExcelColumnAttribute {
        ArgumentNullException.ThrowIfNull(dataToOutput);
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(worksheet);

        var rowOffset = (worksheet.LastRowUsed()?.RowNumber() ?? 0) + 1;

        var doublets = from i in Enumerable.Range(0, dataToOutput.Length)
                       from j in Enumerable.Range(0, headers.Length)
                       select new Tuple<int, int>(i, j);

        var cells = doublets.Chunk(500).ToArray();
        var lockObject = new object();

        var columnOffset = 0;

        var tasks = new List<Task>();

        foreach (var chunk in cells) {
            tasks.Add(Task.Run(() => {
                lock (lockObject) {
                    for (var i = 0; i < chunk.Length; i++) {
                        var (cellRow, cellColumn) = chunk[i];

                        var element = dataToOutput[cellRow];

                        if (EqualityComparer<T>.Default.Equals(element, default)) continue;

                        var propertyName = headers[cellColumn].PropertyName;

                        var value = element.GetType().GetProperty(propertyName)?.GetValue(element) ?? string.Empty;
                        var rowNumber = rowOffset + cellRow;

                        worksheet.Row(rowNumber).Height = closedXmlParameters.RowHeight;

                        _cellFormattingHelper.FormatValueCells(new ExcelCellValueParameters() {
                            Worksheet = worksheet,
                            DataType = headers[cellColumn].ExcelDataType,
                            RowNumber = rowNumber,
                            ColumnNumber = cellColumn + 1 - columnOffset,
                            FontColor = closedXmlParameters.FontColor,
                            BackgroundColor = closedXmlParameters.BackgroundColor,
                            Value = value,
                            CellWidth = headers[cellColumn].ColumnWidth,
                            StringFormat = headers[cellColumn].FormatStyle,
                            FontName = closedXmlParameters.FontName,
                            FontSize = closedXmlParameters.FontSize
                        });

                        worksheet.Row(rowNumber).AdjustToContents();
                        worksheet.Row(rowNumber).ClearHeight();

                        columnOffset = ClearColumnOffset(rowOffset, rowNumber, i, columnOffset, chunk);
                    }
                }
            }));

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Clears the column offset.
    /// </summary>
    /// <param name="rowOffset">The row offset.</param>
    /// <param name="currentRow">The current row.</param>
    /// <param name="index">The index.</param>
    /// <param name="columnOffset">The column offset.</param>
    /// <param name="cells">The cells.</param>
    /// <returns>System.Int32.</returns>
    private static int ClearColumnOffset(int rowOffset, int currentRow, int index, int columnOffset, Tuple<int, int>[] cells) {
        var nextCellIndex = index + 1;

        if (nextCellIndex >= cells.Length) return 0;

        var nextCellRow = rowOffset + cells[nextCellIndex].Item1;

        return currentRow != nextCellRow ? 0 : columnOffset;
    }
}