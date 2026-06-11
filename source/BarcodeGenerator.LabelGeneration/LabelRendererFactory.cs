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

public class LabelRendererFactory : IRendererFactory {

    public LabelRendererFactory(IIndex<LabelTemplateType, ILabelRenderer> _labelRenderers) {
    }

    public ILabelRenderer GetLabelRenderer(LabelTemplateType labelTemplateType) {
        throw new NotImplementedException();
    }
}