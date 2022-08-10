// <copyright file="BattleRole.cs" company="MaaAssistantArknights">
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
    /// The role in a battle.
    /// </summary>
    public enum BattleRole
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// Caster.
        /// </summary>
        Caster,

        /// <summary>
        /// Medic.
        /// </summary>
        Medic,

        /// <summary>
        /// Vanguard.
        /// </summary>
        Pioneer,

        /// <summary>
        /// Sniper.
        /// </summary>
        Sniper,

        /// <summary>
        /// Special.
        /// </summary>
        Special,

        /// <summary>
        /// Support.
        /// </summary>
        Support,

        /// <summary>
        /// Tank.
        /// </summary>
        Tank,

        /// <summary>
        /// Guard.
        /// </summary>
        Warrior,

        /// <summary>
        /// Drone.
        /// </summary>
        Drone,
    }
}
