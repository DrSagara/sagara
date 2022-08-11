// <copyright file="LogTraceFunction.cs" company="MaaAssistantArknights">
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
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public sealed class LogTraceFunction : IDisposable
    {
        private readonly Stopwatch stopwatch = new();

        private readonly string caller;

        private readonly object[] args;

        public LogTraceFunction([CallerMemberName] string caller = "", params object[] args)
        {
            this.caller = caller;
            this.args = args;

            if (args.Length > 0)
            {
                Logger.Instance.Trace(caller, args, "| enter");
            }
            else
            {
                Logger.Instance.Trace(caller, "| enter");
            }

            this.stopwatch.Start();
        }

        public void Dispose()
        {
            this.stopwatch.Stop();

            if (this.args.Length > 0)
            {
                Logger.Instance.Trace(this.caller, this.args, "| leave", $"{(int)this.stopwatch.Elapsed.TotalMilliseconds}ms");
            }
            else
            {
                Logger.Instance.Trace(this.caller, "| leave", $"{(int)this.stopwatch.Elapsed.TotalMilliseconds}ms");
            }
        }
    }
}
