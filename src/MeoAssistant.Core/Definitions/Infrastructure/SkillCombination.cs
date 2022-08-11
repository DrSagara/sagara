// <copyright file="SkillCombination.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Wrappers;

    /// <summary>
    /// The skill combination.
    /// </summary>
    public class SkillCombination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkillCombination"/> class.
        /// </summary>
        public SkillCombination()
            : this(new())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillCombination"/> class.
        /// </summary>
        /// <param name="skills">The skills.</param>
        public SkillCombination(HashSet<Skill> skills)
        {
            this.Skills = skills;
            skills.ToList().ForEach(s =>
            {
                s.Efficiency.ToList().ForEach(x => this.Efficiency[x.Key] = x.Value);
                s.EfficiencyRegex.ToList().ForEach(x => this.EfficiencyRegex[x.Key] = x.Value);
            });
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        public HashSet<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets the efficiency.
        /// </summary>
        public Dictionary<string, double> Efficiency { get; set; } = new();

        /// <summary>
        /// Gets or sets the efficiency regular expressions.
        /// </summary>
        public Dictionary<string, string> EfficiencyRegex { get; set; } = new();

        /// <summary>
        /// Gets or sets the name filter.
        /// </summary>
        public IEnumerable<string> NameFilter { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the name for OCR.
        /// </summary>
        public Cv.Mat NameImage { get; set; } = default!;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is SkillCombination rhs)
            {
                return this.Skills == rhs.Skills;
            }

            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Skills.Aggregate(0, (current, next) => current ^ next.GetHashCode());
        }
    }
}
