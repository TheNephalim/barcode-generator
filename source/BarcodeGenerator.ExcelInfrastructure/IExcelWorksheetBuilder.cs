// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;
using System.Drawing;

namespace BarcodeGenerator.ExcelInfrastructure;

// ReSharper disable once TypeParameterCanBeVariant
/// <summary>
/// Interface IExcelWorksheetBuilder
/// </summary>
/// <typeparam name="TBuilderClass">The type of the t builder class.</typeparam>
/// <typeparam name="T"></typeparam>
public interface IExcelWorksheetBuilder<out TBuilderClass, in T> {

    /// <summary>
    /// Adds the data.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>TBuilderClass.</returns>
    TBuilderClass AddData(T data);

    /// <summary>
    /// Adds the workbook.
    /// </summary>
    /// <param name="workbook">The workbook.</param>
    /// <returns>TBuilderClass.</returns>
    TBuilderClass AddWorkbook(IXLWorkbook workbook);

    /// <summary>
    /// Builds this instance.
    /// </summary>
    /// <returns>IXLWorkbook.</returns>
    Task<IXLWorkbook> BuildAsync();

    /// <summary>
    /// Withes the header start number.
    /// </summary>
    /// <param name="headerStartNumber">The header start number.</param>
    /// <returns>TBuilderClass.</returns>
    TBuilderClass WithHeaderStartNumber(int headerStartNumber);

    /// <summary>
    /// Withes the color of the label.
    /// </summary>
    /// <param name="labelColor">Color of the label.</param>
    /// <returns>TBuilderClass.</returns>
    TBuilderClass WithLabelColor(XLColor labelColor);

    /// <summary>
    /// Withes the color of the value.
    /// </summary>
    /// <param name="valueColor">Color of the value.</param>
    /// <returns>TBuilderClass.</returns>
    TBuilderClass WithValueColor(Color valueColor);
}