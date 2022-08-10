// <copyright file="SkillGroup.cs" company="MaaAssistantArknights">
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
    /// <summary>
    /// The skill group.
    /// </summary>
    public record SkillGroup
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the combination of conditions of skills.
        /// </summary>
        public Dictionary<string, int> Conditions { get; set; } = new();

        /// <summary>
        /// Gets or sets the required skill combinations.
        /// </summary>
        public IEnumerable<SkillCombination> Necessary { get; set; } = Enumerable.Empty<SkillCombination>();

        /// <summary>
        /// Gets or sets the optional skill combinations.
        /// </summary>
        public IEnumerable<SkillCombination> Optional { get; set; } = Enumerable.Empty<SkillCombination>();

        /// <summary>
        /// Gets or sets a value indicating whether to allow adding external operators.
        /// </summary>
        public bool AllowExternal { get; set; } = false;
    }
}
