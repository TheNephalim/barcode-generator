// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-10-2026
// ***********************************************************************

using System.Drawing;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Defines methods for generating and saving barcode images in the Code 128 format.
/// </summary>
/// <remarks>
/// Implementations of this interface are expected to provide functionality for creating
/// high-quality barcode images and saving them in various formats. The ZXing library
/// is typically used for barcode generation.
/// </remarks>
public interface IBarcodeImageGenerator {

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
    Bitmap GenerateCode128(string barcodeValue);

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
    void SaveCode128Png(string barcodeValue, string filePath);
}