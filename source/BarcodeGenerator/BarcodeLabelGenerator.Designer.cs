namespace BarcodeGenerator;

partial class BarcodeLabelGenerator {
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
        nudStartNumber = new NumericUpDown();
        nudEndNumber = new NumericUpDown();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        monthCalendar1 = new MonthCalendar();
        btnGenerate = new Button();
        btnCancel = new Button();
        cmboSources = new ComboBox();
        label4 = new Label();
        nudCopyNumber = new NumericUpDown();
        chkIsCollated = new CheckBox();
        chkSuppressLastNumberUpdate = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)nudStartNumber).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudEndNumber).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudCopyNumber).BeginInit();
        SuspendLayout();
        // 
        // nudStartNumber
        // 
        nudStartNumber.Location = new Point(430, 54);
        nudStartNumber.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        nudStartNumber.Name = "nudStartNumber";
        nudStartNumber.Size = new Size(120, 23);
        nudStartNumber.TabIndex = 1;
        // 
        // nudEndNumber
        // 
        nudEndNumber.Location = new Point(590, 54);
        nudEndNumber.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        nudEndNumber.Name = "nudEndNumber";
        nudEndNumber.Size = new Size(120, 23);
        nudEndNumber.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(37, 14);
        label1.Name = "label1";
        label1.Size = new Size(77, 15);
        label1.TabIndex = 3;
        label1.Text = "Source Code:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(430, 36);
        label2.Name = "label2";
        label2.Size = new Size(98, 15);
        label2.TabIndex = 4;
        label2.Text = "Starting Number:";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(590, 36);
        label3.Name = "label3";
        label3.Size = new Size(94, 15);
        label3.TabIndex = 5;
        label3.Text = "Ending Number:";
        // 
        // monthCalendar1
        // 
        monthCalendar1.Location = new Point(179, 36);
        monthCalendar1.Name = "monthCalendar1";
        monthCalendar1.TabIndex = 7;
        // 
        // btnGenerate
        // 
        btnGenerate.Location = new Point(490, 194);
        btnGenerate.Name = "btnGenerate";
        btnGenerate.Size = new Size(89, 38);
        btnGenerate.TabIndex = 8;
        btnGenerate.Text = "Generate";
        btnGenerate.UseVisualStyleBackColor = true;
        btnGenerate.Click += btnGenerate_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(590, 194);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(94, 38);
        btnCancel.TabIndex = 9;
        btnCancel.Text = "Close";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // cmboSources
        // 
        cmboSources.FormattingEnabled = true;
        cmboSources.Location = new Point(39, 34);
        cmboSources.Name = "cmboSources";
        cmboSources.Size = new Size(121, 23);
        cmboSources.TabIndex = 10;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(430, 89);
        label4.Name = "label4";
        label4.Size = new Size(67, 15);
        label4.TabIndex = 11;
        label4.Text = "# of Copies";
        // 
        // nudCopyNumber
        // 
        nudCopyNumber.Location = new Point(430, 112);
        nudCopyNumber.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
        nudCopyNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCopyNumber.Name = "nudCopyNumber";
        nudCopyNumber.Size = new Size(49, 23);
        nudCopyNumber.TabIndex = 12;
        nudCopyNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // chkIsCollated
        // 
        chkIsCollated.AutoSize = true;
        chkIsCollated.Location = new Point(529, 112);
        chkIsCollated.Name = "chkIsCollated";
        chkIsCollated.Size = new Size(148, 19);
        chkIsCollated.TabIndex = 13;
        chkIsCollated.Text = "Group Copies Together";
        chkIsCollated.UseVisualStyleBackColor = true;
        // 
        // chkSuppressLastNumberUpdate
        // 
        chkSuppressLastNumberUpdate.AutoSize = true;
        chkSuppressLastNumberUpdate.Location = new Point(529, 137);
        chkSuppressLastNumberUpdate.Name = "chkSuppressLastNumberUpdate";
        chkSuppressLastNumberUpdate.Size = new Size(209, 19);
        chkSuppressLastNumberUpdate.TabIndex = 14;
        chkSuppressLastNumberUpdate.Text = "Do not update last printed number";
        chkSuppressLastNumberUpdate.UseVisualStyleBackColor = true;
        // 
        // BarcodeLabelGenerator
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.DarkSeaGreen;
        ClientSize = new Size(800, 279);
        Controls.Add(chkSuppressLastNumberUpdate);
        Controls.Add(chkIsCollated);
        Controls.Add(nudCopyNumber);
        Controls.Add(label4);
        Controls.Add(cmboSources);
        Controls.Add(btnCancel);
        Controls.Add(btnGenerate);
        Controls.Add(monthCalendar1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(nudEndNumber);
        Controls.Add(nudStartNumber);
        Name = "BarcodeLabelGenerator";
        Text = "Form1";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)nudStartNumber).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudEndNumber).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudCopyNumber).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private NumericUpDown nudStartNumber;
    private NumericUpDown nudEndNumber;
    private Label label1;
    private Label label2;
    private Label label3;
    private MonthCalendar monthCalendar1;
    private Button btnGenerate;
    private Button btnCancel;
    private ComboBox cmboSources;
    private Label label4;
    private NumericUpDown nudCopyNumber;
    private CheckBox chkIsCollated;
    private CheckBox chkSuppressLastNumberUpdate;
}