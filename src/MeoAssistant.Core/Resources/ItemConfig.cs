// <copyright file="ItemConfig.cs" company="MaaAssistantArknights">
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
    public class ItemConfig : AbstractConfig
    {
        /// <summary>
        /// <list type="bullet">
        ///     <item>
        ///         <term>key</term>
        ///         <description>材料编号Id</description>
        ///     </item>
        ///     <item>
        ///         <term>value</term>
        ///         <description>材料名（zh，utf8）</description>
        ///     </item>
        /// </list>
        /// </summary>
        public Dictionary<string, string> ItemName { get; private set; } = new();

        public HashSet<string> AllItemIds { get; private set; } = new();

        public IEnumerable<string> OrderedMaterialItemIds { get; private set; } = Enumerable.Empty<string>();

        public string GetItemName(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return "Unknown";
            }

            return this.ItemName.TryGetValue(id, out var itemName) ? itemName : string.Empty;
        }

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
