﻿using System;
using System.Collections.Generic;
using System.Linq;
using MM2Randomizer.Enums;
using MM2Randomizer.Patcher;
using MM2Randomizer.Settings.Options;

namespace MM2Randomizer.Randomizers.Colors
{
    /// <summary>
    /// Stage Color Palette Randomizer
    /// </summary>
    public class RColors : IRandomizer
    {
        //
        // Constructors
        //

        public RColors()
        {
        }


        //
        // IRandomizer Methods
        //

        public void Randomize(Patch in_Patch, RandomizationContext in_Context)
        {
            this.RandomizeStageColors(in_Patch, in_Context);
            this.RandomizeWeaponColors(in_Patch, in_Context);
            this.RandomizeBossColors(in_Patch, in_Context);
            this.RandomizeIntroColors(in_Patch, in_Context);
            this.RandomizeMenuColors(in_Patch, in_Context);
        }


        //
        // Private Helper Methods
        //

        private void RandomizeMenuColors(Patch in_Patch, RandomizationContext in_Context)
        {
            List<ColorSet> StageSelectColorSets = new List<ColorSet>()
            {
                new ColorSet() { // Start/Password background color data
                    addresses = new Int32[] {
                        0x036f0b, 0x036f0c
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // Default Light Blue
                            (EColorsHex)0x21,(EColorsHex)0x11,
                        },
                        new EColorsHex[] { // Blue
                            (EColorsHex)0x22,(EColorsHex)0x12,
                        },
                        new EColorsHex[] { // Purple
                            (EColorsHex)0x23,(EColorsHex)0x13,
                        },
                        new EColorsHex[] { // Pink
                            (EColorsHex)0x24,(EColorsHex)0x14,
                        },
                        new EColorsHex[] { // Red
                            (EColorsHex)0x25,(EColorsHex)0x15,
                        },
                        new EColorsHex[] { // Orange-Red
                            (EColorsHex)0x26,(EColorsHex)0x16,
                        },
                        new EColorsHex[] { // Gold
                            (EColorsHex)0x27,(EColorsHex)0x17,
                        },
                        new EColorsHex[] { // Yellow
                            (EColorsHex)0x28,(EColorsHex)0x18,
                        },
                        new EColorsHex[] { // Light-Green
                            (EColorsHex)0x29,(EColorsHex)0x19,
                        },
                        new EColorsHex[] { // Turquoise
                            (EColorsHex)0x2b,(EColorsHex)0x1b,
                        },
                        new EColorsHex[] { // Teal
                            (EColorsHex)0x2c,(EColorsHex)0x1c,
                        },
                        new EColorsHex[] { // Dark Light Blue
                            (EColorsHex)0x11,(EColorsHex)0x01,
                        },
                        new EColorsHex[] { // Dark Blue
                            (EColorsHex)0x12,(EColorsHex)0x02,
                        },
                        new EColorsHex[] { // Dark Purple
                            (EColorsHex)0x13,(EColorsHex)0x03,
                        },
                        new EColorsHex[] { // Dark Pink
                            (EColorsHex)0x14,(EColorsHex)0x04,
                        },
                        new EColorsHex[] { // Dark Red
                            (EColorsHex)0x15,(EColorsHex)0x05,
                        },
                        new EColorsHex[] { // Dark Orange-Red
                            (EColorsHex)0x16,(EColorsHex)0x06,
                        },
                        new EColorsHex[] { // Dark Gold
                            (EColorsHex)0x17,(EColorsHex)0x07,
                        },
                        new EColorsHex[] { // Dark Yellow
                            (EColorsHex)0x18,(EColorsHex)0x08,
                        },
                        new EColorsHex[] { // Dark Light-Green
                            (EColorsHex)0x19,(EColorsHex)0x09,
                        },
                        new EColorsHex[] { // Dark Turquoise
                            (EColorsHex)0x1b,(EColorsHex)0x0b,
                        },
                        new EColorsHex[] { // Dark Teal
                            (EColorsHex)0x1c,(EColorsHex)0x0c,
                        },
                        new EColorsHex[] { // Gray
                            (EColorsHex)0x10,(EColorsHex)0x00,
                        },
                        new EColorsHex[] { // Black
                            (EColorsHex)0x00,(EColorsHex)0x0f,
                        },
                    }
                },

                new ColorSet() { // Stage Select and Credits Panel background color sets
                    addresses = new Int32[] {
                        0x0344ab, 0x0344ac,
                        0x0344af, 0x0344b0,
                        0x0344b3, 0x0344b4,
                        0x0344b7, 0x0344b8,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // Default light blue
                            (EColorsHex)0x11,(EColorsHex)0x2C,
                            (EColorsHex)0x11,(EColorsHex)0x2C,
                            (EColorsHex)0x11,(EColorsHex)0x2C,
                            (EColorsHex)0x11,(EColorsHex)0x2C,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x12,(EColorsHex)0x21,
                            (EColorsHex)0x12,(EColorsHex)0x21,
                            (EColorsHex)0x12,(EColorsHex)0x21,
                            (EColorsHex)0x12,(EColorsHex)0x21,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x13,(EColorsHex)0x22,
                            (EColorsHex)0x13,(EColorsHex)0x22,
                            (EColorsHex)0x13,(EColorsHex)0x22,
                            (EColorsHex)0x13,(EColorsHex)0x22,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x15,(EColorsHex)0x24,
                            (EColorsHex)0x15,(EColorsHex)0x24,
                            (EColorsHex)0x15,(EColorsHex)0x24,
                            (EColorsHex)0x15,(EColorsHex)0x24,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x16,(EColorsHex)0x25,
                            (EColorsHex)0x16,(EColorsHex)0x25,
                            (EColorsHex)0x16,(EColorsHex)0x25,
                            (EColorsHex)0x16,(EColorsHex)0x25,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x17,(EColorsHex)0x26,
                            (EColorsHex)0x17,(EColorsHex)0x26,
                            (EColorsHex)0x17,(EColorsHex)0x26,
                            (EColorsHex)0x17,(EColorsHex)0x26,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x18,(EColorsHex)0x27,
                            (EColorsHex)0x18,(EColorsHex)0x27,
                            (EColorsHex)0x18,(EColorsHex)0x27,
                            (EColorsHex)0x18,(EColorsHex)0x27,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x19,(EColorsHex)0x28,
                            (EColorsHex)0x19,(EColorsHex)0x28,
                            (EColorsHex)0x19,(EColorsHex)0x28,
                            (EColorsHex)0x19,(EColorsHex)0x28,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x1b,(EColorsHex)0x2a,
                            (EColorsHex)0x1b,(EColorsHex)0x2a,
                            (EColorsHex)0x1b,(EColorsHex)0x2a,
                            (EColorsHex)0x1b,(EColorsHex)0x2a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x1c,(EColorsHex)0x2b,
                            (EColorsHex)0x1c,(EColorsHex)0x2b,
                            (EColorsHex)0x1c,(EColorsHex)0x2b,
                            (EColorsHex)0x1c,(EColorsHex)0x2b,
                        },

                        new EColorsHex[] {
                            (EColorsHex)0x01,(EColorsHex)0x1c,
                            (EColorsHex)0x01,(EColorsHex)0x1c,
                            (EColorsHex)0x01,(EColorsHex)0x1c,
                            (EColorsHex)0x01,(EColorsHex)0x1c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x03,(EColorsHex)0x16,
                            (EColorsHex)0x03,(EColorsHex)0x16,
                            (EColorsHex)0x03,(EColorsHex)0x16,
                            (EColorsHex)0x03,(EColorsHex)0x16,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0b,(EColorsHex)0x22,
                            (EColorsHex)0x0b,(EColorsHex)0x22,
                            (EColorsHex)0x0b,(EColorsHex)0x22,
                            (EColorsHex)0x0b,(EColorsHex)0x22,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x00,(EColorsHex)0x0f,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0f,(EColorsHex)0x00,
                            (EColorsHex)0x0f,(EColorsHex)0x00,
                            (EColorsHex)0x0f,(EColorsHex)0x00,
                            (EColorsHex)0x0f,(EColorsHex)0x00,
                        },
                    }
                },
            };

            // Boss Intro Panel color set, use the similar formatted Start/Password colorbytes
            StageSelectColorSets.Add(new ColorSet()
            {
                addresses = new Int32[] { 0x34186, 0x3418B },
                ColorBytes = new List<EColorsHex[]>(StageSelectColorSets[0].ColorBytes),
            });


            // Wily Map color set: Blue sky, castle walls, radar dish, shadows
            ColorSet wilyMap1 = new ColorSet()
            {
                addresses = new Int32[] {
                    0x035E99, 0x035EA5, // dark 1, 2 ($01)
                    0x035EB9, 0x035EBA, // mid 1, 2  ($11)
                    0x035EC5, 0x035EDA, 0x035BA6, // mid 3-5  ($11)
                    0x035ED9, 0x035EE5, 0x035BA5, 0x035BB1, // lite 1-4 ($21)
                },

                ColorBytes = new List<EColorsHex[]>()
                {
                    new EColorsHex[] { // Dark gray
                        (EColorsHex)0x1d,(EColorsHex)0x1d,
                        (EColorsHex)0x2d,(EColorsHex)0x2d,
                        (EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,
                        (EColorsHex)0x3d,(EColorsHex)0x3d,(EColorsHex)0x3d,(EColorsHex)0x3d,
                    },
                }
            };
            for (Int32 i = 0; i < 12; i++)
            {
                // Add the standard range of palette color shades (starting with default blue)
                wilyMap1.ColorBytes.Add(new EColorsHex[]
                {
                    (EColorsHex)0x01 + i,(EColorsHex)0x01 + i,
                    (EColorsHex)0x11 + i,(EColorsHex)0x11 + i,
                    (EColorsHex)0x11 + i,(EColorsHex)0x11 + i,(EColorsHex)0x11 + i,
                    (EColorsHex)0x21 + i,(EColorsHex)0x21 + i,(EColorsHex)0x21 + i,(EColorsHex)0x21 + i,
                });
            }
            StageSelectColorSets.Add(wilyMap1);


            // Wily Map color set: Roofs, turret
            ColorSet wilyMap2 = new ColorSet()
            {
                addresses = new Int32[] {
                    0x035EA1, // dark orange, $06 (fade in only)
                    0x035EC1, // mid orange, $16 (fade in only)
                    0x035EE1, 0x035BAD, // lite orange, $26
                    0x035EC2, // dark red, $05 (fade in only)
                    0x035EE2, 0x035BAE, // mid red, $15
                },

                ColorBytes = new List<EColorsHex[]>() { }
            };
            for (Int32 i = 1; i <= 12; i++)
            {
                // Add the standard range of palette color shades (i = 0 is default colors)
                wilyMap2.ColorBytes.Add(new EColorsHex[]
                {
                    (EColorsHex)0x00 + ((0x06 + i) % 12),
                    (EColorsHex)0x10 + ((0x06 + i) % 12),
                    (EColorsHex)0x20 + ((0x06 + i) % 12),(EColorsHex)0x20 + ((0x06 + i) % 12),
                    (EColorsHex)0x00 + ((0x05 + i) % 12),
                    (EColorsHex)0x10 + ((0x05 + i) % 12),(EColorsHex)0x10 + ((0x05 + i) % 12),
                });
            }
            StageSelectColorSets.Add(wilyMap2);


            // Wily Map color set: Wily logo
            ColorSet wilyMap3 = new ColorSet()
            {
                addresses = new Int32[] {
                    0x035EA9, // dark green 1 ($09)
                    0x035EEA, // dark green 2 ($09)
                    0x035BB6, // dark green 3 ($09)
                    0x035EC9, // mid green 1  ($19)
                    0x035EE9, // light green 1 ($29)
                    0x035BB5, // light green 2 ($29)
                },

                ColorBytes = new List<EColorsHex[]>()
                {
                    new EColorsHex[] { // Dark gray
                        (EColorsHex)0x1d,(EColorsHex)0x1d,(EColorsHex)0x1d,
                        (EColorsHex)0x2d,
                        (EColorsHex)0x3d,(EColorsHex)0x3d,
                    },
                }
            };
            for (Int32 i = 1; i <= 12; i++)
            {
                // Add the standard range of palette color shades (starting with default)
                wilyMap3.ColorBytes.Add(new EColorsHex[]
                {
                    (EColorsHex)0x00 + ((0x09 + i) % 12),(EColorsHex)0x00 + ((0x09 + i) % 12),(EColorsHex)0x00 + ((0x09 + i) % 12),
                    (EColorsHex)0x10 + ((0x09 + i) % 12),
                    (EColorsHex)0x20 + ((0x09 + i) % 12),(EColorsHex)0x20 + ((0x09 + i) % 12),
                });
            }
            StageSelectColorSets.Add(wilyMap3);


            // Wily Map color set: Wily logo stroke
            ColorSet wilyMap4 = new ColorSet()
            {
                addresses = new Int32[] {
                    0x035EC8,           // dark orange
                    0x035EE8, 0x035BB4, // mid orange
                },

                ColorBytes = new List<EColorsHex[]>()
                {
                    new EColorsHex[] { // Dark gray
                        (EColorsHex)0x1d,
                        (EColorsHex)0x2d,(EColorsHex)0x2d,
                    },
                }
            };
            for (Int32 i = 1; i <= 12; i++)
            {
                // Add the standard range of palette color shades (starting with default)
                wilyMap4.ColorBytes.Add(new EColorsHex[]
                {
                    (EColorsHex)0x00 + ((0x06 + i) % 12),
                    (EColorsHex)0x10 + ((0x06 + i) % 12),(EColorsHex)0x10 + ((0x06 + i) % 12),
                });
            }
            StageSelectColorSets.Add(wilyMap4);


            // Wily Map color set: Ground/cliffs
            ColorSet wilyMap5 = new ColorSet()
            {
                addresses = new Int32[] {
                    0x035EC4, 0x035EE6, 0x035BD2, 0x035BB2, // dark brown
                    0x035EE4, 0x035BD0, 0x035BB0, // mid brown
                },

                ColorBytes = new List<EColorsHex[]>()
                {
                    new EColorsHex[] { // Gray
                        (EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,
                        (EColorsHex)0x3d,(EColorsHex)0x3d,(EColorsHex)0x3d
                    },
                }
            };

            for (Int32 i = 1; i <= 12; i++)
            {
                // Add the standard range of palette color shades (starting with default)
                wilyMap5.ColorBytes.Add(new EColorsHex[]
                {
                    (EColorsHex)0x00 + ((0x07 + i) % 12),(EColorsHex)0x00 + ((0x07 + i) % 12),(EColorsHex)0x00 + ((0x07 + i) % 12),(EColorsHex)0x00 + ((0x07 + i) % 12),
                    (EColorsHex)0x10 + ((0x07 + i) % 12),(EColorsHex)0x10 + ((0x07 + i) % 12),(EColorsHex)0x10 + ((0x07 + i) % 12),
                });
            }
            StageSelectColorSets.Add(wilyMap5);


            // Wily Map color set: Palette flash
            ColorSet wilyMap6 = new ColorSet()
            {
                addresses = new Int32[] {
                    0x035BC4, 0x035BC8, 0x035BCC, 0x035BC5, 0x035BC9, 0x035BCD, 0x035BC6, 0x035BCA, 0x035BCE, 0x035BD1
                },

                ColorBytes = new List<EColorsHex[]>()
                {
                    new EColorsHex[] { // Gray
                        (EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d,(EColorsHex)0x2d
                    },
                }
            };

            for (Int32 i = 1; i <= 12; i++)
            {
                wilyMap6.ColorBytes.Add(
                    new EColorsHex[]{
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                        (EColorsHex)(0x10 + i),
                    });
            }
            StageSelectColorSets.Add(wilyMap6);


            // Wily Map color set: Line path
            ColorSet wilyMap7 = new ColorSet()
            {
                addresses = new Int32[] {
                    0x035BC2, 0x035BE2
                },

                ColorBytes = new List<EColorsHex[]>()
                {
                    new EColorsHex[] { // Gray
                        (EColorsHex)0x2C,(EColorsHex)0x2C
                    },
                }
            };

            for (Int32 i = 1; i <= 12; i++)
            {
                wilyMap7.ColorBytes.Add(new EColorsHex[] {
                    (EColorsHex)(0x10 + i),
                    (EColorsHex)(0x10 + i),
                });
            }
            StageSelectColorSets.Add(wilyMap7);


            // Execute randomization
            for (Int32 i = 0; i < StageSelectColorSets.Count; i++)
            {
                ColorSet set = StageSelectColorSets[i];
                set.RandomizeAndWrite(in_Patch, in_Context.Seed, i);
            }
        }

        private void RandomizeWeaponColors(Patch in_Patch, RandomizationContext in_Context)
        {
            // Create lists of possible colors to choose from and shuffle them
            List<Byte> possibleDarkColors = new List<Byte>();
            List<Byte> possibleLightColors = new List<Byte>();

            for (Byte i = 0x01; i <= 0x0C; i++)
            {
                // Add first two rows of colors to dark list (except black/white/gray)
                possibleDarkColors.Add(i);
                possibleDarkColors.Add((Byte)(i + 0x10));
                // Add third and fourth rows to light list (except black/white/gray)
                possibleLightColors.Add((Byte)(i + 0x20));
                possibleLightColors.Add((Byte)(i + 0x30));
            }

            // Add black and dark-gray to dark list, white and light-gray to light list
            possibleDarkColors.Add(0x0F);
            possibleDarkColors.Add(0x00);
            possibleLightColors.Add(0x10);
            possibleLightColors.Add(0x20);

            // Randomize lists, and pick the first 9 and 8 elements to use as new colors
            possibleDarkColors = in_Context.Seed.Shuffle(possibleDarkColors).ToList();
            possibleLightColors = in_Context.Seed.Shuffle(possibleLightColors).ToList();
            Queue<Byte> DarkColors = new Queue<Byte>(possibleDarkColors.GetRange(0, 9));
            Queue<Byte> LightColors = new Queue<Byte>(possibleLightColors.GetRange(0, 8));

            // Get starting address depending on game version
            //Int32 startAddress = (RandomMM2.Settings.IsJapanese) ? MegaManColorAddressJ : MEGA_MAN_COLOR_ADDRESS;
            Int32 startAddress = MEGA_MAN_COLOR_ADDRESS;

            // Change 8 robot master weapon colors
            foreach (EBossIndex i in EBossIndex.RobotMasters)
            {
                Byte dark = DarkColors.Dequeue();
                Byte light = LightColors.Dequeue();

                Int32 pos = startAddress + 0x04 + i.Offset * 0x04;
                in_Patch.Add(pos, light, String.Format("{0} Weapon Color Light", ((EDmgVsBoss.Offset)i).ToString()));
                in_Patch.Add(pos+1, dark, String.Format("{0} Weapon Color Dark", ((EDmgVsBoss.Offset)i).ToString()));

                if (EBossIndex.Heat == i)
                {
                    //0x03DE49 - H charge colors
                    //    0F 15 - flash neutral color (15 = weapon color)
                    //    31 15 - flash lv 1(outline only; keep 15 from weapon color)
                    //    35 2C - flash lv 2
                    //    30 30 - flash lv 3
                    in_Patch.Add(0x03DE4A, dark, "Heat Weapon Charge Color 1");
                    in_Patch.Add(0x03DE4C, dark, "Heat Weapon Charge Color 2");
                }
            }

            // Change 3 Item colors
            Byte itemColor = DarkColors.Dequeue();
            for (Int32 i = 0; i < 3; i++)
            {
                in_Patch.Add(startAddress + 0x25 + i * 0x04, itemColor, String.Format("Item {0} Dark Color", i+1));
            }
        }

        private void RandomizeBossColors(Patch in_Patch, RandomizationContext in_Context)
        {
            //// Robot Master Color Palettes
            List<Int32> solidColorSolo = new List<Int32>
            {
                0x00B4EA, // Wood leaf color 0x29
                //0x01B4A1, // Metal blade color 0x30 // WARNING: This should be synchronized with some stage BG colors, or else can appear invisible.
            };

            List<Int32> solidColorPair1Main = new List<Int32> {
                0x01F4ED, // Crash red color 0x16
                0x0174B7, // Flash blue color 0x12
                0x0074B4, // Air projectile blue color 0x11
                0x00B4ED, // Wood orange color 0x17
            };

            List<Int32> solidColorPair1White = new List<Int32> {
                0x01F4EC, // Crash white color 0x30
                0x0174B6, // Flash white color 0x30
                0x0074B3, // Air projectile white color 0x30
                0x00B4EC, // Wood white color 0x36
            };

            List<Int32> solidColorPair2Dark = new List<Int32> {
                0x0034B4, // Heat projectile red color 0x15
                0x0034B7, // Heat red color 0x15
                0x0074B7, // Air blue color 0x11
                0x0134C6, // Quick intro color 2 0x28
                0x0134C9, // Quick red color 0x15
                0x01B4A5, // Metal red color 0x15
                0x00F4B7, // Bubble green color 0x19
            };

            List<Int32> solidColorPair2Light = new List<Int32> {
                0x0034B3, // Heat projectile yellow color 0x28
                0x0034B6, // Heat yellow color 0x28
                0x0074B6, // Air yellow color 0x28
                0x0134C5, // Quick intro color 1 0x30
                0x0134C8, // Quick yellow color 0x28
                0x01B4A4, // Metal yellow color 0x28
                0x00F4B6, // Bubble white & projectile color 0x30
            };

            // Colors for bosses with 1 solid color and 1 white
            List<Byte> goodSolidColors = new List<Byte>()
            {
                0x0F,0x20,0x31,0x22,0x03,0x23,0x14,0x05,0x15,0x16,0x07,0x27,0x28,0x09,0x1A,0x2A,0x0B,0x2B,0x0C,0x1C,
            };

            // Colors for bosses with a dark and a light color
            List<Byte> goodDarkColors = new List<Byte>()
            {
                0x01,0x12,0x03,0x04,0x05,0x16,0x07,0x18,0x09,0x1A,0x0B,0x0C,0x0F,0x00,
            };
            List<Byte> goodLightColors = new List<Byte>()
            {
                0x21,0x32,0x23,0x34,0x15,0x26,0x27,0x28,0x29,0x3A,0x1B,0x2C,0x10,0x20,
            };

            // Dark colors only
            List<Byte> darkOnly = new List<Byte>()
            {
                0x0F,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0A,0x0B,0x0C
            };
            // Medium colors only
            List<Byte> mediumOnly = new List<Byte>()
            {
                0x11,0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1A,0x1B,0x1C
            };
            // Light colors only
            List<Byte> lightOnly = new List<Byte>()
            {
                0x21,0x22,0x23,0x24,0x25,0x26,0x27,0x28,0x29,0x2A,0x2B,0x2C
            };

            //Int32 rColor = 0;
            Byte solidColor = 0;// = in_Context.Seed.GetNextElement(goodSolidColors);

            for (Int32 i = 0; i < solidColorSolo.Count; i++)
            {
                solidColor = in_Context.Seed.NextElement(goodSolidColors);
                in_Patch.Add(solidColorSolo[i], solidColor, String.Format("Robot Master Color"));
            }

            for (Int32 i = 0; i < solidColorPair1Main.Count; i++)
            {
                in_Patch.Add(solidColorPair1Main[i], solidColor, String.Format("Robot Master Color"));

                // Make 2nd color brighter. If already bright, make white.
                solidColor = in_Context.Seed.NextElement(goodSolidColors);
                Byte solidColorLight = (Byte)(solidColor + 16);

                if (solidColorLight > 0x3C)
                {
                    solidColorLight = 0x30;
                }

                in_Patch.Add(solidColorPair1White[i], solidColorLight, String.Format("Robot Master Color"));
            }

            for (Int32 i = 0; i < solidColorPair2Dark.Count; i++)
            {
                in_Patch.Add(solidColorPair2Dark[i], in_Context.Seed.NextElement(goodDarkColors), String.Format("Robot Master Color"));
                in_Patch.Add(solidColorPair2Light[i], in_Context.Seed.NextElement(goodLightColors), String.Format("Robot Master Color"));
            }


            //
            // Wily Machine
            //

            // choose main body color
            Byte wilyMachineBodyColorReplacement = in_Context.Seed.NextElement(darkOnly);
            Byte wilyMachineBodyColorReplacementLight;

            if (0x0F == wilyMachineBodyColorReplacement)
            {
                // Dark gray up from black
                wilyMachineBodyColorReplacementLight = 0;
            }
            else
            {
                wilyMachineBodyColorReplacementLight = (Byte)(wilyMachineBodyColorReplacement + 16);
            }

            Byte wilyMachineBodyColorReplacementLighter = (Byte)(wilyMachineBodyColorReplacementLight + 16);

            in_Patch.Add(0x02D7D5, wilyMachineBodyColorReplacementLighter, "Wily Machine Light-Gold Color"); // 0x27
            in_Patch.Add(0x02D7D2, wilyMachineBodyColorReplacementLight, "Wily Machine Gold 1 Color"); // 0x17
            in_Patch.Add(0x02D7D6, wilyMachineBodyColorReplacementLight, "Wily Machine Gold 2 Color"); // 0x17
            in_Patch.Add(0x02D7DA, wilyMachineBodyColorReplacementLight, "Wily Machine Gold 3 Color"); // 0x17
            in_Patch.Add(0x02D7D7, wilyMachineBodyColorReplacement, "Wily Machine Dark Gold 1 Color"); // 0x07
            in_Patch.Add(0x02D7DB, wilyMachineBodyColorReplacement, "Wily Machine Dark Gold 2 Color"); // 0x07

            // choose front color
            Byte wilyMachineFrontColorReplacement = in_Context.Seed.NextElement(mediumOnly);
            Byte wilyMachineFrontColorReplacementLight = (Byte)(wilyMachineFrontColorReplacement + 16);
            Byte wilyMachineFrontColorReplacementLighter = (Byte)(wilyMachineFrontColorReplacementLight + 32);

            in_Patch.Add(0x02D7D1, wilyMachineFrontColorReplacement, "Wily Machine Red 1 Color"); // 0x15
            in_Patch.Add(0x02D7D9, wilyMachineFrontColorReplacement, "Wily Machine Red 2 Color"); // 0x15
            in_Patch.Add(0x02D7D3, wilyMachineFrontColorReplacementLighter, "Wily Machine Light Red 1 Color"); // 0x15

            if (BooleanOption.True == in_Context.ActualizedBehaviorSettings?.QualityOfLifeOption.DisableFlashingEffects)
            {
                in_Patch.Add(0x2DA94, wilyMachineFrontColorReplacementLight, "Wily Machine Flash Color");
                in_Patch.Add(0x2DA21, wilyMachineFrontColorReplacementLighter, "Wily Machine Restore Color");
            }


            //
            // Dragon
            //

            // choose orange replacement
            Byte dragonOrangeColorReplacement = in_Context.Seed.NextElement(darkOnly);
            Byte dragonOrangeColorReplacementLight;

            if (0x0F == dragonOrangeColorReplacement)
            {
                // Dark gray up from black
                dragonOrangeColorReplacementLight = 0;
            }
            else
            {
                dragonOrangeColorReplacementLight = (Byte)(dragonOrangeColorReplacement + 16);
            }

            Byte dragonOrangeColorReplacementLighter = (Byte)(dragonOrangeColorReplacementLight + 16);
            Byte dragonOrangeColorReplacementLightest = (Byte)(dragonOrangeColorReplacementLighter + 16);

            in_Patch.Add(0x02CF8F, dragonOrangeColorReplacementLighter, "Dragon Orange Color 1");
            in_Patch.Add(0x02CF97, dragonOrangeColorReplacementLighter, "Dragon Orange Color 2");
            in_Patch.Add(0x0034C6, dragonOrangeColorReplacementLightest, "Dragon Orange Mouth");
            in_Patch.Add(0x0034C7, dragonOrangeColorReplacementLighter, "Dragon Orange Color 3");

            if (BooleanOption.True == in_Context.ActualizedBehaviorSettings?.QualityOfLifeOption.DisableFlashingEffects)
            {
                in_Patch.Add(0x002D1B0, dragonOrangeColorReplacementLightest, "Dragon Hit Flash Color");
                in_Patch.Add(0x002D185, dragonOrangeColorReplacementLighter, "Dragon Hit Restore Color");
            }

            // Choose green replacement
            Byte dragonGreenColorReplacement = in_Context.Seed.NextElement(darkOnly);
            Byte dragonGreenColorReplacementLight;

            if (0x0F == dragonGreenColorReplacement)
            {
                // Dark gray up from black
                dragonGreenColorReplacementLight = 0;
            }
            else
            {
                dragonGreenColorReplacementLight = (Byte)(dragonGreenColorReplacement + 16);
            }

            Byte dragonGreenColorReplacementLighter = (Byte)(dragonGreenColorReplacementLight + 16);

            in_Patch.Add(0x02CF8C, dragonGreenColorReplacementLighter, "Dragon Light Green 1");
            in_Patch.Add(0x02CF8D, dragonGreenColorReplacementLight, "Dragon Dark Green 1");
            in_Patch.Add(0x02CF98, dragonGreenColorReplacementLighter, "Dragon Light Green 2");
            in_Patch.Add(0x02CF99, dragonGreenColorReplacementLight, "Dragon Dark Green 2");
            in_Patch.Add(0x0034C8, dragonGreenColorReplacementLighter, "Dragon Light Green 3");
            in_Patch.Add(0x0034C9, dragonGreenColorReplacementLight, "Dragon Dark Green 3");
            in_Patch.Add(0x02CF91, dragonGreenColorReplacementLight, "Dragon Dark Green 4");

            // choose blue replacement
            Byte dragonBlueColorReplacement = in_Context.Seed.NextElement(darkOnly);
            Byte dragonBlueColorReplacementLight;

            if (0x0F == dragonBlueColorReplacement)
            {
                // Dark gray up from black
                dragonBlueColorReplacementLight = 0;
            }
            else
            {
                dragonBlueColorReplacementLight = (Byte)(dragonBlueColorReplacement + 16);
            }

            Byte dragonBlueColorReplacementLighter = (Byte)(dragonBlueColorReplacementLight + 16);
            in_Patch.Add(0x02CF90, dragonBlueColorReplacementLight, "Dragon Blue Color 1");


            //
            // Guts Tank
            //

            // Choose red replacement
            Byte gutstankRedColorReplacement = in_Context.Seed.NextElement(darkOnly);
            Byte gutstankRedColorReplacementLight;

            if (0x0F == gutstankRedColorReplacement)
            {
                // Dark gray up from black
                gutstankRedColorReplacementLight = 0;
            }
            else
            {
                gutstankRedColorReplacementLight = (Byte)(gutstankRedColorReplacement + 16);
            }

            Byte gutstankRedColorReplacementLighter = (Byte)(gutstankRedColorReplacementLight + 16);

            in_Patch.Add(0x00BF40, gutstankRedColorReplacement, "Guts Dark Red 1");
            in_Patch.Add(0x00BF41, gutstankRedColorReplacementLight, "Guts Light Red 1");
            in_Patch.Add(0x00BF50, gutstankRedColorReplacement, "Guts Dark Red 2");
            in_Patch.Add(0x00BF51, gutstankRedColorReplacementLight, "Guts Light Red 2");
            in_Patch.Add(0x00BF39, gutstankRedColorReplacementLight, "Guts Light Red 3");
            in_Patch.Add(0x00BF49, gutstankRedColorReplacementLight, "Guts Light Red 4");
            in_Patch.Add(0x00BF3D, gutstankRedColorReplacementLight, "Guts Light Red 5");
            in_Patch.Add(0x00BF4D, gutstankRedColorReplacementLight, "Guts Light Red 6");

            // Choose blue replacement
            Byte gutstankBlueColorReplacement = in_Context.Seed.NextElement(darkOnly);
            Byte gutstankBlueColorReplacementLight;

            if (0x0F == gutstankBlueColorReplacement)
            {
                gutstankBlueColorReplacementLight = 0;
            }
            else
            {
                gutstankBlueColorReplacementLight = (Byte)(gutstankBlueColorReplacement + 16);
            }

            Byte gutstankBlueColorReplacementLighter = (Byte)(gutstankBlueColorReplacementLight + 16);

            in_Patch.Add(0x00BF38, gutstankBlueColorReplacementLight, "Guts Blue 1");
            in_Patch.Add(0x00BF48, gutstankBlueColorReplacementLighter, "Guts Blue 2");


            // Choose orange replacement
            Byte gutstankOrangeColorReplacement = in_Context.Seed.NextElement(darkOnly);
            Byte gutstankOrangeColorReplacementLight;

            if (0x0F == gutstankOrangeColorReplacement)
            {
                // Dark gray up from black
                gutstankOrangeColorReplacementLight = 0;
            }
            else
            {
                gutstankOrangeColorReplacementLight = (Byte)(gutstankOrangeColorReplacement + 16);
            }

            Byte gutstankOrangeColorReplacementLighter = (Byte)(gutstankOrangeColorReplacementLight + 16);
            Byte gutstankOrangeColorReplacementLightest = (Byte)(gutstankOrangeColorReplacementLighter + 16);

            in_Patch.Add(0x00BF3F, gutstankOrangeColorReplacementLighter, "Guts Light Orange Color 1");
            in_Patch.Add(0x00BF4F, gutstankOrangeColorReplacementLighter, "Guts Light Orange Color 2");
            in_Patch.Add(0x00BF37, gutstankOrangeColorReplacementLighter, "Guts Light Orange Color 3");
            in_Patch.Add(0x00BF47, gutstankOrangeColorReplacementLighter, "Guts Light Orange Color 4");
            in_Patch.Add(0x00BF33, gutstankOrangeColorReplacementLighter, "Guts Light Orange Color 5");
            in_Patch.Add(0x00BF34, gutstankOrangeColorReplacementLightest, "Guts Lighter Orange Color 1");
            in_Patch.Add(0x00BF43, gutstankOrangeColorReplacementLighter, "Guts Light Orange Color 6");
            in_Patch.Add(0x00BF44, gutstankOrangeColorReplacementLightest, "Guts Lighter Orange Color 2");
            in_Patch.Add(0x00B4FE, gutstankOrangeColorReplacementLightest, "Guts Lighter Orange Color 3");
            in_Patch.Add(0x00B4FF, gutstankOrangeColorReplacementLighter, "Guts Light Orange Color 7");
            in_Patch.Add(0x03918F, gutstankOrangeColorReplacementLighter, "Guts Orange Color Stage");
            in_Patch.Add(0x039190, gutstankOrangeColorReplacementLightest, "Guts Light Orange Color Stage");


            //
            // Alien
            //

            //0x02DC74(3 bytes) Alien Body, static   0x16 0x29 0x19
            //0x02DC78(3 bytes) Alien Head, static   0x16 0x29 0x19
            // Looks good as 4 separate color groups, should be easy. Save the animations for later.
            List<Byte> mediumAndLight = new List<Byte>(mediumOnly);
            mediumAndLight.AddRange(lightOnly);

            // Alien Body Color
            Byte alienSolidBodyColor = in_Context.Seed.NextElement(mediumAndLight);
            in_Patch.Add(0x02DC74, alienSolidBodyColor, String.Format("Alien Body Solid Color"));

            Byte alienBodyColor = in_Context.Seed.NextElement(mediumOnly);
            in_Patch.Add(0x02DC76, alienBodyColor, String.Format("Alien Body Dark Color"));
            in_Patch.Add(0x02DC75, (Byte)(alienBodyColor + 16), String.Format("Alien Body Light Color"));

            // Alien Head Color
            Byte alienSolidHeadColor = in_Context.Seed.NextElement(mediumAndLight);
            in_Patch.Add(0x02DC78, alienSolidHeadColor, String.Format("Alien Head Solid Color"));

            Byte alienHeadColor = in_Context.Seed.NextElement(mediumOnly);
            in_Patch.Add(0x02DC7A, alienHeadColor, String.Format("Alien Head Dark Color"));
            in_Patch.Add(0x02DC79, (Byte)(alienHeadColor + 16), String.Format("Alien Head Light Color"));
        }

        private void RandomizeIntroColors(Patch in_Patch, RandomizationContext in_Context)
        {
            List<ColorSet> IntroColorSets = new List<ColorSet>()
            {
                new ColorSet() { // Building 1
                    addresses = new Int32[] {
                        0x36a62,                    // partial 1
                        0x36a81, 0x36a82,           // partial 2
                        0x36aa0, 0x36aa1, 0x36aa2 },// full
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // default
                            (EColorsHex)0x03,
                            (EColorsHex)0x03, (EColorsHex)0x13,
                            (EColorsHex)0x03, (EColorsHex)0x13, (EColorsHex)0x24
                        },
                        new EColorsHex[] { // gold
                            (EColorsHex)0x08,
                            (EColorsHex)0x08, (EColorsHex)0x18,
                            (EColorsHex)0x08, (EColorsHex)0x18, (EColorsHex)0x29
                        },
                        new EColorsHex[] { // blue
                            (EColorsHex)0x01,
                            (EColorsHex)0x01, (EColorsHex)0x11,
                            (EColorsHex)0x01, (EColorsHex)0x11, (EColorsHex)0x2a
                        },
                        new EColorsHex[] { // dark pink
                            (EColorsHex)0x05,
                            (EColorsHex)0x05, (EColorsHex)0x15,
                            (EColorsHex)0x05, (EColorsHex)0x15, (EColorsHex)0x2a
                        },
                        
                        new EColorsHex[] { // orange
                            (EColorsHex)0x07,
                            (EColorsHex)0x07, (EColorsHex)0x17,
                            (EColorsHex)0x07, (EColorsHex)0x17, (EColorsHex)0x28
                        },
                        new EColorsHex[] { // dark green
                            (EColorsHex)0x09,
                            (EColorsHex)0x09, (EColorsHex)0x19,
                            (EColorsHex)0x09, (EColorsHex)0x19, (EColorsHex)0x2a
                        },
                        new EColorsHex[] { // dark turquoise
                            (EColorsHex)0x0b,
                            (EColorsHex)0x0b, (EColorsHex)0x1b,
                            (EColorsHex)0x0b, (EColorsHex)0x1b, (EColorsHex)0x26
                        },
                        new EColorsHex[] { // dark cyan
                            (EColorsHex)0x0c,
                            (EColorsHex)0x0c, (EColorsHex)0x1c,
                            (EColorsHex)0x0c, (EColorsHex)0x1c, (EColorsHex)0x21
                        },
                        new EColorsHex[] { // gray
                            (EColorsHex)0x00,
                            (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x00, (EColorsHex)0x10, (EColorsHex)0x20
                        },
                    }
                },

                new ColorSet() { // Building 2
                    addresses = new Int32[] {
                        0x36a6a,                    // partial 1
                        0x36a89, 0x36a8a,           // partial 2
                        0x36aa8, 0x36aa9, 0x36aaa },// full
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // default light pink
                            (EColorsHex)0x04,
                            (EColorsHex)0x04, (EColorsHex)0x14,
                            (EColorsHex)0x04, (EColorsHex)0x14, (EColorsHex)0x27
                        },
                        new EColorsHex[] { // light green
                            (EColorsHex)0x0a,
                            (EColorsHex)0x0a, (EColorsHex)0x1b,
                            (EColorsHex)0x0a, (EColorsHex)0x1b, (EColorsHex)0x23
                        },
                        new EColorsHex[] { // orange-red
                            (EColorsHex)0x06,
                            (EColorsHex)0x06, (EColorsHex)0x17,
                            (EColorsHex)0x06, (EColorsHex)0x17, (EColorsHex)0x2a
                        },
                        new EColorsHex[] { // green-brown
                            (EColorsHex)0x08,
                            (EColorsHex)0x08, (EColorsHex)0x1a,
                            (EColorsHex)0x08, (EColorsHex)0x1a, (EColorsHex)0x21
                        },
                        new EColorsHex[] { // pink-blue
                            (EColorsHex)0x02,
                            (EColorsHex)0x02, (EColorsHex)0x14,
                            (EColorsHex)0x02, (EColorsHex)0x14, (EColorsHex)0x27
                        },
                        new EColorsHex[] { // green-blue
                            (EColorsHex)0x01,
                            (EColorsHex)0x01, (EColorsHex)0x1b,
                            (EColorsHex)0x01, (EColorsHex)0x1b, (EColorsHex)0x24
                        },
                        new EColorsHex[] { // cool-blue
                            (EColorsHex)0x0c,
                            (EColorsHex)0x0c, (EColorsHex)0x12,
                            (EColorsHex)0x0c, (EColorsHex)0x12, (EColorsHex)0x25
                        },
                        new EColorsHex[] { // gray
                            (EColorsHex)0x00,
                            (EColorsHex)0x00, (EColorsHex)0x0f,
                            (EColorsHex)0x00, (EColorsHex)0x0f, (EColorsHex)0x10
                        },
                        new EColorsHex[] { // orange stroke
                            (EColorsHex)0x27,
                            (EColorsHex)0x27, (EColorsHex)0x0f,
                            (EColorsHex)0x27, (EColorsHex)0x0f, (EColorsHex)0x10
                        },
                    }
                },
                new ColorSet() { // Mountain Sky
                    addresses = new Int32[] { 0x36aa5, 0x36aa6 },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // default blue
                            (EColorsHex)0x11, (EColorsHex)0x0C
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x12, (EColorsHex)0x01
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x13, (EColorsHex)0x02
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x14, (EColorsHex)0x03
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x15, (EColorsHex)0x04
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x16, (EColorsHex)0x05
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x17, (EColorsHex)0x06
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x18, (EColorsHex)0x07
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x19, (EColorsHex)0x08
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x1a, (EColorsHex)0x09
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x1b, (EColorsHex)0x0a
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x1c, (EColorsHex)0x0b
                        },
                        new EColorsHex[] { // 
                            (EColorsHex)0x10, (EColorsHex)0x00
                        },
                    }
                },
            };

            for (Int32 i = 0; i < IntroColorSets.Count; i++)
            {
                ColorSet set = IntroColorSets[i];
                set.RandomizeAndWrite(in_Patch, in_Context.Seed, i);
            }
        }

        private void RandomizeStageColors(Patch in_Patch, RandomizationContext in_Context)
        {
            List<ColorSet> StagesColorSets = new List<ColorSet>()
            {
                #region 01 Heatman

                new ColorSet() { // Heat | River 
                    addresses = new Int32[] {
                        0x3e1f, 0x3e20, 0x3e21, // default BG
                        0x3e3f, 0x3e4f, 0x3e5f, // animated BG
                        0x3e40, 0x3e50, 0x3e60,
                        0x3e41, 0x3e51, 0x3e61 },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            EColorsHex.Taupe,       EColorsHex.LightOrange, EColorsHex.Orange,
                            EColorsHex.Taupe,       EColorsHex.LightOrange, EColorsHex.Orange,
                            EColorsHex.LightOrange, EColorsHex.Orange,      EColorsHex.Taupe,
                            EColorsHex.Orange,      EColorsHex.Taupe,       EColorsHex.LightOrange,
                        },
                        new EColorsHex[] {
                            EColorsHex.LightGreen,  EColorsHex.Green,       EColorsHex.ForestGreen,
                            EColorsHex.LightGreen,  EColorsHex.Green,       EColorsHex.ForestGreen,
                            EColorsHex.Green,       EColorsHex.ForestGreen, EColorsHex.LightGreen,
                            EColorsHex.ForestGreen, EColorsHex.LightGreen,  EColorsHex.Green,
                        },
                        new EColorsHex[] {
                            EColorsHex.Yellow,      EColorsHex.GoldenRod,   EColorsHex.Brown,
                            EColorsHex.Yellow,      EColorsHex.GoldenRod,   EColorsHex.Brown,
                            EColorsHex.GoldenRod,   EColorsHex.Brown,       EColorsHex.Yellow,
                            EColorsHex.Brown,       EColorsHex.Yellow,      EColorsHex.GoldenRod,
                        },
                        new EColorsHex[] {
                            EColorsHex.LightPink,   EColorsHex.Magenta,     EColorsHex.DarkMagenta,
                            EColorsHex.LightPink,   EColorsHex.Magenta,     EColorsHex.DarkMagenta,
                            EColorsHex.Magenta,     EColorsHex.DarkMagenta, EColorsHex.LightPink,
                            EColorsHex.DarkMagenta, EColorsHex.LightPink,   EColorsHex.Magenta,
                        }
                    }
                },
                new ColorSet() { // Heat | Background
                    addresses = new Int32[] {
                        0x3e1b, 0x3e1c, 0x3e1d,  // default BG
                        0x3e3b, 0x3e4b, 0x3e5b,  // animated BG1
                        0x3e3c, 0x3e4c, 0x3e5c,  // animated BG2
                        0x3e3d, 0x3e4d, 0x3e5d },// animated BG3
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            EColorsHex.Orange,EColorsHex.Crimson,EColorsHex.DarkRed,
                            EColorsHex.Orange, EColorsHex.Orange,  EColorsHex.Orange,
                            EColorsHex.Crimson,EColorsHex.Crimson,  EColorsHex.Crimson,
                            EColorsHex.DarkRed,EColorsHex.DarkRed,  EColorsHex.DarkRed,
                        },
                        new EColorsHex[] {
                            EColorsHex.Magenta,EColorsHex.DarkMagenta,EColorsHex.RoyalPurple,
                            EColorsHex.Magenta,     EColorsHex.Magenta,  EColorsHex.Magenta,
                            EColorsHex.DarkMagenta, EColorsHex.DarkMagenta,  EColorsHex.DarkMagenta,
                            EColorsHex.RoyalPurple, EColorsHex.RoyalPurple,  EColorsHex.RoyalPurple,
                        },
                        new EColorsHex[] {
                            EColorsHex.Magenta,EColorsHex.DarkMagenta,EColorsHex.RoyalPurple,
                            EColorsHex.MediumGray,  EColorsHex.MediumGray,  EColorsHex.MediumGray,
                            EColorsHex.GoldenRod,   EColorsHex.GoldenRod,  EColorsHex.GoldenRod,
                            EColorsHex.Brown,       EColorsHex.Brown,  EColorsHex.Brown,
                        },
                        new EColorsHex[] {
                            EColorsHex.DarkTeal,EColorsHex.RoyalBlue,EColorsHex.Blue,
                            EColorsHex.DarkTeal,    EColorsHex.DarkTeal,  EColorsHex.DarkTeal,
                            EColorsHex.RoyalBlue,   EColorsHex.RoyalBlue,  EColorsHex.RoyalBlue,
                            EColorsHex.Blue,        EColorsHex.Blue,  EColorsHex.Blue,
                        },
                        new EColorsHex[] {
                            EColorsHex.DarkGreen,EColorsHex.Black3,EColorsHex.Kelp,
                            EColorsHex.DarkGreen,   EColorsHex.DarkGreen,  EColorsHex.DarkGreen,
                            EColorsHex.Black3,      EColorsHex.Black3,  EColorsHex.Black3,
                            EColorsHex.Kelp,        EColorsHex.Kelp,  EColorsHex.Kelp,
                        },
                    }
                },
                new ColorSet() { // Heat | Foreground
                    addresses = new Int32[] {
                        0x3e13, 0x3e14, 0x3e15,  // default BG
                        0x3e33, 0x3e43, 0x3e53,  // animated BG1
                        0x3e34, 0x3e44, 0x3e54,  // animated BG2
                        0x3e35, 0x3e45, 0x3e55 },// animated BG3
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            EColorsHex.Taupe,       EColorsHex.LightOrange,EColorsHex.VioletRed,
                            EColorsHex.Taupe,       EColorsHex.Taupe,  EColorsHex.Taupe,
                            EColorsHex.LightOrange, EColorsHex.LightOrange,  EColorsHex.LightOrange,
                            EColorsHex.VioletRed,   EColorsHex.VioletRed,  EColorsHex.VioletRed,
                        },
                        new EColorsHex[] {
                            EColorsHex.PastelPink,EColorsHex.LightPink,EColorsHex.Purple,
                            EColorsHex.PastelPink,  EColorsHex.PastelPink,  EColorsHex.PastelPink,
                            EColorsHex.LightPink,   EColorsHex.LightPink,  EColorsHex.LightPink,
                            EColorsHex.Purple,      EColorsHex.Purple,  EColorsHex.Purple,
                        },
                        new EColorsHex[] {
                            EColorsHex.PastelGreen,EColorsHex.LightGreen,EColorsHex.Grass,
                            EColorsHex.PastelGreen, EColorsHex.PastelGreen,  EColorsHex.PastelGreen,
                            EColorsHex.LightGreen,  EColorsHex.LightGreen,  EColorsHex.LightGreen,
                            EColorsHex.Grass,       EColorsHex.Grass,  EColorsHex.Grass,
                        },
                        new EColorsHex[] {
                            EColorsHex.PaleBlue,EColorsHex.SoftBlue,EColorsHex.MediumBlue,
                            EColorsHex.PaleBlue,    EColorsHex.PaleBlue,  EColorsHex.PaleBlue,
                            EColorsHex.SoftBlue,    EColorsHex.SoftBlue,  EColorsHex.SoftBlue,
                            EColorsHex.MediumBlue,  EColorsHex.MediumBlue,  EColorsHex.MediumBlue,
                        },
                    }
                },
                new ColorSet() { // Heat | Foreground2
                    addresses = new Int32[] {
                        0x3e17, 0x3e18, 0x3e19,  // default BG
                        0x3e37, 0x3e47, 0x3e57,  // animated BG1
                        0x3e38, 0x3e48, 0x3e58,  // animated BG2
                        0x3e39, 0x3e49, 0x3e59 },// animated BG3
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.LightGray,EColorsHex.Gray,
                            EColorsHex.White,      EColorsHex.White,  EColorsHex.White,
                            EColorsHex.LightGray,  EColorsHex.LightGray,  EColorsHex.LightGray,
                            EColorsHex.Gray,       EColorsHex.Gray,  EColorsHex.Gray,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.Beige,EColorsHex.YellowOrange,
                            EColorsHex.White,          EColorsHex.White,  EColorsHex.White,
                            EColorsHex.Beige,          EColorsHex.Beige,  EColorsHex.Beige,
                            EColorsHex.YellowOrange,   EColorsHex.YellowOrange,  EColorsHex.YellowOrange,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.PastelBlue,EColorsHex.LightBlue,
                            EColorsHex.White,      EColorsHex.White,  EColorsHex.White,
                            EColorsHex.PastelBlue, EColorsHex.PastelBlue,  EColorsHex.PastelBlue,
                            EColorsHex.LightBlue,  EColorsHex.LightBlue,  EColorsHex.LightBlue,
                        },
                        new EColorsHex[] {
                            EColorsHex.LightGray,EColorsHex.Gray,EColorsHex.Brown,
                            EColorsHex.LightGray,  EColorsHex.LightGray,  EColorsHex.LightGray,
                            EColorsHex.Gray,       EColorsHex.Gray,  EColorsHex.Gray,
                            EColorsHex.Brown,      EColorsHex.Brown,  EColorsHex.Brown,
                        },
                    }
                },

                #endregion

                #region 01 Wily 1

                new ColorSet() { // Wily 1 | Solid Background and Clouds
                    addresses = new Int32[] {0x3f15, 0x3f17, 0x3f18, 0x3f19,},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Default Dark Cyan
                        new EColorsHex[] {(EColorsHex)0x0C,(EColorsHex)0x1C,(EColorsHex)0x0C,(EColorsHex)0x0C},
                        new EColorsHex[] {(EColorsHex)0x0b,(EColorsHex)0x1b,(EColorsHex)0x0b,(EColorsHex)0x0b},
                        new EColorsHex[] {(EColorsHex)0x09,(EColorsHex)0x19,(EColorsHex)0x09,(EColorsHex)0x09},
                        new EColorsHex[] {(EColorsHex)0x08,(EColorsHex)0x18,(EColorsHex)0x08,(EColorsHex)0x08},
                        new EColorsHex[] {(EColorsHex)0x07,(EColorsHex)0x17,(EColorsHex)0x07,(EColorsHex)0x07},
                        new EColorsHex[] {(EColorsHex)0x05,(EColorsHex)0x15,(EColorsHex)0x05,(EColorsHex)0x05},
                        new EColorsHex[] {(EColorsHex)0x04,(EColorsHex)0x14,(EColorsHex)0x04,(EColorsHex)0x04},
                        new EColorsHex[] {(EColorsHex)0x03,(EColorsHex)0x13,(EColorsHex)0x03,(EColorsHex)0x03},
                        new EColorsHex[] {(EColorsHex)0x02,(EColorsHex)0x12,(EColorsHex)0x02,(EColorsHex)0x02},
                        new EColorsHex[] {(EColorsHex)0x0f,(EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x0f},
                    }
                },

                new ColorSet() { // Wily 1 | Building Exterior Walls
                    addresses = new Int32[] {0x3f13, 0x3f14,},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Default Gray
                        new EColorsHex[] {(EColorsHex)0x20,(EColorsHex)0x10},
                        new EColorsHex[] {(EColorsHex)0x21,(EColorsHex)0x11,},
                        new EColorsHex[] {(EColorsHex)0x23,(EColorsHex)0x13,},
                        new EColorsHex[] {(EColorsHex)0x26,(EColorsHex)0x16,},
                        new EColorsHex[] {(EColorsHex)0x27,(EColorsHex)0x17,},
                        new EColorsHex[] {(EColorsHex)0x28,(EColorsHex)0x18,},
                        new EColorsHex[] {(EColorsHex)0x2a,(EColorsHex)0x1a,},
                        new EColorsHex[] {(EColorsHex)0x2c,(EColorsHex)0x1c,},

                    }
                },

                new ColorSet() { // Wily 1 | Ground and Building Interior Walls
                    addresses = new Int32[] {0x3f1b, 0x3f1c, 0x3f1d,},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Default Gold3
                        new EColorsHex[] {(EColorsHex)0x38,(EColorsHex)0x27,(EColorsHex)0x07},
                        new EColorsHex[] {(EColorsHex)0x37,(EColorsHex)0x26,(EColorsHex)0x06},
                        new EColorsHex[] {(EColorsHex)0x36,(EColorsHex)0x25,(EColorsHex)0x05},
                        new EColorsHex[] {(EColorsHex)0x34,(EColorsHex)0x23,(EColorsHex)0x03,},
                        new EColorsHex[] {(EColorsHex)0x33,(EColorsHex)0x22,(EColorsHex)0x02,},
                        new EColorsHex[] {(EColorsHex)0x32,(EColorsHex)0x21,(EColorsHex)0x01,},
                        new EColorsHex[] {(EColorsHex)0x31,(EColorsHex)0x2c,(EColorsHex)0x0c,},
                        new EColorsHex[] {(EColorsHex)0x3c,(EColorsHex)0x2b,(EColorsHex)0x0b,},
                        new EColorsHex[] {(EColorsHex)0x3b,(EColorsHex)0x2a,(EColorsHex)0x0a,},
                        new EColorsHex[] {(EColorsHex)0x39,(EColorsHex)0x28,(EColorsHex)0x08,},

                    }
                },

                new ColorSet() { // Wily 1 | Building Background
                    addresses = new Int32[] {0x3f1f, 0x3f20, 0x3f21,},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Default Teal
                        new EColorsHex[] {(EColorsHex)0x2c,(EColorsHex)0x1b,(EColorsHex)0x0c},
                        new EColorsHex[] {(EColorsHex)0x2a,(EColorsHex)0x19,(EColorsHex)0x0a},
                        new EColorsHex[] {(EColorsHex)0x29,(EColorsHex)0x18,(EColorsHex)0x09},
                        new EColorsHex[] {(EColorsHex)0x27,(EColorsHex)0x16,(EColorsHex)0x07},
                        new EColorsHex[] {(EColorsHex)0x24,(EColorsHex)0x13,(EColorsHex)0x04},
                        new EColorsHex[] {(EColorsHex)0x23,(EColorsHex)0x12,(EColorsHex)0x03},
                        new EColorsHex[] {(EColorsHex)0x22,(EColorsHex)0x11,(EColorsHex)0x02},
                        new EColorsHex[] {(EColorsHex)0x21,(EColorsHex)0x1c,(EColorsHex)0x01},
                    }
                },

                #endregion

                #region 02 Airman

                new ColorSet() { // Air | Platforms
                    addresses = new Int32[] {
                        0x7e17, 0x7e18, 0x7e19,
                        0x7e37, 0x7e47, 0x7e57, 0x7e67,
                        0x7e38, 0x7e48, 0x7e58, 0x7e68,
                        0x7e39, 0x7e49, 0x7e59, 0x7e69 },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.VioletRed,EColorsHex.Black2,
                            EColorsHex.White,      EColorsHex.White,  EColorsHex.White,  EColorsHex.White,
                            EColorsHex.VioletRed,  EColorsHex.VioletRed,  EColorsHex.VioletRed,  EColorsHex.VioletRed,
                            EColorsHex.Black2,     EColorsHex.Black2,  EColorsHex.Black2,  EColorsHex.Black2,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.Orange,EColorsHex.Black2,
                            EColorsHex.White,      EColorsHex.White,  EColorsHex.White,  EColorsHex.White,
                            EColorsHex.Orange,     EColorsHex.Orange,  EColorsHex.Orange,  EColorsHex.Orange,
                            EColorsHex.Black2,     EColorsHex.Black2,  EColorsHex.Black2,  EColorsHex.Black2,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.Yellow,EColorsHex.Black2,
                            EColorsHex.White,      EColorsHex.White,  EColorsHex.White,  EColorsHex.White,
                            EColorsHex.Yellow,     EColorsHex.Yellow,  EColorsHex.Yellow,  EColorsHex.Yellow,
                            EColorsHex.Black2,     EColorsHex.Black2,  EColorsHex.Black2,  EColorsHex.Black2,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.Grass,EColorsHex.Black2,
                            EColorsHex.White,      EColorsHex.White,  EColorsHex.White,  EColorsHex.White,
                            EColorsHex.Grass,      EColorsHex.Grass,  EColorsHex.Grass,  EColorsHex.Grass,
                            EColorsHex.Black2,     EColorsHex.Black2,  EColorsHex.Black2,  EColorsHex.Black2,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.SoftBlue,EColorsHex.Black2,
                            EColorsHex.White,      EColorsHex.White,  EColorsHex.White,  EColorsHex.White,
                            EColorsHex.SoftBlue,   EColorsHex.SoftBlue,  EColorsHex.SoftBlue,  EColorsHex.SoftBlue,
                            EColorsHex.Black2,     EColorsHex.Black2,  EColorsHex.Black2,  EColorsHex.Black2,
                        },
                    }
                },
                new ColorSet() { // Air | Clouds 
                    addresses = new Int32[] {
                        0x7e13, 0x7e14, 0x7e15,
                        0x7e33, 0x7e43, 0x7e53, 0x7e63,
                        0x7e34, 0x7e44, 0x7e54, 0x7e64,
                        0x7e35, 0x7e45, 0x7e55, 0x7e65 },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            EColorsHex.LightBlue,  EColorsHex.PastelBlue,  EColorsHex.White,
                            EColorsHex.LightBlue,  EColorsHex.PastelBlue,  EColorsHex.White,  EColorsHex.PastelBlue,
                            EColorsHex.PastelBlue, EColorsHex.White,       EColorsHex.White,  EColorsHex.White,
                            EColorsHex.White,      EColorsHex.White,       EColorsHex.White,  EColorsHex.White,
                        },
                        new EColorsHex[] {
                            EColorsHex.LightGray,  EColorsHex.LightGray,    EColorsHex.LightGray,
                            EColorsHex.LightGray,  EColorsHex.Gray,         EColorsHex.DarkRed,     EColorsHex.Gray,
                            EColorsHex.LightGray,  EColorsHex.LightGray,    EColorsHex.Gray,        EColorsHex.LightGray,
                            EColorsHex.LightGray,  EColorsHex.LightGray,    EColorsHex.LightGray,   EColorsHex.LightGray,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x04, (EColorsHex)0x00,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x02, (EColorsHex)0x00,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x0c, (EColorsHex)0x00,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x0b, (EColorsHex)0x00,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x0a, (EColorsHex)0x00,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x08, (EColorsHex)0x00,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x06, (EColorsHex)0x00,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10, (EColorsHex)0x10,
                        },
                    }
                },
                new ColorSet() { // Air | Sky 
                    addresses = new Int32[] { 0x7e22 },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {  EColorsHex.LightBlue },
                        new EColorsHex[] {  EColorsHex.LightPurple },
                        new EColorsHex[] {  EColorsHex.LightOrange },
                        new EColorsHex[] {  EColorsHex.YellowOrange },
                        new EColorsHex[] {  EColorsHex.Yellow },
                        new EColorsHex[] {  EColorsHex.Lime },
                        new EColorsHex[] {  EColorsHex.RoyalBlue },
                        new EColorsHex[] {  EColorsHex.RoyalBlue },
                        new EColorsHex[] {  EColorsHex.DarkGreen },
                        new EColorsHex[] {  EColorsHex.Black3 },
                    }
                },

                #endregion

                #region 02 Wily 2

                new ColorSet() { // Wily 2 | Ground
                    addresses = new Int32[] {
                        0x7f13, 0x7f14, 0x7f15,
                        0x7f33, 0x7f34, 0x7f35,
                        0x7f43, 0x7f44, 0x7f45,
                        0x7f53, 0x7f54, 0x7f55,
                        0x7f63, 0x7f64, 0x7f65,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x10,(EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x10,(EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x10,(EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x10,(EColorsHex)0x18,(EColorsHex)0x08,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x10,(EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x10,(EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x10,(EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x10,(EColorsHex)0x17,(EColorsHex)0x07,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x16,(EColorsHex)0x06,
                            (EColorsHex)0x10,(EColorsHex)0x16,(EColorsHex)0x06,
                            (EColorsHex)0x10,(EColorsHex)0x16,(EColorsHex)0x06,
                            (EColorsHex)0x10,(EColorsHex)0x16,(EColorsHex)0x06,
                            (EColorsHex)0x10,(EColorsHex)0x16,(EColorsHex)0x06,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x14,(EColorsHex)0x04,
                            (EColorsHex)0x10,(EColorsHex)0x14,(EColorsHex)0x04,
                            (EColorsHex)0x10,(EColorsHex)0x14,(EColorsHex)0x04,
                            (EColorsHex)0x10,(EColorsHex)0x14,(EColorsHex)0x04,
                            (EColorsHex)0x10,(EColorsHex)0x14,(EColorsHex)0x04,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x10,(EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x10,(EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x10,(EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x10,(EColorsHex)0x13,(EColorsHex)0x03,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x10,(EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x10,(EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x10,(EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x10,(EColorsHex)0x12,(EColorsHex)0x02,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x11,(EColorsHex)0x01,
                            (EColorsHex)0x10,(EColorsHex)0x11,(EColorsHex)0x01,
                            (EColorsHex)0x10,(EColorsHex)0x11,(EColorsHex)0x01,
                            (EColorsHex)0x10,(EColorsHex)0x11,(EColorsHex)0x01,
                            (EColorsHex)0x10,(EColorsHex)0x11,(EColorsHex)0x01,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x10,(EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x10,(EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x10,(EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x10,(EColorsHex)0x1c,(EColorsHex)0x0c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x10,(EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x10,(EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x10,(EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x10,(EColorsHex)0x1b,(EColorsHex)0x0b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x10,(EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x10,(EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x10,(EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x10,(EColorsHex)0x19,(EColorsHex)0x09,
                        },
                    }
                },
                
                new ColorSet() { // Wily 2 | Background
                    addresses = new Int32[] { 0x7f18, 0x7f38, 0x7f48, 0x7f58, 0x7f68, },
                    ColorBytes = new List<EColorsHex[]>() {
                        // Wood | Leaves | Default
                        new EColorsHex[] {(EColorsHex)0x07,(EColorsHex)0x07, (EColorsHex)0x07, (EColorsHex)0x07, (EColorsHex)0x07,},
                        new EColorsHex[] {(EColorsHex)0x04,(EColorsHex)0x04, (EColorsHex)0x04, (EColorsHex)0x04, (EColorsHex)0x04, },
                        new EColorsHex[] {(EColorsHex)0x02,(EColorsHex)0x02, (EColorsHex)0x02, (EColorsHex)0x02, (EColorsHex)0x02, },
                        new EColorsHex[] {(EColorsHex)0x00,(EColorsHex)0x00, (EColorsHex)0x00, (EColorsHex)0x00, (EColorsHex)0x00, },
                        new EColorsHex[] {(EColorsHex)0x0c,(EColorsHex)0x0c, (EColorsHex)0x0c, (EColorsHex)0x0c, (EColorsHex)0x0c, },
                        new EColorsHex[] {(EColorsHex)0x0b,(EColorsHex)0x0b, (EColorsHex)0x0b, (EColorsHex)0x0b, (EColorsHex)0x0b, },
                        new EColorsHex[] {(EColorsHex)0x0b,(EColorsHex)0x09, (EColorsHex)0x09, (EColorsHex)0x09, (EColorsHex)0x09, },
                        new EColorsHex[] {(EColorsHex)0x18,(EColorsHex)0x18, (EColorsHex)0x18, (EColorsHex)0x18, (EColorsHex)0x18, },
                    }
                },

                new ColorSet() { // Wily 2 | Fan
                    addresses = new Int32[] {
                        0x7f1f, 0x7f20,
                        0x7f3f, 0x7f40,
                        0x7f50, 0x7f51,
                        0x7f5f, 0x7f61,
                        0x7f6f, 0x7f70,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x31, (EColorsHex)0x31,
                            (EColorsHex)0x31, (EColorsHex)0x31,
                            (EColorsHex)0x31, (EColorsHex)0x31,
                            (EColorsHex)0x31, (EColorsHex)0x31,
                            (EColorsHex)0x31, (EColorsHex)0x31,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x2b, (EColorsHex)0x2b,
                            (EColorsHex)0x2b, (EColorsHex)0x2b,
                            (EColorsHex)0x2b, (EColorsHex)0x2b,
                            (EColorsHex)0x2b, (EColorsHex)0x2b,
                            (EColorsHex)0x2b, (EColorsHex)0x2b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x2a, (EColorsHex)0x2a,
                            (EColorsHex)0x2a, (EColorsHex)0x2a,
                            (EColorsHex)0x2a, (EColorsHex)0x2a,
                            (EColorsHex)0x2a, (EColorsHex)0x2a,
                            (EColorsHex)0x2a, (EColorsHex)0x2a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x38, (EColorsHex)0x38,
                            (EColorsHex)0x38, (EColorsHex)0x38,
                            (EColorsHex)0x38, (EColorsHex)0x38,
                            (EColorsHex)0x38, (EColorsHex)0x38,
                            (EColorsHex)0x38, (EColorsHex)0x38,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x26, (EColorsHex)0x26,
                            (EColorsHex)0x26, (EColorsHex)0x26,
                            (EColorsHex)0x26, (EColorsHex)0x26,
                            (EColorsHex)0x26, (EColorsHex)0x26,
                            (EColorsHex)0x26, (EColorsHex)0x26,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x24, (EColorsHex)0x24,
                            (EColorsHex)0x24, (EColorsHex)0x24,
                            (EColorsHex)0x24, (EColorsHex)0x24,
                            (EColorsHex)0x24, (EColorsHex)0x24,
                            (EColorsHex)0x24, (EColorsHex)0x24,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x22, (EColorsHex)0x22,
                            (EColorsHex)0x22, (EColorsHex)0x22,
                            (EColorsHex)0x22, (EColorsHex)0x22,
                            (EColorsHex)0x22, (EColorsHex)0x22,
                            (EColorsHex)0x22, (EColorsHex)0x22,
                        },
                    }
                },

                new ColorSet() { // Wily 2 | Boss Room
                    addresses = new Int32[] {
                        0x7f1b, 0x7f1c, 0x7f1d,
                        0x7f3b, 0x7f3c, 0x7f3d,
                        0x7f4b, 0x7f4c, 0x7f4d,
                        0x7f5b, 0x7f5c, 0x7f5d,
                        0x7f6b, 0x7f6c, 0x7f6d,},
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x34,(EColorsHex)0x15, (EColorsHex)0x05,
                            (EColorsHex)0x34,(EColorsHex)0x15, (EColorsHex)0x05,
                            (EColorsHex)0x34,(EColorsHex)0x15, (EColorsHex)0x05,
                            (EColorsHex)0x34,(EColorsHex)0x15, (EColorsHex)0x05,
                            (EColorsHex)0x34,(EColorsHex)0x15, (EColorsHex)0x05,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x32,(EColorsHex)0x13, (EColorsHex)0x03,
                            (EColorsHex)0x32,(EColorsHex)0x13, (EColorsHex)0x03,
                            (EColorsHex)0x32,(EColorsHex)0x13, (EColorsHex)0x03,
                            (EColorsHex)0x32,(EColorsHex)0x13, (EColorsHex)0x03,
                            (EColorsHex)0x32,(EColorsHex)0x13, (EColorsHex)0x03,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3c,(EColorsHex)0x11, (EColorsHex)0x01,
                            (EColorsHex)0x3c,(EColorsHex)0x11, (EColorsHex)0x01,
                            (EColorsHex)0x3c,(EColorsHex)0x11, (EColorsHex)0x01,
                            (EColorsHex)0x3c,(EColorsHex)0x11, (EColorsHex)0x01,
                            (EColorsHex)0x3c,(EColorsHex)0x11, (EColorsHex)0x01,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3b,(EColorsHex)0x1c, (EColorsHex)0x0c,
                            (EColorsHex)0x3b,(EColorsHex)0x1c, (EColorsHex)0x0c,
                            (EColorsHex)0x3b,(EColorsHex)0x1c, (EColorsHex)0x0c,
                            (EColorsHex)0x3b,(EColorsHex)0x1c, (EColorsHex)0x0c,
                            (EColorsHex)0x3b,(EColorsHex)0x1c, (EColorsHex)0x0c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x39,(EColorsHex)0x1a, (EColorsHex)0x0a,
                            (EColorsHex)0x39,(EColorsHex)0x1a, (EColorsHex)0x0a,
                            (EColorsHex)0x39,(EColorsHex)0x1a, (EColorsHex)0x0a,
                            (EColorsHex)0x39,(EColorsHex)0x1a, (EColorsHex)0x0a,
                            (EColorsHex)0x39,(EColorsHex)0x1a, (EColorsHex)0x0a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x37,(EColorsHex)0x18, (EColorsHex)0x08,
                            (EColorsHex)0x37,(EColorsHex)0x18, (EColorsHex)0x08,
                            (EColorsHex)0x37,(EColorsHex)0x18, (EColorsHex)0x08,
                            (EColorsHex)0x37,(EColorsHex)0x18, (EColorsHex)0x08,
                            (EColorsHex)0x37,(EColorsHex)0x18, (EColorsHex)0x08,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x36,(EColorsHex)0x17, (EColorsHex)0x07,
                            (EColorsHex)0x36,(EColorsHex)0x17, (EColorsHex)0x07,
                            (EColorsHex)0x36,(EColorsHex)0x17, (EColorsHex)0x07,
                            (EColorsHex)0x36,(EColorsHex)0x17, (EColorsHex)0x07,
                            (EColorsHex)0x36,(EColorsHex)0x17, (EColorsHex)0x07,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x10,(EColorsHex)0x00, (EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00, (EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00, (EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00, (EColorsHex)0x0f,
                            (EColorsHex)0x10,(EColorsHex)0x00, (EColorsHex)0x0f,
                        },
                    }
                },

                #endregion

                #region 03 Woodman

                new ColorSet() {
                    addresses = new Int32[] { 0xbe13, 0xbe14, },
                    ColorBytes = new List<EColorsHex[]>() {
                        // Wood | Leaves | Default
                        new EColorsHex[] {  EColorsHex.Lemon, EColorsHex.Grass,},
                        // Wood | Leaves | Blue
                        new EColorsHex[] {  EColorsHex.MediumBlue, EColorsHex.RoyalBlue,},
                        // Wood | Leaves | Red
                        new EColorsHex[] {  EColorsHex.Orange, EColorsHex.Red,},
                        new EColorsHex[] {  (EColorsHex)0x28, (EColorsHex)0x18, },
                        new EColorsHex[] {  (EColorsHex)0x27, (EColorsHex)0x17, },
                        new EColorsHex[] {  (EColorsHex)0x26, (EColorsHex)0x16, },
                        new EColorsHex[] {  (EColorsHex)0x25, (EColorsHex)0x15, },
                        new EColorsHex[] {  (EColorsHex)0x24, (EColorsHex)0x14, },
                        new EColorsHex[] {  (EColorsHex)0x23, (EColorsHex)0x13, },
                        new EColorsHex[] {  (EColorsHex)0x22, (EColorsHex)0x12, },
                        new EColorsHex[] {  (EColorsHex)0x21, (EColorsHex)0x11, },
                        new EColorsHex[] {  (EColorsHex)0x2c, (EColorsHex)0x1c, },
                        new EColorsHex[] {  (EColorsHex)0x2b, (EColorsHex)0x1b, },
                    }
                },

                new ColorSet() {
                    addresses = new Int32[] { 0xbe17, 0xbe18, },
                    ColorBytes = new List<EColorsHex[]>() {
                        // Wood | Trunk | Default
                        new EColorsHex[] {  EColorsHex.Yellow,  EColorsHex.GoldenRod },
                        // Wood | Trunk | Purple
                        new EColorsHex[] {  EColorsHex.LightPurple,  EColorsHex.Purple },
                        // Wood | Trunk | Pink
                        new EColorsHex[] {  EColorsHex.LightVioletRed,  EColorsHex.VioletRed },
                        // Wood | Trunk | Orange
                        new EColorsHex[] {  EColorsHex.YellowOrange,  EColorsHex.Tangerine },
                        // Wood | Trunk | Green
                        new EColorsHex[] {  EColorsHex.LightGreen,  EColorsHex.Green },
                        // Wood | Trunk | Teal
                        new EColorsHex[] {  EColorsHex.LightCyan,  EColorsHex.Teal },
                    }
                },

                new ColorSet() {
                    addresses = new Int32[] { 0xbe1b,0xbe1c,0xbe1d,},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Wood | Floor | Default
                        new EColorsHex[] {  EColorsHex.YellowOrange, EColorsHex.Tangerine, EColorsHex.DarkRed,},
                        // Wood | Floor | Yellow
                        new EColorsHex[] {  EColorsHex.Yellow, EColorsHex.GoldenRod, EColorsHex.Brown,},
                        // Wood | Floor | Green
                        new EColorsHex[] {  EColorsHex.LightGreen, EColorsHex.Green, EColorsHex.ForestGreen,},
                        // Wood | Floor | Teal
                        new EColorsHex[] {  EColorsHex.LightCyan, EColorsHex.Teal, EColorsHex.DarkTeal,},
                        // Wood | Floor | Purple
                        new EColorsHex[] {  EColorsHex.LightPurple, EColorsHex.Purple, EColorsHex.RoyalPurple,},
                        // Wood | Floor | Gray
                        new EColorsHex[] {  EColorsHex.NearWhite, EColorsHex.LightGray, EColorsHex.Black2,},
                    }
                },

                new ColorSet() {
                    addresses = new Int32[] { 0xbe1f, 0x03a118, 0x03a11b, },
                    ColorBytes = new List<EColorsHex[]>() {
                        // Wood | UndergroundBG | Default
                        new EColorsHex[] {  EColorsHex.Brown,  EColorsHex.Brown,  EColorsHex.Brown },
                        // Wood | UndergroundBG | Dark Purple
                        new EColorsHex[] {  EColorsHex.DarkMagenta,  EColorsHex.DarkMagenta,  EColorsHex.DarkMagenta },
                        // Wood | UndergroundBG | Dark Red
                        new EColorsHex[] {  EColorsHex.Crimson,  EColorsHex.Crimson,  EColorsHex.Crimson },
                        // Wood | UndergroundBG | Dark Green
                        new EColorsHex[] {  EColorsHex.Kelp,  EColorsHex.Kelp,  EColorsHex.Kelp },
                        // Wood | UndergroundBG | Dark Teal
                        new EColorsHex[] {  EColorsHex.DarkGreen,  EColorsHex.DarkGreen,  EColorsHex.DarkGreen },
                        // Wood | UndergroundBG | Dark Blue1
                        new EColorsHex[] {  EColorsHex.DarkTeal, EColorsHex.DarkTeal,  EColorsHex.DarkTeal },
                        // Wood | UndergroundBG | Dark Blue2
                        new EColorsHex[] {  EColorsHex.RoyalBlue,  EColorsHex.RoyalBlue,  EColorsHex.RoyalBlue },
                    }
                },

                new ColorSet() {
                    addresses = new Int32[] { 0xbe15,0xbe19,},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Wood | SkyBG | Default
                        new EColorsHex[] {  EColorsHex.LightCyan,  EColorsHex.LightCyan },
                        // Wood | SkyBG | Light Green
                        new EColorsHex[] {  EColorsHex.LightGreen , EColorsHex.LightGreen },
                        // Wood | SkyBG | Blue
                        new EColorsHex[] {  EColorsHex.Blue,  EColorsHex.Blue },
                        // Wood | SkyBG | Dark Purple
                        new EColorsHex[] {  EColorsHex.RoyalPurple,  EColorsHex.RoyalPurple },
                        // Wood | SkyBG | Dark Red
                        new EColorsHex[] {  EColorsHex.Crimson,  EColorsHex.Crimson },
                        // Wood | SkyBG | Light Yellow
                        new EColorsHex[] {  EColorsHex.PastelYellow,  EColorsHex.PastelYellow },
                        // Wood | SkyBG | Black
                        new EColorsHex[] {  EColorsHex.Black2,  EColorsHex.Black2 },
                    }
                },

                #endregion

                #region 03 Wily 3

                new ColorSet() { // Wily 3 | Underwater Walls
                    addresses = new Int32[] { 0xbf13, 0xbf14, 0xbf15},
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x28,(EColorsHex)0x17,(EColorsHex)0x18,},
                        new EColorsHex[] {(EColorsHex)0x27,(EColorsHex)0x16,(EColorsHex)0x17,},
                        new EColorsHex[] {(EColorsHex)0x25,(EColorsHex)0x14,(EColorsHex)0x15,},
                        new EColorsHex[] {(EColorsHex)0x24,(EColorsHex)0x13,(EColorsHex)0x14,},
                        new EColorsHex[] {(EColorsHex)0x23,(EColorsHex)0x12,(EColorsHex)0x13,},
                        new EColorsHex[] {(EColorsHex)0x22,(EColorsHex)0x11,(EColorsHex)0x12,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,},
                        new EColorsHex[] {(EColorsHex)0x21,(EColorsHex)0x1c,(EColorsHex)0x11,},
                        new EColorsHex[] {(EColorsHex)0x2c,(EColorsHex)0x1b,(EColorsHex)0x1c,},
                        new EColorsHex[] {(EColorsHex)0x2a,(EColorsHex)0x19,(EColorsHex)0x1a,},
                        new EColorsHex[] {(EColorsHex)0x29,(EColorsHex)0x18,(EColorsHex)0x19,},
                    }
                },

                new ColorSet() { // Wily 3 | Walls
                    addresses = new Int32[] { 0xbf17, 0xbf18, 0xbf19},
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x29,(EColorsHex)0x18,(EColorsHex)0x07,},
                        new EColorsHex[] {(EColorsHex)0x28,(EColorsHex)0x17,(EColorsHex)0x06,},
                        new EColorsHex[] {(EColorsHex)0x27,(EColorsHex)0x16,(EColorsHex)0x05,},
                        new EColorsHex[] {(EColorsHex)0x25,(EColorsHex)0x14,(EColorsHex)0x03,},
                        new EColorsHex[] {(EColorsHex)0x24,(EColorsHex)0x13,(EColorsHex)0x02,},
                        new EColorsHex[] {(EColorsHex)0x23,(EColorsHex)0x12,(EColorsHex)0x01,},
                        new EColorsHex[] {(EColorsHex)0x22,(EColorsHex)0x11,(EColorsHex)0x0c,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,},
                        new EColorsHex[] {(EColorsHex)0x21,(EColorsHex)0x1c,(EColorsHex)0x0b,},
                        new EColorsHex[] {(EColorsHex)0x2c,(EColorsHex)0x1b,(EColorsHex)0x0a,},
                        new EColorsHex[] {(EColorsHex)0x2a,(EColorsHex)0x19,(EColorsHex)0x08,},
                    }
                },

                new ColorSet() { // Wily 3 | Water
                    addresses = new Int32[] { 0xbf1c, 0xbf1d,},
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x28,(EColorsHex)0x18,},
                        new EColorsHex[] {(EColorsHex)0x27,(EColorsHex)0x17,},
                        new EColorsHex[] {(EColorsHex)0x26,(EColorsHex)0x16,},
                        new EColorsHex[] {(EColorsHex)0x25,(EColorsHex)0x15,},
                        new EColorsHex[] {(EColorsHex)0x23,(EColorsHex)0x13,},
                        new EColorsHex[] {(EColorsHex)0x22,(EColorsHex)0x12,},
                        new EColorsHex[] {(EColorsHex)0x21,(EColorsHex)0x11,},
                        new EColorsHex[] {(EColorsHex)0x2c,(EColorsHex)0x1c,},
                        new EColorsHex[] {(EColorsHex)0x2b,(EColorsHex)0x1b,},
                        new EColorsHex[] {(EColorsHex)0x2a,(EColorsHex)0x1a,},
                        new EColorsHex[] {(EColorsHex)0x0f,(EColorsHex)0x00,},
                    }
                },

                new ColorSet() { // Wily 3 | Background
                    addresses = new Int32[] { 0xbf1f, 0xbf20, 0xbf21},
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x0a,(EColorsHex)0x08,(EColorsHex)0x0b,},
                        new EColorsHex[] {(EColorsHex)0x08,(EColorsHex)0x06,(EColorsHex)0x09,},
                        new EColorsHex[] {(EColorsHex)0x06,(EColorsHex)0x04,(EColorsHex)0x07,},
                        new EColorsHex[] {(EColorsHex)0x04,(EColorsHex)0x02,(EColorsHex)0x05,},
                        new EColorsHex[] {(EColorsHex)0x02,(EColorsHex)0x0c,(EColorsHex)0x03,},
                        new EColorsHex[] {(EColorsHex)0x01,(EColorsHex)0x0b,(EColorsHex)0x02,},
                        new EColorsHex[] {(EColorsHex)0x0c,(EColorsHex)0x0a,(EColorsHex)0x01,},
                        new EColorsHex[] {(EColorsHex)0x0f,(EColorsHex)0x00,(EColorsHex)0x10,},
                    }
                },

                #endregion

                #region 04 Bubbleman

                new ColorSet() { // Bubble | White Floors
                    addresses = new Int32[] {
                        0xfe17,0xfe18, // default BG
                        0xfe37,0xfe38, // frame 1
                        0xfe47,0xfe48, // frame 2
                        0xfe57,0xfe58, // frame 3
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // original colors
                            (EColorsHex)0x20, (EColorsHex)0x10,
                            (EColorsHex)0x20, (EColorsHex)0x10,
                            (EColorsHex)0x20, (EColorsHex)0x10,
                            (EColorsHex)0x20, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x31, (EColorsHex)0x21,
                            (EColorsHex)0x31, (EColorsHex)0x21,
                            (EColorsHex)0x31, (EColorsHex)0x21,
                            (EColorsHex)0x31, (EColorsHex)0x21,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x32, (EColorsHex)0x22,
                            (EColorsHex)0x32, (EColorsHex)0x22,
                            (EColorsHex)0x32, (EColorsHex)0x22,
                            (EColorsHex)0x32, (EColorsHex)0x22,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x33, (EColorsHex)0x23,
                            (EColorsHex)0x33, (EColorsHex)0x23,
                            (EColorsHex)0x33, (EColorsHex)0x23,
                            (EColorsHex)0x33, (EColorsHex)0x23,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x34, (EColorsHex)0x24,
                            (EColorsHex)0x34, (EColorsHex)0x24,
                            (EColorsHex)0x34, (EColorsHex)0x24,
                            (EColorsHex)0x34, (EColorsHex)0x24,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x36, (EColorsHex)0x26,
                            (EColorsHex)0x36, (EColorsHex)0x26,
                            (EColorsHex)0x36, (EColorsHex)0x26,
                            (EColorsHex)0x36, (EColorsHex)0x26,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x37, (EColorsHex)0x27,
                            (EColorsHex)0x37, (EColorsHex)0x27,
                            (EColorsHex)0x37, (EColorsHex)0x27,
                            (EColorsHex)0x37, (EColorsHex)0x27,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x38, (EColorsHex)0x28,
                            (EColorsHex)0x38, (EColorsHex)0x28,
                            (EColorsHex)0x38, (EColorsHex)0x28,
                            (EColorsHex)0x38, (EColorsHex)0x28,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x39, (EColorsHex)0x29,
                            (EColorsHex)0x39, (EColorsHex)0x29,
                            (EColorsHex)0x39, (EColorsHex)0x29,
                            (EColorsHex)0x39, (EColorsHex)0x29,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                        },
                    }
                },

                new ColorSet() { // Bubble | Underwater Floors
                    addresses = new Int32[] {
                        0xfe13,0xfe14, // default BG
                        0xfe33,0xfe34, // frame 1
                        0xfe43,0xfe44, // frame 2
                        0xfe53,0xfe54 // frame 3
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // original colors
                            (EColorsHex)0x20, (EColorsHex)0x10,
                            (EColorsHex)0x20, (EColorsHex)0x10,
                            (EColorsHex)0x20, (EColorsHex)0x10,
                            (EColorsHex)0x20, (EColorsHex)0x10,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x31, (EColorsHex)0x21,
                            (EColorsHex)0x31, (EColorsHex)0x21,
                            (EColorsHex)0x31, (EColorsHex)0x21,
                            (EColorsHex)0x31, (EColorsHex)0x21,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x33, (EColorsHex)0x23,
                            (EColorsHex)0x33, (EColorsHex)0x23,
                            (EColorsHex)0x33, (EColorsHex)0x23,
                            (EColorsHex)0x33, (EColorsHex)0x23,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x35, (EColorsHex)0x25,
                            (EColorsHex)0x35, (EColorsHex)0x25,
                            (EColorsHex)0x35, (EColorsHex)0x25,
                            (EColorsHex)0x35, (EColorsHex)0x25,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x36, (EColorsHex)0x26,
                            (EColorsHex)0x36, (EColorsHex)0x26,
                            (EColorsHex)0x36, (EColorsHex)0x26,
                            (EColorsHex)0x36, (EColorsHex)0x26,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x38, (EColorsHex)0x28,
                            (EColorsHex)0x38, (EColorsHex)0x28,
                            (EColorsHex)0x38, (EColorsHex)0x28,
                            (EColorsHex)0x38, (EColorsHex)0x28,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x39, (EColorsHex)0x29,
                            (EColorsHex)0x39, (EColorsHex)0x29,
                            (EColorsHex)0x39, (EColorsHex)0x29,
                            (EColorsHex)0x39, (EColorsHex)0x29,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                            (EColorsHex)0x3a, (EColorsHex)0x2a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                            (EColorsHex)0x0f, (EColorsHex)0x05,
                        },
                        
                    }
                },

                new ColorSet() { // Bubble | Waterfall
                    addresses = new Int32[] {
                        0xfe1f,0xfe20,0xfe21, // default BG
                        0xfe3f,0xfe40,0xfe41, // frame 1
                        0xfe4f,0xfe50,0xfe51, // frame 2
                        0xfe5f,0xfe60,0xfe61, // frame 3
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // original colors
                            (EColorsHex)0x20,(EColorsHex)0x21,(EColorsHex)0x11,
                            (EColorsHex)0x20,(EColorsHex)0x21,(EColorsHex)0x11,
                            (EColorsHex)0x21,(EColorsHex)0x11,(EColorsHex)0x20,
                            (EColorsHex)0x11,(EColorsHex)0x20,(EColorsHex)0x21,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x21,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x21,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x22,(EColorsHex)0x12,(EColorsHex)0x21,
                            (EColorsHex)0x12,(EColorsHex)0x21,(EColorsHex)0x22,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x26,(EColorsHex)0x27,(EColorsHex)0x17,
                            (EColorsHex)0x26,(EColorsHex)0x27,(EColorsHex)0x17,
                            (EColorsHex)0x27,(EColorsHex)0x17,(EColorsHex)0x26,
                            (EColorsHex)0x17,(EColorsHex)0x26,(EColorsHex)0x27,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x27,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x27,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x28,(EColorsHex)0x18,(EColorsHex)0x27,
                            (EColorsHex)0x18,(EColorsHex)0x27,(EColorsHex)0x28,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x2a,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x2a,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x2b,(EColorsHex)0x1b,(EColorsHex)0x2a,
                            (EColorsHex)0x1b,(EColorsHex)0x2a,(EColorsHex)0x2b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x2b,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x2b,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x2c,(EColorsHex)0x1c,(EColorsHex)0x2b,
                            (EColorsHex)0x1c,(EColorsHex)0x2b,(EColorsHex)0x2c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0f,(EColorsHex)0x0c,(EColorsHex)0x00,
                            (EColorsHex)0x0f,(EColorsHex)0x0c,(EColorsHex)0x00,
                            (EColorsHex)0x0c,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x0c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0f,(EColorsHex)0x05,(EColorsHex)0x00,
                            (EColorsHex)0x0f,(EColorsHex)0x05,(EColorsHex)0x00,
                            (EColorsHex)0x05,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x05,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0f,(EColorsHex)0x08,(EColorsHex)0x00,
                            (EColorsHex)0x0f,(EColorsHex)0x08,(EColorsHex)0x00,
                            (EColorsHex)0x08,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x08,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0f,(EColorsHex)0x09,(EColorsHex)0x00,
                            (EColorsHex)0x0f,(EColorsHex)0x09,(EColorsHex)0x00,
                            (EColorsHex)0x09,(EColorsHex)0x00,(EColorsHex)0x0f,
                            (EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x09,
                        },
                    }
                },

                new ColorSet() { // Bubble | Water
                    addresses = new Int32[] { 0xfe22,
                        0xfe1b, 0xfe1c, 0xfe1d,
                        0xfe3b, 0xfe3c, 0xfe3d,
                        0xfe4b, 0xfe4c, 0xfe4d,
                        0xfe5b, 0xfe5c, 0xfe5d,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,(EColorsHex)0x11,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,
                        },
                        new EColorsHex[] {
                            EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,EColorsHex.Black3,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,(EColorsHex)0x13,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,(EColorsHex)0x05,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,(EColorsHex)0x16,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,(EColorsHex)0x07,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,(EColorsHex)0x17,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,(EColorsHex)0x09,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,(EColorsHex)0x2b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,
                        },
                    }
                },

                #endregion

                #region 04 Wily 4

                new ColorSet() { // Wily 4 | Walls
                    addresses = new Int32[] { 0xff13, 0xff14, 0xff15, },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x14,(EColorsHex)0x03,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x13,(EColorsHex)0x02,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x12,(EColorsHex)0x01,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x11,(EColorsHex)0x0c,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x1c,(EColorsHex)0x0b,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x1b,(EColorsHex)0x0a,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x19,(EColorsHex)0x08,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x18,(EColorsHex)0x07,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x17,(EColorsHex)0x06,},
                        new EColorsHex[] {(EColorsHex)0x10,(EColorsHex)0x16,(EColorsHex)0x05,},
                    }
                },

                new ColorSet() { // Wily 4 | Background
                    addresses = new Int32[] { 0xff18, },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x02, },
                        new EColorsHex[] {(EColorsHex)0x04, },
                        new EColorsHex[] {(EColorsHex)0x07,},
                        new EColorsHex[] {(EColorsHex)0x09, },
                        new EColorsHex[] {(EColorsHex)0x0b, },
                        new EColorsHex[] {(EColorsHex)0x0c, },
                        new EColorsHex[] {(EColorsHex)0x18, },
                        new EColorsHex[] {(EColorsHex)0x00, },
                    }
                },

                new ColorSet() { // Wily 4 | Track
                    addresses = new Int32[] { 0xff1B, 0xff1C, 0xff1d, },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x20,(EColorsHex)0x10,(EColorsHex)0x00,},
                        new EColorsHex[] {(EColorsHex)0x21,(EColorsHex)0x11,(EColorsHex)0x01,},
                        new EColorsHex[] {(EColorsHex)0x23,(EColorsHex)0x13,(EColorsHex)0x03,},
                        new EColorsHex[] {(EColorsHex)0x25,(EColorsHex)0x15,(EColorsHex)0x05,},
                        new EColorsHex[] {(EColorsHex)0x27,(EColorsHex)0x17,(EColorsHex)0x07,},
                        new EColorsHex[] {(EColorsHex)0x29,(EColorsHex)0x19,(EColorsHex)0x09,},
                        new EColorsHex[] {(EColorsHex)0x2b,(EColorsHex)0x1b,(EColorsHex)0x0b,},
                    }
                },

                #endregion

                #region 05 Quickman

                new ColorSet() { // Quick | Walls
                    addresses = new Int32[] { 0x013e13, 0x013e14, 0x013e15, },
                    ColorBytes = new List<EColorsHex[]>() {
                        // Default
                        new EColorsHex[] {(EColorsHex)0x2C,(EColorsHex)0x10,(EColorsHex)0x1C, },
                        // Green
                        new EColorsHex[] {(EColorsHex)0x2b,(EColorsHex)0x10,(EColorsHex)0x1d, },
                        // Yellow
                        new EColorsHex[] {(EColorsHex)0x28,(EColorsHex)0x10,(EColorsHex)0x18, },
                        // Orange
                        new EColorsHex[] {(EColorsHex)0x27,(EColorsHex)0x10,(EColorsHex)0x17, },
                        // Red
                        new EColorsHex[] {(EColorsHex)0x26,(EColorsHex)0x10,(EColorsHex)0x16, },
                        // Pink
                        new EColorsHex[] {(EColorsHex)0x25,(EColorsHex)0x10,(EColorsHex)0x15, },
                        // Magenta
                        new EColorsHex[] {(EColorsHex)0x24,(EColorsHex)0x10,(EColorsHex)0x14, },
                        // Purple
                        new EColorsHex[] {(EColorsHex)0x23,(EColorsHex)0x10,(EColorsHex)0x13, },
                        // Blue
                        new EColorsHex[] {(EColorsHex)0x22,(EColorsHex)0x10,(EColorsHex)0x12, },
                        // Light Blue
                        new EColorsHex[] {(EColorsHex)0x21,(EColorsHex)0x10,(EColorsHex)0x11, },
                    }
                },

                new ColorSet() { // Quick | Beams and Background
                    addresses = new Int32[] {0x013e17, 0x013e18, 0x013e19, 0x013e1b, 0x013e1c, 0x013e1d},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Default
                        new EColorsHex[] {(EColorsHex)0x37,(EColorsHex)0x27,(EColorsHex)0x07,(EColorsHex)0x28,(EColorsHex)0x16,(EColorsHex)0x07, },
                        // Purple
                        new EColorsHex[] {(EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x04,(EColorsHex)0x25,(EColorsHex)0x13,(EColorsHex)0x04, },
                        // Blue
                        new EColorsHex[] {(EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x02,(EColorsHex)0x23,(EColorsHex)0x11,(EColorsHex)0x02, },
                        // Cyan
                        new EColorsHex[] {(EColorsHex)0x3C,(EColorsHex)0x2C,(EColorsHex)0x0C,(EColorsHex)0x21,(EColorsHex)0x1B,(EColorsHex)0x0C, },
                        // Green
                        new EColorsHex[] {(EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x0a,(EColorsHex)0x2b,(EColorsHex)0x19,(EColorsHex)0x0a, },
                        // Green 2
                        new EColorsHex[] {(EColorsHex)0x39,(EColorsHex)0x29,(EColorsHex)0x09,(EColorsHex)0x2a,(EColorsHex)0x18,(EColorsHex)0x09, },
                        // Gold
                        new EColorsHex[] {(EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x08,(EColorsHex)0x29,(EColorsHex)0x17,(EColorsHex)0x08, },
                        // Gray
                        new EColorsHex[] {(EColorsHex)0x0f,(EColorsHex)0x0f,(EColorsHex)0x00,(EColorsHex)0x20,(EColorsHex)0x10,(EColorsHex)0x00, },

                    }
                },

                #endregion

                #region 05 Wily 5

                new ColorSet() { // Wily 5 | Walls
                    addresses = new Int32[] {
                        0x013f13, 0x013f14, 0x013f15,
                        0x013f33, 0x013f34, 0x013f35,
                        0x013f43, 0x013f44, 0x013f45,
                        0x013f53, 0x013f54, 0x013f55,
                        0x013f63, 0x013f64, 0x013f65,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x30,(EColorsHex)0x32,(EColorsHex)0x22,
                            (EColorsHex)0x30,(EColorsHex)0x32,(EColorsHex)0x22,
                            (EColorsHex)0x30,(EColorsHex)0x32,(EColorsHex)0x22,
                            (EColorsHex)0x30,(EColorsHex)0x32,(EColorsHex)0x22,
                            (EColorsHex)0x30,(EColorsHex)0x32,(EColorsHex)0x22,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x30,(EColorsHex)0x38,(EColorsHex)0x18,
                            (EColorsHex)0x30,(EColorsHex)0x38,(EColorsHex)0x18,
                            (EColorsHex)0x30,(EColorsHex)0x38,(EColorsHex)0x18,
                            (EColorsHex)0x30,(EColorsHex)0x38,(EColorsHex)0x18,
                            (EColorsHex)0x30,(EColorsHex)0x38,(EColorsHex)0x18,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x30,(EColorsHex)0x3a,(EColorsHex)0x1a,
                            (EColorsHex)0x30,(EColorsHex)0x3a,(EColorsHex)0x1a,
                            (EColorsHex)0x30,(EColorsHex)0x3a,(EColorsHex)0x1a,
                            (EColorsHex)0x30,(EColorsHex)0x3a,(EColorsHex)0x1a,
                            (EColorsHex)0x30,(EColorsHex)0x3a,(EColorsHex)0x1a,
                        },
                    }
                },

                new ColorSet() { // Wily 5 | Teleporters
                    addresses = new Int32[] {
                        0x013f13, 0x013f14, 0x013f15,
                        0x013f33, 0x013f34, 0x013f35,
                        0x013f43, 0x013f44, 0x013f45,
                        0x013f53, 0x013f54, 0x013f55,
                        0x013f63, 0x013f64, 0x013f65,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x37,(EColorsHex)0x27,(EColorsHex)0x17,
                            (EColorsHex)0x37,(EColorsHex)0x27,(EColorsHex)0x17,
                            (EColorsHex)0x37,(EColorsHex)0x27,(EColorsHex)0x17,
                            (EColorsHex)0x37,(EColorsHex)0x27,(EColorsHex)0x17,
                            (EColorsHex)0x37,(EColorsHex)0x27,(EColorsHex)0x17,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                            (EColorsHex)0x34,(EColorsHex)0x24,(EColorsHex)0x14,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                            (EColorsHex)0x32,(EColorsHex)0x22,(EColorsHex)0x12,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                            (EColorsHex)0x3c,(EColorsHex)0x2c,(EColorsHex)0x1c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                            (EColorsHex)0x3b,(EColorsHex)0x2b,(EColorsHex)0x1b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                            (EColorsHex)0x3a,(EColorsHex)0x2a,(EColorsHex)0x1a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                            (EColorsHex)0x38,(EColorsHex)0x28,(EColorsHex)0x18,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                            (EColorsHex)0x36,(EColorsHex)0x26,(EColorsHex)0x16,
                        },
                    }
                },

                new ColorSet() { // Wily 5 | Computers 1
                    addresses = new Int32[] {
                        0x013f1b, 0x013f1c,
                        0x013f3b, 0x013f3c,
                        0x013f4b, 0x013f4c,
                        0x013f5b, 0x013f5c,
                        0x013f6b, 0x013f6c,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x19,(EColorsHex)0x09,
                            (EColorsHex)0x19,(EColorsHex)0x09,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x18,(EColorsHex)0x08,
                            (EColorsHex)0x18,(EColorsHex)0x08,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x17,(EColorsHex)0x07,
                            (EColorsHex)0x17,(EColorsHex)0x07,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x15,(EColorsHex)0x05,
                            (EColorsHex)0x15,(EColorsHex)0x05,
                            (EColorsHex)0x15,(EColorsHex)0x05,
                            (EColorsHex)0x15,(EColorsHex)0x05,
                            (EColorsHex)0x15,(EColorsHex)0x05,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x13,(EColorsHex)0x03,
                            (EColorsHex)0x13,(EColorsHex)0x03,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x12,(EColorsHex)0x02,
                            (EColorsHex)0x12,(EColorsHex)0x02,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x1c,(EColorsHex)0x0c,
                            (EColorsHex)0x1c,(EColorsHex)0x0c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x1b,(EColorsHex)0x0b,
                            (EColorsHex)0x1b,(EColorsHex)0x0b,
                        },
                    }
                },

                new ColorSet() { // Wily 5 | Computers 2
                    addresses = new Int32[] {
                        0x013f1d,
                        0x013f3d,
                        0x013f4d,
                        0x013f5d,
                        0x013f6d,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x21,
                            (EColorsHex)0x21,
                            (EColorsHex)0x21,
                            (EColorsHex)0x21,
                            (EColorsHex)0x21,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x2b,
                            (EColorsHex)0x2b,
                            (EColorsHex)0x2b,
                            (EColorsHex)0x2b,
                            (EColorsHex)0x2b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x2a,
                            (EColorsHex)0x2a,
                            (EColorsHex)0x2a,
                            (EColorsHex)0x2a,
                            (EColorsHex)0x2a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x28,
                            (EColorsHex)0x28,
                            (EColorsHex)0x28,
                            (EColorsHex)0x28,
                            (EColorsHex)0x28,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x26,
                            (EColorsHex)0x26,
                            (EColorsHex)0x26,
                            (EColorsHex)0x26,
                            (EColorsHex)0x26,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x23,
                            (EColorsHex)0x23,
                            (EColorsHex)0x23,
                            (EColorsHex)0x23,
                            (EColorsHex)0x23,
                        },
                    }
                },

                new ColorSet() { // Wily 5 | Computers 3
                    addresses = new Int32[] {
                        0x013f1f, 0x013f20, 0x013f21,
                        0x013f3f, 0x013f40, 0x013f41,
                        0x013f4f, 0x013f50, 0x013f51,
                        0x013f5f, 0x013f60, 0x013f61,
                        0x013f6f, 0x013f70, 0x013f71,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            (EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,
                            (EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x01,
                            (EColorsHex)0x01,(EColorsHex)0x21,(EColorsHex)0x01,
                            (EColorsHex)0x01,(EColorsHex)0x01,(EColorsHex)0x21,
                            (EColorsHex)0x01,(EColorsHex)0x21,(EColorsHex)0x21,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,
                            (EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x0c,
                            (EColorsHex)0x0c,(EColorsHex)0x2c,(EColorsHex)0x0c,
                            (EColorsHex)0x0c,(EColorsHex)0x0c,(EColorsHex)0x2c,
                            (EColorsHex)0x0c,(EColorsHex)0x2c,(EColorsHex)0x2c,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,
                            (EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x0b,
                            (EColorsHex)0x0b,(EColorsHex)0x2b,(EColorsHex)0x0b,
                            (EColorsHex)0x0b,(EColorsHex)0x0b,(EColorsHex)0x2b,
                            (EColorsHex)0x0b,(EColorsHex)0x2b,(EColorsHex)0x2b,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x0a,(EColorsHex)0x0a,(EColorsHex)0x0a,
                            (EColorsHex)0x0a,(EColorsHex)0x0a,(EColorsHex)0x0a,
                            (EColorsHex)0x0a,(EColorsHex)0x2a,(EColorsHex)0x0a,
                            (EColorsHex)0x0a,(EColorsHex)0x0a,(EColorsHex)0x2a,
                            (EColorsHex)0x0a,(EColorsHex)0x2a,(EColorsHex)0x2a,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x08,(EColorsHex)0x08,(EColorsHex)0x08,
                            (EColorsHex)0x08,(EColorsHex)0x08,(EColorsHex)0x08,
                            (EColorsHex)0x08,(EColorsHex)0x28,(EColorsHex)0x08,
                            (EColorsHex)0x08,(EColorsHex)0x08,(EColorsHex)0x28,
                            (EColorsHex)0x08,(EColorsHex)0x28,(EColorsHex)0x28,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x06,(EColorsHex)0x06,(EColorsHex)0x06,
                            (EColorsHex)0x06,(EColorsHex)0x06,(EColorsHex)0x06,
                            (EColorsHex)0x06,(EColorsHex)0x26,(EColorsHex)0x06,
                            (EColorsHex)0x06,(EColorsHex)0x06,(EColorsHex)0x26,
                            (EColorsHex)0x06,(EColorsHex)0x26,(EColorsHex)0x26,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,
                            (EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x04,
                            (EColorsHex)0x04,(EColorsHex)0x24,(EColorsHex)0x04,
                            (EColorsHex)0x04,(EColorsHex)0x04,(EColorsHex)0x24,
                            (EColorsHex)0x04,(EColorsHex)0x24,(EColorsHex)0x24,
                        },
                        new EColorsHex[] {
                            (EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x00,
                            (EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x00,
                            (EColorsHex)0x00,(EColorsHex)0x20,(EColorsHex)0x00,
                            (EColorsHex)0x00,(EColorsHex)0x0f,(EColorsHex)0x20,
                            (EColorsHex)0x00,(EColorsHex)0x20,(EColorsHex)0x20,
                        },
                    }
                },

                #endregion

                #region 06 Flashman

                new ColorSet() { // Flash | Background
                    addresses = new Int32[] { 0x017e14, 0x017e15,            // default BG colors
                                            0x017e34, 0x017e44, 0x017e54,  // animated BG frame 1
                                            0x017e35, 0x017e45, 0x017e55 },// animated BG frame 2 
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                             EColorsHex.Blue,  EColorsHex.DarkBlue,
                             EColorsHex.Blue,  EColorsHex.Blue,  EColorsHex.Blue,
                             EColorsHex.DarkBlue,  EColorsHex.DarkBlue,  EColorsHex.DarkBlue,
                        },
                        new EColorsHex[] {
                             EColorsHex.Magenta,  EColorsHex.DarkMagenta,
                             EColorsHex.Magenta,  EColorsHex.Magenta,  EColorsHex.Magenta,
                             EColorsHex.DarkMagenta,  EColorsHex.DarkMagenta,  EColorsHex.DarkMagenta,
                        },
                        new EColorsHex[] {
                             EColorsHex.Orange,  EColorsHex.Red,
                             EColorsHex.Orange,  EColorsHex.Orange,  EColorsHex.Orange,
                             EColorsHex.Red,  EColorsHex.Red,  EColorsHex.Red,
                        },
                        new EColorsHex[] {
                             EColorsHex.GoldenRod,  EColorsHex.Brown,
                             EColorsHex.GoldenRod,  EColorsHex.GoldenRod,  EColorsHex.GoldenRod,
                             EColorsHex.Brown,  EColorsHex.Brown,  EColorsHex.Brown,
                        },
                        new EColorsHex[] {
                             EColorsHex.Green,  EColorsHex.ForestGreen,
                             EColorsHex.Green,  EColorsHex.Green,  EColorsHex.Green,
                             EColorsHex.ForestGreen,  EColorsHex.ForestGreen,  EColorsHex.ForestGreen,
                        },
                        new EColorsHex[] {
                             EColorsHex.Gray,  EColorsHex.Black3,
                             EColorsHex.Gray,  EColorsHex.Gray,  EColorsHex.Gray,
                             EColorsHex.Black3,  EColorsHex.Black3,  EColorsHex.Black3,
                        },
                    }
                },
                new ColorSet() { // Flash | Foreground
                    // Note: 3 color sets are used for the flashing blocks.
                    // I've kept them grouped here for common color themes.
                    addresses = new Int32[] {
                        0x017e17, 0x017e18, 0x017e19, 0x017e1b, 0x017e1c, 0x017e1d, 0x017e1f, 0x017e20, 0x017e21, // default BG colors
                        0x017e37, 0x017e47, 0x017e57, // animated BG block 1 frame 1
                        0x017e38, 0x017e48, 0x017e58, // animated BG block 1 frame 2
                        0x017e39, 0x017e49, 0x017e59, // animated BG block 1 frame 3
                        0x017e3b, 0x017e4b, 0x017e5b, // animated BG block 2 frame 1
                        0x017e3c, 0x017e4c, 0x017e5c, // animated BG block 2 frame 2
                        0x017e3d, 0x017e4d, 0x017e5d, // animated BG block 2 frame 3
                        0x017e3f, 0x017e4f, 0x017e5f, // animated BG block 3 frame 1
                        0x017e40, 0x017e50, 0x017e60, // animated BG block 3 frame 2
                        0x017e41, 0x017e51, 0x017e61},// animated BG block 3 frame 3
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {
                            EColorsHex.White, EColorsHex.PastelBlue, EColorsHex.LightCyan,EColorsHex.NearWhite, EColorsHex.LightBlue,EColorsHex.MediumBlue,EColorsHex.NearWhite,EColorsHex.LightBlue,EColorsHex.MediumBlue,
                            EColorsHex.White, EColorsHex.NearWhite,  EColorsHex.NearWhite,
                            EColorsHex.PastelBlue,  EColorsHex.LightBlue,  EColorsHex.LightBlue,
                            EColorsHex.LightCyan,  EColorsHex.MediumBlue,  EColorsHex.MediumBlue,
                            EColorsHex.NearWhite,  EColorsHex.White,  EColorsHex.NearWhite,
                            EColorsHex.LightBlue,  EColorsHex.PastelBlue,  EColorsHex.LightBlue,
                            EColorsHex.MediumBlue,  EColorsHex.LightCyan,  EColorsHex.MediumBlue,
                            EColorsHex.NearWhite,  EColorsHex.NearWhite,  EColorsHex.White,
                            EColorsHex.LightBlue,  EColorsHex.LightBlue,  EColorsHex.PastelBlue,
                            EColorsHex.MediumBlue,  EColorsHex.MediumBlue,  EColorsHex.LightCyan,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.PastelPurple,EColorsHex.LightPink,EColorsHex.NearWhite,EColorsHex.LightPurple,EColorsHex.Purple,EColorsHex.NearWhite,EColorsHex.LightPurple,EColorsHex.Purple,
                            EColorsHex.White,       EColorsHex.NearWhite,  EColorsHex.NearWhite,
                            EColorsHex.PastelPurple,EColorsHex.LightPurple,  EColorsHex.LightPurple,
                            EColorsHex.LightPink,   EColorsHex.Purple,  EColorsHex.Purple,
                            EColorsHex.NearWhite,   EColorsHex.White,  EColorsHex.NearWhite,
                            EColorsHex.LightPurple, EColorsHex.PastelPurple,  EColorsHex.LightPurple,
                            EColorsHex.Purple,      EColorsHex.LightPink,  EColorsHex.Purple,
                            EColorsHex.NearWhite,   EColorsHex.NearWhite,  EColorsHex.White,
                            EColorsHex.LightPurple, EColorsHex.LightPurple,  EColorsHex.PastelPurple,
                            EColorsHex.Purple,      EColorsHex.Purple,  EColorsHex.LightPink,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.Taupe,EColorsHex.LightOrange,EColorsHex.NearWhite,EColorsHex.Orange,EColorsHex.Red,EColorsHex.NearWhite,EColorsHex.LightOrange,EColorsHex.Orange,
                            EColorsHex.White,       EColorsHex.NearWhite,  EColorsHex.NearWhite,
                            EColorsHex.Taupe,       EColorsHex.LightOrange,  EColorsHex.Orange,
                            EColorsHex.LightOrange, EColorsHex.Orange,  EColorsHex.Red,
                            EColorsHex.NearWhite,   EColorsHex.White,  EColorsHex.NearWhite,
                            EColorsHex.Orange,      EColorsHex.Taupe,  EColorsHex.LightOrange,
                            EColorsHex.Red,         EColorsHex.LightOrange,  EColorsHex.Orange,
                            EColorsHex.NearWhite,   EColorsHex.NearWhite,  EColorsHex.White,
                            EColorsHex.LightOrange, EColorsHex.Orange,  EColorsHex.Taupe,
                            EColorsHex.Orange,      EColorsHex.Red,  EColorsHex.LightOrange,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.PastelYellow,EColorsHex.Yellow,EColorsHex.NearWhite,EColorsHex.GoldenRod,EColorsHex.Brown,EColorsHex.NearWhite,EColorsHex.Yellow,EColorsHex.GoldenRod,
                            EColorsHex.White,       EColorsHex.NearWhite,  EColorsHex.NearWhite,
                            EColorsHex.PastelYellow,EColorsHex.Yellow,  EColorsHex.GoldenRod,
                            EColorsHex.Yellow,      EColorsHex.GoldenRod,  EColorsHex.Brown,
                            EColorsHex.NearWhite,   EColorsHex.White,  EColorsHex.NearWhite,
                            EColorsHex.GoldenRod,   EColorsHex.PastelYellow,  EColorsHex.Yellow,
                            EColorsHex.Brown,       EColorsHex.Yellow,  EColorsHex.GoldenRod,
                            EColorsHex.NearWhite,   EColorsHex.NearWhite,  EColorsHex.White,
                            EColorsHex.Yellow,      EColorsHex.GoldenRod,  EColorsHex.PastelYellow,
                            EColorsHex.GoldenRod,   EColorsHex.Brown,  EColorsHex.Yellow,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.PastelGreen,EColorsHex.LightGreen,EColorsHex.NearWhite,EColorsHex.Green,EColorsHex.ForestGreen,EColorsHex.NearWhite,EColorsHex.LightGreen,EColorsHex.Green,
                            EColorsHex.White,       EColorsHex.NearWhite,  EColorsHex.NearWhite,
                            EColorsHex.PastelGreen, EColorsHex.LightGreen,  EColorsHex.Green,
                            EColorsHex.LightGreen,  EColorsHex.Green,  EColorsHex.ForestGreen,
                            EColorsHex.NearWhite,   EColorsHex.White,  EColorsHex.NearWhite,
                            EColorsHex.Green,       EColorsHex.PastelGreen,  EColorsHex.LightGreen,
                            EColorsHex.ForestGreen, EColorsHex.LightGreen,  EColorsHex.Green,
                            EColorsHex.NearWhite,   EColorsHex.NearWhite,  EColorsHex.White,
                            EColorsHex.LightGreen,  EColorsHex.Green,  EColorsHex.PastelGreen,
                            EColorsHex.Green,       EColorsHex.ForestGreen,  EColorsHex.LightGreen,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.PastelCyan,EColorsHex.Lime,EColorsHex.NearWhite,EColorsHex.Moss,EColorsHex.DarkGreen,EColorsHex.NearWhite,EColorsHex.Lime,EColorsHex.Moss,
                            EColorsHex.White,       EColorsHex.NearWhite,  EColorsHex.NearWhite,
                            EColorsHex.PastelCyan,  EColorsHex.Lime,  EColorsHex.Moss,
                            EColorsHex.Lime,        EColorsHex.Moss,  EColorsHex.DarkGreen,
                            EColorsHex.NearWhite,   EColorsHex.White,  EColorsHex.NearWhite,
                            EColorsHex.Moss,        EColorsHex.PastelCyan,  EColorsHex.Lime,
                            EColorsHex.DarkGreen,   EColorsHex.Lime,  EColorsHex.Moss,
                            EColorsHex.NearWhite,   EColorsHex.NearWhite,  EColorsHex.White,
                            EColorsHex.Lime,        EColorsHex.Moss,  EColorsHex.PastelCyan,
                            EColorsHex.Moss,        EColorsHex.DarkGreen,  EColorsHex.Lime,
                        },
                        new EColorsHex[] {
                            EColorsHex.White,EColorsHex.Black3,EColorsHex.LightGray,EColorsHex.NearWhite,EColorsHex.Black3,EColorsHex.DarkRed,EColorsHex.NearWhite,EColorsHex.Black3,EColorsHex.Gray,
                            EColorsHex.White,       EColorsHex.NearWhite,  EColorsHex.NearWhite,
                            EColorsHex.Black3,      EColorsHex.Black3,  EColorsHex.Black3,
                            EColorsHex.LightGray,   EColorsHex.Gray,  EColorsHex.DarkRed,
                            EColorsHex.NearWhite,   EColorsHex.White,  EColorsHex.NearWhite,
                            EColorsHex.Black3,      EColorsHex.Black3,  EColorsHex.Black3,
                            EColorsHex.DarkRed,     EColorsHex.LightGray,  EColorsHex.Gray,
                            EColorsHex.NearWhite,   EColorsHex.NearWhite,  EColorsHex.White,
                            EColorsHex.Black3,      EColorsHex.Black3,  EColorsHex.Black3,
                            EColorsHex.Gray,        EColorsHex.DarkRed,  EColorsHex.LightGray,
                        },
                    }
                },

                #endregion

                #region 06 Wily 6

                new ColorSet() { // Wily 6 | Walls
                    addresses = new Int32[] { 0x017f13, 0x017f14, 0x017f15, },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { (EColorsHex)0x27,(EColorsHex)0x18,(EColorsHex)0x0a },
                        new EColorsHex[] { (EColorsHex)0x28,(EColorsHex)0x19,(EColorsHex)0x0b },
                        new EColorsHex[] { (EColorsHex)0x28,(EColorsHex)0x1a,(EColorsHex)0x0c },
                        new EColorsHex[] { (EColorsHex)0x2a,(EColorsHex)0x1b,(EColorsHex)0x01 },
                        new EColorsHex[] { (EColorsHex)0x2b,(EColorsHex)0x1c,(EColorsHex)0x02 },
                        new EColorsHex[] { (EColorsHex)0x2c,(EColorsHex)0x11,(EColorsHex)0x03 },
                        new EColorsHex[] { (EColorsHex)0x21,(EColorsHex)0x12,(EColorsHex)0x04 },
                        new EColorsHex[] { (EColorsHex)0x22,(EColorsHex)0x13,(EColorsHex)0x05 },
                        new EColorsHex[] { (EColorsHex)0x25,(EColorsHex)0x16,(EColorsHex)0x08 },
                        new EColorsHex[] { (EColorsHex)0x26,(EColorsHex)0x17,(EColorsHex)0x09 },
                        new EColorsHex[] { (EColorsHex)0x10,(EColorsHex)0x00,(EColorsHex)0x0f },
                    }
                },

                new ColorSet() { // Wily 6 | Background
                    addresses = new Int32[] { 0x017f18, },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] {(EColorsHex)0x0b,},
                        new EColorsHex[] {(EColorsHex)0x08, },
                        new EColorsHex[] {(EColorsHex)0x17, },
                        new EColorsHex[] {(EColorsHex)0x07, },
                        new EColorsHex[] {(EColorsHex)0x05, },
                        new EColorsHex[] {(EColorsHex)0x04, },
                        new EColorsHex[] {(EColorsHex)0x03, },
                        new EColorsHex[] {(EColorsHex)0x01, },
                        new EColorsHex[] {(EColorsHex)0x0c, },
                    }
                },

                #endregion

                #region 07 Metalman

                new ColorSet() { // Metal | Platforms
                    addresses = new Int32[] {
                        0x01be13, 0x01be14, 0x01be15,
                        0x01be33, 0x01be34, 0x01be35,
                        0x01be43, 0x01be44, 0x01be45,
                        0x01be53, 0x01be54, 0x01be55,
                        0x01be63, 0x01be64, 0x01be65,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // Default
                            (EColorsHex)0x38, (EColorsHex)0x2a, (EColorsHex)0x17,
                            (EColorsHex)0x38, (EColorsHex)0x2a, (EColorsHex)0x17,
                            (EColorsHex)0x38, (EColorsHex)0x2a, (EColorsHex)0x17,
                            (EColorsHex)0x38, (EColorsHex)0x2a, (EColorsHex)0x17,
                            (EColorsHex)0x38, (EColorsHex)0x2a, (EColorsHex)0x17,},
                        new EColorsHex[] { // Turquoise
                            (EColorsHex)0x3c, (EColorsHex)0x22, (EColorsHex)0x1d,
                            (EColorsHex)0x3c, (EColorsHex)0x22, (EColorsHex)0x1d,
                            (EColorsHex)0x3c, (EColorsHex)0x22, (EColorsHex)0x1d,
                            (EColorsHex)0x3c, (EColorsHex)0x22, (EColorsHex)0x1d,
                            (EColorsHex)0x3c, (EColorsHex)0x22, (EColorsHex)0x1d,},
                        new EColorsHex[] { // Pink
                            (EColorsHex)0x32, (EColorsHex)0x24, (EColorsHex)0x13,
                            (EColorsHex)0x32, (EColorsHex)0x24, (EColorsHex)0x13,
                            (EColorsHex)0x32, (EColorsHex)0x24, (EColorsHex)0x13,
                            (EColorsHex)0x32, (EColorsHex)0x24, (EColorsHex)0x13,
                            (EColorsHex)0x32, (EColorsHex)0x24, (EColorsHex)0x13,},
                        new EColorsHex[] { // Purple
                            (EColorsHex)0x34, (EColorsHex)0x26, (EColorsHex)0x15,
                            (EColorsHex)0x34, (EColorsHex)0x26, (EColorsHex)0x15,
                            (EColorsHex)0x34, (EColorsHex)0x26, (EColorsHex)0x15,
                            (EColorsHex)0x34, (EColorsHex)0x26, (EColorsHex)0x15,
                            (EColorsHex)0x34, (EColorsHex)0x26, (EColorsHex)0x15,},
                        new EColorsHex[] { // Yellow
                            (EColorsHex)0x36, (EColorsHex)0x28, (EColorsHex)0x17,
                            (EColorsHex)0x36, (EColorsHex)0x28, (EColorsHex)0x17,
                            (EColorsHex)0x36, (EColorsHex)0x28, (EColorsHex)0x17,
                            (EColorsHex)0x36, (EColorsHex)0x28, (EColorsHex)0x17,
                            (EColorsHex)0x36, (EColorsHex)0x28, (EColorsHex)0x17,},
                        new EColorsHex[] { // White
                            (EColorsHex)0x20, (EColorsHex)0x10, (EColorsHex)0x0f,
                            (EColorsHex)0x20, (EColorsHex)0x10, (EColorsHex)0x0f,
                            (EColorsHex)0x20, (EColorsHex)0x10, (EColorsHex)0x0f,
                            (EColorsHex)0x20, (EColorsHex)0x10, (EColorsHex)0x0f,
                            (EColorsHex)0x20, (EColorsHex)0x10, (EColorsHex)0x0f,},
                        new EColorsHex[] { // Dark Blue/Orange
                            (EColorsHex)0x1c, (EColorsHex)0x0b, (EColorsHex)0x07,
                            (EColorsHex)0x1c, (EColorsHex)0x0b, (EColorsHex)0x07,
                            (EColorsHex)0x1c, (EColorsHex)0x0b, (EColorsHex)0x07,
                            (EColorsHex)0x1c, (EColorsHex)0x0b, (EColorsHex)0x07,
                            (EColorsHex)0x1c, (EColorsHex)0x0b, (EColorsHex)0x07,},
                        new EColorsHex[] { // Blue
                            (EColorsHex)0x2c, (EColorsHex)0x22, (EColorsHex)0x11,
                            (EColorsHex)0x2c, (EColorsHex)0x22, (EColorsHex)0x11,
                            (EColorsHex)0x2c, (EColorsHex)0x22, (EColorsHex)0x11,
                            (EColorsHex)0x2c, (EColorsHex)0x22, (EColorsHex)0x11,
                            (EColorsHex)0x2c, (EColorsHex)0x22, (EColorsHex)0x11,},

                    }
                },

                //new ColorSet() { // Metal | Solid Background
                //    addresses = new Int32[] {
                //        0x01be21, 0x01be22,
                //        0x01be41, 0x01be51,
                //        0x01b260, 0x01be70,
                //    },
                //    ColorBytes = new List<EColorsHex[]>() {
                //        new EColorsHex[] { // Default Black
                //            (EColorsHex)0x0f, (EColorsHex)0x0f,
                //            (EColorsHex)0x0f, (EColorsHex)0x0f,
                //            (EColorsHex)0x0f, (EColorsHex)0x0f,},
                //    }
                //},

                new ColorSet() { // Metal | Background Gears
                    addresses = new Int32[] {
                        0x01be1f, 0x01be20,0x01be3f, 0x01be40,0x01be4f, 0x01be50,0x01be5f, 0x01be61,0x01be6f, 0x01be71,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // Default Dark Red
                            (EColorsHex)0x07, (EColorsHex)0x07,(EColorsHex)0x07, (EColorsHex)0x07,(EColorsHex)0x07, (EColorsHex)0x07,(EColorsHex)0x07, (EColorsHex)0x07,(EColorsHex)0x07, (EColorsHex)0x07,},
                        new EColorsHex[] { // Dark Magenta
                            (EColorsHex)0x04, (EColorsHex)0x04,(EColorsHex)0x04, (EColorsHex)0x04,(EColorsHex)0x04, (EColorsHex)0x04,(EColorsHex)0x04, (EColorsHex)0x04,(EColorsHex)0x04, (EColorsHex)0x04,},
                        new EColorsHex[] { // Dark Purple
                            (EColorsHex)0x03, (EColorsHex)0x03,(EColorsHex)0x03, (EColorsHex)0x03,(EColorsHex)0x03, (EColorsHex)0x03,(EColorsHex)0x03, (EColorsHex)0x03,(EColorsHex)0x03, (EColorsHex)0x03,},
                        new EColorsHex[] { // Dark Blue
                            (EColorsHex)0x02, (EColorsHex)0x02,(EColorsHex)0x02, (EColorsHex)0x02,(EColorsHex)0x02, (EColorsHex)0x02,(EColorsHex)0x02, (EColorsHex)0x02,(EColorsHex)0x02, (EColorsHex)0x02,},
                        new EColorsHex[] { // Dark Gray
                            (EColorsHex)0x00, (EColorsHex)0x00,(EColorsHex)0x00, (EColorsHex)0x00,(EColorsHex)0x00, (EColorsHex)0x00,(EColorsHex)0x00, (EColorsHex)0x00,(EColorsHex)0x00, (EColorsHex)0x00,},
                        new EColorsHex[] { // Dark Cyan
                            (EColorsHex)0x0C, (EColorsHex)0x0C,(EColorsHex)0x0C, (EColorsHex)0x0C,(EColorsHex)0x0C, (EColorsHex)0x0C,(EColorsHex)0x0C, (EColorsHex)0x0C,(EColorsHex)0x0C, (EColorsHex)0x0C,},
                        new EColorsHex[] { // Dark Turquoise
                            (EColorsHex)0x0B, (EColorsHex)0x0B,(EColorsHex)0x0B, (EColorsHex)0x0B,(EColorsHex)0x0B, (EColorsHex)0x0B,(EColorsHex)0x0B, (EColorsHex)0x0B,(EColorsHex)0x0B, (EColorsHex)0x0B,},
                        new EColorsHex[] { // Dark Brown
                            (EColorsHex)0x08, (EColorsHex)0x08,(EColorsHex)0x08, (EColorsHex)0x08,(EColorsHex)0x08, (EColorsHex)0x08,(EColorsHex)0x08, (EColorsHex)0x08,(EColorsHex)0x08, (EColorsHex)0x08,},
                    }
                },

                new ColorSet() { // Metal | Conveyor Animation
                    addresses = new Int32[] {
                        0x01be1c, 0x01be1d,
                        0x01be3c, 0x01be3d,
                        0x01be4c, 0x01be4d,
                        0x01be5c, 0x01be5d,
                        0x01be6c, 0x01be6d,
                    },
                    ColorBytes = new List<EColorsHex[]>() {
                        new EColorsHex[] { // Default
                            (EColorsHex)0x05, (EColorsHex)0x27,
                            (EColorsHex)0x27, (EColorsHex)0x05,
                            (EColorsHex)0x05, (EColorsHex)0x27,
                            (EColorsHex)0x27, (EColorsHex)0x05,
                            (EColorsHex)0x05, (EColorsHex)0x27,},
                        new EColorsHex[] { // Dark Brown, Light Green
                            (EColorsHex)0x07, (EColorsHex)0x29,
                            (EColorsHex)0x29, (EColorsHex)0x07,
                            (EColorsHex)0x07, (EColorsHex)0x29,
                            (EColorsHex)0x29, (EColorsHex)0x07,
                            (EColorsHex)0x07, (EColorsHex)0x29,},
                        new EColorsHex[] { // Dark Green, Light Turquoise
                            (EColorsHex)0x09, (EColorsHex)0x2b,
                            (EColorsHex)0x2b, (EColorsHex)0x09,
                            (EColorsHex)0x09, (EColorsHex)0x2b,
                            (EColorsHex)0x2b, (EColorsHex)0x09,
                            (EColorsHex)0x09, (EColorsHex)0x2b,},
                        new EColorsHex[] { // Dark Turquoise, Light Blue
                            (EColorsHex)0x0b, (EColorsHex)0x21,
                            (EColorsHex)0x21, (EColorsHex)0x0b,
                            (EColorsHex)0x0b, (EColorsHex)0x21,
                            (EColorsHex)0x21, (EColorsHex)0x0b,
                            (EColorsHex)0x0b, (EColorsHex)0x21,},
                        new EColorsHex[] { // Dark Blue, Light Purple
                            (EColorsHex)0x01, (EColorsHex)0x23,
                            (EColorsHex)0x23, (EColorsHex)0x01,
                            (EColorsHex)0x01, (EColorsHex)0x23,
                            (EColorsHex)0x23, (EColorsHex)0x01,
                            (EColorsHex)0x01, (EColorsHex)0x23,},
                        new EColorsHex[] { // Orange, Yellow
                            (EColorsHex)0x16, (EColorsHex)0x28,
                            (EColorsHex)0x28, (EColorsHex)0x16,
                            (EColorsHex)0x16, (EColorsHex)0x28,
                            (EColorsHex)0x28, (EColorsHex)0x16,
                            (EColorsHex)0x16, (EColorsHex)0x28,},
                        new EColorsHex[] { // Dark Gray, Light Gray
                            (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00,
                            (EColorsHex)0x00, (EColorsHex)0x10,
                            (EColorsHex)0x10, (EColorsHex)0x00,
                            (EColorsHex)0x00, (EColorsHex)0x10,},
                    }
                },

                #endregion

                #region 08 Crashman

                // TODO: Comment later, missing a color in boss corridor
                new ColorSet() {
                    addresses = new Int32[] { 0x01fe13, 0x01fe14, 0x03b63a, 0x03b63b, 0x03b642, 0x03b643, 0x03b646, 0x03b647, 0x03b64a, 0x03b64b, 0x03b64e, 0x03b64f, 0x039188, 0x039189, 0x03918c, 0x03918d, },
                    ColorBytes = new List<EColorsHex[]>() {
                        // Crash | Border1 | Default
                        new EColorsHex[] {  EColorsHex.PastelLemon, EColorsHex.GoldenRod, EColorsHex.PastelLemon, EColorsHex.GoldenRod, EColorsHex.PastelLemon, EColorsHex.GoldenRod, EColorsHex.PastelLemon, EColorsHex.GoldenRod, EColorsHex.PastelLemon, EColorsHex.GoldenRod, EColorsHex.PastelLemon, EColorsHex.GoldenRod, EColorsHex.PastelLemon, EColorsHex.GoldenRod, EColorsHex.PastelLemon, EColorsHex.GoldenRod,},
                        // Crash | Border1 | Blue
                        new EColorsHex[] {  EColorsHex.MediumBlue, EColorsHex.RoyalBlue, EColorsHex.MediumBlue, EColorsHex.RoyalBlue, EColorsHex.MediumBlue, EColorsHex.RoyalBlue, EColorsHex.MediumBlue, EColorsHex.RoyalBlue, EColorsHex.MediumBlue, EColorsHex.RoyalBlue, EColorsHex.MediumBlue, EColorsHex.RoyalBlue, EColorsHex.MediumBlue, EColorsHex.RoyalBlue, EColorsHex.MediumBlue, EColorsHex.RoyalBlue,},
                        // Crash | Border1 | Orange
                        new EColorsHex[] {  EColorsHex.YellowOrange, EColorsHex.Orange, EColorsHex.YellowOrange, EColorsHex.Orange, EColorsHex.YellowOrange, EColorsHex.Orange, EColorsHex.YellowOrange, EColorsHex.Orange, EColorsHex.YellowOrange, EColorsHex.Orange, EColorsHex.YellowOrange, EColorsHex.Orange, EColorsHex.YellowOrange, EColorsHex.Orange, EColorsHex.YellowOrange, EColorsHex.Orange,},
                        // Crash | Border1 | Green
                        new EColorsHex[] {  EColorsHex.Lime, EColorsHex.ForestGreen, EColorsHex.Lime, EColorsHex.ForestGreen, EColorsHex.Lime, EColorsHex.ForestGreen, EColorsHex.Lime, EColorsHex.ForestGreen, EColorsHex.Lime, EColorsHex.ForestGreen, EColorsHex.Lime, EColorsHex.ForestGreen, EColorsHex.Lime, EColorsHex.ForestGreen, EColorsHex.Lime, EColorsHex.ForestGreen,},
                        // Crash | Border1 | Red Black
                        new EColorsHex[] {  EColorsHex.Black2, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Red,},
                    }
                },
                new ColorSet() {
                    addresses = new Int32[] { 0x01fe15,0x01fe17,0x03b63c,0x03b644,0x03b648,0x03b64c,0x03b650,},
                    ColorBytes = new List<EColorsHex[]>() {
                        // Crash | Background | Default
                        new EColorsHex[] {  EColorsHex.Blue, EColorsHex.Blue, EColorsHex.RoyalBlue, EColorsHex.RoyalBlue, EColorsHex.Black2, EColorsHex.Black2, EColorsHex.Black2,},
                        // Crash | Background | Yellow
                        new EColorsHex[] {  EColorsHex.Yellow, EColorsHex.Yellow, EColorsHex.Brown, EColorsHex.Brown, EColorsHex.Black2, EColorsHex.Black2, EColorsHex.Black2,},
                        // Crash | Background | Orange
                        new EColorsHex[] {  EColorsHex.Orange, EColorsHex.Orange, EColorsHex.Red, EColorsHex.Red, EColorsHex.Black2, EColorsHex.Black2, EColorsHex.Black2,},
                        // Crash | Background | Green
                        new EColorsHex[] {  EColorsHex.Lime, EColorsHex.Lime, EColorsHex.Moss, EColorsHex.Moss, EColorsHex.Black2, EColorsHex.Black2, EColorsHex.Black2,},
                        // Crash | Background | Purple
                        new EColorsHex[] {  EColorsHex.LightPink, EColorsHex.LightPink, EColorsHex.DarkMagenta, EColorsHex.DarkMagenta, EColorsHex.Black2, EColorsHex.Black2, EColorsHex.Black2,}
                    }
                },
                new ColorSet() {
                    addresses = new Int32[] { 0x01fe18,0x01fe19, },
                    ColorBytes = new List<EColorsHex[]>() {
                        // Crash | Doodads | Default
                        new EColorsHex[] {  EColorsHex.YellowOrange, EColorsHex.NearWhite,},
                        // Crash | Doodads | Green
                        new EColorsHex[] {  EColorsHex.Green, EColorsHex.NearWhite,},
                        // Crash | Doodads | Teal
                        new EColorsHex[] {  EColorsHex.Teal, EColorsHex.NearWhite,},
                        // Crash | Doodads | Purple
                        new EColorsHex[] {  EColorsHex.Purple, EColorsHex.NearWhite,},
                        // Crash | Doodads | Red
                        new EColorsHex[] {  EColorsHex.Crimson, EColorsHex.NearWhite,},
                        // Crash | Doodads | Gray
                        new EColorsHex[] {  EColorsHex.Gray, EColorsHex.NearWhite,},
                    }
                },

            #endregion
            };

            for (Int32 i = 0; i < StagesColorSets.Count; i++)
            {
                ColorSet set = StagesColorSets[i];
                set.RandomizeAndWrite(in_Patch, in_Context.Seed, i);
            }
        }


        //
        // Private Data Members
        //

        private const Int32 MEGA_MAN_COLOR_ADDRESS = 0x03d314;
    }
}
