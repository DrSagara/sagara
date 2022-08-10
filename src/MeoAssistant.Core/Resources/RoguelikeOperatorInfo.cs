// <copyright file="RoguelikeOperatorInfo.cs" company="MaaAssistantArknights">
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

    /// <summary>
    /// 干员信息，战斗相关
    /// </summary>
    public record RoguelikeOperatorInfo
    {
        public string Name { get; set; } = string.Empty;

        public int Skill { get; set; } = 0;

        public int AlternateSkill { get; set; } = 0;

        public BattleSkillUsage SkillUsage { get; set; } = BattleSkillUsage.Possibly;

        public BattleSkillUsage AlternateSkillUsage { get; set; } = BattleSkillUsage.Possibly;
    }
}
