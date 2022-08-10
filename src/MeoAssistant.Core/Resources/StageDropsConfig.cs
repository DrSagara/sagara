// <copyright file="StageDropsConfig.cs" company="MaaAssistantArknights">
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
    public sealed class StageDropsConfig : AbstractConfig
    {
        private Dictionary<StageKey, StageInfo> stageInfo = new();

        public HashSet<string> AllStageCodes { get; private set; } = new();

        public HashSet<string> AllItemIds { get; private set; } = new();

        public StageInfo GetStageInfo(string code, StageDifficulty difficulty)
        {
            return this.stageInfo.GetValueOrDefault(new() { Code = code, Difficulty = difficulty }) ?? new();
        }

        public void AppendDrops(StageKey stageKey, StageDropType type, string itemId)
        {
            this.stageInfo[stageKey].Drops[type] = this.stageInfo[stageKey].Drops[type].Append(itemId);
        }

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
