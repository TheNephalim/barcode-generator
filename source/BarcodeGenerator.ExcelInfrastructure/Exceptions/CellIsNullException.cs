// ***********************************************************************
// Assembly         : BarcodeGenerator.ExcelInfrastructure
// Author           : Robert Eberhart
// Created          : 09-05-2026
// ***********************************************************************

namespace BarcodeGenerator.ExcelInfrastructure.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a worksheet cell is null.
/// </summary>
/// <remarks>
/// This exception is typically used in scenarios where operations on a null worksheet cell
/// would result in an invalid state or unexpected behavior.
/// </remarks>
/// <seealso cref="Exception" />
[Serializable]
public class CellIsNullException : Exception {

    /// <summary>
    /// Initializes a new instance of the <see cref="CellIsNullException"/> class.
    /// </summary>
    public CellIsNullException() : base() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CellIsNullException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CellIsNullException(string? message) : base(message) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CellIsNullException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified.</param>
    public CellIsNullException(string? message, Exception? innerException) : base(message, innerException) {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CellIsNullException"/> class.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    protected CellIsNullException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) {
    }
}