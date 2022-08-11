// <copyright file="TaskData.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Utilities.Types;

    public class TaskData : AbstractConfig
    {
        private static TaskData? instance;

        protected TaskData()
        {
        }

        public static TaskData Instance => instance ??= new();

        public HashSet<string> TemplateRequired { get; protected set; } = new();

        protected Dictionary<string, TaskInfo> AllTaskInfos { get; set; } = new();

        public TTaskInfo? Get<TTaskInfo>(string name)
            where TTaskInfo : TaskInfo
        {
            return (TTaskInfo?)this.Get(name);
        }

        public TaskInfo? Get(string name)
        {
            return this.AllTaskInfos.ContainsKey(name) ? this.AllTaskInfos[name] : null;
        }

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }
}
