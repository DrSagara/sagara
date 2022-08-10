// <copyright file="BattleCopilotData.cs" company="MaaAssistantArknights">
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
    /// <summary>
    /// The copilot data of a battle.
    /// </summary>
    public record BattleCopilotData
    {
        /// <summary>
        /// Gets or sets the minimum required version.
        /// </summary>
        public string MinimumRequired { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the colour of the title.
        /// </summary>
        public string TitleColor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the colour of the details.
        /// </summary>
        public string DetailsColor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        public Dictionary<string, IEnumerable<BattleDeployOperator>> Groups { get; set; } = new();

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        public IEnumerable<BattleAction> Actions { get; set; } = Enumerable.Empty<BattleAction>();
    }
}
