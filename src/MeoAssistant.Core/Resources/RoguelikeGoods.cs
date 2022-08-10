// <copyright file="RoguelikeGoods.cs" company="MaaAssistantArknights">
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

    public record RoguelikeGoods
    {
        public string Name { get; set; } = string.Empty;

        public IEnumerable<BattleRole> Roles { get; set; } = Enumerable.Empty<BattleRole>();

        public IEnumerable<string> Characters { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 晋升 N 个干员
        /// </summary>
        public int Promotion { get; set; } = 0;

        public bool NoLongerBuy { get; set; } = false;

        public bool IgnoreNoLongerBuy { get; set; } = false;
    }
}
