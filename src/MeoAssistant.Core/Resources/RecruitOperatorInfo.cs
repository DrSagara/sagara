// <copyright file="RecruitOperatorInfo.cs" company="MaaAssistantArknights">
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
    /// <summary>
    /// 干员信息，公开招募相关
    /// </summary>
    public class RecruitOperatorInfo : IComparable<RecruitOperatorInfo>
    {
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int Level { get; set; } = 0;

        public string Sex { get; set; } = string.Empty;

        public HashSet<string> Tags { get; set; } = new();

        public bool Hidden { get; set; } = false;

        public string NameEn { get; set; } = string.Empty;

        public bool HasTag(string tag)
        {
            return this.Tags.Contains(tag);
        }

        /// <inheritdoc/>
        public int CompareTo(RecruitOperatorInfo? other)
        {
            if (this.Level != other?.Level)
            {
                return this.Level.CompareTo(other?.Level);
            }

            return this.Name.CompareTo(other.Name);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is RecruitOperatorInfo other)
            {
                return this.Name == other.Name && this.Level == other.Level;
            }

            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Level.GetHashCode();
        }
    }
}
