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
    private readonly Func<InventorySourceMaintenance> _inventorySourceMaintenanceFactory;
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
        Func<PriceLabelGenerator> pricingLabelGeneratorFormFactory,
        Func<InventorySourceMaintenance> inventorySourceMaintenanceFactory) {
        InitializeComponent();

        _barcodeLabelGeneratorFactory = barcodeLabelGeneratorFactory ?? throw new ArgumentNullException(nameof(barcodeLabelGeneratorFactory));
        _pricingLabelGeneratorFormFactory = pricingLabelGeneratorFormFactory ?? throw new ArgumentNullException(nameof(pricingLabelGeneratorFormFactory));
        _inventorySourceMaintenanceFactory = inventorySourceMaintenanceFactory ?? throw new ArgumentNullException(nameof(inventorySourceMaintenanceFactory));
    }

    /// <summary>
    /// Handles the <see cref="Button.Click"/> event for the "Launch Barcode Label Generator" button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the button that was clicked.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method initializes and displays the Barcode Label Generator form as a modal dialog.
    /// </remarks>
    private void btnLaunchBarcodeLabelGenerator_Click(object sender, EventArgs e) {
        var form = _barcodeLabelGeneratorFactory();
        form.ShowDialog(this);
    }

    /// <summary>
    /// Handles the click event for the "Launch Price Label Generator" button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the button that was clicked.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method creates an instance of the price label generator form using the factory
    /// and displays it as a modal dialog.
    /// </remarks>
    private void btnLaunchPriceLabelGenerator_Click(object sender, EventArgs e) {
        var form = _pricingLabelGeneratorFormFactory();
        form.ShowDialog(this);
    }

    /// <summary>
    /// Handles the <c>Click</c> event of the <c>exitToolStripMenuItem</c>.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method closes the current form when the exit menu item is clicked.
    /// </remarks>
    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
        Close();
    }

    private void inventorySourcesToolStripMenuItem_Click(object sender, EventArgs e) {
        var form = _inventorySourceMaintenanceFactory();
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