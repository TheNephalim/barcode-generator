namespace BarcodeGenerator {
    partial class ImportFlipwiseInventoryExport {
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
            openFileDialog1 = new OpenFileDialog();
            btnOpenFlipwiseExport = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btnCommitImport = new Button();
            btnClearData = new Button();
            btnCloseWindow = new Button();
            cmbAssignSource = new ComboBox();
            label2 = new Label();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblPrefix = new Label();
            txtAssignPrefix = new TextBox();
            label3 = new Label();
            txtFilterInput = new TextBox();
            btnClearFilters = new Button();
            grpbAssign = new GroupBox();
            btnApplyToSelected = new Button();
            label4 = new Label();
            cmbFilterSource = new ComboBox();
            grpbFilters = new GroupBox();
            btnSelectFiltered = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            grpbAssign.SuspendLayout();
            grpbFilters.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "ofdFlipwiseFileDialog";
            // 
            // btnOpenFlipwiseExport
            // 
            btnOpenFlipwiseExport.Location = new Point(234, 29);
            btnOpenFlipwiseExport.Name = "btnOpenFlipwiseExport";
            btnOpenFlipwiseExport.Size = new Size(125, 23);
            btnOpenFlipwiseExport.TabIndex = 0;
            btnOpenFlipwiseExport.Text = "Open File Dialog";
            btnOpenFlipwiseExport.UseVisualStyleBackColor = true;
            btnOpenFlipwiseExport.Click += btnOpenFlipwiseExport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(52, 29);
            label1.Name = "label1";
            label1.Size = new Size(164, 20);
            label1.TabIndex = 1;
            label1.Text = "Select Flipwise Export:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(52, 285);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(880, 171);
            dataGridView1.TabIndex = 2;
            // 
            // btnCommitImport
            // 
            btnCommitImport.Location = new Point(652, 482);
            btnCommitImport.Name = "btnCommitImport";
            btnCommitImport.Size = new Size(107, 23);
            btnCommitImport.TabIndex = 3;
            btnCommitImport.Text = "Commit Import";
            btnCommitImport.UseVisualStyleBackColor = true;
            btnCommitImport.Click += btnCommitImport_Click;
            // 
            // btnClearData
            // 
            btnClearData.Location = new Point(775, 482);
            btnClearData.Name = "btnClearData";
            btnClearData.Size = new Size(75, 23);
            btnClearData.TabIndex = 4;
            btnClearData.Text = "Clear Data";
            btnClearData.UseVisualStyleBackColor = true;
            btnClearData.Click += btnClearData_Click;
            // 
            // btnCloseWindow
            // 
            btnCloseWindow.Location = new Point(857, 482);
            btnCloseWindow.Name = "btnCloseWindow";
            btnCloseWindow.Size = new Size(75, 23);
            btnCloseWindow.TabIndex = 5;
            btnCloseWindow.Text = "Close";
            btnCloseWindow.UseVisualStyleBackColor = true;
            btnCloseWindow.Click += btnCloseWindow_Click;
            // 
            // cmbAssignSource
            // 
            cmbAssignSource.FormattingEnabled = true;
            cmbAssignSource.Location = new Point(104, 69);
            cmbAssignSource.Name = "cmbAssignSource";
            cmbAssignSource.Size = new Size(179, 25);
            cmbAssignSource.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(16, 67);
            label2.Name = "label2";
            label2.Size = new Size(49, 17);
            label2.TabIndex = 7;
            label2.Text = "Source";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(25, 62);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(46, 17);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(112, 63);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(167, 25);
            cmbStatus.TabIndex = 9;
            cmbStatus.SelectedValueChanged += cmbStatus_SelectedValueChanged;
            // 
            // lblPrefix
            // 
            lblPrefix.AutoSize = true;
            lblPrefix.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrefix.ForeColor = Color.White;
            lblPrefix.Location = new Point(16, 30);
            lblPrefix.Name = "lblPrefix";
            lblPrefix.Size = new Size(48, 17);
            lblPrefix.TabIndex = 10;
            lblPrefix.Text = "Prefix:";
            // 
            // txtAssignPrefix
            // 
            txtAssignPrefix.Location = new Point(104, 30);
            txtAssignPrefix.MaxLength = 3;
            txtAssignPrefix.Name = "txtAssignPrefix";
            txtAssignPrefix.Size = new Size(119, 25);
            txtAssignPrefix.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 25);
            label3.Name = "label3";
            label3.Size = new Size(45, 17);
            label3.TabIndex = 12;
            label3.Text = "Filter:";
            // 
            // textBox2
            // 
            txtFilterInput.Location = new Point(112, 25);
            txtFilterInput.MaxLength = 80;
            txtFilterInput.Name = "txtFilterInput";
            txtFilterInput.Size = new Size(244, 25);
            txtFilterInput.TabIndex = 13;
            txtFilterInput.TextChanged += txtFilterInput_TextChanged;
            // 
            // btnClearFilters
            // 
            btnClearFilters.ForeColor = Color.Black;
            btnClearFilters.Location = new Point(262, 143);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(100, 24);
            btnClearFilters.TabIndex = 14;
            btnClearFilters.Text = "Clear Filters";
            btnClearFilters.UseVisualStyleBackColor = true;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // grpbAssign
            // 
            grpbAssign.Controls.Add(btnApplyToSelected);
            grpbAssign.Controls.Add(lblPrefix);
            grpbAssign.Controls.Add(txtAssignPrefix);
            grpbAssign.Controls.Add(label2);
            grpbAssign.Controls.Add(cmbAssignSource);
            grpbAssign.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpbAssign.ForeColor = Color.White;
            grpbAssign.Location = new Point(52, 85);
            grpbAssign.Name = "grpbAssign";
            grpbAssign.Size = new Size(462, 155);
            grpbAssign.TabIndex = 15;
            grpbAssign.TabStop = false;
            grpbAssign.Text = "Assign";
            // 
            // btnApplyToSelected
            // 
            btnApplyToSelected.ForeColor = Color.Black;
            btnApplyToSelected.Location = new Point(293, 107);
            btnApplyToSelected.Name = "btnApplyToSelected";
            btnApplyToSelected.Size = new Size(146, 33);
            btnApplyToSelected.TabIndex = 12;
            btnApplyToSelected.Text = "Apply To Selected";
            btnApplyToSelected.UseVisualStyleBackColor = true;
            btnApplyToSelected.Click += btnApplyToSelected_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(24, 90);
            label4.Name = "label4";
            label4.Size = new Size(49, 17);
            label4.TabIndex = 13;
            label4.Text = "Source";
            // 
            // cmbFilterSource
            // 
            cmbFilterSource.FormattingEnabled = true;
            cmbFilterSource.Location = new Point(112, 92);
            cmbFilterSource.Name = "cmbFilterSource";
            cmbFilterSource.Size = new Size(167, 25);
            cmbFilterSource.TabIndex = 12;
            cmbFilterSource.SelectedValueChanged += cmbFilterSource_SelectedValueChanged;
            // 
            // grpbFilters
            // 
            grpbFilters.Controls.Add(btnSelectFiltered);
            grpbFilters.Controls.Add(label3);
            grpbFilters.Controls.Add(label4);
            grpbFilters.Controls.Add(btnClearFilters);
            grpbFilters.Controls.Add(cmbStatus);
            grpbFilters.Controls.Add(lblStatus);
            grpbFilters.Controls.Add(cmbFilterSource);
            grpbFilters.Controls.Add(txtFilterInput);
            grpbFilters.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpbFilters.ForeColor = Color.White;
            grpbFilters.Location = new Point(526, 71);
            grpbFilters.Name = "grpbFilters";
            grpbFilters.Size = new Size(406, 192);
            grpbFilters.TabIndex = 16;
            grpbFilters.TabStop = false;
            grpbFilters.Text = "Filters";
            // 
            // btnSelectFiltered
            // 
            btnSelectFiltered.ForeColor = Color.Black;
            btnSelectFiltered.Location = new Point(116, 143);
            btnSelectFiltered.Name = "btnSelectFiltered";
            btnSelectFiltered.Size = new Size(140, 24);
            btnSelectFiltered.TabIndex = 13;
            btnSelectFiltered.Text = "Select Filtered";
            btnSelectFiltered.UseVisualStyleBackColor = true;
            btnSelectFiltered.Click += btnSelectFiltered_Click;
            // 
            // ImportFlipwiseInventoryExport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(955, 517);
            Controls.Add(grpbFilters);
            Controls.Add(grpbAssign);
            Controls.Add(btnCloseWindow);
            Controls.Add(btnClearData);
            Controls.Add(btnCommitImport);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(btnOpenFlipwiseExport);
            Name = "ImportFlipwiseInventoryExport";
            Text = "Import Flipwise Inventory Export";
            Load += ImportFlipwiseInventoryExport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            grpbAssign.ResumeLayout(false);
            grpbAssign.PerformLayout();
            grpbFilters.ResumeLayout(false);
            grpbFilters.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button btnOpenFlipwiseExport;
        private Label label1;
        private DataGridView dataGridView1;
        private Button btnCommitImport;
        private Button btnClearData;
        private Button btnCloseWindow;
        private ComboBox cmbAssignSource;
        private Label label2;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Label lblPrefix;
        private TextBox txtAssignPrefix;
        private Label label3;
        private TextBox txtFilterInput;
        private Button btnClearFilters;
        private GroupBox grpbAssign;
        private Label label4;
        private ComboBox cmbFilterSource;
        private GroupBox grpbFilters;
        private Button btnApplyToSelected;
        private Button btnSelectFiltered;
    }
}