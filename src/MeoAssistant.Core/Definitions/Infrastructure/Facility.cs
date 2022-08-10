// <copyright file="Facility.cs" company="MaaAssistantArknights">
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
    /// The facility of infrastructure.
    /// </summary>
    public record Facility
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IEnumerable<string> Products { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the maximum number of operators.
        /// </summary>
        public int MaxNumberOfOperators { get; set; } = 0;
    }
}
