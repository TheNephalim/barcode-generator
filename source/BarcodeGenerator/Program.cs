using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using BarcodeGenerator.Configuration;
using BarcodeGenerator.Data.Database;
using BarcodeGenerator.Data.Repositories;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BarcodeGenerator;

/// <summary>
/// Represents the entry point for the BarcodeGenerator application.
/// </summary>
/// <remarks>
/// This class contains the main logic to initialize and run the application.
/// </remarks>
internal static class Program {

    /// <summary>
    /// Serves as the main entry point for the BarcodeGenerator application.
    /// </summary>
    /// <remarks>
    /// This method initializes the application configuration and starts the main form of the BarcodeGenerator application.
    /// </remarks>
    [STAThread]
    private static void Main() {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var barcodeGeneratorConfiguration = configuration
            .GetSection(BarcodeGeneratorConfiguration.SectionName)
            .Get<BarcodeGeneratorConfiguration>() ?? new BarcodeGeneratorConfiguration();

        var builder = new ContainerBuilder();

        var thisAssembly = Assembly.GetExecutingAssembly();

        builder.RegisterInstance(barcodeGeneratorConfiguration)
            .AsSelf()
            .SingleInstance();

        builder.RegisterAssemblyTypes(thisAssembly)
                .Where<object, ScanningActivatorData, DynamicRegistrationStyle>(t => t.Name.EndsWith("Form"))
                .AsSelf()
                .InstancePerDependency();

        builder.Register(_ => {
            var folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BarcodeGenerator");

            Directory.CreateDirectory(folder);

            var databasePath = Path.Combine(folder, "barcode-generator.db");
            var connectionString = $"Data Source={databasePath}";
            return new SqliteConnectionFactory(connectionString);
        }).As<IDbConnectionFactory>()
            .SingleInstance();

        builder.RegisterType<InventorySourceRepository>()
            .As<IInventorySourceRepository>()
            .InstancePerDependency();

        builder.RegisterType<InventoryItemRepository>()
            .As<IInventoryItemRepository>()
            .InstancePerDependency();

        builder.RegisterType<InventorySkuRepository>()
            .As<IInventorySkuRepository>()
            .InstancePerDependency();

        builder.RegisterType<DatabaseInitializer>()
            .AsSelf()
            .InstancePerDependency();

        ModuleRegistrar.Register(builder);
        FormRegistrar.Register(builder);

        using var container = builder.Build();

        var initializer = container.Resolve<DatabaseInitializer>();
        initializer.Initialize();

        Application.Run(container.Resolve<MainForm>());
    }
}