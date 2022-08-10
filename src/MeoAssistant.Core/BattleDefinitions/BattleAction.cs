// <copyright file="BattleAction.cs" company="MaaAssistantArknights">
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
    /// The action in a battle.
    /// </summary>
    public record BattleAction
    {
        /// <summary>
        /// Gets or sets the number of kills.
        /// </summary>
        public int Kills { get; set; } = 0;

        /// <summary>
        /// Gets or sets the cost changes.
        /// </summary>
        public int CostChanges { get; set; } = 0;

        /// <summary>
        /// Gets or sets the action type.
        /// </summary>
        public BattleActionType Type { get; set; } = BattleActionType.Deploy;

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        public string GroupName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        public BattleDeployDirection Direction { get; set; } = BattleDeployDirection.Right;

        /// <summary>
        /// Gets or sets the skill usage.
        /// </summary>
        public BattleSkillUsage ModifyUsage { get; set; } = BattleSkillUsage.NotUse;

        /// <summary>
        /// Gets or sets the pre delay.
        /// </summary>
        public int PreDelay { get; set; } = 0;

        /// <summary>
        /// Gets or sets the post delay.
        /// </summary>
        public int RearDelay { get; set; } = 0;

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        public int Timeout { get; set; } = int.MaxValue;

        /// <summary>
        /// Gets or sets the document/description.
        /// </summary>
        public string Doc { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the colour of the document/description.
        /// </summary>
        public string DocColor { get; set; } = string.Empty;
    }
}
