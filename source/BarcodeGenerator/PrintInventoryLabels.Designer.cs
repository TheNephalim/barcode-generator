namespace BarcodeGenerator {
    partial class PrintInventoryLabels {
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
            chkSelectAllItems = new CheckBox();
            label1 = new Label();
            btnClose = new Button();
            btnPrint = new Button();
            txtInventoryFilter = new TextBox();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(749, 222);
            dataGridView1.TabIndex = 0;
            // 
            // chkSelectAllItems
            // 
            chkSelectAllItems.AutoSize = true;
            chkSelectAllItems.Checked = true;
            chkSelectAllItems.CheckState = CheckState.Checked;
            chkSelectAllItems.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkSelectAllItems.ForeColor = Color.White;
            chkSelectAllItems.Location = new Point(24, 67);
            chkSelectAllItems.Name = "chkSelectAllItems";
            chkSelectAllItems.Size = new Size(84, 21);
            chkSelectAllItems.TabIndex = 1;
            chkSelectAllItems.Text = "Select All";
            chkSelectAllItems.UseVisualStyleBackColor = true;
            chkSelectAllItems.CheckedChanged += chkSelectAllItems_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 26);
            label1.Name = "label1";
            label1.Size = new Size(45, 17);
            label1.TabIndex = 2;
            label1.Text = "Filter:";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(698, 397);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 30);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrint.Location = new Point(608, 397);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(75, 30);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // txtInventoryFilter
            // 
            txtInventoryFilter.Location = new Point(75, 26);
            txtInventoryFilter.Name = "txtInventoryFilter";
            txtInventoryFilter.Size = new Size(290, 23);
            txtInventoryFilter.TabIndex = 5;
            txtInventoryFilter.TextChanged += txtInventoryFilter_TextChanged;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(389, 22);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 25);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // PrintInventoryLabels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(txtInventoryFilter);
            Controls.Add(btnPrint);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(chkSelectAllItems);
            Controls.Add(dataGridView1);
            Name = "PrintInventoryLabels";
            Text = "PrintInventoryLabels";
            Load += PrintInventoryLabels_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private CheckBox chkSelectAllItems;
        private Label label1;
        private Button btnClose;
        private Button btnPrint;
        private TextBox txtInventoryFilter;
        private Button btnClear;
    }
}