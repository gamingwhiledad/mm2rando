﻿using MM2Randomizer.Settings.Options;

namespace MM2Randomizer.Settings.OptionGroups
{
    public class CosmeticOptions
    {
        public RandomizationOption<HudElementOption> HudElement { get; } = new RandomizationOption<HudElementOption>();

        public RandomizationOption<PlayerSpriteOption> PlayerSprite { get; } = new RandomizationOption<PlayerSpriteOption>();

        public RandomizationOption<BooleanOption> RandomizeColorPalettes { get; } = new RandomizationOption<BooleanOption>();

        public RandomizationOption<BooleanOption> RandomizeInGameText { get; } = new RandomizationOption<BooleanOption>();

        public RandomizationOption<BooleanOption> RandomizeMusicTracks { get; } = new RandomizationOption<BooleanOption>();
    }
}
