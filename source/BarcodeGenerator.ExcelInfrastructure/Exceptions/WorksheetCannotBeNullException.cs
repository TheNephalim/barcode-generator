// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************
namespace BarcodeGenerator.ExcelInfrastructure.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a worksheet is null in the context of Excel infrastructure operations.
/// </summary>
/// <remarks>
/// This exception is typically used to indicate that a required worksheet parameter is missing or null,
/// which is essential for performing operations on Excel worksheets.
/// </remarks>
public class WorksheetCannotBeNullException : Exception {

    // Default constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="WorksheetCannotBeNullException"/> class
    /// with a default error message indicating that the worksheet cannot be null.
    /// </summary>
    public WorksheetCannotBeNullException() : base("Worksheet cannot be null.") {
    }

    // Constructor with custom message
    /// <summary>
    /// Initializes a new instance of the <see cref="WorksheetCannotBeNullException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public WorksheetCannotBeNullException(string message) : base(message) {
    }

    // Constructor with custom message and inner exception
    /// <summary>
    /// Initializes a new instance of the <see cref="WorksheetCannotBeNullException"/> class
    /// with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public WorksheetCannotBeNullException(string message, Exception innerException) : base(message, innerException) {
    }
}