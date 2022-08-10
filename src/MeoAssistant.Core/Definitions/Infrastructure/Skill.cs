// <copyright file="Skill.cs" company="MaaAssistantArknights">
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
    /// The infrastructure skill.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Gets or sets the skill ID.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the template name.
        /// </summary>
        public string TemplateName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the names.
        /// </summary>
        public IEnumerable<string> Names { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the efficiency.
        /// </summary>
        public Dictionary<string, double> Efficiency { get; set; } = new();

        /// <summary>
        /// Gets or sets the regular expression of efficiency.
        /// </summary>
        public Dictionary<string, string> EfficiencyRegex { get; set; } = new();

        /// <summary>
        /// Gets or sets the number of skills selected at most.
        /// </summary>
        public int MaxNum { get; set; } = int.MaxValue;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Skill skill)
            {
                return this.Id == skill.Id;
            }

            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
