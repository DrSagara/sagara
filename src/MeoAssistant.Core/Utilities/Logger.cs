// <copyright file="Logger.cs" company="MaaAssistantArknights">
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
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Logger : IDisposable
    {
        private const long MaxLogSize = 4 * 1024 * 1024;

        private static Logger? instance;

        private static string dirname = string.Empty;

        private StreamWriter streamWriter;

        private bool disposed;

        private Logger()
        {
            this.CheckFilesizeAndRemove();
            this.streamWriter = new StreamWriter(this.LogFilename, true, Encoding.UTF8);
            this.LogInitInfo();
        }

        ~Logger()
        {
            this.Dispose(false);
        }

        public static Logger Instance => instance ??= new();

        public string LogFilename => Path.Combine(dirname, "asst.log");

        public string LogBakFilename => Path.Combine(dirname, "asst.bak.log");

        public static bool SetDirname(string dirname)
        {
            if (!Directory.Exists(dirname))
            {
                return false;
            }

            Logger.dirname = dirname;
            return true;
        }

#pragma warning disable CA1822 // Mark members as static
        public void Debug(params object[] args)
#pragma warning restore CA1822 // Mark members as static
        {
#if ASST_DEBUG
            this.Log("DEB", args);
#endif
        }

        public void Trace(params object[] args)
        {
            this.Log("TRC", args);
        }

        public void Info(params object[] args)
        {
            this.Log("INF", args);
        }

        public void Warn(params object[] args)
        {
            this.Log("WRN", args);
        }

        public void Error(params object[] args)
        {
            this.Log("ERR", args);
        }

        public void LogWithCustomLevel(string level, params object[] args)
        {
            this.Log(level, args);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Clean up managed sources.
                    // Call Dispose() on your managed sources.
                    this.streamWriter.Dispose();
                }

                // Clean up unmanaged sources.
                this.disposed = true;
            }
        }

        private void CheckFilesizeAndRemove()
        {
            try
            {
                if (File.Exists(this.LogFilename))
                {
                    FileInfo fileInfo = new(this.LogFilename);
                    if (fileInfo.Length >= MaxLogSize)
                    {
                        File.Move(this.LogFilename, this.LogBakFilename);
                    }
                }
            }
            catch (Exception)
            {
                // Ignore.
            }
        }

        private void LogInitInfo()
        {
            this.Trace("-----------------------------");
            this.Trace("MeoAssistant Process Start");

            /*
             * TODO: version
             * TODO: date time
             */

            this.Trace("Working Path", dirname);
            this.Trace("-----------------------------");
        }

        private void Log(string level, params object[] args)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(Logger));
            }

            var now = DateTimeOffset.Now.LocalDateTime.ToString();
            var content = string.Join(" ", args);

            /* TODO: PID, Thread ID */

            this.streamWriter.WriteLine($"[{now}][{level}] {content}");
        }
    }
}
