// <copyright file="Point.cs" company="MaaAssistantArknights">
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
    public class Point
    {
        public Point()
        {
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point Right => new(1, 0);

        public static Point Down => new(0, 1);

        public static Point Left => new(-1, 0);

        public static Point Up => new(0, -1);

        public int X { get; private set; } = 0;

        public int Y { get; private set; } = 0;

        public double Length => Math.Sqrt(Dot(this, this));

        public static Point operator +(Point lhs, Point rhs)
        {
            return new(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Point operator -(Point lhs, Point rhs)
        {
            return new(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Point operator *(Point lhs, Point rhs)
        {
            return new(lhs.X * rhs.X, lhs.Y * rhs.Y);
        }

        public static Point operator *(int scalar, Point value)
        {
            return new Point(value.X * scalar, value.Y * scalar);
        }

        public static Point operator *(Point value, int scalar)
        {
            return new Point(value.X * scalar, value.Y * scalar);
        }

        public static int Dot(Point lhs, Point rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public static double Distance(Point lhs, Point rhs)
        {
            return Math.Sqrt(Math.Pow(rhs.X - lhs.X, 2) + Math.Pow(rhs.Y - lhs.Y, 2));
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[ {this.X}, {this.Y} ]";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }
    }
}
