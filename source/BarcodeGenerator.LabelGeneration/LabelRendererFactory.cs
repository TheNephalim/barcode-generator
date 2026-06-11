// ***********************************************************************
// Assembly          : BarcodeGenerator.LabelGeneration
// Author            : Robert Eberhart
// Created           : 06-11-2026
// ***********************************************************************
// <copyright file="LabelRenderedFactory.cs" company="Littoral Combat Ships">
//     Copyright (c) 2026 Littoral Combat Ships. All rights reserved.
// </copyright>
// ***********************************************************************

using Autofac.Features.Indexed;
using BarcodeGenerator.Entities;

namespace BarcodeGenerator.LabelGeneration;

/// <summary>
/// A factory class responsible for creating instances of <see cref="ILabelRenderer"/>
/// based on the specified <see cref="LabelTemplateType"/>.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IRendererFactory"/> interface and provides
/// functionality to retrieve the appropriate label renderer for a given label template type.
/// It utilizes a mapping of <see cref="LabelTemplateType"/> to corresponding
/// <see cref="ILabelRenderer"/> instances, which is injected during construction.
/// </remarks>
public class LabelRendererFactory : IRendererFactory {
    private readonly IIndex<LabelTemplateType, ILabelRenderer> _labelRenderers;

    /// <summary>
    /// Initializes a new instance of the <see cref="LabelRendererFactory"/> class.
    /// </summary>
    /// <param name="labelRenderers">
    /// A mapping of <see cref="LabelTemplateType"/> to corresponding <see cref="ILabelRenderer"/> instances.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="labelRenderers"/> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This constructor is responsible for setting up the factory with a collection of label renderers,
    /// enabling the creation of appropriate renderers based on the specified label template type.
    /// </remarks>
    public LabelRendererFactory(IIndex<LabelTemplateType, ILabelRenderer> labelRenderers) {
        _labelRenderers = labelRenderers ?? throw new ArgumentNullException(nameof(labelRenderers));
    }

    /// <summary>
    /// Retrieves an instance of <see cref="ILabelRenderer"/> corresponding to the specified
    /// <see cref="LabelTemplateType"/>.
    /// </summary>
    /// <param name="labelTemplateType">
    /// The type of label template for which the renderer is required.
    /// </param>
    /// <returns>
    /// An instance of <see cref="ILabelRenderer"/> that can render labels of the specified type.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when no renderer is found for the specified <paramref name="labelTemplateType"/>.
    /// </exception>
    public ILabelRenderer GetLabelRenderer(LabelTemplateType labelTemplateType) {
        return _labelRenderers.TryGetValue(labelTemplateType, out var renderer) ? renderer : throw new ArgumentException($"No renderer found for label template type: {labelTemplateType}");
    }
}