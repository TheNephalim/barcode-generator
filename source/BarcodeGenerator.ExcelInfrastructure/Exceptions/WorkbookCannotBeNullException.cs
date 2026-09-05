// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************
namespace BarcodeGenerator.ExcelInfrastructure.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a workbook is null.
/// </summary>
public class WorkbookCannotBeNullException : Exception {

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkbookCannotBeNullException" /> class.
    /// </summary>
    public WorkbookCannotBeNullException() : base() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkbookCannotBeNullException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public WorkbookCannotBeNullException(string? message) : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkbookCannotBeNullException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public WorkbookCannotBeNullException(string? message, Exception? innerException) : base(message, innerException) {
    }
}