﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MM2Randomizer.Enums;
using MM2Randomizer.Extensions;
using MM2Randomizer.Patcher;
using MM2Randomizer.Random;

namespace MM2Randomizer.Randomizers.Stages
{
    public class RStages : IRandomizer
    {
        private List<StageFromSelect> StageSelect;
        private StringBuilder debug = new StringBuilder();

        public RStages() { }

        public override String ToString()
        {
            return debug.ToString();
        }

        public void FixPortraits(ref Byte[] portraitBG_x, ref Byte[] portraitBG_y)
        {
            // Get the new stage order
            Int32[] newOrder = new Int32[8];
            foreach (StageFromSelect stage in StageSelect)
            {
                newOrder[stage.PortraitDestinationOriginal] = stage.PortraitDestinationNew;
            }

            // Permute portrait x/y values via the shuffled stage-order array 
            Byte[] cpy = new Byte[8];

            for (Int32 i = 0; i < 8; i++)
            {
                cpy[newOrder[i]] = portraitBG_y[i];
            }

            Array.Copy(cpy, portraitBG_y, 8);

            for (Int32 i = 0; i < 8; i++)
            {
                cpy[newOrder[i]] = portraitBG_x[i];
            }

            Array.Copy(cpy, portraitBG_x, 8);
        }

        /// <summary>
        /// Shuffle the Robot Master stages.  This shuffling will not be indicated by the Robot Master portraits.
        /// </summary>
        public void Randomize(Patch in_Patch, ISeed in_Seed)
        {
            // StageSelect  Address    Value
            // -----------------------------
            // Bubble Man   0x034670   3
            // Air Man      0x034671   1
            // Quick Man    0x034672   4
            // Wood Man     0x034673   2
            // Crash Man    0x034674   7
            // Flash Man    0x034675   5
            // Metal Man    0x034676   6
            // Heat Man     0x034677   0

            StageSelect = new List<StageFromSelect>();

            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Bubble Man",
                PortraitAddress = ERMPortraitAddress.BubbleMan,
                PortraitDestinationOriginal = 3,
                PortraitDestinationNew = 3,
                StageClearAddress = ERMStageClearAddress.BubbleMan,
                StageClearDestinationOriginal = 8,
                StageClearDestinationNew = 8,
                TextAddress = ERMPortraitText.BubbleMan,
                TextValues = "BUBBLE",
            });
            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Air Man",
                PortraitAddress = ERMPortraitAddress.AirMan,
                PortraitDestinationOriginal = 1,
                PortraitDestinationNew = 1,
                StageClearAddress = ERMStageClearAddress.AirMan,
                StageClearDestinationOriginal = 2,
                StageClearDestinationNew = 2,
                TextAddress = ERMPortraitText.AirMan,
                TextValues = "`AIR```"
            });
            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Quick Man",
                PortraitAddress = ERMPortraitAddress.QuickMan,
                PortraitDestinationOriginal = 4,
                PortraitDestinationNew = 4,
                StageClearAddress = ERMStageClearAddress.QuickMan,
                StageClearDestinationOriginal = 16,
                StageClearDestinationNew = 16,
                TextAddress = ERMPortraitText.QuickMan,
                TextValues = "QUICK`"
            });
            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Wood Man",
                PortraitAddress = ERMPortraitAddress.WoodMan,
                PortraitDestinationOriginal = 2,
                PortraitDestinationNew = 2,
                StageClearAddress = ERMStageClearAddress.WoodMan,
                StageClearDestinationOriginal = 4,
                StageClearDestinationNew = 4,
                TextAddress = ERMPortraitText.WoodMan,
                TextValues = "WOOD``",
            });
            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Clash Man",
                PortraitAddress = ERMPortraitAddress.CrashMan,
                PortraitDestinationOriginal = 7,
                PortraitDestinationNew = 7,
                StageClearAddress = ERMStageClearAddress.CrashMan,
                StageClearDestinationOriginal = 128,
                StageClearDestinationNew = 128,
                TextAddress = ERMPortraitText.CrashMan,
                TextValues = "CRASH`",
            });
            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Flash Man",
                PortraitAddress = ERMPortraitAddress.FlashMan,
                PortraitDestinationOriginal = 5,
                PortraitDestinationNew = 5,
                StageClearAddress = ERMStageClearAddress.FlashMan,
                StageClearDestinationOriginal = 32,
                StageClearDestinationNew = 32,
                TextAddress = ERMPortraitText.FlashMan,
                TextValues = "FLASH`",
            });
            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Metal Man",
                PortraitAddress = ERMPortraitAddress.MetalMan,
                PortraitDestinationOriginal = 6,
                PortraitDestinationNew = 6,
                StageClearAddress = ERMStageClearAddress.MetalMan,
                StageClearDestinationOriginal = 64,
                StageClearDestinationNew = 64,
                TextAddress = ERMPortraitText.MetalMan,
                TextValues = "METAL`",
            });
            StageSelect.Add(new StageFromSelect()
            {
                PortraitName = "Heat Man",
                PortraitAddress = ERMPortraitAddress.HeatMan,
                PortraitDestinationOriginal = 0,
                PortraitDestinationNew = 0, // 4 = quick
                StageClearAddress = ERMStageClearAddress.HeatMan,
                StageClearDestinationOriginal = 1,
                StageClearDestinationNew = 1,
                TextAddress = ERMPortraitText.HeatMan,
                TextValues = "HEAT``",
            });


            List<Byte> newStageOrder = new List<Byte>();

            for (Byte i = 0; i < 8; i++)
            {
                newStageOrder.Add(i);
            }

            newStageOrder = in_Seed.Shuffle(newStageOrder).ToList();

            debug.AppendLine("Stage Select:");
            for (Int32 i = 0; i < 8; i++)
            {
                StageFromSelect stage = StageSelect[i];

                // Change portrait destination
                stage.PortraitDestinationNew = StageSelect[newStageOrder[i]].PortraitDestinationOriginal;

                // Erase the portrait text if StageNameHidden flag is set
                if (RandomMM2.Settings.IsStageNameHidden)
                {
                    for (Int32 k = 0; k < 6; k++)
                    {
                        // Write in a blank space at each letter ('f' by my cipher)
                        in_Patch.Add((Int32)stage.TextAddress + k, '`'.AsCreditsCharacter(), $"Hide Stage Select Portrait Text");
                    }

                    for (Int32 k = 0; k < 3; k++)
                    {
                        // Write in a blank space over "MAN"; 32 8-pixel tiles until the next row, 3 tiles until "MAN" text
                        in_Patch.Add((Int32)stage.TextAddress + 32 + 3 + k, '`'.AsCreditsCharacter(), $"Hide Stage Select Portrait Text");
                    }
                }
                // Change portrait text to match new destination
                else
                {
                    String newlabel = StageSelect[newStageOrder[i]].TextValues;
                    for (Int32 j = 0; j < newlabel.Length; j++)
                    {
                        Char c = newlabel[j];
                        in_Patch.Add((Int32)stage.TextAddress + j, c.AsCreditsCharacter(), $"Stage Select Portrait Text");
                    }
                }

                debug.AppendLine($"{Enum.GetName(typeof(EStageID), stage.PortraitDestinationOriginal)}'s portrait -> {Enum.GetName(typeof(EStageID), StageSelect[i].PortraitDestinationNew)} stage");
            }

            foreach (StageFromSelect stage in StageSelect)
            {
                in_Patch.Add((Int32)stage.PortraitAddress, (Byte)stage.PortraitDestinationNew, $"Stage Select {stage.PortraitName} Destination");
            }
        }
    }

}
