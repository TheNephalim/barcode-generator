// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Interface ICellFormattingHelper
/// </summary>
public interface ICellFormattingHelper {

    /// <summary>
    /// Formats the contract header cells.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    void FormatLabelCells(ExcelCellLabelParameters parameters);

    /// <summary>
    /// Formats the value cells.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    void FormatValueCells(ExcelCellValueParameters parameters);
}