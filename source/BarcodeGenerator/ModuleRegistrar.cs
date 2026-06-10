// ***********************************************************************
// Assembly          : BarcodeGenerator
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************

using Autofac;
using BarcodeGenerator.AutofacConfiguration;

namespace BarcodeGenerator;

/// <summary>
/// Provides methods to register services and dependencies required for the barcode generation functionality.
/// </summary>
/// <remarks>
/// This static class is responsible for configuring the dependency injection container by registering
/// the necessary modules and components. It utilizes the Autofac library to ensure that all required
/// services, such as those defined in <see cref="BarcodeGenerator.AutofacConfiguration.ConfigureBarcodeGeneration"/>,
/// are properly registered and available for use.
/// </remarks>
public static class ModuleRegistrar {

    /// <summary>
    /// Registers the necessary modules and components for barcode generation into the provided
    /// Autofac <see cref="ContainerBuilder"/>.
    /// </summary>
    /// <param name="containerBuilder">
    /// The <see cref="ContainerBuilder"/> instance used to configure the dependency injection container.
    /// </param>
    /// <remarks>
    /// This method identifies the assembly containing the <see cref="BarcodeGenerator.AutofacConfiguration.ConfigureBarcodeGeneration"/>
    /// module and registers all modules within that assembly. It ensures that all required services for barcode generation,
    /// such as implementations of <see cref="BarcodeGenerator.LabelGeneration.IBarcodeImageGenerator"/>, are properly configured
    /// and available for dependency injection.
    /// </remarks>
    public static void Register(ContainerBuilder containerBuilder) {
        var assembly = typeof(ConfigureBarcodeGeneration).Assembly;
        containerBuilder.RegisterAssemblyModules(assembly);
    }
}