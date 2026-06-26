Barcode Generator

Barcode Generator is a Windows Forms application built with .NET for generating and printing barcode labels for inventory management. It was originally developed to support cataloging vinyl records, but the design is intended to support multiple inventory types through configurable data sources and label templates.

The application generates sequential Code 128 barcode labels that can be printed directly to thermal label printers. Labels include human-readable identifiers, purchase lot information, and visual indicators that can be customized for different inventory sources.

Features
Generate sequential barcode ranges
Print directly to thermal label printers
Support multiple copies of each barcode
Optional collated or non-collated copy ordering
Purchase lot tracking
Configurable inventory source prefixes
Autofac dependency injection
Strongly typed configuration using appsettings.json
Windows Forms desktop interface
Planned Features
SQLite database for persistent configuration
Multiple label templates
Inventory-specific label layouts
Label history and reprinting
Scanner integration
Inventory lookup
Location and storage labels
Price label generation
Condition indicator labels
Technology
.NET
C#
Windows Forms
Autofac
ZXing.Net
System.Drawing printing APIs
SQLite (planned)
Primary Use Case

The project was created to support high-volume inventory processing for vinyl records, allowing items to be cleaned, cataloged, labeled, and scanned efficiently during storage, online sales, and record shows. The architecture is intentionally generic so it can be extended to support books, media, collectibles, and other inventory types.
