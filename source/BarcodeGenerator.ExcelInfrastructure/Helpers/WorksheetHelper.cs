// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.Reporting.Contracts.Attributes;
using ClosedXML.Excel;
using System.Drawing;
using System.Linq.Expressions;

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Provides helper methods for working with Excel worksheets, including adding headers and data.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IWorksheetHelper"/> interface and provides functionality
/// for manipulating Excel worksheets using the ClosedXML library.
/// </remarks>
/// <seealso cref="IWorksheetHelper"/>
public sealed class WorksheetHelper : IWorksheetHelper {

    /// <summary>
    /// Initializes a new instance of the <see cref="WorksheetHelper" /> class.
    /// </summary>
    /// <param name="cellFormattingHelper">The cell formatting helper.</param>
    public WorksheetHelper(ICellFormattingHelper cellFormattingHelper) {
        ArgumentNullException.ThrowIfNull(cellFormattingHelper);
    }

    /// <summary>
    /// Adds the headers to spreadsheet.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
    public void AddHeadersToSpreadsheet<TAttribute>(ExcelHeaderParameters<TAttribute> excelHeaderParameters) where TAttribute : IExcelColumnAttribute {
        ArgumentNullException.ThrowIfNull(excelHeaderParameters);

        var worksheet = excelHeaderParameters.Workbook.Worksheet(excelHeaderParameters.WorksheetNumber);
        if (worksheet is null) {
            throw new InvalidOperationException(
                $"Worksheet number {excelHeaderParameters.WorksheetNumber} does not exist");
        }

        var orderedHeaders = excelHeaderParameters.Headers.OrderBy(x => x.ColumnOrder).ToArray();

        var headerTexts = orderedHeaders.Select(x => x.DisplayText);
        var startCell = worksheet.Cell(excelHeaderParameters.HeaderRowStart, 1);
        var headerRange = startCell.InsertData(new[] { headerTexts });

        headerRange.Style.Font.Bold = true;
        headerRange.Style.Font.FontColor = XLColor.FromColor(Color.White);
        headerRange.Style.Font.FontName = excelHeaderParameters.FontName;
        headerRange.Style.Font.FontSize = excelHeaderParameters.FontSize;
        headerRange.Style.Fill.BackgroundColor = excelHeaderParameters.LabelColor;
        headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        headerRange.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
        headerRange.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

        for (var i = 0; i < orderedHeaders.Length; i++) {
            worksheet.Column(i + 1).Width = orderedHeaders[i].ColumnWidth;
        }

        worksheet.Row(excelHeaderParameters.HeaderRowStart).Height = excelHeaderParameters.HeaderRowHeight;
    }

    /// <summary>
    /// Asynchronously adds simple data to the specified worksheet.
    /// </summary>
    /// <typeparam name="T">The type of the data to output.</typeparam>
    /// <typeparam name="TAttribute">The type of the attribute used to define column properties.</typeparam>
    /// <param name="dataToOutput">The array of data to be written to the worksheet.</param>
    /// <param name="headers">The array of headers defining the column attributes.</param>
    /// <param name="worksheet">The worksheet where the data will be added.</param>
    /// <param name="closedXmlParameters">The parameters for configuring the ClosedXML styles and settings.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="dataToOutput"/>, <paramref name="headers"/>, or <paramref name="worksheet"/> is <c>null</c>.
    /// </exception>
    public void AddSimpleDataToWorksheet<T, TAttribute>(T[] dataToOutput,
        TAttribute[] headers,
        IXLWorksheet worksheet,
        ClosedXmlParameters closedXmlParameters)
        where T : class
        where TAttribute : IExcelColumnAttribute {
        ArgumentNullException.ThrowIfNull(dataToOutput);
        ArgumentNullException.ThrowIfNull(headers);
        ArgumentNullException.ThrowIfNull(worksheet);

        if (dataToOutput.Length == 0) {
            return;
        }

        var propertyGetters = CreatePropertyGetters<T, TAttribute>(headers);
        var orderedHeaders = headers.OrderBy(h => h.ColumnOrder).ToArray();

        var dataForBulkInsert =
            dataToOutput.Select(row => propertyGetters.Select(getter => getter(row) ?? string.Empty).ToArray());

        var startRow = (worksheet.LastRowUsed()?.RowNumber() ?? 0) + 1;
        var startCell = worksheet.Cell(startRow, 1);

        var insertedDataRange = startCell.InsertData(dataForBulkInsert);
        insertedDataRange.Style.Font.FontName = closedXmlParameters.FontName;
        insertedDataRange.Style.Font.FontSize = closedXmlParameters.FontSize;
        insertedDataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        insertedDataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
        insertedDataRange.Style.Fill.BackgroundColor = XLColor.FromColor(closedXmlParameters.BackgroundColor);
        insertedDataRange.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
        insertedDataRange.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

        for (var i = 0; i < orderedHeaders.Length; i++) {
            var header = orderedHeaders[i];
            var currentColumn = worksheet.Column(i + 1);
            currentColumn.Width = header.ColumnWidth;

            var columnDataRange = insertedDataRange.Column(i + 1);

            if (!string.IsNullOrWhiteSpace(header.FormatStyle)) {
                columnDataRange.Style.NumberFormat.Format = header.FormatStyle;
            }
        }

        var insertedRows = worksheet.Rows(startRow, startRow + dataToOutput.Length - 1);
        insertedRows.AdjustToContents();
    }

    /// <summary>
    /// Creates an array of property getter functions for the specified headers.
    /// </summary>
    /// <typeparam name="T">The type of the data objects.</typeparam>
    /// <typeparam name="TAttribute">The type of the attribute used to define metadata for Excel columns.</typeparam>
    /// <param name="headers">An array of headers that define the metadata for the Excel columns.</param>
    /// <returns>
    /// An array of functions, where each function retrieves the value of a specific property
    /// from an object of type <typeparamref name="T"/>.
    /// </returns>
    /// <remarks>
    /// This method generates property getter functions based on the metadata provided in the headers.
    /// Each function is compiled as a lambda expression and can be used to retrieve the value of a property
    /// from an object of type <typeparamref name="T"/>. If a property specified in the header does not exist
    /// in the type <typeparamref name="T"/>, the corresponding function will return an empty string.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="headers"/> parameter is <c>null</c>.
    /// </exception>
    private static Func<T, object?>[] CreatePropertyGetters<T, TAttribute>(TAttribute[] headers)
            where T : class
        where TAttribute : IExcelColumnAttribute {
        return [
            .. headers
                .OrderBy(h => h.ColumnOrder)
                .Select(header => {
                    var propertyInfo = typeof(T).GetProperty(header.PropertyName);
                    if (propertyInfo == null) {
                        return (Func<T, object?>)(_ => string.Empty);
                    }

                    var param = Expression.Parameter(typeof(T), "x");
                    var property = Expression.Property(param, propertyInfo);
                    var convert = Expression.Convert(property, typeof(object));
                    var lambda = Expression.Lambda<Func<T, object?>>(convert, param);
                    return lambda.Compile();
                })
        ];
    }
}