// <copyright file="Doing.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Definitions.Infrastructure
{
    /// <summary>
    /// The current operation, i.e. what is the target doing.
    /// </summary>
    public enum Doing
    {
        /// <summary>
        /// Invalid.
        /// </summary>
        Invalid = -1,

        /// <summary>
        /// Doing nothing, neither resting, nor working.
        /// </summary>
        Nothing,

        /// <summary>
        /// Resting.
        /// </summary>
        Resting,

        /// <summary>
        /// Working.
        /// </summary>
        Working,
    }
}
