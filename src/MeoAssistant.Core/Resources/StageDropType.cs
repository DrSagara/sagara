// <copyright file="StageDropType.cs" company="MaaAssistantArknights">
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
    public enum StageDropType
    {
        Unknown,
        ExpAndLMB,
        Normal,
        Extra,

        /// <summary>
        /// 家具
        /// </summary>
        Furniture,

        /// <summary>
        /// 稀有材料、周年庆箱子等
        /// </summary>
        Special,

        /// <summary>
        /// 理智返还
        /// </summary>
        Sanity,

        /// <summary>
        /// 报酬（合成玉，仅剿灭）
        /// </summary>
        Reward,
    }
}
