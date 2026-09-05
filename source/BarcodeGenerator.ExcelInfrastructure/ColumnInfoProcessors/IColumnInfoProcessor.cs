// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

/// <summary>
/// Interface IColumnInfoProcessor
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IColumnInfoProcessor<T> {

    /// <summary>
    /// Gets the column information.
    /// </summary>
    /// <param name="dataType">Type of the data.</param>
    /// <returns>IList&lt;ExcelColumnAttribute&gt;.</returns>
    T[] GetColumnInfo(Type dataType);
}