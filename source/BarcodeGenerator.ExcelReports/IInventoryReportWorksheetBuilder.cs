// ***********************************************************************
// Assembly          : BarcodeGenerator.ExcelReports
// Author            : Robert Eberhart
// Created           : 09-10-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure;

namespace BarcodeGenerator.ExcelReports;

/// <summary>
/// Represents a builder interface for creating inventory report worksheets in Excel.
/// </summary>
/// <typeparam name="TBuilderClass">
/// The type of the builder class that implements this interface.
/// </typeparam>
/// <typeparam name="TResultsDto">
/// The type of the data transfer object used to populate the worksheet.
/// </typeparam>
public interface IInventoryReportWorksheetBuilder<out TBuilderClass, in TResultsDto> : IExcelWorksheetBuilder<TBuilderClass, TResultsDto>;