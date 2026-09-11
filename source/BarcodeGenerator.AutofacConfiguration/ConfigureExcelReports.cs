// ***********************************************************************
// Assembly          : BarcodeGenerator.AutofacConfiguration
// Author            : Robert Eberhart
// Created           : 09-11-2026
// ***********************************************************************

using Autofac;
using BarcodeGenerator.ExcelInfrastructure;
using BarcodeGenerator.ExcelInfrastructure.ColumnInfoProcessors;
using BarcodeGenerator.ExcelInfrastructure.Helpers;
using BarcodeGenerator.ExcelReports;
using BarcodeGenerator.Reporting.Contracts.Attributes;
using BarcodeGenerator.Reporting.Contracts.Dtos;
using ClosedXML.Excel;

namespace BarcodeGenerator.AutofacConfiguration;

/// <summary>
/// Configures the Autofac dependency injection container for Excel report generation.
/// </summary>
/// <remarks>
/// This class registers various services and components required for generating Excel reports,
/// including workbook parameters, worksheet builders, report generators, column info processors,
/// and other utilities. It ensures proper lifetime management and dependency resolution for these components.
/// </remarks>
public sealed class ConfigureExcelReports : Module {

    /// <summary>
    /// Configures the Autofac container with dependencies required for Excel report generation.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="ContainerBuilder"/> used to register components and services.
    /// </param>
    /// <remarks>
    /// This method registers various services and components related to Excel report generation,
    /// including workbook and worksheet builders, property setters, column info processors,
    /// and helpers for formatting and saving files.
    /// </remarks>
    protected override void Load(ContainerBuilder builder) {
        builder.RegisterType<XLWorkbook>().As<IXLWorkbook>().InstancePerDependency();
        builder.RegisterGeneric(typeof(WorkbookParameters<>)).As(typeof(IWorkbookParameters<>))
            .InstancePerLifetimeScope();

        builder.RegisterType<InventoryReportWorksheetBuilder>()
            .As<IInventoryReportWorksheetBuilder<InventoryReportWorksheetBuilder,
                InventoryItemDto[]>>()
            .InstancePerDependency();

        builder.RegisterType<InventoryReportGenerator>()
            .As<IExcelWorkbookGenerator<InventoryItemDto[]>>()
            .InstancePerDependency();

        builder.RegisterType<DefaultColumnInfoProcessor>()
            .Keyed<IColumnInfoProcessor<DefaultColumnAttribute>>(ColumnInfoProcessorTypes.Default);

        builder.RegisterType<WorkbookPropertiesSetter>()
            .As<IWorkbookPropertiesSetter>()
            .InstancePerLifetimeScope();

        builder.RegisterType<WorksheetPageSetupPropertySetter>()
            .As<IWorksheetPageSetupPropertySetter>()
            .InstancePerLifetimeScope();

        builder.RegisterType<WorksheetPropertiesSetter>()
            .As<IWorksheetPropertiesSetter>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ColumnInfoRetriever>()
            .As<IColumnInfoRetriever>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CellFormattingHelper>()
            .As<ICellFormattingHelper>()
            .InstancePerLifetimeScope();

        builder.RegisterType<WorksheetHelper>()
            .As<IWorksheetHelper>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CellHelper>()
            .As<ICellHelper>()
            .InstancePerLifetimeScope();

        builder.RegisterType<FileSaver>()
            .As<IFileSaver>()
            .InstancePerLifetimeScope();

        builder.RegisterType<StreamSaver>()
            .As<IStreamSaver>()
            .InstancePerLifetimeScope();
    }
}