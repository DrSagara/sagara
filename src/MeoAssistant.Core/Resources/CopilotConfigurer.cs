// <copyright file="CopilotConfigurer.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Resources
{
    using MeoAssistant.Core.BattleDefinitions;

    /// <summary>
    /// The copilot configurer.
    /// </summary>
    public class CopilotConfigurer : AbstractConfigurer
    {
        private readonly Dictionary<string, BattleCopilotData> battleActions = new();

        /// <summary>
        /// Checks if the specified action exists.
        /// </summary>
        /// <param name="stageName">The stage name of the action.</param>
        /// <returns>A value indicating whether the action exists.</returns>
        public bool ContainsActions(string stageName)
        {
            return this.battleActions.ContainsKey(stageName);
        }

        /// <summary>
        /// Gets actions.
        /// </summary>
        /// <param name="stageName">The stage name of the action.</param>
        /// <returns>The actions.</returns>
        public BattleCopilotData? GetActions(string stageName)
        {
            return this.battleActions.TryGetValue(stageName, out var battleCopilotData) ? battleCopilotData : null;
        }

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
