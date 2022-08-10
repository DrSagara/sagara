// <copyright file="BattleSkillUsage.cs" company="MaaAssistantArknights">
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
    /// The battle skill usage.
    /// </summary>
    public enum BattleSkillUsage
    {
        /// <summary>
        /// Not using.
        /// </summary>
        NotUse = 0,

        /// <summary>
        /// Using when possible.
        /// </summary>
        Possibly = 1,

        /// <summary>
        /// Using once.
        /// </summary>
        Once = 2,

        /// <summary>
        /// Auto-decision.
        /// </summary>
        InTime = 3,

        /// <summary>
        /// OnceUsed.
        /// </summary>
        OnceUsed,
    }
}
