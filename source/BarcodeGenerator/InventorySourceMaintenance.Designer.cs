namespace BarcodeGenerator {
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
            Code = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            LastNumber = new DataGridViewTextBoxColumn();
            LastLotDate = new DataGridViewTextBoxColumn();
            Active = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Code, Name, LastNumber, LastLotDate, Active });
            dataGridView1.Location = new Point(46, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(544, 115);
            dataGridView1.TabIndex = 0;
            // 
            // Code
            // 
            Code.HeaderText = "Code";
            Code.Name = "Code";
            // 
            // Name
            // 
            Name.HeaderText = "Name/Description";
            Name.Name = "Name";
            // 
            // LastNumber
            // 
            LastNumber.HeaderText = "Last Number";
            LastNumber.Name = "LastNumber";
            // 
            // LastLotDate
            // 
            LastLotDate.HeaderText = "Last Lot Date";
            LastLotDate.Name = "LastLotDate";
            // 
            // Active
            // 
            Active.HeaderText = "Active";
            Active.Name = "Active";
            // 
            // InventorySourceMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 0);
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "InventorySourceMaintenance";
            Text = "Inventory Source Maintenance";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn LastNumber;
        private DataGridViewTextBoxColumn LastLotDate;
        private DataGridViewTextBoxColumn Active;
    }
}