// <copyright file="Smiley.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Definitions.Infrastructure
{
    using MeoAssistant.Core.Utilities.Types;

    /// <summary>
    /// The smiley.
    /// </summary>
    public record Smiley
    {
        /// <summary>
        /// Gets or sets the smiley type.
        /// </summary>
        public SmileyType Type { get; set; } = SmileyType.Invalid;

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        public Rect Rect { get; set; } = new();
    }
}
