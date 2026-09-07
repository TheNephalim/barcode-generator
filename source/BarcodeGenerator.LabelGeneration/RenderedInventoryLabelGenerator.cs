using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides functionality to generate rendered inventory labels, which include barcode images
/// and associated inventory details.
/// </summary>
/// <remarks>
/// This class is responsible for creating inventory labels that combine barcode images
/// generated using <see cref="IBarcodeImageGenerator"/> with metadata from inventory items.
/// It implements the <see cref="IRenderedInventoryLabelGenerator"/> interface.
/// </remarks>
public class RenderedInventoryLabelGenerator : IRenderedInventoryLabelGenerator {
    private const int BarcodeHeight = 100;
    private const int BarcodeWidth = 400;
    private readonly IBarcodeImageGenerator _barcodeImageGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="RenderedInventoryLabelGenerator"/> class.
    /// </summary>
    /// <param name="barcodeImageGenerator">
    /// An implementation of <see cref="IBarcodeImageGenerator"/> used to generate barcode images.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="barcodeImageGenerator"/> is <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// This constructor sets up the <see cref="RenderedInventoryLabelGenerator"/> with the necessary
    /// dependency for generating barcode images, which is essential for creating rendered inventory labels.
    /// </remarks>
    public RenderedInventoryLabelGenerator(IBarcodeImageGenerator barcodeImageGenerator) {
        _barcodeImageGenerator = barcodeImageGenerator ?? throw new ArgumentNullException(nameof(barcodeImageGenerator));
    }

    /// <summary>
    /// Generates a rendered inventory label that includes a barcode image and associated inventory label details.
    /// </summary>
    /// <param name="label">
    /// The <see cref="BarcodeGenerator.Entities.InventoryLabel"/> containing the SKU and other details
    /// of the inventory item to be rendered.
    /// </param>
    /// <returns>
    /// A <see cref="BarcodeGenerator.Entities.RenderedInventoryLabel"/> instance that encapsulates the barcode image
    /// and metadata for the inventory label.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when the <paramref name="label"/> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method uses the <see cref="BarcodeGenerator.LabelGeneration.IBarcodeImageGenerator"/> to generate
    /// a Code 128 barcode image for the provided SKU and combines it with the inventory label details
    /// to create a fully rendered inventory label.
    /// </remarks>
    public RenderedInventoryLabel Generate(InventoryLabel label) {
        ArgumentNullException.ThrowIfNull(label);

        _barcodeImageGenerator.SaveCode128Png(
            "f4f70e1600",
            @"C:\Temp\barcode.png");

        var barcodeImage = _barcodeImageGenerator.GenerateCode128(label.Sku, BarcodeWidth, BarcodeHeight);

        return new RenderedInventoryLabel() {
            Label = label,
            BarcodeImage = barcodeImage
        };
    }
}