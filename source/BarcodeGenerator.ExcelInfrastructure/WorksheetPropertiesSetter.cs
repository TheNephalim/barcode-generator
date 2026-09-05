// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

// ReSharper disable UnusedType.Global

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Provides functionality to configure and set properties of an Excel worksheet.
/// </summary>
/// <remarks>
/// This class is responsible for setting up various worksheet properties, including headers, footers,
/// page setup, and other related configurations. It utilizes an instance of
/// <see cref="IWorksheetPageSetupPropertySetter"/> to handle page setup properties.
/// </remarks>
/// <seealso cref="IWorksheetPropertiesSetter" />
public class WorksheetPropertiesSetter : IWorksheetPropertiesSetter {
    /// <summary>
    /// The worksheet page setup property setter
    /// </summary>
    private readonly IWorksheetPageSetupPropertySetter _worksheetPageSetupPropertySetter;

    /// <summary>
    /// Initializes a new instance of the <see cref="WorksheetPropertiesSetter"/> class.
    /// </summary>
    /// <param name="worksheetPageSetupPropertySetter">
    /// An instance of <see cref="IWorksheetPageSetupPropertySetter"/> responsible for setting page setup properties of a worksheet.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="worksheetPageSetupPropertySetter"/> is <c>null</c>.
    /// </exception>
    public WorksheetPropertiesSetter(IWorksheetPageSetupPropertySetter worksheetPageSetupPropertySetter) {
        _worksheetPageSetupPropertySetter = worksheetPageSetupPropertySetter ?? throw new ArgumentNullException(nameof(worksheetPageSetupPropertySetter));
    }

    /// <summary>
    /// Configures and sets properties for the specified Excel worksheet.
    /// </summary>
    /// <param name="worksheet">The worksheet to configure.</param>
    /// <param name="reportName">The name of the report associated with the worksheet.</param>
    /// <param name="worksheetProperties">The properties to apply to the worksheet.</param>
    /// <remarks>
    /// This method utilizes the <see cref="IWorksheetPageSetupPropertySetter"/> to configure page setup properties
    /// and applies additional worksheet-specific configurations such as freezing rows, repeating rows, and setting titles.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="worksheet"/> or <paramref name="worksheetProperties"/> is <c>null</c>.
    /// </exception>
    public void Set(IXLWorksheet worksheet, string reportName,
        WorksheetProperties worksheetProperties) {
        _worksheetPageSetupPropertySetter.Set(worksheet, worksheetProperties);
    }
}