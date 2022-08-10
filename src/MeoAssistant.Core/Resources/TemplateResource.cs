// <copyright file="TemplateResource.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Wrappers;

    public class TemplateResource : AbstractResource
    {
        private readonly Dictionary<string, Mat> templates = new();

        private HashSet<string> templateFilenames = new();

        /// <inheritdoc/>
        public override bool Load(string filename)
        {
            throw new NotImplementedException();
        }

        public void SetLoadRequired(HashSet<string> required)
        {
            this.templateFilenames = required;
        }

        public bool IsTemplateExist(string key)
        {
            return this.templates.ContainsKey(key);
        }

        public Mat GetTemplate(string key)
        {
            return this.templates.GetValueOrDefault(key) ?? new();
        }

        public void EmplaceTemplate(string key, Mat template)
        {
            this.templates[key] = template;
        }
    }
}
