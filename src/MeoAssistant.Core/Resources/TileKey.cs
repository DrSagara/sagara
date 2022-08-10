// <copyright file="TileKey.cs" company="MaaAssistantArknights">
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
    public enum TileKey
    {
        Invalid = -1,

        /// <summary>
        /// 不能放干员，敌人也不能走
        /// </summary>
        Forbidden,

        /// <summary>
        /// 可以放高台干员的位置
        /// </summary>
        Wall,

        /// <summary>
        /// 可以放地面干员，敌人也可以走
        /// </summary>
        Road,

        /// <summary>
        /// 蓝门（可能还有其他的情况）
        /// </summary>
        Home,

        /// <summary>
        /// 红门（可能还有其他的情况）
        /// </summary>
        EnemyHome,

        /// <summary>
        /// 不能放干员，但敌人可以走
        /// </summary>
        Floor,

        /// <summary>
        /// 空降兵掉下去的地方
        /// </summary>
        Hole,

        /// <summary>
        /// 传送门入口
        /// </summary>
        Telin,

        /// <summary>
        /// 传送门出口
        /// </summary>
        Telout,

        /// <summary>
        /// 岩浆地块，可以放干员，敌人也可以走，但是会持续掉血
        /// </summary>
        Volcano,

        /// <summary>
        /// 治疗地块，可以放干员，敌人也可以走，会给干员回血
        /// </summary>
        Healing,
    }
}
