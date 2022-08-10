// <copyright file="TaskInfo.cs" company="MaaAssistantArknights">
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
    /// <summary>
    /// 任务信息
    /// </summary>
    public record TaskInfo
    {
        /// <summary>
        /// 任务名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 图像算法类型
        /// </summary>
        public AlgorithmType Algorithm { get; set; } = AlgorithmType.Invalid;

        /// <summary>
        /// 要进行的操作
        /// </summary>
        public ProcessTaskAction Action { get; set; } = ProcessTaskAction.Invalid;

        /// <summary>
        /// 子任务（列表）
        /// </summary>
        public IEnumerable<string> SubTasks { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 子任务如果失败了，是否继续执行剩下的任务
        /// </summary>
        public bool SubErrorIgnored { get; set; } = false;

        /// <summary>
        /// 下一个可能的任务（列表）
        /// </summary>
        public IEnumerable<string> Next { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 任务最多执行多少次
        /// </summary>
        public int MaxTimes { get; set; } = int.MaxValue;

        /// <summary>
        /// 达到最多次数了之后，下一个可能的任务（列表）
        /// </summary>
        public IEnumerable<string> ExceededNext { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 任务出错之后要去执行什么
        /// </summary>
        public IEnumerable<string> OnErrorNext { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 执行了该任务后，需要减少别的任务的执行次数
        /// </summary>
        /// <remarks>例如执行了吃理智药，则说明上一次点击蓝色开始行动按钮没生效，所以蓝色开始行动要-1。</remarks>
        public IEnumerable<string> ReduceOtherTimes { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 指定区域，目前仅针对 <c>ClickRect</c> 任务有用，会点这个区域
        /// </summary>
        public Rect SpecificRect { get; set; } = new();

        /// <summary>
        /// 执行该任务前的延时
        /// </summary>
        public int PreDelay { get; set; } = 0;

        /// <summary>
        /// 执行该任务后的延时
        /// </summary>
        public int RearDelay { get; set; } = 0;

        /// <summary>
        /// 未找到图像时的重试次数
        /// </summary>
        public int RetryTimes { get; set; } = int.MaxValue;

        /// <summary>
        /// 要识别的区域，若为0则全图识别
        /// </summary>
        public Rect ROI { get; set; } = new();

        /// <summary>
        /// 识别结果移动
        /// </summary>
        /// <remarks>
        /// 有些结果识别到的，和要点击的不是同一个位置。即识别到了 <c>res</c>，点击 <c>res + result_move</c> 的位置。
        /// </remarks>
        public Rect RectMove { get; set; } = new();

        /// <summary>
        /// 是否使用缓存区域
        /// </summary>
        public bool IsCacheUsed { get; set; } = false;
    }
}
