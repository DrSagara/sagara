// <copyright file="Resource.cs" company="MaaAssistantArknights">
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

    /// <summary>
    /// The resource.
    /// </summary>
    public class Resource : AbstractResource
    {
        private static Resource? resource;
        private static TemplateResource? templateResource;
        private static GeneralConfig? generalConfig;
        private static RecruitConfig? recruitConfig;
        private static RoguelikeRecruitConfig? roguelikeRecruitConfig;
        private static ItemConfig? itemConfig;
        private static InfrastConfig? infrastConfig;
        private static CopilotConfig? copilotConfig;
        private static RoguelikeCopilotConfig? roguelikeCopilotConfig;
        private static OcrPack? ocrPack;
        private static TilePack? tilePack;
        private static StageDropsConfig? stageDropsConfig;
        private static BattleDataConfig? battleDataConfig;
        private static RoguelikeShoppingConfig? roguelikeShoppingConfig;

        private Resource()
        {
        }

        public static Resource Instance => resource ??= new();

        public static TemplateResource Template => templateResource ??= new();

        public static GeneralConfig Config => generalConfig ??= new();

        public static RecruitConfig Recruit => recruitConfig ??= new();

        public static RoguelikeRecruitConfig RoguelikeRecruit => roguelikeRecruitConfig ??= new();

        public static ItemConfig Item => itemConfig ??= new();

        public static InfrastConfig Infrast => infrastConfig ??= new();

        public static CopilotConfig Copilot => copilotConfig ??= new();

        public static RoguelikeCopilotConfig Roguelike => roguelikeCopilotConfig ??= new();

        public static OcrPack Ocr => ocrPack ??= new();

        public static TilePack Tile => tilePack ??= new();

        public static StageDropsConfig Drops => stageDropsConfig ??= new();

        public static BattleDataConfig BattleData => battleDataConfig ??= new();

        public static RoguelikeShoppingConfig RoguelikeShopping => roguelikeShoppingConfig ??= new();

        /// <inheritdoc/>
        public override bool Load(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
