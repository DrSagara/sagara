// <copyright file="AbstractResource.cs" company="MaaAssistantArknights">
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
    /// <summary>
    /// The abstract resource class.
    /// </summary>
    public abstract class AbstractResource
    {
        /// <summary>
        /// Gets or sets the last error.
        /// </summary>
        public string LastError { get; protected set; } = string.Empty;

        /// <summary>
        /// Loads resource from a file.
        /// </summary>
        /// <param name="filename">The resource filename.</param>
        /// <returns>A value indicating whether the operation is successful.</returns>
        public abstract bool Load(string filename);
    }
}
