// <copyright file="BattleRecruitOperatorInfo.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.BattleDefinitions
{
    using MeoAssistant.Core.Utilities;

    /// <summary>
    /// The operator info of recruitment in a battle.
    /// </summary>
    public record BattleRecruitOperatorInfo
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        public Rect Rect { get; set; }

        /// <summary>
        /// Gets or sets the elite level.
        /// </summary>
        public int Elite { get; set; } = 0;

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public int Level { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether it is required.
        /// </summary>
        public bool IsRequired { get; set; } = false;
    }
}
