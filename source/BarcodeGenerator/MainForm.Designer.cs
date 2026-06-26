namespace BarcodeGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lblLaunchBarcodeGenerator = new Label();
            btnLaunchBarcodeLabelGenerator = new Button();
            lblLaunchPriceLabelGenerator = new Label();
            btnLaunchPriceLabelGenerator = new Button();
            SuspendLayout();
            // 
            // lblLaunchBarcodeGenerator
            // 
            lblLaunchBarcodeGenerator.AutoSize = true;
            lblLaunchBarcodeGenerator.Location = new Point(12, 42);
            lblLaunchBarcodeGenerator.Name = "lblLaunchBarcodeGenerator";
            lblLaunchBarcodeGenerator.Size = new Size(201, 15);
            lblLaunchBarcodeGenerator.TabIndex = 0;
            lblLaunchBarcodeGenerator.Text = "Launch the Barcode Label Generator:";
            // 
            // btnLaunchBarcodeLabelGenerator
            // 
            btnLaunchBarcodeLabelGenerator.Location = new Point(219, 38);
            btnLaunchBarcodeLabelGenerator.Name = "btnLaunchBarcodeLabelGenerator";
            btnLaunchBarcodeLabelGenerator.Size = new Size(75, 23);
            btnLaunchBarcodeLabelGenerator.TabIndex = 1;
            btnLaunchBarcodeLabelGenerator.Text = "Launch";
            btnLaunchBarcodeLabelGenerator.UseVisualStyleBackColor = true;
            btnLaunchBarcodeLabelGenerator.Click += btnLaunchBarcodeLabelGenerator_Click;
            // 
            // lblLaunchPriceLabelGenerator
            // 
            lblLaunchPriceLabelGenerator.AutoSize = true;
            lblLaunchPriceLabelGenerator.Location = new Point(12, 74);
            lblLaunchPriceLabelGenerator.Name = "lblLaunchPriceLabelGenerator";
            lblLaunchPriceLabelGenerator.Size = new Size(184, 15);
            lblLaunchPriceLabelGenerator.TabIndex = 2;
            lblLaunchPriceLabelGenerator.Text = "Launch the Price Label Generator:";
            // 
            // btnLaunchPriceLabelGenerator
            // 
            btnLaunchPriceLabelGenerator.Location = new Point(219, 70);
            btnLaunchPriceLabelGenerator.Name = "btnLaunchPriceLabelGenerator";
            btnLaunchPriceLabelGenerator.Size = new Size(75, 23);
            btnLaunchPriceLabelGenerator.TabIndex = 3;
            btnLaunchPriceLabelGenerator.Text = "Launch";
            btnLaunchPriceLabelGenerator.UseVisualStyleBackColor = true;
            btnLaunchPriceLabelGenerator.Click += btnLaunchPriceLabelGenerator_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(800, 467);
            Controls.Add(btnLaunchPriceLabelGenerator);
            Controls.Add(lblLaunchPriceLabelGenerator);
            Controls.Add(btnLaunchBarcodeLabelGenerator);
            Controls.Add(lblLaunchBarcodeGenerator);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLaunchBarcodeGenerator;
        private Button btnLaunchBarcodeLabelGenerator;
        private Label lblLaunchPriceLabelGenerator;
        private Button btnLaunchPriceLabelGenerator;
    }
}
