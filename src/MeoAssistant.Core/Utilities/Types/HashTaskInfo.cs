// <copyright file="HashTaskInfo.cs" company="MaaAssistantArknights">
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
    /// Hash 计算任务的信息
    /// </summary>
    public record HashTaskInfo : TaskInfo
    {
        /// <summary>
        /// 需要的多个哈希值
        /// </summary>
        public IEnumerable<string> Hashes { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 汉明距离阈值
        /// </summary>
        public int DistanceThreshold { get; set; } = 0;

        /// <summary>
        /// 掩码的二值化范围
        /// </summary>
        public Tuple<int, int> MaskRange { get; set; } = new(0, 0);

        /// <summary>
        /// 是否裁剪周围黑边
        /// </summary>
        public bool Bound { get; set; } = false;
    }
}
