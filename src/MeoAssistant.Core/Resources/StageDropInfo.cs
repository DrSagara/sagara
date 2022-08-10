// <copyright file="StageDropInfo.cs" company="MaaAssistantArknights">
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
    public record StageDropInfo
    {
        public StageDropType DropType { get; set; } = StageDropType.Unknown;

        public string DropTypeName { get; set; } = string.Empty;

        public string ItemId { get; set; } = string.Empty;

        public string ItemName { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;
    }
}
