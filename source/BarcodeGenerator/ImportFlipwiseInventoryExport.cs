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
    private readonly IInventorySkuRepository _inventorySkuRepository;
    private readonly IInventorySourceRepository _sourceRepository;
    private IList<InventoryImportRow> _allInventoryItems = new List<InventoryImportRow>();
    private HashSet<string> _existingSkus = new(StringComparer.OrdinalIgnoreCase);
    private HashSet<string> _existingSourceRecordIds = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Initializes a new instance of the <see cref="ImportFlipwiseInventoryExport"/> class.
    /// </summary>
    /// <param name="inventoryItemRepository">
    /// An instance of <see cref="IInventoryItemRepository"/> used for managing inventory items.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="inventoryItemRepository"/> is <c>null</c>.
    /// </exception>
    public ImportFlipwiseInventoryExport(IInventoryItemRepository inventoryItemRepository, IInventorySourceRepository sourceRepository, IInventorySkuRepository inventorySkuRepository) {
        _inventoryItemRepository = inventoryItemRepository ?? throw new ArgumentNullException(nameof(inventoryItemRepository));
        _sourceRepository = sourceRepository ?? throw new ArgumentNullException(nameof(sourceRepository));
        _inventorySkuRepository = inventorySkuRepository ?? throw new ArgumentNullException(nameof(inventorySkuRepository));
        InitializeComponent();
    }

    private static InventoryImportStatus? GetSelectedStatus(string? value) {
        return value switch {
            "Ready" => InventoryImportStatus.Ready,
            "Duplicate Source Record" => InventoryImportStatus.DuplicateSourceRecord,
            "SKU Conflict" => InventoryImportStatus.SkuConflict,
            "Source Unassigned" => InventoryImportStatus.SourceUnassigned,
            _ => null
        };
    }

    /// <summary>
    /// Applies the current filter criteria to the inventory items and updates the data grid with the filtered results.
    /// </summary>
    /// <remarks>
    /// This method filters the inventory items based on the input provided in the filter text box,
    /// the selected source, and the selected status. The filtered results are then displayed in the data grid.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if any required dependencies or controls are not properly initialized.
    /// </exception>
    private void ApplyFilter() {
        var filter = txtFilterInput.Text.Trim();

        IEnumerable<InventoryImportRow> filteredItems = _allInventoryItems;

        if (!string.IsNullOrWhiteSpace(filter)) {
            filteredItems = _allInventoryItems.Where(
                x => (x.Item.CustomSku?.Contains(filter, StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                     (x.Item.Product?.Contains(filter, StringComparison.InvariantCultureIgnoreCase) ?? false));
        }

        var selectedStatus = GetSelectedStatus(cmbStatus.SelectedItem?.ToString());

        if (selectedStatus.HasValue) {
            filteredItems = filteredItems.Where(x => x.Status == selectedStatus.Value);
        }

        if (cmbFilterSource.SelectedItem is InventorySource source) {
            filteredItems = filteredItems.Where(x => x.InventorySourceId == source.Id);
        }

        dataGridView1.DataSource =
            new BindingList<InventoryImportRow>([.. filteredItems]);
    }

    /// <summary>
    /// Handles the click event for the "Apply to Selected" button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the button that was clicked.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method validates the selected inventory source and SKU prefix, retrieves the last assigned SKU number,
    /// and generates proposed SKUs for the selected inventory items. It also updates the status of each item
    /// and applies the current filter to the inventory list.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the inventory source is not selected or the SKU prefix is invalid.
    /// </exception>
    private async void btnApplyToSelected_Click(object sender, EventArgs e) {
        var skuPrefix = txtAssignPrefix.Text.Trim();
        var selectedSource = cmbAssignSource.SelectedItem as InventorySource;

        if (selectedSource is null) {
            MessageBox.Show("Please select an inventory source.", "Source Not Selected", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(skuPrefix) || skuPrefix.Length > 3) {
            MessageBox.Show("Please enter a valid SKU prefix (max 3 characters).", "Invalid SKU Prefix",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var sourceId = selectedSource.Id;
        var sourceCode = selectedSource.Code;

        var lastNumber = await _inventorySkuRepository.GetLastAssignedSkuNumberAsync(skuPrefix, sourceId) ?? 0;
        var nextNumber = lastNumber + 1;

        var selectedRecords = _allInventoryItems
            .Where(x => x.IsSelected)
            .ToList();

        foreach (var record in selectedRecords) {
            record.InventorySourceId = sourceId;
            record.InventorySourceCode = sourceCode;

            if (string.IsNullOrWhiteSpace(record.Item.CustomSku)) {
                record.ProposedSku = $"{skuPrefix}-{sourceCode}-{nextNumber:D5}";
                nextNumber++;
            } else {
                record.ProposedSku = null;
            }

            record.Status = DetermineStatus(record);
        }

        ApplyFilter();
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
        _allInventoryItems.Clear();
        dataGridView1.DataSource = null;
    }

    /// <summary>
    /// Handles the <c>Click</c> event of the <c>btnClearFilters</c> button.
    /// Clears all filter inputs and resets the filter controls to their default state.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <c>btnClearFilters</c> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    private void btnClearFilters_Click(object sender, EventArgs e) {
        txtFilterInput.Text = null;
        cmbFilterSource.SelectedIndex = -1;
        cmbStatus.SelectedIndex = -1;
        ApplyFilter();
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
            if (_allInventoryItems.Count == 0) {
                MessageBox.Show(
                    "No data to commit. Please open a file first.",
                    "No Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var recordsToImport = _allInventoryItems
                .Where(x => x is { IsSelected: true, Status: InventoryImportStatus.Ready })
                .Select(x => {
                    if (string.IsNullOrWhiteSpace(x.Item.CustomSku)) {
                        x.Item.CustomSku = x.ProposedSku;
                    }

                    return x.Item;
                }).ToList();

            var importResults = await _inventoryItemRepository.ImportAsync(recordsToImport);
            MessageBox.Show(
                $"Import complete: {importResults.RecordsAdded} added, {importResults.RecordsProcessed} processed, Already Imported:  {importResults.ExistingRecords}, Possible Relists:  {importResults.PossibleRelists}, Source Conflicts: {importResults.SourceConflicts}.",
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
    private async void btnOpenFlipwiseExport_Click(object sender, EventArgs e) {
        openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;
        openFileDialog1.FileName = string.Empty;
        openFileDialog1.DefaultExt = "csv";

        if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

        await LoadExistingIdentifiersAsync();

        var filePath = openFileDialog1.FileName;
        _allInventoryItems.Clear();

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

            foreach (var record in records) {
                var inventoryImportRow = new InventoryImportRow() {
                    IsSelected = true,
                    Item = record,
                };

                inventoryImportRow.Status = DetermineStatus(inventoryImportRow);

                _allInventoryItems.Add(inventoryImportRow);
            }

            var bindingSource = new BindingList<InventoryImportRow>(_allInventoryItems);
            dataGridView1.DataSource = bindingSource;

            ApplyFilter();
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

    /// <summary>
    /// Handles the <c>Click</c> event of the <c>btnSelectFiltered</c> button.
    /// Selects all items in the filtered inventory list displayed in the <c>DataGridView</c>.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <c>btnSelectFiltered</c> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    private void btnSelectFiltered_Click(object sender, EventArgs e) {
        if (dataGridView1.DataSource is not BindingList<InventoryImportRow> filteredItems) {
            return;
        }

        foreach (var record in filteredItems) {
            record.IsSelected = true;
        }

        dataGridView1.Refresh();
    }

    /// <summary>
    /// Handles the <see cref="ComboBox.SelectedValueChanged"/> event for the filter source combo box.
    /// </summary>
    /// <param name="sender">The source of the event, typically the combo box.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method is triggered when the selected value of the filter source combo box changes.
    /// It applies the necessary filter by invoking the <see cref="ApplyFilter"/> method.
    /// </remarks>
    private void cmbFilterSource_SelectedValueChanged(object sender, EventArgs e) {
        ApplyFilter();
    }

    /// <summary>
    /// Handles the <see cref="ComboBox.SelectedValueChanged"/> event for the <c>cmbStatus</c> control.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <c>cmbStatus</c> control.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method is responsible for applying a filter when the selected value of the <c>cmbStatus</c> control changes.
    /// </remarks>
    private void cmbStatus_SelectedValueChanged(object sender, EventArgs e) {
        ApplyFilter();
    }

    /// <summary>
    /// Configures the inventory grid for displaying Flipwise inventory export data.
    /// </summary>
    /// <remarks>
    /// This method sets up the <see cref="DataGridView"/> control with predefined columns
    /// and properties to display inventory data in a structured and user-friendly manner.
    /// It disables row addition and deletion, enables column ordering, and configures
    /// selection to full-row mode. The grid includes columns for selection, product details,
    /// SKUs, inventory source, status, source record ID, and purchase date.
    /// </remarks>
    private void ConfigureInventoryGrid() {
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.Columns.Clear();

        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.MultiSelect = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn {
            Name = "colSelected",
            HeaderText = "Select",
            DataPropertyName = nameof(InventoryImportRow.IsSelected),
            Width = 55,
            SortMode = DataGridViewColumnSortMode.Automatic
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "colProduct",
            HeaderText = "Product",
            DataPropertyName = nameof(InventoryImportRow.Product),
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            MinimumWidth = 300,
            FillWeight = 100,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "colCustomSku",
            HeaderText = "Existing SKU",
            DataPropertyName = nameof(InventoryImportRow.CustomSku),
            Width = 130,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "colProposedSku",
            HeaderText = "Proposed SKU",
            DataPropertyName = nameof(InventoryImportRow.ProposedSku),
            Width = 145,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "colInventorySource",
            HeaderText = "Source",
            DataPropertyName = nameof(InventoryImportRow.InventorySourceCode),
            Width = 75,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "colStatus",
            HeaderText = "Status",
            DataPropertyName = nameof(InventoryImportRow.Status),
            Width = 145,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "colSourceRecordId",
            HeaderText = "Source Record ID",
            DataPropertyName = nameof(InventoryImportRow.SourceRecordId),
            Width = 130,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "colPurchasedAt",
            HeaderText = "Purchased At",
            DataPropertyName = nameof(InventoryImportRow.PurchasedAt),
            Width = 120,
            ReadOnly = true
        });
    }

    /// <summary>
    /// Determines the status of an inventory item based on its properties and existing records.
    /// </summary>
    /// <param name="row">The inventory item to evaluate.</param>
    /// <param name="existingSkus">A set of existing SKUs to check for conflicts.</param>
    /// <param name="existingSourceRecordIDs">A set of existing source record IDs to check for duplicates.</param>
    /// <returns>
    /// An <see cref="InventoryImportStatus"/> value indicating the status of the inventory item:
    /// <list type="bullet">
    /// <item><description><see cref="InventoryImportStatus.SourceUnassigned"/> if the item's source record ID is null.</description></item>
    /// <item><description><see cref="InventoryImportStatus.SkuConflict"/> if the item's custom SKU conflicts with an existing SKU.</description></item>
    /// <item><description><see cref="InventoryImportStatus.DuplicateSourceRecord"/> if the item's source record ID is a duplicate.</description></item>
    /// <item><description><see cref="InventoryImportStatus.Ready"/> if the item is ready for import.</description></item>
    /// </list>
    /// </returns>
    private InventoryImportStatus DetermineStatus(InventoryImportRow row) {
        if (!string.IsNullOrWhiteSpace(row.Item.CustomSku) && _existingSkus.Contains(row.Item.CustomSku)) {
            return InventoryImportStatus.SkuConflict;
        }

        if (!string.IsNullOrWhiteSpace(row.Item.SourceRecordId) && _existingSourceRecordIds.Contains(row.Item.SourceRecordId)) {
            return InventoryImportStatus.DuplicateSourceRecord;
        }

        return row.InventorySourceId is null ? InventoryImportStatus.SourceUnassigned : InventoryImportStatus.Ready;
    }

    /// <summary>
    /// Handles the <c>Load</c> event of the <see cref="ImportFlipwiseInventoryExport"/> form.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method initializes the form by populating the source dropdown asynchronously.
    /// If an exception occurs during this process, an error message is displayed, and the form is closed.
    /// </remarks>
    private async void ImportFlipwiseInventoryExport_Load(object sender, EventArgs e) {
        try {
            ConfigureInventoryGrid();

            await PopulateSourceDropdown();
            PopulateStatusDropdown();
        } catch (Exception exception) {
            MessageBox.Show(
                exception.Message,
                "Unable to load inventory sources",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            Close();
        }
    }

    /// <summary>
    /// Loads existing inventory record identifiers asynchronously.
    /// </summary>
    /// <remarks>
    /// This method retrieves existing SKUs and source record identifiers from the inventory repository
    /// and stores them in memory for further processing. The identifiers are used to avoid duplication
    /// during the import of Flipwise inventory export data.
    /// </remarks>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="System.Exception">
    /// Thrown if an error occurs while retrieving the identifiers from the repository.
    /// </exception>
    private async Task LoadExistingIdentifiersAsync() {
        _existingSkus = (await _inventoryItemRepository.GetExistingSkus()).ToHashSet(StringComparer.OrdinalIgnoreCase);
        _existingSourceRecordIds =
            (await _inventoryItemRepository.GetExistingRecordIdentifiers()).ToHashSet(StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Populates the source dropdowns with inventory source data retrieved from the repository.
    /// </summary>
    /// <remarks>
    /// This method asynchronously retrieves all available inventory sources from the
    /// <see cref="IInventorySourceRepository"/> and binds them to the dropdown controls
    /// <c>cmbAssignSource</c> and <c>cmbFilterSource</c>. The dropdowns are configured to display
    /// the name of the inventory source and use its code as the value.
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if there is an issue retrieving data from the repository.
    /// </exception>
    private async Task PopulateSourceDropdown() {
        var sources = await _sourceRepository.GetAllAsync();

        cmbAssignSource.DataSource = sources.ToList();
        cmbAssignSource.DisplayMember = nameof(InventorySource.Name);
        cmbAssignSource.ValueMember = nameof(InventorySource.Id);
        cmbAssignSource.SelectedIndex = -1;

        cmbFilterSource.DataSource = sources.ToList();
        cmbFilterSource.DisplayMember = nameof(InventorySource.Name);
        cmbFilterSource.ValueMember = nameof(InventorySource.Id);
        cmbFilterSource.SelectedIndex = -1;
    }

    /// <summary>
    /// Populates the status dropdown with predefined status options.
    /// </summary>
    /// <remarks>
    /// This method adds the following status options to the dropdown: "All", "Printed", and "Not Printed".
    /// It also sets the default selected item to "All".
    /// </remarks>
    private void PopulateStatusDropdown() {
        cmbStatus.Items.AddRange(["All", "Ready", "Duplicate Source Record", "SKU Conflict", "Source Unassigned"]);
        cmbStatus.SelectedItem = "All";
    }

    /// <summary>
    /// Handles the <see cref="TextBox.TextChanged"/> event for the filter input text box.
    /// </summary>
    /// <param name="sender">The source of the event, typically the filter input text box.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method triggers the application of a filter when the text in the input box changes.
    /// </remarks>
    private void txtFilterInput_TextChanged(object sender, EventArgs e) {
        ApplyFilter();
    }
}