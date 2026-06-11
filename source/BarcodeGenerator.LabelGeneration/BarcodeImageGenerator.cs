// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************

using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

#pragma warning disable CA1416

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality to generate barcode images, specifically for Code 128 format.
/// </summary>
/// <remarks>
/// This class utilizes the ZXing library to create barcode images.
/// It is designed to produce high-quality barcodes with customizable dimensions and margins.
/// </remarks>
public sealed class BarcodeImageGenerator : IBarcodeImageGenerator {

    /// <summary>
    /// Generates a Code 128 barcode image as a <see cref="Bitmap"/>.
    /// </summary>
    /// <param name="barcodeValue">
    /// The value to encode in the barcode. This must not be <see langword="null"/> or empty.
    /// </param>
    /// <returns>
    /// A <see cref="Bitmap"/> representing the generated Code 128 barcode.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="barcodeValue"/> is <see langword="null"/> or empty.
    /// </exception>
    /// <remarks>
    /// This method uses the ZXing library to generate a Code 128 barcode image with predefined dimensions and margins.
    /// </remarks>
    public Bitmap GenerateCode128(string barcodeValue) {
        if (string.IsNullOrEmpty(barcodeValue)) {
            throw new ArgumentException("Barcode value is required", nameof(barcodeValue));
        }

        var writer = new BarcodeWriter<Bitmap>() {
            Format = BarcodeFormat.CODE_128,
            Options = new EncodingOptions() {
                Height = 80,
                Width = 300,
                Margin = 10,
                PureBarcode = false
            },
            Renderer = new BitmapRenderer()
        };

        return writer.Write(barcodeValue);
    }

    /// <summary>
    /// Saves a Code 128 barcode as a PNG image file.
    /// </summary>
    /// <param name="barcodeValue">
    /// The value to encode in the barcode. This must not be <see langword="null"/> or empty.
    /// </param>
    /// <param name="filePath">
    /// The file path where the PNG image will be saved. This must not be <see langword="null"/> or empty.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="barcodeValue"/> or <paramref name="filePath"/> is <see langword="null"/> or empty.
    /// </exception>
    /// <remarks>
    /// This method generates a Code 128 barcode using the specified value and saves it as a PNG image
    /// to the specified file path. The barcode is created with predefined dimensions and margins.
    /// </remarks>
    public void SaveCode128Png(string barcodeValue, string filePath) {
        using var bitmap = GenerateCode128(barcodeValue);
        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
    }
}