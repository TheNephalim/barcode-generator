using BarcodeGenerator.Data.Repositories;
using BarcodeGenerator.Entities;

// ReSharper disable AsyncVoidEventHandlerMethod

namespace BarcodeGenerator;

/// <summary>
/// Represents a form for maintaining inventory sources in the Barcode Generator application.
/// </summary>
/// <remarks>
/// This class is a partial class that inherits from <see cref="Form"/> and is used to manage inventory sources.
/// It is registered as a dependency in the <see cref="FormRegistrar"/> for dependency injection.
/// </remarks>
public partial class InventorySourceMaintenance : Form {
    private static readonly GridColumnDefinition[] SourceColumns = [
        new(nameof(InventorySource.Code), "Code", 100),
        new(nameof(InventorySource.Name), "Description", 175),
        new(nameof(InventorySource.LastPrintedNumber), "Last #", 80),
        new(nameof(InventorySource.LastPurchaseDate), "Last Lot", 100),
        new(nameof(InventorySource.IsActive), "Active", 60)
    ];

    private readonly IInventorySourceRepository _inventorySourceRepository;
    private InventorySource? _currentInventorySource;
    private FormMode _mode;
    private bool _suppressSelectionChanged = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventorySourceMaintenance"/> class.
    /// </summary>
    /// <param name="inventorySourceRepository">
    /// An instance of <see cref="IInventorySourceRepository"/> used to manage and retrieve inventory source data.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="inventorySourceRepository"/> is <c>null</c>.
    /// </exception>
    public InventorySourceMaintenance(IInventorySourceRepository inventorySourceRepository) {
        _inventorySourceRepository = inventorySourceRepository ?? throw new ArgumentNullException(nameof(inventorySourceRepository));
        InitializeComponent();
    }

    /// <summary>
    /// Specifies the mode of the form in the <see cref="InventorySourceMaintenance"/> class.
    /// </summary>
    /// <remarks>
    /// This enum is used to determine the current state of the form, such as whether it is being used
    /// to view, create, or edit an inventory source.
    /// </remarks>
    /// <summary>
    /// The form is in viewing mode, allowing the user to view inventory source details.
    /// </summary>
    /// <summary>
    /// The form is in creating mode, allowing the user to add a new inventory source.
    /// </summary>
    /// <summary>
    /// The form is in editing mode, allowing the user to modify an existing inventory source.
    /// </summary>
    private enum FormMode {
        Viewing,
        Creating,
        Editing
    }

    /// <summary>
    /// Creates a new <see cref="DataGridViewColumn"/> based on the specified <see cref="GridColumnDefinition"/>.
    /// </summary>
    /// <param name="column">The definition of the grid column, including its property name, header text, width, and read-only status.</param>
    /// <returns>A configured <see cref="DataGridViewColumn"/> instance.</returns>
    /// <remarks>
    /// This method initializes a <see cref="DataGridViewColumn"/> using the properties defined in the provided <see cref="GridColumnDefinition"/>.
    /// </remarks>
    private static DataGridViewColumn CreateColumn(GridColumnDefinition column) {
        DataGridViewColumn gridColumn = column.PropertyName == nameof(InventorySource.IsActive)
            ? new DataGridViewCheckBoxColumn()
            : new DataGridViewTextBoxColumn();

        gridColumn.DataPropertyName = column.PropertyName;
        gridColumn.HeaderText = column.HeaderText;
        gridColumn.Name = $"col{column.PropertyName}";
        gridColumn.Width = column.Width;
        gridColumn.ReadOnly = column.ReadOnly;

        return gridColumn;
    }

    /// <summary>
    /// Adds columns to the <see cref="DataGridView"/> control based on predefined column definitions.
    /// </summary>
    /// <remarks>
    /// This method clears any existing columns in the <see cref="DataGridView"/> and adds new columns
    /// using the definitions provided in the <c>SourceColumns</c> array.
    /// </remarks>
    private void AddColumns() {
        dataGridView1.Columns.Clear();

        foreach (var column in SourceColumns) {
            dataGridView1.Columns.Add(CreateColumn(column));
        }
    }

    /// <summary>
    /// Asynchronously adds a new inventory source to the repository and updates the data grid view.
    /// </summary>
    /// <remarks>
    /// This method creates a new <see cref="InventorySource"/> object using the <see cref="CreateInventorySource"/> method,
    /// adds it to the repository via <see cref="IInventorySourceRepository.AddSourceAsync(InventorySource)"/>,
    /// and then refreshes the data grid view to reflect the changes.
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    /// <exception cref="FormatException">
    /// Thrown if the input values for the inventory source are invalid during the creation process.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown if any required input field for the inventory source is <c>null</c> or empty.
    /// </exception>
    private async Task AddSourceAsync() {
        var source = CreateInventorySource();
        await _inventorySourceRepository.AddSourceAsync(source);
        await InitializeDataGridView();
    }

    /// <summary>
    /// Handles the <c>Click</c> event of the <c>btnAddNew</c> button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <c>btnAddNew</c> button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method clears the current inventory source, resets the selection in the data grid view,
    /// and clears the form. It ensures that the <c>SelectionChanged</c> event is suppressed during execution.
    /// </remarks>
    private void btnAddNew_Click(object sender, EventArgs e) {
        _suppressSelectionChanged = true;

        try {
            _currentInventorySource = null;
            _mode = FormMode.Creating;

            ClearSelection();
            ClearForm();
        } finally {
            _suppressSelectionChanged = false;
        }
    }

    /// <summary>
    /// Handles the <see cref="Button.Click"/> event for the Close button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the Close button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method closes the current form when the Close button is clicked.
    /// </remarks>
    private void btnClose_Click(object sender, EventArgs e) {
        Close();
    }

    /// <summary>
    /// Handles the <see cref="Button.Click"/> event for the Save button.
    /// </summary>
    /// <param name="sender">The source of the event, typically the Save button.</param>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method performs actions to either add a new inventory source or update an existing one,
    /// depending on the state of the <c>_currentInventorySource</c>.
    /// </remarks>
    private async void btnSave_Click(object sender, EventArgs e) {
        switch (_mode) {
            case FormMode.Creating:
                await AddSourceAsync();
                break;

            case FormMode.Editing:
                await UpdateSourceAsync();
                break;

            case FormMode.Viewing:
            default:
                return;
        }
    }

    /// <summary>
    /// Clears all input fields and resets the form to its default state.
    /// </summary>
    /// <remarks>
    /// This method is typically used when creating a new inventory source or resetting the form
    /// after an operation. It ensures that all text fields are cleared, and the active checkbox
    /// is set to its default value.
    /// </remarks>
    private void ClearForm() {
        txtCode.Text = string.Empty;
        txtDescription.Text = string.Empty;
        txtLastNumber.Text = string.Empty;
        mtxtLotDate.Text = string.Empty;
        chkIsActive.Checked = true;
    }

    /// <summary>
    /// Clears the current selection in the data grid view.
    /// </summary>
    /// <remarks>
    /// This method ensures that no rows are selected in the data grid view and resets the current cell to <c>null</c>.
    /// It is typically used to reset the selection state of the grid, for example, when switching modes or refreshing data.
    /// </remarks>
    private void ClearSelection() {
        if (dataGridView1.Rows.Count <= 0) return;
        dataGridView1.ClearSelection();
        dataGridView1.CurrentCell = null;
    }

    /// <summary>
    /// Configures the <see cref="DataGridView"/> control for displaying inventory source data.
    /// </summary>
    /// <remarks>
    /// This method sets up the <see cref="DataGridView"/> with predefined settings, such as disabling
    /// auto-generated columns, enabling single-row selection, and setting the selection mode to full-row.
    /// It also invokes the <c>AddColumns</c> method to populate the grid with columns defined in the
    /// <c>SourceColumns</c> array.
    /// </remarks>
    private void ConfigureGrid() {
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.MultiSelect = false;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.RowHeadersVisible = false;
        AddColumns();
    }

    /// <summary>
    /// Creates a new instance of the <see cref="InventorySource"/> class based on the current form input values.
    /// </summary>
    /// <returns>
    /// A new <see cref="InventorySource"/> object populated with data from the form fields.
    /// </returns>
    /// <remarks>
    /// This method gathers input from various form controls, such as text boxes and checkboxes,
    /// to construct an <see cref="InventorySource"/> object. The resulting object can then be used
    /// for further operations, such as adding it to a repository.
    /// </remarks>
    /// <exception cref="FormatException">
    /// Thrown if the input values for <c>LastPurchaseDate</c> or <c>LastPrintedNumber</c> cannot be converted to their respective types.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown if any required form field is <c>null</c> or empty.
    /// </exception>
    private InventorySource CreateInventorySource() {
        return new InventorySource() {
            Code = txtCode.Text.Trim(),
            LastPurchaseDate = Convert.ToDateTime(mtxtLotDate.Text),
            LastPrintedNumber = Convert.ToInt32(txtLastNumber.Text),
            IsActive = chkIsActive.Checked,
            Name = txtDescription.Text.Trim()
        };
    }

    /// <summary>
    /// Handles the <see cref="DataGridView.DataBindingComplete"/> event for <c>DataGridView1</c>.
    /// </summary>
    /// <param name="sender">The source of the event, typically the <see cref="DataGridView"/>.</param>
    /// <param name="e">A <see cref="DataGridViewBindingCompleteEventArgs"/> that contains the event data.</param>
    /// <remarks>
    /// This method is used to perform additional actions after the data binding operation is complete,
    /// such as clearing the selection in the <c>DataGridView</c>.
    /// </remarks>
    private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
        ClearSelection();
    }

    /// <summary>
    /// Handles the <see cref="DataGridView.SelectionChanged"/> event for <c>dataGridView1</c>.
    /// </summary>
    /// <param name="sender">The source of the event, typically <c>dataGridView1</c>.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method is triggered when the selection changes in <c>dataGridView1</c>.
    /// It ensures that the operation is skipped if the grid is initializing or if there is no currently selected row.
    /// </remarks>
    private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
        if (_suppressSelectionChanged) return;
        if (dataGridView1.CurrentRow == null) return;

        LoadSources();
        _mode = FormMode.Editing;
    }

    /// <summary>
    /// Asynchronously initializes the data grid view with inventory source data.
    /// </summary>
    /// <remarks>
    /// This method retrieves all inventory sources from the repository and binds them to the data grid view.
    /// It ensures that the data grid view is populated with up-to-date inventory source information.
    /// </remarks>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation of initializing the data grid view.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if there is an issue retrieving data from the repository.
    /// </exception>
    private async Task InitializeDataGridView() {
        var sources = await _inventorySourceRepository.GetAllAsync();
        dataGridView1.DataSource = sources;
    }

    /// <summary>
    /// Handles the <see cref="Form.Load"/> event for the <see cref="InventorySourceMaintenance"/> form.
    /// </summary>
    /// <param name="sender">The source of the event, typically the form itself.</param>
    /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
    /// <remarks>
    /// This method initializes the data grid by configuring it and asynchronously loading its data.
    /// If an exception occurs during initialization, an error message is displayed, and the form is closed.
    /// </remarks>
    private async void InventorySourceMaintenance_Load(object sender, EventArgs e) {
        try {
            _suppressSelectionChanged = true;
            ConfigureGrid();
            await InitializeDataGridView();

            _suppressSelectionChanged = false;
            _mode = FormMode.Viewing;
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
            Close();
        }
    }

    /// <summary>
    /// Loads the details of the currently selected inventory source into the corresponding UI fields.
    /// </summary>
    /// <remarks>
    /// This method retrieves the selected <see cref="InventorySource"/> from the <c>DataGridView</c>
    /// and populates the UI fields, such as code, description, last printed number, last purchase date,
    /// and activity status, with the respective values.
    /// </remarks>
    /// <seealso cref="InventorySource"/>
    private void LoadSources() {
        if (dataGridView1.CurrentRow?.DataBoundItem is not InventorySource source) return;

        _currentInventorySource = source;

        txtCode.Text = source.Code;
        txtDescription.Text = source.Name;
        txtLastNumber.Text = source.LastPrintedNumber.ToString();
        mtxtLotDate.Text = source.LastPurchaseDate.HasValue
            ? source.LastPurchaseDate.Value.ToString("MM/dd/yyyy")
            : string.Empty;
        chkIsActive.Checked = source.IsActive;
    }

    /// <summary>
    /// Extracts and updates the details of the currently selected inventory source from the user interface.
    /// </summary>
    /// <remarks>
    /// This method retrieves the currently selected <see cref="InventorySource"/> from the data grid,
    /// updates its properties based on the values entered in the form fields, and prepares it for further processing.
    /// </remarks>
    /// <exception cref="InvalidCastException">
    /// Thrown if the currently selected row in the data grid does not contain an <see cref="InventorySource"/> object.
    /// </exception>
    /// <exception cref="FormatException">
    /// Thrown if the values entered in the form fields are not in the expected format.
    /// </exception>
    private InventorySource UpdateCurrentSourceFromForm() {
        if (_currentInventorySource is null) {
            throw new InvalidOperationException("No inventory source is currently being edited.");
        }

        _currentInventorySource.LastPurchaseDate = Convert.ToDateTime(mtxtLotDate.Text);
        _currentInventorySource.Code = txtCode.Text.Trim().ToUpperInvariant();
        _currentInventorySource.Name = txtDescription.Text.Trim();
        _currentInventorySource.IsActive = chkIsActive.Checked;
        _currentInventorySource.LastPrintedNumber = Convert.ToInt32(txtLastNumber.Text);

        return _currentInventorySource;
    }

    /// <summary>
    /// Updates the details of the currently selected inventory source in the repository and refreshes the data grid.
    /// </summary>
    /// <remarks>
    /// This method extracts the details of the currently selected <see cref="InventorySource"/> from the user interface,
    /// updates the repository with the modified data, and then refreshes the data grid to reflect the changes.
    /// </remarks>
    /// <exception cref="InvalidCastException">
    /// Thrown if the currently selected row in the data grid does not contain an <see cref="InventorySource"/> object.
    /// </exception>
    /// <exception cref="FormatException">
    /// Thrown if the values entered in the form fields are not in the expected format.
    /// </exception>
    /// <returns>
    /// A task that represents the asynchronous operation of updating the inventory source and refreshing the data grid.
    /// </returns>
    private async Task UpdateSourceAsync() {
        var source = UpdateCurrentSourceFromForm();
        await _inventorySourceRepository.UpdateSourceAsync(source);
        await InitializeDataGridView();
    }
}