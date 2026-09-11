using BarcodeGenerator.Configuration;
using BarcodeGenerator.Data.Repositories;
using BarcodeGenerator.ExcelInfrastructure;
using BarcodeGenerator.Reporting.Contracts.Dtos;

namespace BarcodeGenerator {
    public partial class InventorySpreadsheetGenerator : Form {
        private readonly BarcodeGeneratorConfiguration _configuration;
        private readonly IInventoryItemRepository _inventoryItemRepository;
        private readonly IExcelWorkbookGenerator<InventoryItemDto[]> _workbookGenerator;

        public InventorySpreadsheetGenerator(BarcodeGeneratorConfiguration configuration, IInventoryItemRepository inventoryItemRepository, IExcelWorkbookGenerator<InventoryItemDto[]> workbookGenerator) {
            InitializeComponent();
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _workbookGenerator = workbookGenerator ?? throw new ArgumentNullException(nameof(workbookGenerator));
            _inventoryItemRepository = inventoryItemRepository ??
                                       throw new ArgumentNullException(nameof(inventoryItemRepository));
        }

        private async void btnGenerateSpreadsheet_Click(object sender, EventArgs e) {
            var data = await _inventoryItemRepository.GetAllAsReportDtoAsync();
            var filename = $"{DateTime.Now:yyyyMMdd-hhmmss}-Inventory-Items.xlsx";

            using var saveFileDialog = new SaveFileDialog() {
                Title = "Save Inventory Report",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                DefaultExt = "xlsx",
                AddExtension = true,
                FileName = filename
            };

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) {
                return;
            }

            var filePath = saveFileDialog.FileName;
            var reportParameters = CreateWorkbookParameters(data, filePath);
            await GetExcelReportsAsFileByteArrayAsync(reportParameters);
        }

        /// <summary>
        /// Creates and configures the parameters required for generating an Excel workbook
        /// containing inventory item data.
        /// </summary>
        /// <param name="recordsArray">
        /// An array of <see cref="InventoryItemDto"/> representing the inventory items
        /// to be included in the workbook.
        /// </param>
        /// <returns>
        /// A <see cref="WorkbookParameters{T}"/> object configured with metadata, worksheet
        /// properties, and the provided inventory data.
        /// </returns>
        /// <remarks>
        /// The generated workbook includes metadata such as author, company, subject, and
        /// creation date, which are derived from the application's configuration. The workbook
        /// also includes worksheet-specific properties like title, frozen rows, and repeated rows.
        /// </remarks>
        private WorkbookParameters<InventoryItemDto[]> CreateWorkbookParameters(InventoryItemDto[] recordsArray, string filePath) {
            return new WorkbookParameters<InventoryItemDto[]> {
                WorksheetsProperties = [
                    new WorksheetProperties() {
                        RowsToRepeat = Tuple.Create(1, 1),
                        FreezeRow = 1,
                        ShouldRepeatRows = true,
                        WorksheetTitle = "Search Results"
                    }
                ],
                SpreadsheetData = recordsArray,
                Author = _configuration.ReportConfiguration.Author,
                Company = _configuration.ReportConfiguration.Company,
                Subject = _configuration.ReportConfiguration.Subject,
                CreateDate = DateTime.Now,
                FileName = filePath
            };
        }

        /// <summary>
        /// Generates an Excel report based on the provided parameters and returns it as a byte array.
        /// </summary>
        /// <param name="parameters">
        /// The parameters required for generating the Excel workbook, including metadata and the data to be included in the report.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the Excel report as a byte array.
        /// </returns>
        /// <remarks>
        /// This method uses the provided <see cref="IExcelWorkbookGenerator{TResultsDto}"/> implementation to generate the report
        /// and converts the resulting stream into a byte array for further use.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="parameters"/> argument is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the report generation process encounters an error.
        /// </exception>
        private async Task GetExcelReportsAsFileByteArrayAsync(WorkbookParameters<InventoryItemDto[]> parameters) {
            await _workbookGenerator.GenerateReportToFileAsync(parameters);
        }
    }
}