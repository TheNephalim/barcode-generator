namespace BarcodeGenerator {
    partial class PriceLabelGenerator {
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
            cmboVinylCondition = new ComboBox();
            cmboSleeveCondition = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            cmboPrice = new ComboBox();
            mtbCustomPrice = new MaskedTextBox();
            label3 = new Label();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            btnPrint = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // cmboVinylCondition
            // 
            cmboVinylCondition.FormattingEnabled = true;
            cmboVinylCondition.Location = new Point(32, 44);
            cmboVinylCondition.Name = "cmboVinylCondition";
            cmboVinylCondition.Size = new Size(121, 23);
            cmboVinylCondition.TabIndex = 0;
            // 
            // cmboSleeveCondition
            // 
            cmboSleeveCondition.FormattingEnabled = true;
            cmboSleeveCondition.Location = new Point(186, 44);
            cmboSleeveCondition.Name = "cmboSleeveCondition";
            cmboSleeveCondition.Size = new Size(121, 23);
            cmboSleeveCondition.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(32, 15);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 2;
            label1.Text = "Vinyl Condition";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(186, 16);
            label2.Name = "label2";
            label2.Size = new Size(140, 21);
            label2.TabIndex = 3;
            label2.Text = "Sleeve Condition";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(354, 41);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(146, 25);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Print Condition";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cmboPrice
            // 
            cmboPrice.FormattingEnabled = true;
            cmboPrice.Location = new Point(32, 119);
            cmboPrice.Name = "cmboPrice";
            cmboPrice.Size = new Size(121, 23);
            cmboPrice.TabIndex = 5;
            // 
            // mtbCustomPrice
            // 
            mtbCustomPrice.Location = new Point(186, 119);
            mtbCustomPrice.Mask = "$99999";
            mtbCustomPrice.Name = "mtbCustomPrice";
            mtbCustomPrice.Size = new Size(100, 23);
            mtbCustomPrice.TabIndex = 6;
            mtbCustomPrice.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(32, 92);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 7;
            label3.Text = "Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(181, 92);
            label4.Name = "label4";
            label4.Size = new Size(110, 21);
            label4.TabIndex = 8;
            label4.Text = "Custom Price";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(32, 184);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(121, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(31, 158);
            label5.Name = "label5";
            label5.Size = new Size(148, 21);
            label5.TabIndex = 10;
            label5.Text = "Number of Copies";
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.Location = new Point(368, 235);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(90, 38);
            btnPrint.TabIndex = 11;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(278, 235);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 38);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // VinylPricingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(545, 317);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(mtbCustomPrice);
            Controls.Add(cmboPrice);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmboSleeveCondition);
            Controls.Add(cmboVinylCondition);
            Name = "VinylPricingForm";
            Text = "Vinyl Pricing";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmboVinylCondition;
        private ComboBox cmboSleeveCondition;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private ComboBox cmboPrice;
        private MaskedTextBox mtbCustomPrice;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private Button btnPrint;
        private Button btnClose;
    }
}