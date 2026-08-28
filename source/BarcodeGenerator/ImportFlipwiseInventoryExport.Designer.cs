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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "ofdFlipwiseFileDialog";
            // 
            // btnOpenFlipwiseExport
            // 
            btnOpenFlipwiseExport.Location = new Point(203, 31);
            btnOpenFlipwiseExport.Name = "btnOpenFlipwiseExport";
            btnOpenFlipwiseExport.Size = new Size(125, 23);
            btnOpenFlipwiseExport.TabIndex = 0;
            btnOpenFlipwiseExport.Text = "Open File Dialog";
            btnOpenFlipwiseExport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 34);
            label1.Name = "label1";
            label1.Size = new Size(164, 20);
            label1.TabIndex = 1;
            label1.Text = "Select Flipwise Export:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(741, 171);
            dataGridView1.TabIndex = 2;
            // 
            // btnCommitImport
            // 
            btnCommitImport.Location = new Point(493, 293);
            btnCommitImport.Name = "btnCommitImport";
            btnCommitImport.Size = new Size(107, 23);
            btnCommitImport.TabIndex = 3;
            btnCommitImport.Text = "Commit Import";
            btnCommitImport.UseVisualStyleBackColor = true;
            // 
            // btnClearData
            // 
            btnClearData.Location = new Point(606, 293);
            btnClearData.Name = "btnClearData";
            btnClearData.Size = new Size(75, 23);
            btnClearData.TabIndex = 4;
            btnClearData.Text = "Clear Data";
            btnClearData.UseVisualStyleBackColor = true;
            // 
            // btnCloseWindow
            // 
            btnCloseWindow.Location = new Point(687, 293);
            btnCloseWindow.Name = "btnCloseWindow";
            btnCloseWindow.Size = new Size(75, 23);
            btnCloseWindow.TabIndex = 5;
            btnCloseWindow.Text = "Close";
            btnCloseWindow.UseVisualStyleBackColor = true;
            // 
            // ImportFlipwiseInventoryExport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(800, 360);
            Controls.Add(btnCloseWindow);
            Controls.Add(btnClearData);
            Controls.Add(btnCommitImport);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(btnOpenFlipwiseExport);
            Name = "ImportFlipwiseInventoryExport";
            Text = "Import Flipwise Inventory Export";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
    }
}