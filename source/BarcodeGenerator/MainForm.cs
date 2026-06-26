namespace BarcodeGenerator;

/// <summary>
/// Represents the main form of the Barcode Generator application.
/// </summary>
/// <remarks>
/// This class provides the user interface for generating barcodes,
/// including input fields for source code, start number, and end number.
/// </remarks>
public partial class MainForm : Form {
    private readonly Func<BarcodeLabelGenerator> _barcodeLabelGeneratorFactory;
    private readonly Func<PriceLabelGenerator> _pricingLabelGeneratorFormFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor sets up the main form of the Barcode Generator application
    /// by initializing its components and preparing the user interface for interaction.
    /// </remarks>
    public MainForm(
        Func<BarcodeLabelGenerator> barcodeLabelGeneratorFactory,
        Func<PriceLabelGenerator> pricingLabelGeneratorFormFactory
        ) {
        InitializeComponent();

        _barcodeLabelGeneratorFactory = barcodeLabelGeneratorFactory ?? throw new ArgumentNullException(nameof(barcodeLabelGeneratorFactory));
        _pricingLabelGeneratorFormFactory = pricingLabelGeneratorFormFactory ?? throw new ArgumentNullException(nameof(pricingLabelGeneratorFormFactory));
    }

    private void btnLaunchBarcodeLabelGenerator_Click(object sender, EventArgs e) {
        var form = _barcodeLabelGeneratorFactory();
        form.ShowDialog(this);
    }

    private void btnLaunchPriceLabelGenerator_Click(object sender, EventArgs e) {
        var form = _pricingLabelGeneratorFormFactory();
        form.ShowDialog(this);
    }

    /// <summary>
    /// Handles the <see cref="Form.Load"/> event of the <see cref="MainForm"/>.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method initializes the default values for the numeric up-down controls and the source code text box.
    /// Additionally, it displays a welcome message to the user when the form is loaded.
    /// </remarks>
    private void MainForm_Load(object sender, EventArgs e) {
    }
}