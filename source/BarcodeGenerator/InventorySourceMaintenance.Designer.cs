namespace BarcodeGenerator;

/// <summary>
/// Represents a partial class for managing inventory source maintenance functionality 
/// within the Barcode Generator application.
/// </summary>
/// <remarks>
/// This class is auto-generated and may contain designer-generated code. 
/// It is used to handle resources and functionality related to inventory source maintenance.
/// </remarks>
partial class InventorySourceMaintenance {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        dataGridView1 = new DataGridView();
        lblCode = new Label();
        txtCode = new TextBox();
        lblDescription = new Label();
        txtDescription = new TextBox();
        lblLastNumber = new Label();
        txtLastNumber = new TextBox();
        lblDefaultLotDate = new Label();
        lblActive = new Label();
        btnAddNew = new Button();
        btnSave = new Button();
        btnClose = new Button();
        chkIsActive = new CheckBox();
        mtxtLotDate = new MaskedTextBox();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(46, 38);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new Size(544, 115);
        dataGridView1.TabIndex = 0;
        dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
        dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        // 
        // lblCode
        // 
        lblCode.AutoSize = true;
        lblCode.Location = new Point(52, 192);
        lblCode.Name = "lblCode";
        lblCode.Size = new Size(35, 15);
        lblCode.TabIndex = 1;
        lblCode.Text = "Code";
        // 
        // txtCode
        // 
        txtCode.Location = new Point(157, 192);
        txtCode.Name = "txtCode";
        txtCode.Size = new Size(164, 23);
        txtCode.TabIndex = 2;
        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(50, 239);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(70, 15);
        lblDescription.TabIndex = 3;
        lblDescription.Text = "Description:";
        // 
        // txtDescription
        // 
        txtDescription.Location = new Point(157, 239);
        txtDescription.Name = "txtDescription";
        txtDescription.Size = new Size(164, 23);
        txtDescription.TabIndex = 4;
        // 
        // lblLastNumber
        // 
        lblLastNumber.AutoSize = true;
        lblLastNumber.Location = new Point(52, 283);
        lblLastNumber.Name = "lblLastNumber";
        lblLastNumber.Size = new Size(78, 15);
        lblLastNumber.TabIndex = 5;
        lblLastNumber.Text = "Last Number:";
        // 
        // txtLastNumber
        // 
        txtLastNumber.Location = new Point(157, 283);
        txtLastNumber.Name = "txtLastNumber";
        txtLastNumber.Size = new Size(164, 23);
        txtLastNumber.TabIndex = 6;
        // 
        // lblDefaultLotDate
        // 
        lblDefaultLotDate.AutoSize = true;
        lblDefaultLotDate.Location = new Point(52, 323);
        lblDefaultLotDate.Name = "lblDefaultLotDate";
        lblDefaultLotDate.Size = new Size(95, 15);
        lblDefaultLotDate.TabIndex = 7;
        lblDefaultLotDate.Text = "Default Lot Date:";
        // 
        // lblActive
        // 
        lblActive.AutoSize = true;
        lblActive.Location = new Point(52, 365);
        lblActive.Name = "lblActive";
        lblActive.Size = new Size(43, 15);
        lblActive.TabIndex = 9;
        lblActive.Text = "Active:";
        // 
        // btnAddNew
        // 
        btnAddNew.Location = new Point(353, 424);
        btnAddNew.Name = "btnAddNew";
        btnAddNew.Size = new Size(75, 23);
        btnAddNew.TabIndex = 12;
        btnAddNew.Text = "Add New";
        btnAddNew.UseVisualStyleBackColor = true;
        btnAddNew.Click += btnAddNew_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(434, 424);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 23);
        btnSave.TabIndex = 13;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnClose
        // 
        btnClose.Location = new Point(515, 424);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(75, 23);
        btnClose.TabIndex = 16;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // chkIsActive
        // 
        chkIsActive.AutoSize = true;
        chkIsActive.Location = new Point(157, 364);
        chkIsActive.Name = "chkIsActive";
        chkIsActive.Size = new Size(15, 14);
        chkIsActive.TabIndex = 17;
        chkIsActive.UseVisualStyleBackColor = true;
        // 
        // mtxtLotDate
        // 
        mtxtLotDate.Location = new Point(157, 323);
        mtxtLotDate.Mask = "00/00/0000";
        mtxtLotDate.Name = "mtxtLotDate";
        mtxtLotDate.Size = new Size(164, 23);
        mtxtLotDate.TabIndex = 18;
        mtxtLotDate.ValidatingType = typeof(DateTime);
        // 
        // InventorySourceMaintenance
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Green;
        ClientSize = new Size(649, 459);
        Controls.Add(mtxtLotDate);
        Controls.Add(chkIsActive);
        Controls.Add(btnClose);
        Controls.Add(btnSave);
        Controls.Add(btnAddNew);
        Controls.Add(lblActive);
        Controls.Add(lblDefaultLotDate);
        Controls.Add(txtLastNumber);
        Controls.Add(lblLastNumber);
        Controls.Add(txtDescription);
        Controls.Add(lblDescription);
        Controls.Add(txtCode);
        Controls.Add(lblCode);
        Controls.Add(dataGridView1);
        Name = "InventorySourceMaintenance";
        Text = "Inventory Source Maintenance";
        Load += InventorySourceMaintenance_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dataGridView1;
    private Label lblCode;
    private TextBox txtCode;
    private Label lblDescription;
    private TextBox txtDescription;
    private Label lblLastNumber;
    private TextBox txtLastNumber;
    private Label lblDefaultLotDate;
    private Label lblActive;
    private Button btnAddNew;
    private Button btnSave;
    private Button btnClose;
    private CheckBox chkIsActive;
    private MaskedTextBox mtxtLotDate;
}