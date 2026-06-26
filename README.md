```markdown
# Barcode Generator

Barcode Generator is a Windows Forms application built with .NET for generating and printing sequential barcode labels for inventory management.

The project was originally developed to streamline cataloging and organizing vinyl records but is designed to support a wide variety of inventory types through configurable data sources and reusable label generation components.

The application produces Code 128 barcode labels suitable for thermal printers and is intended to simplify inventory tracking, storage organization, and point-of-sale workflows.

---

## Features

- Generate sequential Code 128 barcodes
- Print directly to supported thermal label printers
- Generate single or multiple copies of labels
- Support both collated and non-collated printing
- Purchase lot/date tracking
- Configurable inventory source prefixes
- Human-readable barcode text
- Windows Forms desktop interface
- Dependency Injection using Autofac
- Strongly typed configuration via `appsettings.json`

---

## Planned Features

The long-term goal is to evolve Barcode Generator into a flexible inventory labeling platform.

Planned enhancements include:

- SQLite configuration database
- Persistent tracking of last printed barcode by inventory source
- Multiple label templates
- Inventory-specific layouts
- Barcode lookup and reprinting
- Label history
- Scanner integration
- Price labels
- Condition indicator labels
- Storage location labels
- Lot and container labels
- Support for additional inventory categories beyond vinyl records

---

## Technology

- .NET
- C#
- Windows Forms
- Autofac
- ZXing.Net
- System.Drawing Printing
- SQLite (planned)

---

## Typical Workflow

The application is designed around a simple inventory workflow.

1. Acquire inventory.
2. Assign an inventory source.
3. Generate sequential barcode labels.
4. Print labels to a thermal printer.
5. Apply labels to inventory.
6. Scan labels during storage, listing, or sales.

Multiple copies of the same barcode can be generated for situations where duplicate labels are required.

---

## Example Barcode

```

PC-000123

```

Where:

- `PC` represents the inventory source.
- `000123` is the sequential inventory identifier.

Additional information, such as purchase lot numbers or dates, can also be printed on the label.

---

## Project Goals

This project emphasizes:

- Simplicity
- Extensibility
- Reusable components
- Clean architecture
- Strong separation between label generation, rendering, and printing

Although the initial focus is vinyl record inventory, the architecture is intentionally generic to support books, media, collectibles, electronics, and other inventory types.

---

## Status

This project is actively under development.

Current development is focused on:

- Improving printing reliability
- Configurable inventory sources
- SQLite integration
- Additional label formats
- Inventory management capabilities

---

## License

This project is licensed under the MIT License.
```
