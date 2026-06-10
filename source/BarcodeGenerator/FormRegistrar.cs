// ***********************************************************************
// Assembly          : BarcodeGenerator
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************
// <copyright file="FormRegistrar.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using Autofac;

namespace BarcodeGenerator;

/// <summary>
/// Provides methods for registering forms in the Barcode Generator application.
/// </summary>
/// <remarks>
/// This class is responsible for registering form types, such as <see cref="MainForm"/>,
/// into the dependency injection container using Autofac.
/// </remarks>
public static class FormRegistrar {

    /// <summary>
    /// Registers the necessary forms into the dependency injection container.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="ContainerBuilder"/> instance used to configure the Autofac container.
    /// </param>
    /// <remarks>
    /// This method registers form types, such as <see cref="MainForm"/>, into the Autofac container
    /// to enable dependency injection throughout the Barcode Generator application.
    /// </remarks>
    public static void Register(ContainerBuilder builder) {
        builder
            .RegisterType<MainForm>()
            .AsSelf()
            .InstancePerDependency();
    }
}