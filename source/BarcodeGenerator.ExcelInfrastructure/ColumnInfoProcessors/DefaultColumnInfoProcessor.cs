// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using BarcodeGenerator.ExcelInfrastructure.Attributes;
using System.Reflection;

namespace BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

/// <summary>
/// Provides a default implementation for processing column information in Excel infrastructure.
/// </summary>
/// <remarks>
/// This class processes properties of a given data type that are decorated with the
/// <see cref="DefaultColumnAttribute" /> and extracts metadata such as column order,
/// display text, and other attributes required for Excel column generation.
/// </remarks>
/// <seealso cref="IColumnInfoProcessor{DefaultColumnAttribute}" />
public class DefaultColumnInfoProcessor : IColumnInfoProcessor<DefaultColumnAttribute> {

    /// <summary>
    /// Gets the column information.
    /// </summary>
    /// <param name="dataType">Type of the data.</param>
    /// <returns>IList&lt;ExcelColumnAttribute&gt;.</returns>
    public DefaultColumnAttribute[] GetColumnInfo(Type dataType) {
        var defaultColumnAttributes = dataType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(DefaultColumnAttribute)))
            .Select(x => x.GetCustomAttribute<DefaultColumnAttribute>());

        return defaultColumnAttributes.Where(x => x != null).OrderBy(x => x.ColumnOrder).ToArray();
    }
}