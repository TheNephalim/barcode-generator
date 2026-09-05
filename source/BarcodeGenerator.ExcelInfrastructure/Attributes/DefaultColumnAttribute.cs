// ***********************************************************************
// Assembly         : BarcodeGenerator.Common
// Author           : Robert Eberhart
// Created          : 11-14-2016
// ***********************************************************************

using ClosedXML.Excel;

namespace BarcodeGenerator.ExcelInfrastructure.Attributes;

/// <summary>
/// Represents an attribute used to define default properties for an Excel column.
/// </summary>
/// <remarks>
/// This attribute is applied to properties to specify metadata such as display text,
/// column order, width, formatting style, and data type for generating Excel columns.
/// </remarks>
/// <seealso cref="IExcelColumnAttribute" />
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Property)]
public class DefaultColumnAttribute : Attribute, IExcelColumnAttribute {

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultColumnAttribute" /> class.
    /// </summary>
    /// <param name="displayText">The display text.</param>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="columnOrder">The column order.</param>
    /// <param name="columnWidth">The width of the Excel column</param>
    /// <param name="formatStyle">The formatting style for the data in the column.</param>
    /// <param name="excelDataType">The Excel data type.</param>
    public DefaultColumnAttribute(string displayText, string propertyName, int columnOrder, double columnWidth, string formatStyle, XLDataType excelDataType) {
        DisplayText = displayText;
        ColumnOrder = columnOrder;
        PropertyName = propertyName;
        ColumnWidth = columnWidth;
        FormatStyle = formatStyle;
        ExcelDataType = excelDataType;
    }

    /// <summary>
    /// Gets the column order.
    /// </summary>
    /// <value>The column order.</value>
    public int ColumnOrder { get; }

    /// <summary>
    /// The width of the Excel column in points.
    /// </summary>
    /// <value>The width of the Excel column.</value>
    public double ColumnWidth { get; }

    /// <summary>
    /// Gets the display text.
    /// </summary>
    /// <value>The display text.</value>
    public string DisplayText { get; }

    /// <summary>
    /// Gets the type of the excel data.
    /// </summary>
    /// <value>The type of the excel data.</value>
    public XLDataType ExcelDataType { get; }

    /// <summary>
    /// Gets the format style.
    /// </summary>
    /// <value>The format style.</value>
    public string FormatStyle { get; }

    /// <summary>
    /// Gets the name of the property.
    /// </summary>
    /// <value>The name of the property.</value>
    public string PropertyName { get; }
}