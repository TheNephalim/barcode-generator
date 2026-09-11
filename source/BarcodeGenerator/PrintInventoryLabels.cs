using BarcodeGenerator.Data.Repositories;
using BarcodeGenerator.Entities;
using BarcodeGenerator.LabelGeneration;
using System.ComponentModel;

// ReSharper disable ClassNeverInstantiated.Global

// ReSharper disable AsyncVoidEventHandlerMethod

namespace BarcodeGenerator;

/// <summary>
/// Represents a form for printing inventory labels.
/// </summary>
/// <remarks>
/// This class provides a user interface for filtering, selecting, and printing inventory labels.
/// It integrates with an <see cref="IInventoryItemRepository"/> to manage inventory data.
/// </remarks>
public partial class PrintInventoryLabels : Form {
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IRenderedInventoryLabelGenerator _inventoryLabelGenerator;
    private readonly ILabelPrinter _labelPrinter;
    private IList<InventoryLabelRow> _allInventoryLabelRows = new List<InventoryLabelRow>();

    private bool _isUpdatingSelection;

    /// <summary>
    /// Initializes a new instance of the <see cref="PrintInventoryLabels"/> class.
    /// </summary>
    /// <param name="inventoryItemRepository">
    /// An instance of <see cref="IInventoryItemRepository"/> used to manage inventory items.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="inventoryItemRepository"/> is <c>null</c>.
    /// </exception>
    public PrintInventoryLabels(IInventoryItemRepository inventoryItemRepository, IRenderedInventoryLabelGenerator inventoryLabelGenerator, ILabelPrinter labelPrinter) {
        InitializeComponent();
        InitializeInventoryGrid();

        _inventoryItemRepository = inventoryItemRepository ?? throw new ArgumentNullException(nameof(inventoryItemRepository));
        _inventoryLabelGenerator = inventoryLabelGenerator ?? throw new ArgumentNullException(nameof(inventoryLabelGenerator));
        _labelPrinter = labelPrinter ?? throw new ArgumentNullException(nameof(labelPrinter));
    }

    /// <summary>
    /// Applies a filter to the inventory items displayed in the data grid.
    /// </summary>
    /// <remarks>
    /// This method retrieves the current filter text from the <see cref="txtInventoryFilter"/> control
    /// and filters the inventory items based on their SKU, title, or source. The filtered items
    /// are then displayed in the data grid.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the data source or any required component is not initialized.
    /// </exception>
    private void ApplyFilter() {
        var filter = txtInventoryFilter.Text.Trim();

        IEnumerable<InventoryLabelRow> filteredItems = _allInventoryLabelRows;

        if (!string.IsNullOrWhiteSpace(filter)) {
            filteredItems = _allInventoryLabelRows.Where(
                x => x.Sku.Contains(filter, StringComparison.InvariantCultureIgnoreCase) ||
                     x.Title.Contains(filter, StringComparison.InvariantCultureIgnoreCase) ||
                     x.Source.Contains(filter, StringComparison.InvariantCultureIgnoreCase));
        }

        if (chkFilterByDate.Checked) {
            filteredItems =
                filteredItems.Where(x =>
                    x.ImportedAt.HasValue && x.ImportedAt.Value.Date == dateTimePicker1.Value.Date);
        }

        if (chkIsPrinted.Checked) {
            filteredItems = filteredItems.Where(x => !x.LabelPrintedAt.HasValue);
        }

        BindGrid([.. filteredItems]);
    }

    /// <summary>
    /// Binds the provided collection of inventory label rows to the data grid view.
    /// </summary>
    /// <param name="rows">
    /// The collection of <see cref="InventoryLabelRow"/> objects to display in the grid.
    /// </param>
    /// <remarks>
    /// This method updates the data source of the grid with the provided rows and configures
    /// the grid's selection behavior. It is typically used to refresh the displayed inventory
    /// data after applying filters or loading new data.
    /// </remarks>
    private void BindGrid(IEnumerable<InventoryLabelRow> rows) {
        dataGridView1.DataSource =
            new BindingList<InventoryLabelRow>([.. rows]);

        dataGridView1.MultiSelect = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    /// <summary>
    /// Handles the Click event of the <c>btnClear</c> button.
    /// </summary>
    /// <param name="sender">
    /// The source of the event, typically the <see cref="Button"/> control that was clicked.
    /// </param>
    /// <param name="e">
    /// An <see cref="EventArgs"/> that contains the event data.
    /// </param>
    /// <remarks>
    /// This method clears the inventory filter text box and reapplies the filter to update the displayed inventory items.
    /// </remarks>
    private void btnClear_Click(object sender, EventArgs e) {
        txtInventoryFilter.Clear();
        chkFilterByDate.Checked = false;
        comboFirstPrint.SelectedIndex = -1;
    }

    /// <summary>
    /// Handles the Click event of the <see cref="btnClose"/> button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="btnClose"/> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method closes the <see cref="PrintInventoryLabels"/> form when the Close button is clicked.
    /// </remarks>
    private void btnClose_Click(object sender, EventArgs e) {
        Close();
    }

    /// <summary>
    /// Handles the Click event of the <see cref="btnPrint"/> button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="btnPrint"/> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method is triggered when the user clicks the "Print" button. It displays a message box
    /// indicating that the print action has been initiated.
    /// </remarks>
    private async void btnPrint_Click(object sender, EventArgs e) {
        dataGridView1.EndEdit();

        var labelRows = (BindingList<InventoryLabelRow>)dataGridView1.DataSource;

        if (labelRows.Count == 0) {
            MessageBox.Show("No items selected to print.", "No Selection", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        var labels = labelRows
            .Where(x => x.IsSelected)
            .SelectMany(x => {
                var copies = x.Copies;
                if (copies <= 1) {
                    copies = 1;
                }

                var inventoryLabels = Enumerable.Range(0, copies).Select(_ => new InventoryLabel() {
                    Sku = x.Sku,
                    Title = x.Title,
                    Price = x.Price,
                    InventoryItemId = x.Id
                });
                return inventoryLabels;
            }).ToList();

        var renderedInventoryLabels = labels.Select(x => _inventoryLabelGenerator.Generate(x)).ToList();

        var printJob = new LabelPrintJob() {
            Labels = renderedInventoryLabels,
            Copies = 1,
            LabelSize = new LabelSize() {
                Width = 200,
                Height = 100
            },
            TemplateType = LabelTemplateType.Inventory
        };

        try {
            _labelPrinter.Print(printJob);
            var inventoryItemIds = renderedInventoryLabels
                .Select(x => x.Label.InventoryItemId)
                .Distinct()
                .ToArray();

            await _inventoryItemRepository.MarkLabelsPrintedAsync(inventoryItemIds,
                DateTime.Now);

            await LoadInventoryAsync();
        } catch (Exception ex) {
            MessageBox.Show($"Failed to print labels: {ex.Message}", "Printing Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        } finally {
            foreach (var label in renderedInventoryLabels) {
                label.Dispose();
            }

            ApplyFilter();
        }

        MessageBox.Show("Inventory labels generated and sent to the printer successfully.", "Information", MessageBoxButtons.OKCancel);
    }

    /// <summary>
    /// Handles the <see cref="CheckBox.CheckedChanged"/> event for <c>checkBox1</c>.
    /// </summary>
    /// <param name="sender">The source of the event, typically the checkbox control.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method is triggered when the checked state of <c>checkBox1</c> changes.
    /// It applies a filter by invoking the <see cref="ApplyFilter"/> method.
    /// </remarks>
    private void checkBox1_CheckedChanged(object sender, EventArgs e) {
        ApplyFilter();
    }

    /// <summary>
    /// Handles the <see cref="CheckBox.CheckedChanged"/> event for the <c>chkFilterByDate</c> control.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="CheckBox"/> control.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method is triggered when the checked state of the <c>chkFilterByDate</c> checkbox changes.
    /// It applies the appropriate filter based on the current state of the checkbox.
    /// </remarks>
    private void chkFilterByDate_CheckedChanged(object sender, EventArgs e) {
        ApplyFilter();
    }

    /// <summary>
    /// Handles the <see cref="CheckBox.CheckedChanged"/> event for the <see cref="chkSelectAllItems"/> control.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="CheckBox"/> control.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// Toggles the selection state of all items in the <see cref="dataGridView1"/> based on the
    /// checked state of the <see cref="chkSelectAllItems"/> control.
    /// </remarks>
    private void chkSelectAllItems_CheckedChanged(object sender, EventArgs e) {
        if (_isUpdatingSelection) {
            return;
        }

        if (dataGridView1.DataSource is not BindingList<InventoryLabelRow> rows) {
            return;
        }

        foreach (var row in rows) {
            row.IsSelected = chkSelectAllItems.Checked;
        }

        dataGridView1.Refresh();
    }

    /// <summary>
    /// Handles the <see cref="ComboBox.SelectedIndexChanged"/> event for the <c>comboFirstPrint</c> control.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="ComboBox"/> control.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method determines the selected value of the <c>comboFirstPrint</c> control and performs an action
    /// based on the selected option. It supports predefined options such as selecting the first 25, 50, or 100 records,
    /// or selecting all filtered records.
    /// </remarks>
    private void comboFirstPrint_SelectedIndexChanged(object sender, EventArgs e) {
        var selectedOption = comboFirstPrint.SelectedItem;

        if (selectedOption == null) return;

        switch (selectedOption.ToString()) {
            case "25":
                SelectFirstRecords(25);
                break;

            case "50":
                SelectFirstRecords(50);
                break;

            case "100":
                SelectFirstRecords(100);
                break;

            case "All Filtered":
                SelectAllFiltered();
                break;
        }
    }

    /// <summary>
    /// Handles the <see cref="DataGridView.CellMouseDown"/> event for <c>dataGridView1</c>.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="DataGridView"/>.</param>
    /// <param name="e">A <see cref="DataGridViewCellMouseEventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method ensures that the row corresponding to the clicked cell is selected when the Shift key is held down.
    /// It also ignores clicks on the header row.
    /// </remarks>
    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
        if (e.RowIndex < 0) {
            return;
        }

        if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }

    /// <summary>
    /// Handles the <see cref="DataGridView.CellMouseUp"/> event for <c>dataGridView1</c>.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="DataGridView"/>.</param>
    /// <param name="e">
    /// A <see cref="DataGridViewCellMouseEventArgs"/> that contains the event data,
    /// including the row and column indices of the clicked cell.
    /// </param>
    /// <remarks>
    /// This method processes mouse-up events on cells in the <c>dataGridView1</c> control.
    /// It handles different scenarios such as row header clicks, checkbox clicks, and normal cell clicks.
    /// The method updates the selection state of rows and refreshes the control accordingly.
    /// </remarks>
    private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
        if (e.RowIndex < 0) {
            return;
        }

        dataGridView1.EndEdit();

        var clickedRow = dataGridView1.Rows[e.RowIndex];

        //
        // Row header click.
        //
        if (e.ColumnIndex < 0) {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                if (row.DataBoundItem is InventoryLabelRow item) {
                    item.IsSelected = true;
                }
            }

            UpdateSelectAllState();
            dataGridView1.Refresh();
            return;
        }

        //
        // Checkbox click.
        //
        if (dataGridView1.Columns[e.ColumnIndex]
            is DataGridViewCheckBoxColumn) {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                if (row.DataBoundItem is InventoryLabelRow item) {
                    item.IsSelected = true;
                }
            }

            if (clickedRow.DataBoundItem is InventoryLabelRow clickedItem) {
                clickedItem.IsSelected =
                    Convert.ToBoolean(
                        clickedRow.Cells[e.ColumnIndex].Value);
            }

            UpdateSelectAllState();
            dataGridView1.Refresh();
            return;
        }

        //
        // Normal cell click / Shift+click.
        //
        foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
            if (row.DataBoundItem is InventoryLabelRow item) {
                item.IsSelected = true;
            }
        }

        UpdateSelectAllState();
        dataGridView1.Refresh();
    }

    /// <summary>
    /// Handles the <see cref="DataGridView.CurrentCellDirtyStateChanged"/> event for <see cref="dataGridView1"/>.
    /// </summary>
    /// <param name="sender">The source of the event, typically <see cref="dataGridView1"/>.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method ensures that changes in a <see cref="DataGridViewCheckBoxCell"/> are committed
    /// immediately when the cell's dirty state changes.
    /// </remarks>
    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
        if (dataGridView1.IsCurrentCellDirty &&
            dataGridView1.CurrentCell is DataGridViewCheckBoxCell) {
            dataGridView1.CommitEdit(
                DataGridViewDataErrorContexts.Commit);
        }
    }

    /// <summary>
    /// Initializes the inventory grid with predefined settings.
    /// </summary>
    /// <remarks>
    /// This method configures the <see cref="DataGridView"/> to disable user modifications,
    /// enforce single-row selection, and prevent automatic column generation.
    /// </remarks>
    private void InitializeInventoryGrid() {
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.MultiSelect = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        dataGridView1.Columns.Clear();
        dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn {
            Name = "Selected",
            HeaderText = "",
            DataPropertyName = nameof(InventoryLabelRow.IsSelected),
            Width = 35
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "CustomSku",
            HeaderText = "SKU",
            DataPropertyName = nameof(InventoryLabelRow.Sku),
            Width = 110,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "Title",
            HeaderText = "Title",
            DataPropertyName = nameof(InventoryLabelRow.Title),
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "ImportedDate",
            HeaderText = "Imported",
            DataPropertyName = nameof(InventoryLabelRow.ImportedAt),
            Width = 75,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "Quantity",
            HeaderText = "Qty",
            DataPropertyName = nameof(InventoryLabelRow.Quantity),
            Width = 50,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "Price",
            HeaderText = "Price",
            DataPropertyName = nameof(InventoryLabelRow.Price),
            Width = 50,
            ReadOnly = true
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "Copies",
            HeaderText = "Copies",
            DataPropertyName = nameof(InventoryLabelRow.Copies),
            Width = 60,
            ReadOnly = false
        });

        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
            Name = "LastPrinted",
            HeaderText = "Last Printed",
            DataPropertyName = nameof(InventoryLabelRow.LabelPrintedAt),
            Width = 100,
            ReadOnly = false
        });
    }

    /// <summary>
    /// Asynchronously loads inventory data and binds it to the data grid view.
    /// </summary>
    /// <remarks>
    /// This method retrieves all inventory items from the repository, converts them into a binding list,
    /// and sets the data source of the <see cref="dataGridView1"/> control. It ensures that the inventory
    /// data is displayed in the user interface for further actions like selection or printing.
    /// </remarks>
    /// <returns>
    /// A task that represents the asynchronous operation of loading inventory data.
    /// </returns>
    /// <exception cref="System.InvalidOperationException">
    /// Thrown if the repository fails to retrieve inventory items.
    /// </exception>
    /// <exception cref="System.Data.SqlClient.SqlException">
    /// Thrown if there is an error during the database query execution.
    /// </exception>
    private async Task LoadInventoryAsync() {
        try {
            _allInventoryLabelRows = await _inventoryItemRepository.GetAll();
            _allInventoryLabelRows = [.. _allInventoryLabelRows.OrderBy(x => x.Title)];

            BindGrid(_allInventoryLabelRows);
        } catch (Exception ex) {
            MessageBox.Show("Could not load the inventory items", "Loading Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Populates the "Print First" combo box with predefined options.
    /// </summary>
    /// <remarks>
    /// This method adds a set of predefined options to the <see cref="comboFirstPrint"/> combo box,
    /// allowing the user to select the number of inventory labels to print first.
    /// </remarks>
    private void PopulatePrintFirst() {
        object[] printFirstOptions = ["25", "50", "100", "All Filtered"];
        comboFirstPrint.Items.AddRange(printFirstOptions);
        comboFirstPrint.SelectedIndex = -1; // Default to the first option
    }

    /// <summary>
    /// Handles the <c>Load</c> event of the <see cref="PrintInventoryLabels"/> form.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method is executed when the form is loaded. It retrieves all inventory items
    /// from the repository, converts them into a binding list of <see cref="BarcodeGenerator.Entities.InventoryLabelRow"/>,
    /// and binds the list to the <c>DataGridView</c> control for display.
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">
    /// Thrown if the repository fails to retrieve the inventory items.
    /// </exception>
    /// <exception cref="System.Data.SqlClient.SqlException">
    /// Thrown if there is an error during the database query execution.
    /// </exception>
    private async void PrintInventoryLabels_Load(object sender, EventArgs e) {
        await LoadInventoryAsync();
        PopulatePrintFirst();
    }

    /// <summary>
    /// Selects all filtered inventory label rows in the data grid.
    /// </summary>
    /// <remarks>
    /// This method iterates through the filtered inventory label rows displayed in the data grid
    /// and marks each row as selected. The data grid is then refreshed to reflect the changes.
    /// </remarks>
    private void SelectAllFiltered() {
        if (dataGridView1.DataSource is not BindingList<InventoryLabelRow> filteredItems) {
            return;
        }

        foreach (var row in filteredItems) {
            row.IsSelected = true;
        }

        dataGridView1.Refresh();
    }

    /// <summary>
    /// Selects the first specified number of records in the inventory label grid.
    /// </summary>
    /// <param name="count">
    /// The number of records to select.
    /// </param>
    /// <remarks>
    /// This method iterates through the data source of the inventory label grid, deselects all records,
    /// and then selects the first <paramref name="count"/> records. The grid is refreshed after the selection.
    /// </remarks>
    private void SelectFirstRecords(int count) {
        if (dataGridView1.DataSource is not BindingList<InventoryLabelRow> filteredItems) {
            return;
        }

        foreach (var item in filteredItems) {
            item.IsSelected = false;
        }

        foreach (var item in filteredItems.Take(count)) {
            item.IsSelected = true;
        }

        dataGridView1.Refresh();
    }

    /// <summary>
    /// Handles the <see cref="TextBox.TextChanged"/> event for the inventory filter text box.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="TextBox"/> control.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method is triggered whenever the text in the inventory filter text box changes.
    /// It trims the input text and applies the filter to update the displayed inventory items.
    /// </remarks>
    private void txtInventoryFilter_TextChanged(object sender, EventArgs e) {
        ApplyFilter();
    }

    /// <summary>
    /// Updates the state of the "Select All" checkbox based on the selection state of all rows in the data grid.
    /// </summary>
    /// <remarks>
    /// This method evaluates whether all rows in the <see cref="dataGridView1"/> are selected.
    /// If all rows are selected, the "Select All" checkbox is checked; otherwise, it is unchecked.
    /// </remarks>
    private void UpdateSelectAllState() {
        _isUpdatingSelection = true;

        try {
            if (dataGridView1.DataSource
                is BindingList<InventoryLabelRow> { Count: > 0 } rows) {
                chkSelectAllItems.Checked =
                    rows.All(x => x.IsSelected);
            } else {
                chkSelectAllItems.Checked = false;
            }
        } finally {
            _isUpdatingSelection = false;
        }
    }
}