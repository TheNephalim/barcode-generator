// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.Reporting.Contracts.Attributes;
using System.Reflection;

namespace BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

/// <summary>
/// Provides functionality to process column information for types that implement
/// <see cref="IExcelColumnAttribute"/>.
/// </summary>
/// <typeparam name="T">
/// The type of attribute that implements <see cref="IExcelColumnAttribute"/> and is used
/// to define metadata for Excel columns.
/// </typeparam>
/// <remarks>
/// This class is responsible for extracting and organizing metadata from properties of a given type
/// that are decorated with the specified attribute <typeparamref name="T"/>. The extracted metadata
/// can be used to configure and customize the appearance and behavior of Excel columns.
/// </remarks>
/// <seealso cref="IColumnInfoProcessor{T}" />
public sealed class ColumnInfoProcessor<T> : IColumnInfoProcessor<T> where T : Attribute, IExcelColumnAttribute {

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
            .OfType<T>()
            .OrderBy(orderByColumn => orderByColumn.ColumnOrder)];
    }
}