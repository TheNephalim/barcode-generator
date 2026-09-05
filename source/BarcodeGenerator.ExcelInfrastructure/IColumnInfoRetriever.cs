// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using Autofac.Features.Indexed;
using BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Interface IColumnInfoRetriever
/// </summary>
public interface IColumnInfoRetriever {

    /// <summary>
    /// Retrieves the column information.
    /// </summary>
    /// <typeparam name="TColumnAttribute">The type of the t column attribute.</typeparam>
    /// <param name="processors">The processors.</param>
    /// <param name="processorType">Type of the processor.</param>
    /// <param name="dataTransferObjectType">Type of the data transfer object.</param>
    /// <returns>TColumnAttribute[].</returns>
    TColumnAttribute[] RetrieveColumnInfo<TColumnAttribute>(
        IIndex<ColumnInfoProcessorTypes, IColumnInfoProcessor<TColumnAttribute>> processors,
        ColumnInfoProcessorTypes processorType,
        Type dataTransferObjectType);
}