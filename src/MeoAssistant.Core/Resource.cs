// <copyright file="Resource.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Resources;

    /// <summary>
    /// The resource.
    /// </summary>
    public class Resource : AbstractResource
    {
        private static Resource uniqueInstance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Resource Instance => uniqueInstance;

        /// <inheritdoc/>
        public override bool Load(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
