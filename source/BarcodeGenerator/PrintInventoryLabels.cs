using BarcodeGenerator.Data.Repositories;
using BarcodeGenerator.Entities;
using System.ComponentModel;

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
    private IList<InventoryLabelRow> _allInventoryLabelRows = new List<InventoryLabelRow>();

    /// <summary>
    /// Initializes a new instance of the <see cref="PrintInventoryLabels"/> class.
    /// </summary>
    /// <param name="inventoryItemRepository">
    /// An instance of <see cref="IInventoryItemRepository"/> used to manage inventory items.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="inventoryItemRepository"/> is <c>null</c>.
    /// </exception>
    public PrintInventoryLabels(IInventoryItemRepository inventoryItemRepository) {
        InitializeComponent();
        InitializeInventoryGrid();

        _inventoryItemRepository = inventoryItemRepository ?? throw new ArgumentNullException(nameof(inventoryItemRepository));
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

        dataGridView1.DataSource =
            new BindingList<InventoryLabelRow>([.. filteredItems]);
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
    private void btnPrint_Click(object sender, EventArgs e) {
        MessageBox.Show("Print!", "Print!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        if (dataGridView1.DataSource is not BindingList<InventoryLabelRow> rows) return;

        foreach (var row in rows) {
            row.IsSelected = chkSelectAllItems.Checked;
        }

        dataGridView1.Refresh();
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
        dataGridView1.MultiSelect = false;
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
            Name = "Copies",
            HeaderText = "Copies",
            DataPropertyName = nameof(InventoryLabelRow.Copies),
            Width = 60,
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

            foreach (var row in _allInventoryLabelRows) {
                row.IsSelected = true;
            }

            dataGridView1.DataSource = new BindingList<InventoryLabelRow>(_allInventoryLabelRows);
        } catch (Exception ex) {
            MessageBox.Show("Could not load the inventory items", "Loading Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
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
}