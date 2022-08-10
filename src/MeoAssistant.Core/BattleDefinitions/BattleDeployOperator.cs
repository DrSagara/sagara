// <copyright file="BattleDeployOperator.cs" company="MaaAssistantArknights">
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
    /// The operator deployment in a battle.
    /// </summary>
    public record BattleDeployOperator
    {
        /// <summary>
        /// Gets or sets the operator name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the skill to use.
        /// </summary>
        public int Skill { get; set; } = 1;

        /// <summary>
        /// Gets or sets the skill usage.
        /// </summary>
        public BattleSkillUsage SkillUsage { get; set; } = BattleSkillUsage.NotUse;
    }
}
