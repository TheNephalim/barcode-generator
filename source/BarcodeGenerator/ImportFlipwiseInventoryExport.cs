using BarcodeGenerator.Data.Repositories;
using BarcodeGenerator.Entities;
using BarcodeGenerator.Entities.ClassMaps;
using CsvHelper;
using CsvHelper.TypeConversion;
using System.ComponentModel;
using System.Globalization;

// ReSharper disable ClassNeverInstantiated.Global

namespace BarcodeGenerator;

/// <summary>
/// Represents a form for importing inventory export data from Flipwise.
/// </summary>
/// <remarks>
/// This class is part of the BarcodeGenerator application and is registered as a dependency
/// in the <see cref="FormRegistrar"/>. It is designed to provide functionality for handling
/// Flipwise inventory export operations.
/// </remarks>
public partial class ImportFlipwiseInventoryExport : Form {
    private readonly IInventoryItemRepository _inventoryItemRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportFlipwiseInventoryExport"/> class.
    /// </summary>
    /// <param name="inventoryItemRepository">
    /// An instance of <see cref="IInventoryItemRepository"/> used for managing inventory items.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="inventoryItemRepository"/> is <c>null</c>.
    /// </exception>
    public ImportFlipwiseInventoryExport(IInventoryItemRepository inventoryItemRepository) {
        _inventoryItemRepository = inventoryItemRepository ?? throw new ArgumentNullException(nameof(inventoryItemRepository));
        InitializeComponent();
    }

    /// <summary>
    /// Handles the Click event of the <see cref="btnClearData"/> button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="btnClearData"/> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method clears the data displayed in the <see cref="dataGridView1"/> by setting its data source to <c>null</c>.
    /// </remarks>
    private void btnClearData_Click(object sender, EventArgs e) {
        dataGridView1.DataSource = null;
    }

    /// <summary>
    /// Handles the Click event of the <see cref="btnCloseWindow"/> button.
    /// Closes the current form when the button is clicked.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    private void btnCloseWindow_Click(object sender, EventArgs e) {
        Close();
    }

    /// <summary>
    /// Handles the click event of the <see cref="btnCommitImport"/> button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="Button"/> that was clicked.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method retrieves the data from the <see cref="dataGridView1"/> control,
    /// attempts to import it into the database asynchronously using the <see cref="_inventoryItemRepository"/>,
    /// and displays an error message if the operation fails.
    /// </remarks>
    private async void btnCommitImport_Click(object sender, EventArgs e) {
        try {
            var recordList = (BindingList<InventoryItem>)dataGridView1.DataSource;
            var importResults = await _inventoryItemRepository.ImportAsync(recordList);
            MessageBox.Show(
                $"Import complete: {importResults.RecordsAdded} added, {importResults.RecordsProcessed} processed, {importResults.RecordsSkipped} skipped.",
                "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = null; // Clear the grid after successful import
        } catch (Exception exception) {
            MessageBox.Show("Could not commit data to database.", "Error Committing to Database", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Handles the click event of the <see cref="btnOpenFlipwiseExport"/> button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="btnOpenFlipwiseExport"/> button.</param>
    /// <param name="e">An instance of <see cref="EventArgs"/> containing event data.</param>
    /// <remarks>
    /// This method opens a file dialog to allow the user to select a Flipwise export file.
    /// It reads the selected file, parses its content using <see cref="CsvReader"/>, and binds the parsed data
    /// to the <see cref="dataGridView1"/> control for display.
    /// </remarks>
    private void btnOpenFlipwiseExport_Click(object sender, EventArgs e) {
        openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;
        openFileDialog1.FileName = string.Empty;
        openFileDialog1.DefaultExt = "csv";

        if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

        var filePath = openFileDialog1.FileName;

        try {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<FlipwiseInventoryItemClassMap>();

            var records = csv.GetRecords<InventoryItem>().ToList();
            if (records.Count == 0) {
                MessageBox.Show("The selected file did not contain any inventory records.",
                    "No Records Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var bindingSource = new BindingList<InventoryItem>(records);
            dataGridView1.DataSource = bindingSource;
        } catch (FileNotFoundException) {
            MessageBox.Show("The selected file could not be found.  It may have been removed or deleted.",
                "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } catch (UnauthorizedAccessException) {
            MessageBox.Show("You do not have permission to read the selected file.",
                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } catch (HeaderValidationException ex) {
            MessageBox.Show(
                "The selected CSV file does not contain the expected Flipwise columns.\n\n" +
                "Please make sure you selected a Flipwise inventory export.",
                "Invalid Flipwise Export",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        } catch (TypeConverterException ex) {
            var row = ex.Context?.Parser?.Row;

            MessageBox.Show(
                $"A value in row {row} could not be converted to the expected data type.\n\n" +
                $"{ex.Message}",
                "Invalid Data",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        } catch (CsvHelperException ex) {
            MessageBox.Show(
                $"The selected file could not be imported because it contains invalid or unexpected CSV data.\n\n" +
                $"Row: {ex.Context?.Parser?.Row}\n" +
                $"{ex.Message}",
                "CSV Import Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        } catch (Exception ex) {
            MessageBox.Show(
                $"An unexpected error occurred while importing the inventory file.\n\n{ex.Message}",
                "Import Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}