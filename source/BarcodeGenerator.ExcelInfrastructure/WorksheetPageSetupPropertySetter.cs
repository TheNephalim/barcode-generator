// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure;

/// <summary>
/// Provides functionality to configure and set up page-related properties for an Excel worksheet.
/// </summary>
/// <remarks>
/// This class is responsible for setting up various properties of an Excel worksheet, such as margins,
/// page orientation, rows to repeat, and sheet view settings. It utilizes the ClosedXML library to
/// manipulate the worksheet's page setup and view configurations.
/// </remarks>
/// <seealso cref="IWorksheetPageSetupPropertySetter" />
public sealed class WorksheetPageSetupPropertySetter : IWorksheetPageSetupPropertySetter {

    /// <summary>
    /// Sets the specified worksheet.
    /// </summary>
    /// <param name="worksheet">The worksheet.</param>
    /// <param name="worksheetProperties">The worksheet properties.</param>
    public void Set(IXLWorksheet worksheet, WorksheetProperties worksheetProperties) {
        ArgumentNullException.ThrowIfNull(worksheet);
        ArgumentNullException.ThrowIfNull(worksheetProperties);

        var pageSetup = worksheet.PageSetup;
        var sheetView = worksheet.SheetView;
        var margins = pageSetup.Margins;

        SetRowsToReport(pageSetup, worksheetProperties.ShouldRepeatRows, worksheetProperties.RowsToRepeat);
        SetPageOrientation(pageSetup);
        SetMargins(margins);
        SetSheetView(sheetView, worksheetProperties.FreezeRow);
    }

    /// <summary>
    /// Sets the margins.
    /// </summary>
    /// <param name="margins">The margins.</param>
    private static void SetMargins(IXLMargins margins) {
        margins.Top = 0.75D;
        margins.Bottom = 0.75D;
        margins.Left = 0.7D;
        margins.Right = 0.7D;
        margins.Footer = 0.3D;
        margins.Header = 0.3D;
    }

    /// <summary>
    /// Sets the page orientation.
    /// </summary>
    /// <param name="pageSetup">The page setup.</param>
    private static void SetPageOrientation(IXLPageSetup pageSetup) {
        ArgumentNullException.ThrowIfNull(pageSetup);
        pageSetup.SetPageOrientation(XLPageOrientation.Landscape);
    }

    /// <summary>
    /// Sets the rows to report.
    /// </summary>
    /// <param name="pageSetup">The page setup.</param>
    /// <param name="shouldRepeatRows">if set to <c>true</c> [should repeat rows].</param>
    /// <param name="rowsToRepeat">The rows to repeat.</param>
    private static void SetRowsToReport(IXLPageSetup pageSetup, bool shouldRepeatRows, Tuple<int, int>? rowsToRepeat) {
        ArgumentNullException.ThrowIfNull(pageSetup);

        if (!shouldRepeatRows || rowsToRepeat is null) {
            return;
        }

        var (rowStart, rowEnd) = rowsToRepeat;
        pageSetup.SetRowsToRepeatAtTop(rowStart, rowEnd);
    }

    /// <summary>
    /// Configures the sheet view settings for the specified worksheet.
    /// </summary>
    /// <param name="sheetView">The sheet view to configure.</param>
    /// <param name="freezeRow">
    /// The row index to freeze. Rows above this index will remain visible when scrolling.
    /// </param>
    /// <remarks>
    /// This method sets the sheet view to normal mode and applies the specified freeze row setting.
    /// It utilizes the ClosedXML library's <see cref="IXLSheetView"/> to manipulate the view configuration.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="sheetView"/> is <c>null</c>.
    /// </exception>
    private static void SetSheetView(IXLSheetView sheetView, int freezeRow) {
        sheetView.SetView(XLSheetViewOptions.Normal);
        sheetView.Freeze(freezeRow, 0);
    }
}