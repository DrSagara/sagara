// <copyright file="TileInfo.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Utilities.Types;

    public record TileInfo
    {
        public BuildableType Buildable { get; set; } = BuildableType.Invalid;

        public HeightType Height { get; set; } = HeightType.Invalid;

        public TileKey Key { get; set; } = TileKey.Invalid;

        /// <summary>
        /// 像素坐标
        /// </summary>
        public Point Position { get; set; } = new();

        /// <summary>
        /// 格子位置
        /// </summary>
        public Point Location { get; set; } = new();
    }
}
