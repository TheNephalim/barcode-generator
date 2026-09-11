// ***********************************************************************
// Assembly          : BarcodeGenerator.ExcelReports
// Author            : Robert Eberhart
// Created           : 09-10-2026
// ***********************************************************************

using BarcodeGenerator.Configuration;
using BarcodeGenerator.ExcelInfrastructure;
using BarcodeGenerator.Reporting.Contracts.Dtos;
using ClosedXML.Excel;
using System.Drawing;

namespace BarcodeGenerator.ExcelReports;

public sealed class InventoryReportGenerator : IExcelWorkbookGenerator<InventoryItemDto[]> {
    private readonly IInventoryReportWorksheetBuilder<InventoryReportWorksheetBuilder, InventoryItemDto[]> _builder;
    private readonly BarcodeGeneratorConfiguration _configuration;
    private readonly IFileSaver _fileSaver;
    private readonly IStreamSaver _streamSaver;
    private readonly IWorkbookPropertiesSetter _workbookPropertiesSetter;

    /// <summary>
    /// Initializes a new instance of the <see cref="BarcodeGenerator.ExcelReports.InventoryReportGenerator"/> class.
    /// </summary>
    /// <param name="fileSaver">
    /// An implementation of <see cref="BarcodeGenerator.ExcelInfrastructure.IFileSaver"/> responsible for saving Excel workbooks to files.
    /// </param>
    /// <param name="streamSaver">
    /// An implementation of <see cref="BarcodeGenerator.ExcelInfrastructure.IStreamSaver"/> responsible for saving Excel workbooks to streams.
    /// </param>
    /// <param name="workbook">
    /// An instance of <see cref="ClosedXML.Excel.IXLWorkbook"/> representing the Excel workbook to be generated.
    /// </param>
    /// <param name="workbookPropertiesSetter">
    /// An implementation of <see cref="BarcodeGenerator.ExcelInfrastructure.IWorkbookPropertiesSetter"/> for setting properties of the workbook.
    /// </param>
    /// <param name="configuration">
    /// An instance of <see cref="BarcodeGenerator.Configuration.BarcodeGeneratorConfiguration"/> containing configuration settings for the report generator.
    /// </param>
    /// <param name="builder">
    /// An implementation of <see cref="BarcodeGenerator.ExcelReports.IInventoryReportWorksheetBuilder{BarcodeGenerator.ExcelReports.InventoryReportWorksheetBuilder, BarcodeGenerator.Reporting.Contracts.Dtos.InventoryItemDto[]}"/>
    /// responsible for building the worksheet for the inventory report.
    /// </param>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown if any of the provided parameters are <c>null</c>.
    /// </exception>
    public InventoryReportGenerator(IFileSaver fileSaver, IStreamSaver streamSaver, IWorkbookPropertiesSetter workbookPropertiesSetter, BarcodeGeneratorConfiguration configuration, IInventoryReportWorksheetBuilder<InventoryReportWorksheetBuilder, InventoryItemDto[]> builder) {
        _fileSaver = fileSaver ?? throw new ArgumentNullException(nameof(fileSaver));
        _streamSaver = streamSaver ?? throw new ArgumentNullException(nameof(streamSaver));
        _workbookPropertiesSetter = workbookPropertiesSetter ?? throw new ArgumentNullException(nameof(workbookPropertiesSetter));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    /// <summary>
    /// Asynchronously generates an Excel report based on the provided workbook parameters and saves it to a file.
    /// </summary>
    /// <param name="workbookParameters">
    /// The parameters required for generating the Excel workbook, including metadata and the data to be included in the report.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    /// <remarks>
    /// This method builds the Excel workbook using the provided parameters and saves it to the specified file.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="workbookParameters"/> argument is <c>null</c>.
    /// </exception>
    /// <exception cref="Exception">
    /// Thrown if an error occurs during the report generation or file-saving process.
    /// </exception>
    public Task GenerateReportToFileAsync(IWorkbookParameters<InventoryItemDto[]> workbookParameters) {
        ArgumentNullException.ThrowIfNull(workbookParameters);

        try {
            var workbook = BuildWorkbook(workbookParameters);

            _fileSaver.SaveToFile(workbook, workbookParameters.FileName);
        } catch (Exception exception) {
            throw;
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// Generates an Excel report based on the provided workbook parameters and returns it as a stream.
    /// </summary>
    /// <param name="workbookParameters">
    /// The parameters required for generating the Excel workbook, including metadata and the data to be included in the report.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the Excel report as a <see cref="Stream"/>.
    /// </returns>
    /// <remarks>
    /// This method builds the Excel workbook using the provided <paramref name="workbookParameters"/> and saves it to a stream.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if an error occurs during the report generation process.
    /// </exception>
    public Task<Stream> GenerateReportToStreamAsync(IWorkbookParameters<InventoryItemDto[]> workbookParameters) {
        try {
            var workbook = BuildWorkbook(workbookParameters);

            return Task.FromResult(_streamSaver.SaveToStream(workbook));
        } catch (Exception exception) {
            throw new InvalidOperationException(exception.Message);
        }
    }

    /// <summary>
    /// Builds an Excel workbook using the provided workbook parameters.
    /// </summary>
    /// <param name="workbookParameters">
    /// The parameters required to build the workbook, including spreadsheet data, author, company,
    /// creation date, and worksheet properties.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="workbookParameters"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the <c>SpreadsheetData</c> property of <paramref name="workbookParameters"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method configures workbook properties such as author, company, creation date, and worksheet settings.
    /// It also populates the workbook with data and applies formatting options.
    /// </remarks>
    private IXLWorkbook BuildWorkbook(IWorkbookParameters<InventoryItemDto[]> workbookParameters) {
        ArgumentNullException.ThrowIfNull(workbookParameters);

        if (workbookParameters.SpreadsheetData is null) {
            throw new ArgumentException("Spreadsheet data cannot be null.", nameof(workbookParameters));
        }

        var workbook = new XLWorkbook();

        workbook = _workbookPropertiesSetter
             .AddWorkbook(workbook)
             .AddReportName(_configuration.ReportConfiguration.Subject)
             .AddAuthor(workbookParameters.Author)
             .AddCompany(workbookParameters.Company)
             .AddDate(workbookParameters.CreateDate)
             .AddWorksheet(new WorksheetProperties() {
                 FreezeRow = 1,
                 ShouldRepeatRows = workbookParameters.WorksheetsProperties[0].ShouldRepeatRows,
                 RowsToRepeat = workbookParameters.WorksheetsProperties[0].RowsToRepeat,
                 WorksheetTitle = workbookParameters.WorksheetsProperties[0].WorksheetTitle
             })
             .Set();

        return _builder
            .AddWorkbook(workbook)
            .AddData(workbookParameters.SpreadsheetData)
            .WithHeaderStartNumber(1)
            .WithLabelColor(XLColor.FromArgb(153, 153, 153))
            .WithValueColor(Color.Black)
            .Build();
    }
}