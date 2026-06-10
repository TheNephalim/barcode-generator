// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality to build instances of <see cref="BarcodeGenerator.Entities.BarcodeLabel"/>.
/// </summary>
/// <remarks>
/// This class allows for the step-by-step construction of a <see cref="BarcodeGenerator.Entities.BarcodeLabel"/>
/// by setting properties such as the purchase date, label index, and source code.
/// It ensures that the resulting barcode label is properly configured before being created.
/// </remarks>
public sealed class BarcodeLabelBuilder {
    private DateTime _datePurchased;
    private int _index;
    private string _source = "None";

    /// <summary>
    /// Builds and returns a new instance of <see cref="BarcodeGenerator.Entities.BarcodeLabel"/>
    /// with the configured properties.
    /// </summary>
    /// <returns>
    /// A new instance of <see cref="BarcodeGenerator.Entities.BarcodeLabel"/>
    /// containing the purchase date, label index, and source code.
    /// </returns>
    /// <remarks>
    /// The method uses the properties set via the builder methods to construct a properly
    /// configured <see cref="BarcodeGenerator.Entities.BarcodeLabel"/>.
    /// Ensure that all required properties are set before calling this method.
    /// </remarks>
    public BarcodeLabel Build() {
        var barcodeLabel = new BarcodeLabel() {
            SourceCode = _source,
            DatePurchased = _datePurchased.ToString("yyyyMMdd"),
            LabelIndex = _index.ToString().PadLeft(5, '0')
        };

        return barcodeLabel;
    }

    /// <summary>
    /// Sets the purchase date for the barcode label being built.
    /// </summary>
    /// <param name="datePurchased">The date the item was purchased.</param>
    /// <returns>The current instance of <see cref="BarcodeLabelBuilder"/> to allow method chaining.</returns>
    public BarcodeLabelBuilder WithDatePurchased(DateTime datePurchased) {
        _datePurchased = datePurchased;
        return this;
    }

    /// <summary>
    /// Sets the index for the barcode label being built.
    /// </summary>
    /// <param name="index">The index to assign to the barcode label. Must be greater than zero.</param>
    /// <returns>The current instance of <see cref="BarcodeLabelBuilder"/> to allow method chaining.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index"/> is less than or equal to zero.</exception>
    public BarcodeLabelBuilder WithIndex(int index) {
        if (index <= 0) throw new ArgumentOutOfRangeException(nameof(index));

        _index = index;

        return this;
    }

    /// <summary>
    /// Sets the source for the barcode label being built.
    /// </summary>
    /// <param name="source">The source to assign to the barcode label. Cannot be null or empty.</param>
    /// <returns>The current instance of <see cref="BarcodeLabelBuilder"/> to allow method chaining.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is null or empty.</exception>
    public BarcodeLabelBuilder WithSource(string source) {
        if (string.IsNullOrEmpty(source)) {
            throw new ArgumentException("Source is required", nameof(source));
        }

        _source = source;

        return this;
    }
}