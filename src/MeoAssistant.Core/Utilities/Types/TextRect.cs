// <copyright file="TextRect.cs" company="MaaAssistantArknights">
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
    public class TextRect
    {
        public TextRect()
        {
        }

        public TextRect(double score, Rect rect, string text)
        {
            this.Score = score;
            this.Rect = rect;
            this.Text = text;
        }

        public double Score { get; private set; } = 0.0;

        public Rect Rect { get; private set; } = new();

        public string Text { get; private set; } = string.Empty;

        public static explicit operator string(TextRect textRect)
        {
            return textRect.Text;
        }

        public static explicit operator Rect(TextRect textRect)
        {
            return textRect.Rect;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Text} : {this.Rect}, score: {this.Score}";
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is TextRect textRect)
            {
                return this.Text == textRect.Text && this.Rect == textRect.Rect;
            }
            else if (obj is string str)
            {
                return this.Text == str;
            }

            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Text.GetHashCode() ^ this.Rect.GetHashCode();
        }
    }
}
