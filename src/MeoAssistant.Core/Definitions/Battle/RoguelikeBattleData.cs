// <copyright file="RoguelikeBattleData.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Definitions.Battle
{
    using MeoAssistant.Core.Utilities.Types;

    /// <summary>
    /// The roguelike battle data.
    /// </summary>
    public record RoguelikeBattleData
    {
        /// <summary>
        /// Gets or sets the stage name.
        /// </summary>
        public string StageName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets replacementHome.
        /// </summary>
        public IEnumerable<Point> ReplacementHome { get; set; } = Enumerable.Empty<Point>();

        /// <summary>
        /// Gets or sets keyKills.
        /// </summary>
        public IEnumerable<int> KeyKills { get; set; } = Enumerable.Empty<int>();
    }
}
