using Autofac;

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

        var builder = new ContainerBuilder();

        ModuleRegistrar.Register(builder);
        FormRegistrar.Register(builder);

        using var container = builder.Build();

        Application.Run(container.Resolve<MainForm>());
    }
}