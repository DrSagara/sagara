// <copyright file="GeneralConfig.cs" company="MaaAssistantArknights">
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
    /// <summary>
    /// The general configurer.
    /// </summary>
    public class GeneralConfig : AbstractConfig
    {
        private readonly Dictionary<string, AdbConfig> adbConfig = new();
        private readonly Dictionary<string, string> intentName = new();

        /// <summary>
        /// Gets the version.
        /// </summary>
        public string Version { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        public Options Options { get; set; } = new();

        /// <summary>
        /// Gets the ADB config.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The ADB config.</returns>
        public AdbConfig? GetAdbConfig(string name)
        {
            return this.adbConfig.TryGetValue(name, out var adbConfig) ? adbConfig : null;
        }

        /// <summary>
        /// Gets the intent name.
        /// </summary>
        /// <param name="clientType">The client type.</param>
        /// <returns>The intent name.</returns>
        public string? GetIntentName(string clientType)
        {
            return this.intentName.TryGetValue(clientType, out var intentName) ? intentName : null;
        }

        /// <inheritdoc/>
        protected override bool Parse(object json)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The Penguin report config.
    /// </summary>
    public record PenguinReportConfig
    {
        /// <summary>
        /// Gets or sets the command format.
        /// </summary>
        public string CommandFormat { get; set; } = string.Empty;
    }

    /// <summary>
    /// The depot export template.
    /// </summary>
    public record DepotExportTemplate
    {
        /// <summary>
        /// Gets or sets the ark planner.
        /// </summary>
        public string ArkPlanner { get; set; } = string.Empty;
    }

    /// <summary>
    /// The options.
    /// </summary>
    public record Options
    {
        /// <summary>
        /// Gets or sets the delay between tasks.
        /// </summary>
        public int TaskDelay { get; set; } = 0;

        /// <summary>
        /// Gets or sets the lower bound of the random delay before clicking.
        /// </summary>
        public int ControlDelayLower { get; set; } = 0;

        /// <summary>
        /// Gets or sets the upper bound of the random delay before clicking.
        /// </summary>
        public int ControlDelayUpper { get; set; } = 0;

        /// <summary>
        /// Gets or sets the extra swiping distance.
        /// </summary>
        public int AdbExtraSwipeDistance { get; set; } = 0;

        /// <summary>
        /// Gets or sets the extra swiping duration.
        /// </summary>
        public int AdbExtraSwipeDuration { get; set; } = 0;

        /// <summary>
        /// Gets or sets the PenguinStats report format.
        /// </summary>
        public PenguinReportConfig PenguinReport { get; set; } = new();

        /// <summary>
        /// Gets or sets the depot export template.
        /// </summary>
        public DepotExportTemplate DepotExportTemplate { get; set; } = new();
    }

    /// <summary>
    /// The ADB config.
    /// </summary>
    public record AdbConfig
    {
        // TODO
    }
}
