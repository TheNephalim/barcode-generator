using BarcodeGenerator.Entities;
using BarcodeGenerator.LabelGeneration;

namespace BarcodeGenerator;

/// <summary>
/// Represents the main form of the Barcode Generator application.
/// </summary>
/// <remarks>
/// This class provides the user interface for generating barcodes,
/// including input fields for source code, start number, and end number.
/// </remarks>
public partial class MainForm : Form {
    private readonly IBarcodeLabelGenerator _barcodeLabelGenerator;
    private readonly IRenderedBarcodeLabelGenerator _renderedBarcodeLabelGenerator;
    private readonly Dictionary<string, string> _sources = new() {
        { "PC", "Personal Collection" },
        { "GW", "Goodwill" },
        { "TS", "Thrift Store" },
        { "FB", "Facebook Marketplace" },
        { "ES", "Estate Sale" },
        { "LH", "Linda Hirschberg" },
        { "ETA", "Early Times Auction" },
        { "FM", "Fred Melby" },
        { "JW", "Jim Wood" },
        { "OT", "Other" }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor sets up the main form of the Barcode Generator application
    /// by initializing its components and preparing the user interface for interaction.
    /// </remarks>
    public MainForm(IRenderedBarcodeLabelGenerator renderedBarcodeLabelGenerator, IBarcodeLabelGenerator barcodeLabelGenerator) {
        if (barcodeLabelGenerator == null) throw new ArgumentNullException(nameof(barcodeLabelGenerator));
        InitializeComponent();

        _renderedBarcodeLabelGenerator =
            renderedBarcodeLabelGenerator ?? throw new ArgumentNullException(nameof(renderedBarcodeLabelGenerator));
        _barcodeLabelGenerator = barcodeLabelGenerator;
    }

    /// <summary>
    /// Validates the range of label indexes to ensure the start index is not greater than the end index.
    /// </summary>
    /// <param name="startIndex">The starting index of the label range.</param>
    /// <param name="endIndex">The ending index of the label range.</param>
    /// <returns>
    /// <c>true</c> if the start index is greater than the end index, indicating an invalid range;
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// Displays a warning message to the user if the range is invalid.
    /// </remarks>
    private static bool InvalidLabelIndexes(int startIndex, int endIndex) {
        if (startIndex > endIndex) {
            MessageBox.Show("Start number cannot be greater than end number",
                "Invalid Range",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Handles the click event of the <see cref="btnGenerate"/> button.
    /// Generates barcode labels based on the specified start and end indexes, source code, and purchase date.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="btnGenerate"/> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method validates the input indexes and generates barcode labels if the validation passes.
    /// A message box is displayed upon successful generation.
    /// </remarks>
    private void btnGenerate_Click(object sender, EventArgs e) {
        var sourceCode = cmboSources.SelectedValue?.ToString();
        var datePurchased = monthCalendar1.SelectionStart;

        var startIndex = Convert.ToInt32(nudStartNumber.Value);
        var endIndex = Convert.ToInt32(nudEndNumber.Value);

        if (InvalidLabelIndexes(startIndex, endIndex)) return;

        if (string.IsNullOrEmpty(sourceCode)) {
            MessageBox.Show("Please select a source code.",
                "Missing Source",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        var barcodes = GenerateBarcodes(startIndex, endIndex, sourceCode, datePurchased);

        MessageBox.Show("Generate!", "Information", MessageBoxButtons.OKCancel);
    }

    /// <summary>
    /// Generates a list of rendered barcode labels based on the specified range, source code, and purchase date.
    /// </summary>
    /// <param name="startIndex">The starting index for generating barcode labels.</param>
    /// <param name="endIndex">The ending index for generating barcode labels.</param>
    /// <param name="sourceCode">The source code associated with the barcode labels. Can be <c>null</c>.</param>
    /// <param name="datePurchased">The purchase date to be included in the barcode labels.</param>
    /// <returns>A list of <see cref="RenderedBarcodeLabel"/> objects representing the generated barcode labels.</returns>
    /// <remarks>
    /// This method first generates barcode labels using the <see cref="IBarcodeLabelGenerator"/> implementation.
    /// It then converts these labels into rendered barcode labels using the <see cref="IRenderedBarcodeLabelGenerator"/> implementation.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="sourceCode"/> is <c>null</c>.</exception>
    private IList<RenderedBarcodeLabel> GenerateBarcodes(int startIndex, int endIndex, string sourceCode, DateTime datePurchased) {
        var barcodeLabels = _barcodeLabelGenerator.Generate(startIndex, endIndex, sourceCode, datePurchased);
        return _renderedBarcodeLabelGenerator.Generate(barcodeLabels);
    }

    /// <summary>
    /// Initializes the numeric up-down controls with default values.
    /// </summary>
    /// <remarks>
    /// This method sets the default values for the <see cref="nudStartNumber"/> and <see cref="nudEndNumber"/> controls.
    /// The default value for <see cref="nudStartNumber"/> is set to 1, and for <see cref="nudEndNumber"/> is set to 100.
    /// </remarks>
    private void InitializeNumericControls() {
        // Set default values for numeric up-down controls
        nudStartNumber.Value = 1;
        nudEndNumber.Value = 100;
    }

    private void label1_Click(object sender, EventArgs e) {
        MessageBox.Show("Label clicks");
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
        InitializeNumericControls();

        PopulateSourceDropdown();
    }

    /// <summary>
    /// Populates the source dropdown with a list of predefined sources.
    /// </summary>
    /// <remarks>
    /// This method binds the <see cref="ComboBox"/> control <see cref="cmboSources"/> to a list of sources
    /// defined in the <see cref="_sources"/> dictionary. The display member is set to the source description,
    /// and the value member is set to the source key.
    /// </remarks>
    private void PopulateSourceDropdown() {
        cmboSources.DataSource = _sources.ToList();
        cmboSources.DisplayMember = "Value";
        cmboSources.ValueMember = "Key";
    }
}