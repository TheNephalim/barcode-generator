// ***********************************************************************
// Assembly          : BarcodeGenerator.AutofacConfiguration
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************

using Autofac;
using BarcodeGenerator.Entities;
using BarcodeGenerator.LabelGeneration;
using System.Runtime.Versioning;

namespace BarcodeGenerator.AutofacConfiguration;

/// <summary>
/// Configures the Autofac dependency injection container for label generation components.
/// </summary>
/// <remarks>
/// This class is responsible for registering implementations of label generation-related services,
/// including barcode label generation, barcode image generation, and label printing.
/// It extends the <see cref="Autofac.Module"/> class to provide custom module configuration.
/// </remarks>
[SupportedOSPlatform("windows")]
public sealed class ConfigureLabelGeneration : Module {

    /// <summary>
    /// Registers label generation-related services and components into the Autofac dependency injection container.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="ContainerBuilder"/> instance used to register services and components.
    /// </param>
    /// <remarks>
    /// This method registers the following services:
    /// <list type="bullet">
    /// <item><description><see cref="IBarcodeLabelGenerator"/> implementation for generating barcode labels.</description></item>
    /// <item><description><see cref="IBarcodeImageGenerator"/> implementation for generating barcode images.</description></item>
    /// <item><description><see cref="ILabelPrinter"/> implementation for printing labels.</description></item>
    /// </list>
    /// </remarks>
    protected override void Load(ContainerBuilder builder) {
        builder.RegisterType<BarcodeLabelGenerator>().As<IBarcodeLabelGenerator>().SingleInstance();
        builder.RegisterType<BarcodeImageGenerator>().As<IBarcodeImageGenerator>().SingleInstance();
        builder
            .RegisterType<RenderedBarcodeLabelGenerator>()
            .As<IRenderedBarcodeLabelGenerator>()
            .SingleInstance();

        builder.RegisterType<OneByThreeLabelRenderer>()
            .Keyed<ILabelRenderer>(LabelTemplateType.OneByThree)
            .InstancePerDependency();

        builder.RegisterType<ThermalPrinter>()
            .Keyed<ILabelPrinter>(LabelTemplateType.OneByThree)
            .InstancePerDependency();

        builder.RegisterType<LabelRendererFactory>()
            .As<IRendererFactory>()
            .InstancePerDependency();

        builder.RegisterType<LabelPrinterFactory>()
            .As<ILabelPrinterFactory>()
            .InstancePerDependency();
    }
}