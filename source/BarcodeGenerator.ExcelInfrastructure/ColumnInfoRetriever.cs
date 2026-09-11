// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using Autofac.Features.Indexed;
using BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Provides functionality to retrieve column information for Excel processing.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IColumnInfoRetriever"/> interface and is responsible for retrieving
/// column metadata based on the specified processors, processor type, and data transfer object type.
/// </remarks>
/// <seealso cref="IColumnInfoRetriever" />
public sealed class ColumnInfoRetriever : IColumnInfoRetriever {

    /// <summary>
    /// Retrieves the column information.
    /// </summary>
    /// <typeparam name="TColumnAttribute">The type of the t column attribute.</typeparam>
    /// <param name="processors">The processors.</param>
    /// <param name="processorType">Type of the processor.</param>
    /// <param name="dataTransferObjectType">Type of the data transfer object.</param>
    /// <returns>IList&lt;TColumnAttribute&gt;.</returns>
    public TColumnAttribute[] RetrieveColumnInfo<TColumnAttribute>(
        IIndex<ColumnInfoProcessorTypes, IColumnInfoProcessor<TColumnAttribute>> processors,
        ColumnInfoProcessorTypes processorType,
        Type dataTransferObjectType) {
        return processors[processorType].GetColumnInfo(dataTransferObjectType);
    }
}