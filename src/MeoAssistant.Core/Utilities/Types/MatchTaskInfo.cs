// <copyright file="MatchTaskInfo.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Utilities.Types
{
    /// <summary>
    /// 图片匹配任务的信息
    /// </summary>
    public record MatchTaskInfo : TaskInfo
    {
        /// <summary>
        /// 匹配模板图片文件名
        /// </summary>
        public string TemplateName { get; set; } = string.Empty;

        /// <summary>
        /// 模板匹配阈值
        /// </summary>
        public double TemplateThreshold { get; set; } = 0;

        /// <summary>
        /// 某些任务使用的特殊的阈值
        /// </summary>
        public double SpecialThreshold { get; set; } = 0;

        /// <summary>
        /// 掩码的二值化范围
        /// </summary>
        public Tuple<int, int> MaskRange { get; set; } = new(0, 0);
    }
}
