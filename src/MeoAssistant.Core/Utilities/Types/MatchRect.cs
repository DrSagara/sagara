// <copyright file="MatchRect.cs" company="MaaAssistantArknights">
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
    public class MatchRect
    {
        public MatchRect()
        {
        }

        public MatchRect(double score, Rect rect)
        {
            this.Score = score;
            this.Rect = rect;
        }

        public double Score { get; private set; } = 0.0;

        public Rect Rect { get; private set; } = new();

        public static explicit operator Rect(MatchRect matchRect)
        {
            return matchRect.Rect;
        }
    }
}
