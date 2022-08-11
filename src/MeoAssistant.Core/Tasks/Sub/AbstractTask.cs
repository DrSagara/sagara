// <copyright file="AbstractTask.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Tasks.Sub
{
    using System.Text.Json.Serialization;
    using System.Text.RegularExpressions;
    using MeoAssistant.Core.Tasks.Plugin;
    using MeoAssistant.Core.Utilities;

    public abstract class AbstractTask
    {
        public const int RetryTimesDefault = 20;

        public AbstractTask(AssistantCallback callback, string taskChain, params object[] callbackArgs)
        {
            this.AssistantCallback = callback;
            this.CallbackArgs = callbackArgs;
            this.TaskChain = taskChain;
        }

        public bool? ExitFlag { get; set; }

        public int RetryTimes { get; set; } = RetryTimesDefault;

        public Controller? Controller { get; set; }

        public RuntimeStatus Status { get; set; }

        public bool IsEnabled { get; set; } = true;

        public bool IgnoreError { get; set; } = true;

        public int TaskId { get; set; } = 0;

        protected AssistantCallback AssistantCallback { get; set; }

        protected string TaskChain { get; set; }

        protected object[] CallbackArgs { get; set; }

        protected int CurrentRetry { get; set; } = 0;

        protected bool NeedExit => this.ExitFlag ?? false;

        protected HashSet<AbstractTaskPlugin> Plugins { get; set; } = new();

        protected BasicInfoType? BasicInfoCache { get; set; }

        public virtual bool Run()
        {
            if (!this.IsEnabled)
            {
                Logger.Instance.Info("task disabled, pass", this.BasicInfo());
                return true;
            }

            this.Callback(AssistantMessage.SubTaskStart, this.BasicInfo());

            for (this.CurrentRetry = 0; this.CurrentRetry <= this.RetryTimes; this.CurrentRetry++)
            {
                if (this.RunInternal())
                {
                    this.Callback(AssistantMessage.SubTaskCompleted, this.BasicInfo());
                    return true;
                }

                if (this.NeedExit)
                {
                    return false;
                }

                int delay = Resource.Config.Options.TaskDelay;
                this.Sleep(delay);

                if (!this.OnRunFails())
                {
                    this.Callback(AssistantMessage.SubTaskError, this.BasicInfo());
                    return false;
                }
            }

            this.Callback(AssistantMessage.SubTaskError, this.BasicInfo());
            return false;
        }

        public BasicInfoType BasicInfo()
        {
            if (this.BasicInfoCache == null)
            {
                var className = this.GetType().Name;
                Regex rx = new(@"[a-zA-Z]+Task");
                var matches = rx.Match(className);
                var taskName = matches.Success ? matches.Groups[0].Value : className;

                this.BasicInfoCache = new()
                {
                    TaskChain = this.TaskChain,
                    TaskId = this.TaskId,
                    Class = className,
                    SubTask = taskName,
                    Details = new(),
                };
            }

            return this.BasicInfoCache;
        }

        public void ClearPlugin()
        {
            this.Plugins.Clear();
        }

        protected abstract bool RunInternal();

        protected virtual void Callback(AssistantMessage msg, object detail)
        {
            foreach (var plugin in this.Plugins)
            {
                // TODO
            }

            this.AssistantCallback(msg, detail, this.CallbackArgs);
        }

        protected bool Sleep(int millisecond)
        {
            if (this.NeedExit)
            {
                return false;
            }

            if (millisecond == 0)
            {
                Thread.Yield();
                return true;
            }

            var start = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Logger.Instance.Trace("ready to sleep", millisecond);
            var interval = millisecond / 5;

            while (!this.NeedExit)
            {
                Thread.Sleep(interval);
                if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - start > millisecond)
                {
                    break;
                }
            }

            Logger.Instance.Trace("end of sleep", millisecond);

            return !this.NeedExit;
        }

        protected virtual bool OnRunFails()
        {
            return true;
        }

        protected BasicInfoType BasicInfoWithWhat(string what)
        {
            var basicInfo = this.BasicInfo();
            basicInfo.What = what;
            return basicInfo;
        }

        protected virtual void ClickReturnButton()
        {
            // TODO
        }

        protected void SaveImage()
        {
            // TODO
        }

        public record BasicInfoType
        {
            [JsonPropertyName("taskchain")]
            public string TaskChain { get; set; } = string.Empty;

            [JsonPropertyName("taskid")]
            public int TaskId { get; set; }

            [JsonPropertyName("class")]
            public string Class { get; set; } = string.Empty;

            [JsonPropertyName("subtask")]
            public string SubTask { get; set; } = string.Empty;

            [JsonPropertyName("details")]
            public object Details { get; set; } = new();

            [JsonPropertyName("what")]
            public string What { get; set; } = string.Empty;
        }
    }
}
