// ***********************************************************************
// Assembly          : BarcodeGenerator.ExcelReports
// Author            : Robert Eberhart
// Created           : 09-10-2026
// ***********************************************************************

using Autofac.Features.Indexed;
using BarcodeGenerator.ExcelInfrastructure;
using BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;
using BarcodeGenerator.ExcelInfrastructure.Helpers;
using BarcodeGenerator.Reporting.Contracts.Attributes;
using BarcodeGenerator.Reporting.Contracts.Dtos;
using ClosedXML.Excel;
using System.Drawing;

namespace BarcodeGenerator.ExcelReports;

public sealed class InventoryReportWorksheetBuilder : IInventoryReportWorksheetBuilder<InventoryReportWorksheetBuilder, InventoryItemDto[]> {
    private const int WorksheetNumber = 1;
    private readonly DefaultColumnAttribute[] _excelColumns;
    private readonly IWorksheetHelper _worksheetHelper;
    private int _headerRowStart;
    private XLColor _labelColor;
    private InventoryItemDto[] _spreadSheetData;
    private Color _valueColor;
    private IXLWorkbook? _workbook;

    public InventoryReportWorksheetBuilder(IIndex<ColumnInfoProcessorTypes, IColumnInfoProcessor<DefaultColumnAttribute>> processors,
        IWorksheetHelper worksheetHelper, IColumnInfoRetriever columnInfoRetriever) {
        _worksheetHelper = worksheetHelper;

        _excelColumns = columnInfoRetriever.RetrieveColumnInfo(processors, ColumnInfoProcessorTypes.Default,
            typeof(InventoryItemDto));

        _labelColor = XLColor.FromArgb(211, 211, 211);
        _valueColor = Color.White;
        _headerRowStart = 1;
        _spreadSheetData = [];
    }

    public InventoryReportWorksheetBuilder AddData(InventoryItemDto[] data) {
        ArgumentNullException.ThrowIfNull(data);
        _spreadSheetData = data;
        return this;
    }

    public InventoryReportWorksheetBuilder AddWorkbook(IXLWorkbook workbook) {
        ArgumentNullException.ThrowIfNull(workbook);

        _workbook = workbook;

        return this;
    }

    public IXLWorkbook Build() {
        if (_workbook == null) {
            throw new InvalidOperationException("Workbook cannot be null. Call AddWorkbook() first.");
        }

        AddHeadersToWorksheet(_workbook);
        AddDataToWorksheet(_spreadSheetData, WorksheetNumber, _workbook, _excelColumns);

        return _workbook;
    }

    public InventoryReportWorksheetBuilder WithHeaderStartNumber(int headerStartNumber) {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(headerStartNumber, 0);

        _headerRowStart = headerStartNumber;

        return this;
    }

    public InventoryReportWorksheetBuilder WithLabelColor(XLColor labelColor) {
        ArgumentNullException.ThrowIfNull(labelColor);

        _labelColor = labelColor;

        return this;
    }

    public InventoryReportWorksheetBuilder WithValueColor(Color valueColor) {
        ArgumentNullException.ThrowIfNull(valueColor);

        _valueColor = valueColor;

        return this;
    }

    private void AddDataToWorksheet(InventoryItemDto[] data, int worksheetNumber, IXLWorkbook workbook,
        DefaultColumnAttribute[] excelColumns) {
        ArgumentNullException.ThrowIfNull(data);
        ArgumentOutOfRangeException.ThrowIfLessThan(worksheetNumber, 1);
        ArgumentNullException.ThrowIfNull(workbook);
        ArgumentNullException.ThrowIfNull(excelColumns);

        var columns = excelColumns.OrderBy(x => x.ColumnOrder).ToArray();
        var worksheet = workbook.Worksheet(worksheetNumber);

        _worksheetHelper.AddSimpleDataToWorksheet(data, columns, worksheet,
            new ClosedXmlParameters {
                FontColor = XLColor.FromColor(_valueColor),
                BackgroundColor = Color.White,
                RowHeight = 24D,
                FontSize = 10D,
                FontName = FontNameConstants.Calibri
            });

        worksheet.RangeUsed()?.SetAutoFilter();
    }

    private void AddHeadersToWorksheet(IXLWorkbook workbook) {
        _worksheetHelper.AddHeadersToSpreadsheet(
            new ExcelHeaderParameters<DefaultColumnAttribute> {
                Workbook = workbook,
                WorksheetNumber = WorksheetNumber,
                HeaderRowStart = _headerRowStart,
                LabelColor = _labelColor,
                Headers = _excelColumns,
                FontSize = 10D,
                FontName = FontNameConstants.Calibri,
            }
        );
    }
}