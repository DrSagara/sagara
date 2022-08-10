// <copyright file="BattleDeployDirection.cs" company="MaaAssistantArknights">
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
    /// The deployment direction in a battle.
    /// </summary>
    public enum BattleDeployDirection
    {
        /// <summary>
        /// Right.
        /// </summary>
        Right = 0,

        /// <summary>
        /// Down.
        /// </summary>
        Down = 1,

        /// <summary>
        /// Left.
        /// </summary>
        Left = 2,

        /// <summary>
        /// Up.
        /// </summary>
        Up = 3,

        /// <summary>
        /// No direction.
        /// </summary>
        None = 4,
    }
}
