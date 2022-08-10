// <copyright file="BattleActionType.cs" company="MaaAssistantArknights">
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
    /// The action type in a battle.
    /// </summary>
    public enum BattleActionType
    {
        /// <summary>
        /// Deployment.
        /// </summary>
        Deploy,

        /// <summary>
        /// Using skill.
        /// </summary>
        UseSkill,

        /// <summary>
        /// Retreating.
        /// </summary>
        Retreat,

        /// <summary>
        /// Skill usage.
        /// </summary>
        SkillUsage,

        /// <summary>
        /// Switching to 2x speed.
        /// </summary>
        SwitchSpeed,

        /// <summary>
        /// Switching to slow speed.
        /// </summary>
        BulletTime,

        /// <summary>
        /// Using all skills.
        /// </summary>
        UseAllSkill,

        /// <summary>
        /// Output only.
        /// </summary>
        Output,

        /// <summary>
        /// Using skills automatically until the battle ends.
        /// </summary>
        SkillDaemon,
    }
}
