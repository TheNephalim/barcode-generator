// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Defines the contract for setting properties of an Excel worksheet.
/// </summary>
/// <remarks>
/// Implementations of this interface are responsible for configuring various properties
/// of a worksheet, such as headers, footers, page setup, and other related settings.
/// </remarks>
public interface IWorksheetPropertiesSetter {

    /// <summary>
    /// Configures and applies properties to the specified Excel worksheet.
    /// </summary>
    /// <param name="worksheet">The worksheet to configure.</param>
    /// <param name="reportName">The name of the report associated with the worksheet.</param>
    /// <param name="worksheetProperties">The properties to apply to the worksheet.</param>
    /// <remarks>
    /// This method is responsible for setting up various worksheet properties, such as freezing rows,
    /// repeating rows, and setting worksheet titles. It ensures that the worksheet is properly configured
    /// according to the provided <paramref name="worksheetProperties"/>.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="worksheet"/> or <paramref name="worksheetProperties"/> is <c>null</c>.
    /// </exception>
    void Set(IXLWorksheet worksheet, string reportName,
        WorksheetProperties worksheetProperties);
}