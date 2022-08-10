// <copyright file="BattleDeployInfo.cs" company="MaaAssistantArknights">
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
    /// The deployment information in a battle.
    /// </summary>
    public record BattleDeployInfo
    {
        /// <summary>
        /// Gets or sets the deployment location.
        /// </summary>
        public Point Location { get; set; } = new();

        /// <summary>
        /// Gets or sets the deployment position.
        /// </summary>
        public Point Position { get; set; } = new();

        /// <summary>
        /// Gets or sets the operator info.
        /// </summary>
        public BattleDeployOperator Info { get; set; } = new();
    }
}
