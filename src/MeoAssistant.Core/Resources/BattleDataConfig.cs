// <copyright file="BattleDataConfig.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Definitions.Battle;
    using MeoAssistant.Core.Utilities.Types;

    /// <summary>
    /// The battle data configurer.
    /// </summary>
    public class BattleDataConfig : AbstractConfig
    {
        /// <summary>
        /// The empty range.
        /// </summary>
        public static readonly BattleAttackRange EmptyRange =
            new() { Range = new Point[] { new(0, 0) } };

        private readonly Dictionary<string, BattleCharacterData> characters = new();
        private readonly Dictionary<string, BattleAttackRange> ranges = new();

        /// <summary>
        /// Gets role.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The <see cref="BattleRole"/>.</returns>
        public BattleRole GetRole(string name)
        {
            return this.characters.TryGetValue(name, out var character) ? character.Role : BattleRole.Unknown;
        }

        /// <summary>
        /// Gets rarity.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The rarity.</returns>
        public int GetRarity(string name)
        {
            return this.characters.TryGetValue(name, out var character) ? character.Rarity : 0;
        }

        /// <summary>
        /// Gets range.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="index">The index.</param>
        /// <returns>The range.</returns>
        public BattleAttackRange GetRange(string name, int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
