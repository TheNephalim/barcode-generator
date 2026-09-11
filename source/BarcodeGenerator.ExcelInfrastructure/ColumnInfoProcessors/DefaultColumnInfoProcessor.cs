// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.Reporting.Contracts.Attributes;
using System.Reflection;

namespace BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

/// <summary>
/// Represents the default implementation of the <see cref="IColumnInfoProcessor{DefaultColumnAttribute}" /> interface.
/// This processor is responsible for extracting column information from properties decorated with the <see cref="DefaultColumnAttribute" />.
/// </summary>
/// <remarks>
/// The <see cref="DefaultColumnInfoProcessor" /> retrieves all properties of a given type that are marked with the
/// <see cref="DefaultColumnAttribute" /> and orders them based on the <c>ColumnOrder</c> property of the attribute.
/// </remarks>
public sealed class DefaultColumnInfoProcessor : IColumnInfoProcessor<DefaultColumnAttribute> {

    /// <summary>
    /// Retrieves an array of <see cref="DefaultColumnAttribute"/> instances associated with the properties of the specified data type.
    /// </summary>
    /// <param name="dataType">The type of the data whose properties will be inspected for <see cref="DefaultColumnAttribute"/>.</param>
    /// <returns>An array of <see cref="DefaultColumnAttribute"/> instances, ordered by their <c>ColumnOrder</c> property.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="dataType"/> is <c>null</c>.</exception>
    public DefaultColumnAttribute[] GetColumnInfo(Type dataType) {
        var attributes = dataType.GetProperties()
            .Select(property => property.GetCustomAttribute<DefaultColumnAttribute>())
            .Where(attribute => attribute is not null)
            .OfType<DefaultColumnAttribute>()
            .OrderBy(attribute => attribute.ColumnOrder)
            .ToArray();

        return attributes;
    }
}