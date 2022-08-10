// <copyright file="AssistantMessage.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Utilities
{
    /// <summary>
    /// The message of Assistant.
    /// </summary>
    public enum AssistantMessage
    {
        /// <summary>
        /// The internal error.
        /// </summary>
        InternalError = 0,

        /// <summary>
        /// Initialisation failed.
        /// </summary>
        InitFailed,

        /// <summary>
        /// Connection error.
        /// </summary>
        ConnectionInfo,

        /// <summary>
        /// Completion of all tasks.
        /// </summary>
        AllTasksCompleted,

        /// <summary>
        /// Task chain execution/recognition error.
        /// </summary>
        TaskChainError = 10000,

        /// <summary>
        /// Starting of a task chain.
        /// </summary>
        TaskChainStart,

        /// <summary>
        /// Completion of a task chain.
        /// </summary>
        TaskChainCompleted,

        /// <summary>
        /// Extra info of a task chain.
        /// </summary>
        TaskChainExtraInfo,

        /// <summary>
        /// Error of sub tasks.
        /// </summary>
        SubTaskError = 20000,

        /// <summary>
        /// Starting of a sub task.
        /// </summary>
        SubTaskStart,

        /// <summary>
        /// Completion of a sub task.
        /// </summary>
        SubTaskCompleted,

        /// <summary>
        /// Extra info of a sub task.
        /// </summary>
        SubTaskExtraInfo,
    }
}
