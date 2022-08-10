// <copyright file="WorkMode.cs" company="MaaAssistantArknights">
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
    /// The work mode.
    /// </summary>
    public enum WorkMode
    {
        /// <summary>
        /// Invalid.
        /// </summary>
        Invalid = -1,

        /// <summary>
        /// Gentle mode.
        /// </summary>
        Gentle,

        /// <summary>
        /// Aggressive mode.
        /// </summary>
        Aggressive,

        /// <summary>
        /// Extreme mode.
        /// </summary>
        Extreme,
    }
}
