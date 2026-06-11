// ***********************************************************************
// Assembly          : ${$NAMESPACE$}
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
// <copyright file="IRendererFactory.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// Provides a factory for creating instances of <see cref="ILabelRenderer"/> based on specified label template types.
/// </summary>
/// <remarks>
/// This interface defines a contract for generating label renderers tailored to specific template types.
/// Implementations of this factory are responsible for ensuring that the appropriate renderer is returned
/// for the given <see cref="LabelTemplateType"/>.
/// </remarks>
public interface IRendererFactory {

    /// <summary>
    /// Retrieves an instance of <see cref="ILabelRenderer"/> corresponding to the specified label template type.
    /// </summary>
    /// <param name="labelTemplateType">
    /// The <see cref="LabelTemplateType"/> for which the label renderer is to be created.
    /// </param>
    /// <returns>
    /// An instance of <see cref="ILabelRenderer"/> tailored to the specified <paramref name="labelTemplateType"/>.
    /// </returns>
    /// <remarks>
    /// This method is responsible for providing a label renderer that matches the requirements of the given
    /// <see cref="LabelTemplateType"/>. Implementations should ensure that the returned renderer is compatible
    /// with the specified template type.
    /// </remarks>
    ILabelRenderer GetLabelRenderer(LabelTemplateType labelTemplateType);
}