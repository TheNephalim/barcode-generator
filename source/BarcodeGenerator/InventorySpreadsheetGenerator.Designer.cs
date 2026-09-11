namespace BarcodeGenerator {
    partial class InventorySpreadsheetGenerator {
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
            btnGenerateSpreadsheet = new Button();
            SuspendLayout();
            // 
            // btnGenerateSpreadsheet
            // 
            btnGenerateSpreadsheet.Location = new Point(56, 37);
            btnGenerateSpreadsheet.Name = "btnGenerateSpreadsheet";
            btnGenerateSpreadsheet.Size = new Size(159, 34);
            btnGenerateSpreadsheet.TabIndex = 0;
            btnGenerateSpreadsheet.Text = "Generate Spreadsheet";
            btnGenerateSpreadsheet.UseVisualStyleBackColor = true;
            btnGenerateSpreadsheet.Click += btnGenerateSpreadsheet_Click;
            // 
            // InventorySpreadsheetGenerator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGenerateSpreadsheet);
            Name = "InventorySpreadsheetGenerator";
            Text = "Inventory Spreadsheet Generator";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGenerateSpreadsheet;
    }
}