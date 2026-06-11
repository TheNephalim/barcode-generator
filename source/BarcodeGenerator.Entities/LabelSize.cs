// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents the dimensions of a label, including its length and width.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and is used to define the size of a label.
/// It is commonly utilized in conjunction with other classes, such as <see cref="LabelPrintJob"/>, to specify label dimensions.
/// </remarks>
public class LabelSize {
    /// <summary>
    /// Gets or sets the height of the label.
    /// </summary>
    /// <value>
    /// The height of the label, typically measured in printer units (e.g., hundredths of an inch).
    /// </value>
    /// <remarks>
    /// This property is used to define the vertical dimension of a label. It is commonly utilized
    /// in conjunction with the <see cref="Width"/> property to specify the overall size of a label.
    /// For example, it is used in <see cref="LabelPrintJob"/> to configure label dimensions for printing.
    /// </remarks>
    public int Height { get; set; }

    /// <summary>
    /// Gets or sets the width of the label.
    /// </summary>
    /// <value>
    /// The width of the label, typically measured in units such as millimeters or inches.
    /// </value>
    /// <remarks>
    /// This property is used to define the horizontal dimension of the label.
    /// Ensure that the value is consistent with the intended label size and printing requirements.
    /// </remarks>
    public int Width { get; set; }
}