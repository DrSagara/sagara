// <copyright file="Operator.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Wrappers;

    /// <summary>
    /// The operator.
    /// </summary>
    public record Operator
    {
        /// <summary>
        /// Gets or sets the hash of the operator.
        /// </summary>
        public string FaceHash { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the smiley.
        /// </summary>
        public Smiley Smiley { get; set; } = new();

        /// <summary>
        /// Gets or sets the percent of fatigue of the operator.
        /// </summary>
        public double MoodRatio { get; set; } = 0;

        /// <summary>
        /// Gets or sets the current operation.
        /// </summary>
        public Doing Doing { get; set; } = Doing.Invalid;

        /// <summary>
        /// Gets or sets a value indicating whether the operator is selected.
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        public HashSet<Skill> Skills { get; set; } = new();

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        public Rect Rect { get; set; } = new();

        /// <summary>
        /// Gets or sets the name for OCR.
        /// </summary>
        public Mat NameImage { get; set; } = default!;
    }
}
