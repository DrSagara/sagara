// <copyright file="OcrTaskInfo.cs" company="MaaAssistantArknights">
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
    /// 文字识别任务的信息
    /// </summary>
    public record OcrTaskInfo : TaskInfo
    {
        /// <summary>
        /// 文字的容器，匹配到这里面任一个，就算匹配上了
        /// </summary>
        public IEnumerable<string> Text { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 是否需要全匹配，否则搜索到子串就算匹配上了
        /// </summary>
        public bool FullMatch { get; set; } = false;

        /// <summary>
        /// 部分文字容易识别错，字符串强制 replace 之后，再进行匹配
        /// </summary>
        public Dictionary<string, string> ReplaceMap { get; set; } = new();
    }
}
