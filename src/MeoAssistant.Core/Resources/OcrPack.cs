// <copyright file="OcrPack.cs" company="MaaAssistantArknights">
// MeoAsstGui - A part of the MeoAssistantArknights project
// Copyright (C) 2021 MistEO and Contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
// </copyright>

namespace MeoAssistant.Core.Resources
{
    using MeoAssistant.Core.Utilities.Types;
    using MeoAssistant.Core.Wrappers;

    public sealed class OcrPack : AbstractResource
    {
        private const int MaxBoxSize = 128;

        /// <inheritdoc/>
        public override bool Load(string filename)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TextRect> Recognize(Mat image, TextRectProc? pred = null, bool withoutDet = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TextRect> Recognize(Mat image, Rect roi, TextRectProc? pred = null, bool withoutDet = false)
        {
            throw new NotImplementedException();
        }
    }
}
