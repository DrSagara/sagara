// <copyright file="ProcessTaskAction.cs" company="MaaAssistantArknights">
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

namespace MeoAssistant.Core.Utilities.Types
{
    [Flags]
    public enum ProcessTaskAction : int
    {
        Invalid = 0,
        BasicClick = 0x100,

        /// <summary>
        /// 点击自身位置
        /// </summary>
        ClickSelf = BasicClick | 1,

        /// <summary>
        /// 点击指定区域
        /// </summary>
        ClickRect = BasicClick | 2,

        /// <summary>
        /// 点击随机区域
        /// </summary>
        ClickRand = BasicClick | 4,

        /// <summary>
        /// 什么都不做
        /// </summary>
        DoNothing = 0x200,

        /// <summary>
        /// 停止当前Task
        /// </summary>
        Stop = 0x400,
        BasicSwipe = 0x1000,

        /// <summary>
        /// 往左划一下
        /// </summary>
        SwipeToTheLeft = BasicSwipe | 1,

        /// <summary>
        /// 往右划一下
        /// </summary>
        SwipeToTheRight = BasicSwipe | 2,

        /// <summary>
        /// 慢慢地往左划一下
        /// </summary>
        SlowlySwipeToTheLeft = SwipeToTheLeft | 4,

        /// <summary>
        /// 慢慢地往右划一下
        /// </summary>
        SlowlySwipeToTheRight = SwipeToTheRight | 8,
    }
}
