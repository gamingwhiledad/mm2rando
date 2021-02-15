using System;
using System.Collections.Generic;
using MM2Randomizer.Patcher;
using MM2Randomizer.Random;

namespace MM2Randomizer.Randomizers
{
    public class RBossRoom : IRandomizer
    {
        public class BossRoomRandomComponent
        {
            // This seems to be every table necessary to shuffle for getting a boss
            // to function and display properly in a different boss room.
            public Byte IntroValue { get; set; }    // 0F 0F 0B 05 09 07 05 03
            public Byte AIPtrByte1 { get; set; }    // C5 E3 FB 56 9E 56 20 C3
            public Byte AIPtrByte2 { get; set; }    // 80 82 84 86 87 89 8B 8C
            public Byte GfxFix1 { get; set; }       // 50 66 6C 60 54 5A 63 69
            public Byte GfxFix2 { get; set; }       // 51 67 6D 61 55 5C 64 6A
            public Byte YPosFix1 { get; set; }      // 09 0C 0F 0A 09 09 08 08
            public Byte YPosFix2 { get; set; }      // 0C 10 10 0C 0C 0C 0C 0C
            public Byte[] SpriteBankSlotRowsBytes { get; set; }
            public Int32 OriginalBossIndex { get; set; }
            // ...and maybe room layout???

            public BossRoomRandomComponent(Int32 original, Byte introValue, Byte aiPtr1, Byte aiPtr2, Byte gfxfix1, Byte gfxfix2, Byte yFix1, Byte yFix2, Byte[] spriteBankSlotRows)
            {
                this.IntroValue = introValue;
                this.AIPtrByte1 = aiPtr1;
                this.AIPtrByte2 = aiPtr2;
                this.GfxFix1 = gfxfix1;
                this.GfxFix2 = gfxfix2;
                this.YPosFix1 = yFix1;
                this.YPosFix2 = yFix2;
                this.SpriteBankSlotRowsBytes = spriteBankSlotRows;
                this.OriginalBossIndex = original;
            }
        }
        
        public RBossRoom()
        {
            // Initialize BossRoomRandomComponents, and add to "Components" list.
            // This list is still needed even if this module isn't enabled; it just won't get shuffled.
            BossRoomRandomComponent HeatManComponent = new BossRoomRandomComponent(
                    original: 0,
                    introValue: 0x0F, // 0x02C15E
                    aiPtr1: 0xC5, // 0x02C057
                    aiPtr2: 0x80, // 0x02C065
                    gfxfix1: 0x50, // 0x02E4E9
                    gfxfix2: 0x51, // 0x02C166
                    yFix1: 0x09, // 0x02C14E
                    yFix2: 0x0C, // 0x02C156
                    spriteBankSlotRows: new Byte[] {
                        0x98, 0x06,
                        0x99, 0x06,
                        0x9A, 0x06,
                        0x9B, 0x06,
                        0x9C, 0x06,
                        0x9D, 0x06,
                    });

            BossRoomRandomComponent AirManComponent = new BossRoomRandomComponent(
                    original: 1,
                    introValue: 0x0F,
                    aiPtr1: 0xE3,
                    aiPtr2: 0x82,
                    gfxfix1: 0x66,
                    gfxfix2: 0x67,
                    yFix1: 0x0C,
                    yFix2: 0x10,
                    spriteBankSlotRows: new Byte[] {
                        0xAB, 0x05,
                        0xAC, 0x05,
                        0xAD, 0x05,
                        0xAA, 0x06,
                        0xAB, 0x06,
                        0xAC, 0x06,
                    });

            BossRoomRandomComponent WoodManComponent = new BossRoomRandomComponent(
                    original: 2,
                    introValue: 0x0B,
                    aiPtr1: 0xFB,
                    aiPtr2: 0x84,
                    gfxfix1: 0x6C,
                    gfxfix2: 0x6D,
                    yFix1: 0x0F,
                    yFix2: 0x10,
                    spriteBankSlotRows: new Byte[] {
                        0xAC, 0x06,
                        0xAD, 0x06,
                        0xAE, 0x06,
                        0xAF, 0x06,
                        0xB0, 0x06,
                        0xB1, 0x06,
                    });

            BossRoomRandomComponent BubbleManComponent = new BossRoomRandomComponent(
                    original: 3,
                    introValue: 0x05,
                    aiPtr1: 0x56,
                    aiPtr2: 0x86,
                    gfxfix1: 0x60,
                    gfxfix2: 0x61,
                    yFix1: 0x0A,
                    yFix2: 0x0C,
                    spriteBankSlotRows: new Byte[] {
                        0x98, 0x07,
                        0x99, 0x07,
                        0x9A, 0x07,
                        0x9B, 0x07,
                        0x9C, 0x07,
                        0x9D, 0x07,
                    });

            BossRoomRandomComponent QuickManComponent = new BossRoomRandomComponent(
                    original: 4,
                    introValue: 0x09,
                    aiPtr1: 0x9E,
                    aiPtr2: 0x87,
                    gfxfix1: 0x54,
                    gfxfix2: 0x55,
                    yFix1: 0x09,
                    yFix2: 0x0C,
                    spriteBankSlotRows: new Byte[] {
                        0x90, 0x07,
                        0x91, 0x07,
                        0x92, 0x07,
                        0x93, 0x07,
                        0x94, 0x07,
                        0x95, 0x07,
                    });

            BossRoomRandomComponent FlashManComponent = new BossRoomRandomComponent(
                    original: 5,
                    introValue: 0x07,
                    aiPtr1: 0x56,
                    aiPtr2: 0x89,
                    gfxfix1: 0x5A,
                    gfxfix2: 0x5C,
                    yFix1: 0x09,
                    yFix2: 0x0C,
                    spriteBankSlotRows: new Byte[] {
                        0x9E, 0x06,
                        0x9F, 0x06,
                        0x96, 0x07,
                        0x97, 0x07,
                        0x9E, 0x07,
                        0x9F, 0x07,
                    });

            BossRoomRandomComponent MetalManComponent = new BossRoomRandomComponent(
                    original: 6,
                    introValue: 0x05,
                    aiPtr1: 0x20,
                    aiPtr2: 0x8B,
                    gfxfix1: 0x63,
                    gfxfix2: 0x64,
                    yFix1: 0x08,
                    yFix2: 0x0C,
                    spriteBankSlotRows: new Byte[] {
                        0xB0, 0x03,
                        0xB1, 0x03,
                        0xB2, 0x03,
                        0xB3, 0x03,
                        0xAA, 0x05,
                        0xAB, 0x05,
                    });

            BossRoomRandomComponent CrashManComponent = new BossRoomRandomComponent(
                    original: 7,
                    introValue: 0x03,
                    aiPtr1: 0xC3,
                    aiPtr2: 0x8C,
                    gfxfix1: 0x69,
                    gfxfix2: 0x6A,
                    yFix1: 0x08,
                    yFix2: 0x0C,
                    spriteBankSlotRows: new Byte[] {
                        0xAE, 0x05,
                        0xAF, 0x05,
                        0xB0, 0x05,
                        0xB1, 0x05,
                        0xB2, 0x05,
                        0xB3, 0x05,
                    }
                );

            this.Components = new List<BossRoomRandomComponent>
            {
                HeatManComponent,
                AirManComponent,
                WoodManComponent,
                BubbleManComponent,
                QuickManComponent,
                FlashManComponent,
                MetalManComponent,
                CrashManComponent,
            };
        }

        public IList<BossRoomRandomComponent> Components { get; set; }

        /// <summary>
        /// Shuffle which Robot Master awards which weapon.
        /// </summary>
        public void Randomize(Patch in_Patch, ISeed in_Seed)
        {
            IList<BossRoomRandomComponent> bossRoomComponents = in_Seed.Shuffle(this.Components);

            //DEBUG test a boss in a particular boss room, also comment out the corresponding boss from the Components list above
            //Components.Insert(3, BubbleManComponent);

            // Write in new boss positions
            for (Int32 i = 0; i < 8; i++)
            {
                BossRoomRandomComponent bossroom = bossRoomComponents[i];
                in_Patch.Add(0x02C15E + i, bossroom.IntroValue, $"Boss Intro Value for Boss Room {i}");
                in_Patch.Add(0x02C057 + i, bossroom.AIPtrByte1, $"Boss AI Ptr Byte1 for Boss Room {i}");
                in_Patch.Add(0x02C065 + i, bossroom.AIPtrByte2, $"Boss AI Ptr Byte2 for Boss Room {i}");
                in_Patch.Add(0x02E4E9 + i, bossroom.GfxFix1, $"Boss GFX Fix 1 for Boss Room {i}");
                in_Patch.Add(0x02C166 + i, bossroom.GfxFix1, $"Boss GFX Fix 2 for Boss Room {i}");
                in_Patch.Add(0x02C14E + i, bossroom.YPosFix1, $"Boss Y-Pos Fix1 for Boss Room {i}");
                in_Patch.Add(0x02C156 + i, bossroom.YPosFix2, $"Boss Y-Pos Fix2 for Boss Room {i}");
            }

            // Adjust sprite banks for each boss room
            Int32[] spriteBankBossRoomAddresses =
            {
                0x0034A6, // Heat room
                0x0074A6, // Air room
                0x00B4DC, // Wood room
                0x00F4A6, // Bubble room
                0x0134B8, // Quick room
                0x0174A6, // Flash room
                0x01B494, // Metal room
                0x01F4DC, // Clash room
            };

            for (Int32 i = 0; i < spriteBankBossRoomAddresses.Length; i++)
            {
                for (Int32 j = 0; j < bossRoomComponents[i].SpriteBankSlotRowsBytes.Length; j++)
                {
                    in_Patch.Add(spriteBankBossRoomAddresses[i] + j,
                        bossRoomComponents[i].SpriteBankSlotRowsBytes[j], 
                        $"Boss Room {i} Sprite Bank Swap {j}");
                }
            }

            // Undo shuffling of damage values for each boss room
            Int32 contactDmgTbl = 0x2E9C2;
            Byte[] originalDmgVals = new Byte[] { 08,08,08,04,04,04,06,04 };
            Byte[] newDmgVals = new Byte[8];

            for (Int32 i = 0; i < bossRoomComponents.Count; i++)
            {
                newDmgVals[i] = originalDmgVals[bossRoomComponents[i].OriginalBossIndex];
                in_Patch.Add(contactDmgTbl + i, newDmgVals[i]);
            }


            this.Components = bossRoomComponents;
        }
    }
}
