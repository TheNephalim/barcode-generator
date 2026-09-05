// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure.Attributes;
using System.Reflection;

namespace BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

/// <summary>
/// Processes column information for a specified type of attribute that implements
/// <see cref="IExcelColumnAttribute" />.
/// </summary>
/// <typeparam name="T">
/// The type of attribute to process. Must be a class that inherits from
/// <see cref="Attribute" /> and implements <see cref="IExcelColumnAttribute" />.
/// </typeparam>
/// <remarks>
/// This class provides functionality to retrieve and process column information
/// from properties of a given data type that are decorated with the specified attribute.
/// </remarks>
public class ColumnInfoProcessor<T> : IColumnInfoProcessor<T> where T : Attribute, IExcelColumnAttribute {

    /// <summary>
    /// Gets the column information.
    /// </summary>
    /// <param name="dataType">Type of the data.</param>
    /// <returns>IList&lt;ExcelColumnAttribute&gt;.</returns>
    public T[] GetColumnInfo(Type dataType) {
        return [.. dataType
            .GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(T)))
            .Select(x => x.GetCustomAttribute<T>())
            .OrderBy(orderByColumn => orderByColumn.ColumnOrder)];
    }
}