// ***********************************************************************
// Assembly          : BarcodeGenerator.AutofacConfiguration
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************

using Autofac;
using BarcodeGenerator.LabelGeneration;

namespace BarcodeGenerator.AutofacConfiguration;

/// <summary>
/// Configures the dependency injection container for barcode generation services.
/// </summary>
/// <remarks>
/// This class is a custom Autofac module that registers the necessary services and components
/// required for barcode generation. It ensures that the appropriate implementations, such as
/// <see cref="BarcodeGenerator.LabelGeneration.BarcodeImageGenerator"/>, are registered and
/// available for dependency injection.
/// </remarks>
public sealed class ConfigureBarcodeGeneration : Module {

    /// <summary>
    /// Registers the barcode generation services and components into the Autofac container.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="ContainerBuilder"/> used to configure the dependency injection container.
    /// </param>
    /// <remarks>
    /// This method ensures that the <see cref="BarcodeGenerator.LabelGeneration.BarcodeImageGenerator"/>
    /// is registered as the implementation for <see cref="BarcodeGenerator.LabelGeneration.IBarcodeImageGenerator"/>.
    /// </remarks>
    protected override void Load(ContainerBuilder builder) {
        builder.RegisterType<BarcodeImageGenerator>().As<IBarcodeImageGenerator>().SingleInstance();
    }
}