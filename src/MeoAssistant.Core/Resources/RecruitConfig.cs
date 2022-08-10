// <copyright file="RecruitConfig.cs" company="MaaAssistantArknights">
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
    public class RecruitConfig : AbstractConfig
    {
        public const int CorrectNumberOfTags = 5;

        public HashSet<string> AllTags { get; protected set; } = new();

        public IEnumerable<RecruitOperatorInfo> AllOperators { get; protected set; } = Enumerable.Empty<RecruitOperatorInfo>();

        protected IEnumerable<string> AllTypes { get; set; } = Enumerable.Empty<string>();

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
