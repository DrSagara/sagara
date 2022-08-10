// <copyright file="InfrastConfig.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Definitions.Infrastructure;

    public class InfrastConfig : AbstractConfig
    {
        /// <summary>
        /// 所有基建技能
        /// <list type="bullet">
        ///     <item>
        ///         <term>key</term>
        ///         <description>设施名</description>
        ///     </item>
        ///     <item>
        ///         <term>value</term>
        ///         <description>map[技能id，技能]</description>
        ///     </item>
        /// </list>
        /// </summary>
        public Dictionary<string, Dictionary<string, Skill>> Skills { get; set; } = new();

        /// <summary>
        /// 所有设施信息
        /// <list type="bullet">
        ///     <item>
        ///         <term>key</term>
        ///         <description>设施名</description>
        ///     </item>
        ///     <item>
        ///         <term>value</term>
        ///         <description>信息</description>
        ///     </item>
        /// </list>
        /// </summary>
        public Dictionary<string, Facility> FacilitiesInfo { get; set; } = new();

        /// <summary>
        /// 所有加成技能组
        /// </summary>
        public Dictionary<string, IEnumerable<SkillGroup>> SkillGroups { get; set; } = new();

        /// <summary>
        /// 需要加载的模板
        /// </summary>
        public HashSet<string> TemplateRequired { get; set; } = new();

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
