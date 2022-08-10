// <copyright file="BattleCharacterData.cs" company="MaaAssistantArknights">
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
    /// <summary>
    /// The character data in a battle.
    /// </summary>
    public record BattleCharacterData
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public BattleRole Role { get; set; }

        /// <summary>
        /// Gets or sets the ranges.
        /// </summary>
        public Tuple<string, string, string> Ranges { get; set; } = new(string.Empty, string.Empty, string.Empty);

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public int Rarity { get; set; } = 0;
    }
}
