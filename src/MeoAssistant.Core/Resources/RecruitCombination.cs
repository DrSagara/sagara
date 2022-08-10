// <copyright file="RecruitCombination.cs" company="MaaAssistantArknights">
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
    public record RecruitCombination
    {
        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<RecruitOperatorInfo> Operators { get; set; } = Enumerable.Empty<RecruitOperatorInfo>();

        public int MaxLevel { get; set; } = 0;

        public int MinLevel { get; set; } = 0;

        public double AverageLevel { get; set; } = 0;

        /// <summary>
        /// Intersection of two <see cref="RecruitCombination"/>s.
        /// </summary>
        /// <param name="lhs">The left hand side.</param>
        /// <param name="rhs">The right hand side.</param>
        /// <returns>The result.</returns>
        public static RecruitCombination operator *(RecruitCombination lhs, RecruitCombination rhs)
        {
            var tags = lhs.Tags.ToHashSet().Union(rhs.Tags).ToList();
            tags.Sort();
            var operators = lhs.Operators.ToHashSet().Intersect(rhs.Operators).ToList();
            operators.Sort();

            RecruitCombination result = new()
            {
                Tags = tags,
                Operators = operators,
            };

            result.UpdateAttributes();
            return result;
        }

        public void UpdateAttributes()
        {
            this.MinLevel = this.Operators.Select(x => x.Level).Aggregate(7, Math.Min);
            this.MaxLevel = this.Operators.Select(x => x.Level).Aggregate(0, Math.Max);
            this.AverageLevel = this.Operators.Select(x => x.Level).Aggregate(0, (current, next) => current + next) / this.Operators.Count();
        }
    }
}
