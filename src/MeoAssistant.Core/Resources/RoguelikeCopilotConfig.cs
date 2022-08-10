// <copyright file="RoguelikeCopilotConfig.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Definitions.Battle;

    public class RoguelikeCopilotConfig : AbstractConfig
    {
        protected Dictionary<string, RoguelikeBattleData> StageData { get; set; } = new();

        public RoguelikeBattleData? GetStageData(string stageName)
        {
            return this.StageData.GetValueOrDefault(stageName);
        }

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
