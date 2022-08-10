// <copyright file="BattleRealTimeOperator.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Wrappers;

    /// <summary>
    /// The real time operator in a battle.
    /// </summary>
    public record BattleRealTimeOperator
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public int Cost { get; set; } = 0;

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public BattleRole Role { get; set; } = BattleRole.Unknown;

        /// <summary>
        /// Gets or sets a value indicating whether it is available.
        /// </summary>
        public bool IsAvailable { get; set; } = false;

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        public Rect Rect { get; set; }

        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        public Mat Avatar { get; set; } = default!;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether the skill is in cooldown.
        /// </summary>
        public bool IsCooling { get; set; } = false;
    }
}
