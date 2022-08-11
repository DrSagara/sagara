// <copyright file="RuntimeStatus.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core
{
    using MeoAssistant.Core.Utilities.Types;

    /// <summary>
    /// The runtime status.
    /// </summary>
    public class RuntimeStatus
    {
        public const string RoguelikeCharElitePrefix = "RoguelikeElite-";

        public const string RoguelikeCharLevelPrefix = "RoguelikeLevel-";

        public const string RoguelikeCharRarityPrefix = "RoguelikeRarity-";

        public const string RoguelikeCharOverview = "RoguelikeOverview";

        public const string RoguelikeTraderNoLongerBuy = "RoguelikeNoLongerBuy";

        private readonly Dictionary<string, long> numbers = new();

        private readonly Dictionary<string, Rect> rects = new();

        private readonly Dictionary<string, string> strings = new();

        public long? GetNumber(string key)
        {
            return this.numbers.ContainsKey(key) ? this.numbers[key] : null;
        }

        public void SetNumber(string key, long value)
        {
            this.numbers[key] = value;
        }

        public void ClearNumbers()
        {
            this.numbers.Clear();
        }

        public Rect? GetRect(string key)
        {
            return this.rects.ContainsKey(key) ? this.rects[key] : null;
        }

        public void SetRect(string key, Rect rect)
        {
            this.rects[key] = rect;
        }

        public void ClearRects()
        {
            this.rects.Clear();
        }

        public string? GetString(string key)
        {
            return this.strings.ContainsKey(key) ? this.strings[key] : null;
        }

        public void SetString(string key, string value)
        {
            this.strings[key] = value;
        }

        public void ClearStrings()
        {
            this.strings.Clear();
        }
    }
}
