// <copyright file="Controller.cs" company="MaaAssistantArknights">
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
    using MeoAssistant.Core.Utilities;
    using MeoAssistant.Core.Utilities.Types;
    using MeoAssistant.Core.Wrappers;

    /// <summary>
    /// The controller.
    /// </summary>
    public class Controller : IDisposable
    {
        private const int SwipeExtraDelayDefault = 1000;

        private bool isInited;

        private Guid guid;

        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="callbackArgs">The callback arguments.</param>
        public Controller(AssistantCallback callback, params object[] callbackArgs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Controller"/> class.
        /// </summary>
        ~Controller()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets a value indicating whether the controller has been initialised.
        /// </summary>
        public bool IsInited => this.isInited;

        /// <summary>
        /// Gets the GUID.
        /// </summary>
        public Guid Guid => this.guid;

        /// <summary>
        /// Connects to the emulator.
        /// </summary>
        /// <param name="adbPath">The ADB path.</param>
        /// <param name="address">The address.</param>
        /// <param name="config">The config.</param>
        /// <returns>A value indicating whether the operation is successful.</returns>
        public bool Connect(string adbPath, string address, string config)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Releases connection.
        /// </summary>
        /// <returns>A value indicating whether the operation is successful.</returns>
        public bool Release()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets image.
        /// </summary>
        /// <param name="isRaw">A value indicating whether to get raw image.</param>
        /// <returns>The image matrix.</returns>
        public Mat GetImage(bool isRaw = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets encoded image.
        /// </summary>
        /// <returns>The image in byte array.</returns>
        public byte[] GetImageEncode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts game.
        /// </summary>
        /// <param name="clientType">The client type.</param>
        /// <param name="isBlocking">A value indicating whether the operation is blocking.</param>
        /// <returns>The task ID, or <see langword="null"/> if an error occurs.</returns>
        public int? StartGame(string clientType, bool isBlocking = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops game.
        /// </summary>
        /// <param name="isBlocking">A value indicating whether the operation is blocking.</param>
        /// <returns>The task ID, or <see langword="null"/> if an error occurs.</returns>
        public int? StopGame(bool isBlocking = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a clicking event.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <returns>The task ID.</returns>
        public int Click(Point p, bool block = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a clicking event.
        /// </summary>
        /// <param name="rect">The rectangle.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <returns>The task ID.</returns>
        public int Click(Rect rect, bool block = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a clicking event without scale.
        /// </summary>
        /// <param name="p">The point.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <returns>The task ID.</returns>
        public int ClickWithoutScale(Point p, bool block = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a clicking event without scale.
        /// </summary>
        /// <param name="rect">The rectangle.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <returns>The task ID.</returns>
        public int ClickWithoutScale(Rect rect, bool block = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a swiping event.
        /// </summary>
        /// <param name="p1">The starting point.</param>
        /// <param name="p2">The ending point.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <param name="extraDelay">The extra delay.</param>
        /// <param name="extraSwipe">A value indicating whether an extra swiping is required.</param>
        /// <returns>The task ID.</returns>
        public int Swipe(
            Point p1,
            Point p2,
            int duration = 0,
            bool block = true,
            int extraDelay = SwipeExtraDelayDefault,
            bool extraSwipe = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a swiping event.
        /// </summary>
        /// <param name="r1">The starting rectangle.</param>
        /// <param name="r2">The ending rectangle.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <param name="extraDelay">The extra delay.</param>
        /// <param name="extraSwipe">A value indicating whether an extra swiping is required.</param>
        /// <returns>The task ID.</returns>
        public int Swipe(
            Rect r1,
            Rect r2,
            int duration = 0,
            bool block = true,
            int extraDelay = SwipeExtraDelayDefault,
            bool extraSwipe = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a swiping event without scale.
        /// </summary>
        /// <param name="p1">The starting point.</param>
        /// <param name="p2">The ending point.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <param name="extraDelay">The extra delay.</param>
        /// <param name="extraSwipe">A value indicating whether an extra swiping is required.</param>
        /// <returns>The task ID.</returns>
        public int SwipeWithoutScale(
            Point p1,
            Point p2,
            int duration = 0,
            bool block = true,
            int extraDelay = SwipeExtraDelayDefault,
            bool extraSwipe = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a swiping event without scale.
        /// </summary>
        /// <param name="r1">The starting rectangle.</param>
        /// <param name="r2">The ending rectangle.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="block">A value indicating whether the operation is blocking.</param>
        /// <param name="extraDelay">The extra delay.</param>
        /// <param name="extraSwipe">A value indicating whether an extra swiping is required.</param>
        /// <returns>The task ID.</returns>
        public int SwipeWithoutScale(
            Rect r1,
            Rect r2,
            int duration = 0,
            bool block = true,
            int extraDelay = SwipeExtraDelayDefault,
            bool extraSwipe = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Waits until the task of the given ID completes.
        /// </summary>
        /// <param name="id">The task ID.</param>
        public void Wait(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets scale size.
        /// </summary>
        /// <returns>The width and height of the screen size.</returns>
        public (int Width, int Height) GetScaleSize()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">A value indicating whether the call is from <see cref="Dispose()"/>.</param>
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Clean up managed sources.
                    // Call Dispose() on your managed sources.
                }

                // Clean up unmanaged sources.
                this.disposed = true;
            }
        }
    }
}
