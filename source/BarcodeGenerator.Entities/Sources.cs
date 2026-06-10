// ***********************************************************************
// Assembly          : BarcodeGenerator.Entities
// Author            : Robert Eberhart
// Created           : 06-09-2026
// ***********************************************************************
namespace BarcodeGenerator.Entities;

/// <summary>
/// Represents a source entity within the BarcodeGenerator system.
/// </summary>
/// <remarks>
/// This class is part of the <c>BarcodeGenerator.Entities</c> namespace and provides properties
/// to define and manage source-related data, such as identifiers, activity status, and descriptive information.
/// </remarks>
public class Sources {
    /// <summary>
    /// Gets or sets the unique identifier for the source entity.
    /// </summary>
    /// <value>
    /// A <see cref="Guid"/> representing the unique identifier of the source.
    /// </value>
    /// <remarks>
    /// This property is used to uniquely identify a source within the BarcodeGenerator system.
    /// </remarks>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the source is active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the source is active; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    /// This property is used to determine the activity status of a source entity.
    /// </remarks>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the code that uniquely identifies the source.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the unique code of the source.
    /// </value>
    /// <remarks>
    /// This property is used to store a unique identifier for the source entity,
    /// which can be used for lookup, validation, or other operations within the BarcodeGenerator system.
    /// </remarks>
    public string SourceCode { get; set; } = "Default Code";

    /// <summary>
    /// Gets or sets the name of the source.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the name of the source. Defaults to "Default Name".
    /// </value>
    /// <remarks>
    /// This property is used to store and retrieve the descriptive name associated with a source entity.
    /// </remarks>
    public string SourceName { get; set; } = "Default Name";
}