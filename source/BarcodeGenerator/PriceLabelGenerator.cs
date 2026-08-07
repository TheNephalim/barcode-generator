using BarcodeGenerator.Entities;
using BarcodeGenerator.LabelGeneration;

namespace BarcodeGenerator;

/// <summary>
/// Represents a form for generating price labels in the Barcode Generator application.
/// </summary>
/// <remarks>
/// The <see cref="BarcodeGenerator.PriceLabelGenerator"/> class provides functionality for creating
/// and managing price labels, including initializing components and populating various combo boxes
/// for price, sleeve condition, and vinyl condition.
/// </remarks>
public partial class PriceLabelGenerator : Form {
    private readonly Dictionary<string, string> _conditions = new() {
        { "None", "None" },
        { "M", "M" },
        { "M-", "M-" },
        { "VG+", "VG+" },
        { "VG", "VG" },
        { "VG-", "VG-" },
        { "G+", "G+" },
        { "G-", "G-" },
        { "F", "F" },
        { "P", "P" }
    };

    private readonly ILabelPrinter _labelPrinter;

    /// <summary>
    /// Initializes a new instance of the <see cref="BarcodeGenerator.PriceLabelGenerator"/> class.
    /// </summary>
    /// <param name="labelPrinter">
    /// An instance of <see cref="BarcodeGenerator.LabelGeneration.ILabelPrinterFactory"/> used to create label printers.
    /// </param>
    /// <exception cref="System.ArgumentNullException">
    /// Thrown when <paramref name="labelPrinter"/> is <c>null</c>.
    /// </exception>
    public PriceLabelGenerator(ILabelPrinter labelPrinter) {
        _labelPrinter = labelPrinter ?? throw new ArgumentNullException(nameof(labelPrinter));
        InitializeComponent();

        PopulateSleeveConditionComboBox();
        PopulateVinylConditionComboBox();
        PopulatePriceComboBox();
    }

    /// <summary>
    /// Creates a new <see cref="LabelPrintJob"/> instance configured with the specified number of copies
    /// and a single pricing label.
    /// </summary>
    /// <param name="copies">The number of copies to print.</param>
    /// <param name="pricingLabel">The <see cref="PricingLabel"/> to be included in the print job.</param>
    /// <returns>
    /// A <see cref="LabelPrintJob"/> instance containing the specified number of copies, the provided
    /// pricing label, and default settings for label size and template type.
    /// </returns>
    /// <remarks>
    /// This method initializes a <see cref="LabelPrintJob"/> with a default label size of 100x100 and
    /// a template type of <see cref="LabelTemplateType.OneInchRound"/>.
    /// </remarks>
    private static LabelPrintJob CreateLabelPrintJob(int copies, PricingLabel pricingLabel) {
        var printJob = new LabelPrintJob() {
            Copies = copies,
            Labels = new List<IPrintableLabel>() { pricingLabel },
            LabelSize = new LabelSize() { Width = 100, Height = 100 },
            TemplateType = LabelTemplateType.OneInchRound
        };
        return printJob;
    }

    /// <summary>
    /// Generates a <see cref="PricingLabel"/> with the specified price, vinyl condition, sleeve condition,
    /// and an option to include condition details.
    /// </summary>
    /// <param name="price">The price to be displayed on the label.</param>
    /// <param name="vinylCondition">The condition of the vinyl, or <c>null</c> if not specified.</param>
    /// <param name="sleeveCondition">The condition of the sleeve, or <c>null</c> if not specified.</param>
    /// <param name="printCondition">
    /// A value indicating whether the condition details (vinyl and sleeve) should be included on the label.
    /// </param>
    /// <returns>A <see cref="PricingLabel"/> object populated with the specified details.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if any required parameter is <c>null</c> or invalid.
    /// </exception>
    private static PricingLabel GeneratePricingLabel(decimal price, string? vinylCondition, string? sleeveCondition,
        bool printCondition) {
        var pricingLabel = new PricingLabel() {
            Price = price,
            VinylCondition = vinylCondition,
            SleeveCondition = sleeveCondition,
            IncludeCondition = printCondition
        };
        return pricingLabel;
    }

    /// <summary>
    /// Handles the <see cref="Button.Click"/> event for the <c>btnClose</c> button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <c>btnClose</c> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method closes the current form when the <c>btnClose</c> button is clicked.
    /// </remarks>
    private void btnClose_Click(object sender, EventArgs e) {
        this.Close();
    }

    /// <summary>
    /// Handles the click event of the <c>btnPrint</c> button.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method retrieves user input values such as the number of copies, price, custom price,
    /// vinyl and sleeve conditions, and a print condition. It generates a pricing label and
    /// creates a print job, which is then sent to the printer.
    /// </remarks>
    private void btnPrint_Click(object sender, EventArgs e) {
        var copies = (int)numericUpDown1.Value;
        var price = Convert.ToDecimal(cmboPrice.SelectedValue);
        var customPrice = decimal.TryParse(mtbCustomPrice.Text, out var decimalPrice) ? (decimal?)decimalPrice : null;
        var vinylCondition = cmboSleeveCondition.SelectedValue?.ToString();
        var sleeveCondition = cmboVinylCondition.SelectedValue?.ToString();
        var printCondition = checkBox1.Checked;

        var pricingLabel = GeneratePricingLabel(price, vinylCondition, sleeveCondition, printCondition);
        var printJob = CreateLabelPrintJob(copies, pricingLabel);

        _labelPrinter.Print(printJob);
    }

    /// <summary>
    /// Populates the price combo box with a predefined list of price options.
    /// </summary>
    /// <remarks>
    /// This method initializes the price combo box (<see cref="cmboPrice"/>) with a default "None" option
    /// and a range of price options in $5 increments, starting from $5 up to $100.
    /// The combo box is configured to display the text representation of each price option
    /// and use the corresponding value for selection.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the combo box <see cref="cmboPrice"/> is not properly initialized.
    /// </exception>
    private void PopulatePriceComboBox() {
        var prices = new List<PriceOption>() {
            new() {
                Value = null,
                DisplayText = "None"
            }
        };

        for (var price = 5; price <= 100; price += 5) {
            prices.Add(new PriceOption {
                Value = price,
                DisplayText = $"${price}"
            });
        }

        cmboPrice.DataSource = prices;
        cmboPrice.DisplayMember = "DisplayText";
        cmboPrice.ValueMember = "Value";
    }

    /// <summary>
    /// Populates the sleeve condition combo box with predefined condition values.
    /// </summary>
    /// <remarks>
    /// The combo box is populated using a dictionary of condition values, where the keys represent
    /// internal identifiers and the values represent display text. The data source, display member,
    /// and value member of the combo box are configured accordingly.
    /// </remarks>
    private void PopulateSleeveConditionComboBox() {
        cmboSleeveCondition.DataSource = new BindingSource(_conditions, null);
        cmboSleeveCondition.DisplayMember = "Value";
        cmboSleeveCondition.ValueMember = "Key";
    }

    /// <summary>
    /// Populates the vinyl condition combo box with a predefined set of vinyl condition values.
    /// </summary>
    /// <remarks>
    /// The combo box is populated using a dictionary of key-value pairs where the key represents
    /// the internal value and the value represents the display text. This method binds the dictionary
    /// to the combo box as its data source, setting the display and value members appropriately.
    /// </remarks>
    private void PopulateVinylConditionComboBox() {
        cmboVinylCondition.DataSource = new BindingSource(_conditions, null);
        cmboVinylCondition.DisplayMember = "Value";
        cmboVinylCondition.ValueMember = "Key";
    }
}