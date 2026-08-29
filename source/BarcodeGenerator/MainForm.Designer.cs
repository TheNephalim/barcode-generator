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
            components = new System.ComponentModel.Container();
            lblLaunchBarcodeGenerator = new Label();
            btnLaunchBarcodeLabelGenerator = new Button();
            lblLaunchPriceLabelGenerator = new Label();
            btnLaunchPriceLabelGenerator = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            labelsToolStripMenuItem = new ToolStripMenuItem();
            generateInventoryLabelsToolStripMenuItem = new ToolStripMenuItem();
            generatePriceLabelsToolStripMenuItem = new ToolStripMenuItem();
            reprintLabelsToolStripMenuItem = new ToolStripMenuItem();
            printTestLabelToolStripMenuItem = new ToolStripMenuItem();
            maintenanceToolStripMenuItem = new ToolStripMenuItem();
            inventorySourcesToolStripMenuItem = new ToolStripMenuItem();
            labelTemplatesToolStripMenuItem = new ToolStripMenuItem();
            printerSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            scannerTestToolStripMenuItem = new ToolStripMenuItem();
            resetLastNumberToolStripMenuItem = new ToolStripMenuItem();
            exportLabelHistoryToolStripMenuItem = new ToolStripMenuItem();
            databaseBackupToolStripMenuItem = new ToolStripMenuItem();
            importFlipwiseInventoryExportToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblLaunchBarcodeGenerator
            // 
            lblLaunchBarcodeGenerator.AutoSize = true;
            lblLaunchBarcodeGenerator.Location = new Point(12, 54);
            lblLaunchBarcodeGenerator.Name = "lblLaunchBarcodeGenerator";
            lblLaunchBarcodeGenerator.Size = new Size(201, 15);
            lblLaunchBarcodeGenerator.TabIndex = 0;
            lblLaunchBarcodeGenerator.Text = "Launch the Barcode Label Generator:";
            // 
            // btnLaunchBarcodeLabelGenerator
            // 
            btnLaunchBarcodeLabelGenerator.Location = new Point(219, 50);
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
            lblLaunchPriceLabelGenerator.Location = new Point(12, 86);
            lblLaunchPriceLabelGenerator.Name = "lblLaunchPriceLabelGenerator";
            lblLaunchPriceLabelGenerator.Size = new Size(184, 15);
            lblLaunchPriceLabelGenerator.TabIndex = 2;
            lblLaunchPriceLabelGenerator.Text = "Launch the Price Label Generator:";
            // 
            // btnLaunchPriceLabelGenerator
            // 
            btnLaunchPriceLabelGenerator.Location = new Point(219, 82);
            btnLaunchPriceLabelGenerator.Name = "btnLaunchPriceLabelGenerator";
            btnLaunchPriceLabelGenerator.Size = new Size(75, 23);
            btnLaunchPriceLabelGenerator.TabIndex = 3;
            btnLaunchPriceLabelGenerator.Text = "Launch";
            btnLaunchPriceLabelGenerator.UseVisualStyleBackColor = true;
            btnLaunchPriceLabelGenerator.Click += btnLaunchPriceLabelGenerator_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, labelsToolStripMenuItem, maintenanceToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // labelsToolStripMenuItem
            // 
            labelsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateInventoryLabelsToolStripMenuItem, generatePriceLabelsToolStripMenuItem, reprintLabelsToolStripMenuItem, printTestLabelToolStripMenuItem });
            labelsToolStripMenuItem.Name = "labelsToolStripMenuItem";
            labelsToolStripMenuItem.Size = new Size(52, 20);
            labelsToolStripMenuItem.Text = "Labels";
            // 
            // generateInventoryLabelsToolStripMenuItem
            // 
            generateInventoryLabelsToolStripMenuItem.Name = "generateInventoryLabelsToolStripMenuItem";
            generateInventoryLabelsToolStripMenuItem.Size = new Size(210, 22);
            generateInventoryLabelsToolStripMenuItem.Text = "Generate Inventory Labels";
            // 
            // generatePriceLabelsToolStripMenuItem
            // 
            generatePriceLabelsToolStripMenuItem.Name = "generatePriceLabelsToolStripMenuItem";
            generatePriceLabelsToolStripMenuItem.Size = new Size(210, 22);
            generatePriceLabelsToolStripMenuItem.Text = "Generate Price Labels";
            // 
            // reprintLabelsToolStripMenuItem
            // 
            reprintLabelsToolStripMenuItem.Name = "reprintLabelsToolStripMenuItem";
            reprintLabelsToolStripMenuItem.Size = new Size(210, 22);
            reprintLabelsToolStripMenuItem.Text = "Reprint Labels";
            // 
            // printTestLabelToolStripMenuItem
            // 
            printTestLabelToolStripMenuItem.Name = "printTestLabelToolStripMenuItem";
            printTestLabelToolStripMenuItem.Size = new Size(210, 22);
            printTestLabelToolStripMenuItem.Text = "Print Test Label";
            // 
            // maintenanceToolStripMenuItem
            // 
            maintenanceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inventorySourcesToolStripMenuItem, labelTemplatesToolStripMenuItem, printerSettingsToolStripMenuItem });
            maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            maintenanceToolStripMenuItem.Size = new Size(88, 20);
            maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // inventorySourcesToolStripMenuItem
            // 
            inventorySourcesToolStripMenuItem.Name = "inventorySourcesToolStripMenuItem";
            inventorySourcesToolStripMenuItem.Size = new Size(168, 22);
            inventorySourcesToolStripMenuItem.Text = "Inventory Sources";
            inventorySourcesToolStripMenuItem.Click += inventorySourcesToolStripMenuItem_Click;
            // 
            // labelTemplatesToolStripMenuItem
            // 
            labelTemplatesToolStripMenuItem.Name = "labelTemplatesToolStripMenuItem";
            labelTemplatesToolStripMenuItem.Size = new Size(168, 22);
            labelTemplatesToolStripMenuItem.Text = "Label Templates";
            // 
            // printerSettingsToolStripMenuItem
            // 
            printerSettingsToolStripMenuItem.Name = "printerSettingsToolStripMenuItem";
            printerSettingsToolStripMenuItem.Size = new Size(168, 22);
            printerSettingsToolStripMenuItem.Text = "Printer Settings";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scannerTestToolStripMenuItem, resetLastNumberToolStripMenuItem, exportLabelHistoryToolStripMenuItem, databaseBackupToolStripMenuItem, importFlipwiseInventoryExportToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // scannerTestToolStripMenuItem
            // 
            scannerTestToolStripMenuItem.Name = "scannerTestToolStripMenuItem";
            scannerTestToolStripMenuItem.Size = new Size(244, 22);
            scannerTestToolStripMenuItem.Text = "Scanner Test";
            // 
            // resetLastNumberToolStripMenuItem
            // 
            resetLastNumberToolStripMenuItem.Name = "resetLastNumberToolStripMenuItem";
            resetLastNumberToolStripMenuItem.Size = new Size(244, 22);
            resetLastNumberToolStripMenuItem.Text = "Reset Last Number";
            // 
            // exportLabelHistoryToolStripMenuItem
            // 
            exportLabelHistoryToolStripMenuItem.Name = "exportLabelHistoryToolStripMenuItem";
            exportLabelHistoryToolStripMenuItem.Size = new Size(244, 22);
            exportLabelHistoryToolStripMenuItem.Text = "Export Label History";
            // 
            // databaseBackupToolStripMenuItem
            // 
            databaseBackupToolStripMenuItem.Name = "databaseBackupToolStripMenuItem";
            databaseBackupToolStripMenuItem.Size = new Size(244, 22);
            databaseBackupToolStripMenuItem.Text = "Database Backup";
            // 
            // importFlipwiseInventoryExportToolStripMenuItem
            // 
            importFlipwiseInventoryExportToolStripMenuItem.Name = "importFlipwiseInventoryExportToolStripMenuItem";
            importFlipwiseInventoryExportToolStripMenuItem.Size = new Size(244, 22);
            importFlipwiseInventoryExportToolStripMenuItem.Text = "Import Flipwise Inventory Export";
            importFlipwiseInventoryExportToolStripMenuItem.Click += importFlipwiseInventoryExportToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(800, 212);
            Controls.Add(btnLaunchPriceLabelGenerator);
            Controls.Add(lblLaunchPriceLabelGenerator);
            Controls.Add(btnLaunchBarcodeLabelGenerator);
            Controls.Add(lblLaunchBarcodeGenerator);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Barcode Generator";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLaunchBarcodeGenerator;
        private Button btnLaunchBarcodeLabelGenerator;
        private Label lblLaunchPriceLabelGenerator;
        private Button btnLaunchPriceLabelGenerator;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem labelsToolStripMenuItem;
        private ToolStripMenuItem generateInventoryLabelsToolStripMenuItem;
        private ToolStripMenuItem generatePriceLabelsToolStripMenuItem;
        private ToolStripMenuItem reprintLabelsToolStripMenuItem;
        private ToolStripMenuItem printTestLabelToolStripMenuItem;
        private ToolStripMenuItem maintenanceToolStripMenuItem;
        private ToolStripMenuItem inventorySourcesToolStripMenuItem;
        private ToolStripMenuItem labelTemplatesToolStripMenuItem;
        private ToolStripMenuItem printerSettingsToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem scannerTestToolStripMenuItem;
        private ToolStripMenuItem resetLastNumberToolStripMenuItem;
        private ToolStripMenuItem exportLabelHistoryToolStripMenuItem;
        private ToolStripMenuItem databaseBackupToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem importFlipwiseInventoryExportToolStripMenuItem;
        private ErrorProvider errorProvider1;
    }
}
