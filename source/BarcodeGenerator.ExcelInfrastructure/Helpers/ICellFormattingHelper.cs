// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure.Helpers;

/// <summary>
/// Provides methods for formatting Excel cells, including label and value cells.
/// </summary>
/// <remarks>
/// This interface defines methods for applying specific formatting to Excel cells,
/// such as labels and values, using parameter objects like
/// <see cref="ExcelCellLabelParameters"/> and <see cref="ExcelCellValueParameters"/>.
/// Implementations of this interface are used to ensure consistent styling and
/// formatting across Excel worksheets.
/// </remarks>
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