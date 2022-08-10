// <copyright file="Rect.cs" company="MaaAssistantArknights">
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
    public class Rect
    {
        public Rect()
        {
        }

        public Rect(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public int X { get; private set; } = 0;

        public int Y { get; private set; } = 0;

        public int Width { get; private set; } = 0;

        public int Height { get; private set; } = 0;

        public int Area => this.Width * this.Height;

        public bool IsEmpty => this.Width == 0 || this.Height == 0;

        public static Rect operator *(Rect lhs, double rhs)
        {
            return new(lhs.X, lhs.Y, (int)(lhs.Width * rhs), (int)(lhs.Height * rhs));
        }

        public Rect CenterZoom(double scale, int maxWidth = int.MaxValue, int maxHeight = int.MaxValue)
        {
            var halfWidthScale = (int)(this.Width * (1 - scale) / 2);
            var halfHeightScale = (int)(this.Height * (1 - scale) / 2);
            Rect dst = new(
                this.X + halfWidthScale,
                this.Y + halfHeightScale,
                (int)(this.Width * scale),
                (int)(this.Height * scale));

            if (dst.X < 0)
            {
                dst.X = 0;
            }

            if (dst.Y < 0)
            {
                dst.Y = 0;
            }

            if (dst.Width + dst.X >= maxWidth)
            {
                dst.Width = maxWidth - dst.X;
            }

            if (dst.Height + dst.Y >= maxHeight)
            {
                dst.Height = maxHeight - dst.Y;
            }

            return dst;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Rect rhs)
            {
                return this.X == rhs.X && this.Y == rhs.Y && this.Width == rhs.Width && this.Height == rhs.Height;
            }

            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.X.GetHashCode()
                ^ this.Y.GetHashCode()
                ^ this.Width.GetHashCode()
                ^ this.Height.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[ {this.X}, {this.Y}, {this.Width}, {this.Height} ]";
        }

        public bool Include(Rect rhs)
        {
            return this.X <= rhs.X
                && this.Y <= rhs.Y
                && (this.X + this.Width) >= (rhs.X + rhs.Width)
                && (this.Y + this.Height) >= (rhs.Y + rhs.Height);
        }

        public bool Include(Point rhs)
        {
            return this.X <= rhs.X
                && this.Y <= rhs.Y
                && (this.X + this.Width) >= rhs.X
                && (this.Y + this.Height) >= rhs.Y;
        }

        public Rect Move(Rect move)
        {
            return new(this.X + move.X, this.Y + move.Y, move.Width, move.Height);
        }
    }
}
