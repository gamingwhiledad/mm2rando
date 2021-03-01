﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MM2Randomizer.Enums;
using MM2Randomizer.Patcher;
using MM2Randomizer.Random;

namespace MM2Randomizer.Randomizers
{
    public class RWeaknesses : IRandomizer
    {
        // Robot Master damage table. If RWeaknesses module is not enabled, these default values will be used.
        //           P H A W B F Q M C
        // Heatman   2 0 2 0 6 0 2 1 0
        // Airman    2 6 0 8 0 0 2 0 0
        // Woodman   1 A 4 0 0 0 0 2 2
        // Bubbleman 1 0 0 0 0 0 2 4 2
        // Quickman  2 A 2 0 0 1 0 0 4
        // Flashman  2 6 0 0 2 0 0 4 3
        // Metalman  1 4 0 0 0 0 4 A 0
        // Clashman  1 6 A 0 1 0 1 0 0
        public static Int32[,] BotWeaknesses = new Int32[8, 9]
        {
            { 2, 0, 2, 0, 6, 0, 2, 1, 0, },
            { 2, 6, 0, 8, 0, 0, 2, 0, 0, },
            { 1,10, 4, 0, 0, 0, 0, 2, 2, },
            { 1, 0, 0, 0, 0, 0, 2, 4, 2, },
            { 2,10, 2, 0, 0, 1, 0, 0, 4, },
            { 2, 6, 0, 0, 2, 0, 0, 4, 3, },
            { 1, 4, 0, 0, 0, 0, 4,10, 0, },
            { 1, 6,10, 0, 1, 0, 1, 0, 0, },
        };

        // Wily boss damage table. If module not enabled, these defaults will be used. Flash ignored.
        //        P H A W B Q M C
        // Dragon 1 8 0 0 0 1 0 1
        // Pico   1 3 0 0 A 7 7 0
        // Guts   1 8 0 0 1 2 0 1
        // Bueb   0 0 0 0 0 0 0 B
        // WilyM  1 E 1 0 0 1 1 4
        // Alien  X X X X 1 X X X
        public static Int32[,] WilyWeaknesses = new Int32[6, 8]
        {
            {  1,  8,  0,  0,  0,  1,  0,  1,},
            {  1,  3,  0,  0, 10,  7,  7,  0,},
            {  1,  8,  0,  0,  1,  2,  0,  1,},
            {  0,  0,  0,  0,  0,  0,  0, 20,},
            {  1, 10,  1,  0,  0,  1,  1,  4,},
            {255,255,255,255,  1,255,255,255,},
        };

        private Char[,] WilyWeaknessInfo = new Char[6, 8];

        private StringBuilder debug = new StringBuilder();
        public override String ToString()
        {
            return debug.ToString();
        }

        public RWeaknesses() { }

        public void Randomize(Patch in_Patch, ISeed in_Seed)
        {
            debug = new StringBuilder();
            RandomizeU(in_Patch, in_Seed);
            RandomizeWilyUJ(in_Patch, in_Seed);
        }

        /// <summary>
        /// Identical to RandomWeaknesses() but using Mega Man 2 (U).nes offsets
        /// </summary>
        private void RandomizeU(Patch in_Patch, ISeed in_Seed)
        {
            List<EDmgVsBoss> bossPrimaryWeaknessAddresses = EDmgVsBoss.GetTables(false, true);
            List<EDmgVsBoss> bossWeaknessShuffled = new List<EDmgVsBoss>(bossPrimaryWeaknessAddresses);
            bossWeaknessShuffled = in_Seed.Shuffle(bossWeaknessShuffled).ToList();

            // Preparation: Disable redundant Atomic Fire healing code
            // (Note that 0xFF in any weakness table is sufficient to heal a boss)
            in_Patch.Add(0x02E66D, 0xFF, "Atomic Fire Boss To Heal" ); // Normally "00" to indicate Heatman.

            // Select 4 robots to be weak against Buster
            List<Int32> busterList = in_Seed.Shuffle(new Int32[]{ 0, 1, 2, 3, 4, 5, 6, 7 }).ToList().GetRange(0, 4);

            // Select 2 robots to be very weak to some weapon
            List<Int32> veryWeakBots = in_Seed.Shuffle(new Int32[]{ 0, 1, 2, 3, 4, 5, 6, 7 }).ToList().GetRange(0, 2);
            Int32 bossWithGreatWeakness = veryWeakBots[0];
            Int32 bossWithUltimateWeakness = veryWeakBots[1];
            // Select 2 weapons to deal great damage to the 2 bosses above (exclude buster, flash)
            List<Int32> greatWeaknessWeapons = in_Seed.Shuffle(new Int32[] { 0, 1, 2, 3, 4, 5, 6, }).ToList().GetRange(0, 2);
            Int32 weaponGreatWeakness = greatWeaknessWeapons[0];
            Int32 weaponUltimateWeakness = greatWeaknessWeapons[1];


            // Foreach boss
            for (Int32 i = 0; i < 8; i++)
            {
                // First, fill in special weapon tables with a 50% chance to block or do 1 damage
                for (Int32 j = 0; j < bossPrimaryWeaknessAddresses.Count; j++)
                {
                    Double rTestImmune = in_Seed.NextDouble();
                    Byte damage = 0;
                    if (rTestImmune > 0.5)
                    {
                        if (bossPrimaryWeaknessAddresses[j] == EDmgVsBoss.U_DamageH)
                        {
                            // ...except for Atomic Fire, which will do some more damage
                            damage = (Byte)(RWeaponBehavior.AmmoUsage[1] / 2);
                        }
                        else if (bossPrimaryWeaknessAddresses[j] == EDmgVsBoss.U_DamageF)
                        {
                            damage = 0x00;
                        }
                        else
                        {
                            damage = 0x01;
                        }
                    }
                    in_Patch.Add(bossPrimaryWeaknessAddresses[j] + i, damage, String.Format("{0} Damage to {1}", bossPrimaryWeaknessAddresses[j].WeaponName, (EDmgVsBoss.Offset)i));
                    BotWeaknesses[i, j + 1] = damage;
                }

                // Write the primary weakness for this boss
                Byte dmgPrimary = RWeaknesses.GetRoboDamagePrimary(in_Seed, bossWeaknessShuffled[i]);
                in_Patch.Add(bossWeaknessShuffled[i] + i, dmgPrimary, $"{bossWeaknessShuffled[i].WeaponName} Damage to {(EDmgVsBoss.Offset)i} (Primary)");

                // Write the secondary weakness for this boss (next element in list)
                // Secondary weakness will either do 2 damage or 4 if it is Atomic Fire
                // Time Stopper cannot be a secondary weakness. Instead it will heal that boss.
                // As a result, one Robot Master will not have a secondary weakness
                Int32 i2 = (i + 1 >= 8) ? 0 : i + 1;
                EDmgVsBoss weakWeap2 = bossWeaknessShuffled[i2];
                Byte dmgSecondary = 0x02;
                if (weakWeap2 == EDmgVsBoss.U_DamageH)
                {
                    dmgSecondary = 0x04;
                }
                else if (weakWeap2 == EDmgVsBoss.U_DamageF)
                {
                    dmgSecondary = 0x00;

                    // Address in Time-Stopper code that normally heals Flashman, change to heal this boss instead
                    in_Patch.Add(0x02C08F, (Byte)i, $"Time-Stopper Heals {(EDmgVsBoss.Offset)i} (Special Code)");
                }
                in_Patch.Add(weakWeap2 + i, dmgSecondary, $"{weakWeap2.WeaponName} Damage to {(EDmgVsBoss.Offset)i} (Secondary)");
                        
                // Add buster damage
                if (busterList.Contains(i))
                {
                    in_Patch.Add(EDmgVsBoss.U_DamageP + i, 0x02, $"Buster Damage to {(EDmgVsBoss.Offset)i}");
                    BotWeaknesses[i, 0] = 0x02;
                }
                else
                {
                    in_Patch.Add(EDmgVsBoss.U_DamageP + i, 0x01, $"Buster Damage to {(EDmgVsBoss.Offset)i}");
                    BotWeaknesses[i, 0] = 0x01;
                }

                // Save info
                Int32 weapIndexPrimary = GetWeaponIndexFromAddress(bossWeaknessShuffled[i]);
                BotWeaknesses[i, weapIndexPrimary] = dmgPrimary;
                Int32 weapIndexSecondary = GetWeaponIndexFromAddress(weakWeap2);
                BotWeaknesses[i, weapIndexSecondary] = dmgSecondary;

                // Independently, apply a great weakness and an ultimate weakness (potentially overriding a previous weakness)
                if (bossWithGreatWeakness == i)
                {
                    // Great weakness. Can't be Buster or Flash. Deal 7 damage.
                    EDmgVsBoss wpn = EDmgVsBoss.GetTables(false, false)[weaponGreatWeakness];
                    in_Patch.Add(wpn.Address + i, 0x07, $"{wpn.WeaponName} Damage to {(EDmgVsBoss.Offset)i} (Great)");
                    BotWeaknesses[i, wpn.Index] = 0x07;
                }
                else if (bossWithUltimateWeakness == i)
                {
                    // Ultimate weakness. Can't be Buster or Flash. Deal 10 damage.
                    EDmgVsBoss wpn = EDmgVsBoss.GetTables(false, false)[weaponUltimateWeakness];
                    in_Patch.Add(wpn.Address + i, 0x0A, $"{wpn.WeaponName} Damage to {(EDmgVsBoss.Offset)i} (Ultimate)");
                    BotWeaknesses[i, wpn.Index] = 0x0A;
                }
            }

            // TODO: Fix this debug output, it's incorrect. It corresponds to the stages, not bosses. Needs
            // to be permuted based on random bosses in boss room.
            debug.AppendLine("Robot Master Weaknesses:");
            debug.AppendLine("P\tH\tA\tW\tB\tQ\tF\tM\tC:");
            debug.AppendLine("--------------------------------------------");
            for (Int32 i = 0; i < 8; i++)
            {
                for (Int32 j = 0; j < 9; j++)
                {
                    debug.Append(String.Format("{0}\t", BotWeaknesses[i, j]));
                }
                debug.AppendLine("< " + ((EDmgVsBoss.Offset)i).ToString());
            }
            debug.Append(Environment.NewLine);

        }

        /// <summary>
        /// Do 3 or 4 damage for high-ammo weapons, and ammo-damage + 1 for the others
        /// Time Stopper will always do 1 damage.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private static Byte GetRoboDamagePrimary(ISeed in_Seed, EDmgVsBoss weapon)
        {
            // Flat 25% chance to do 2 extra damage
            Byte damage = 0;
            Double rExtraDmg = in_Seed.NextDouble();
            if (rExtraDmg > 0.75)
            {
                damage = 2;
            }

            if (weapon == EDmgVsBoss.U_DamageH)
            {
                damage += (Byte)(RWeaponBehavior.AmmoUsage[1] + 1);
            }
            else if (weapon == EDmgVsBoss.U_DamageA)
            {
                damage += (Byte)(RWeaponBehavior.AmmoUsage[2] + 1);
            }
            else if (weapon == EDmgVsBoss.U_DamageW)
            {
                damage += (Byte)(RWeaponBehavior.AmmoUsage[3] + 1);
            }
            else if (weapon == EDmgVsBoss.U_DamageF)
            {
                return 1;
            }
            else if (weapon == EDmgVsBoss.U_DamageC)
            {
                damage += (Byte)(RWeaponBehavior.AmmoUsage[7] + 1);
            }

            // 50% chance to cap the minimum damage at 4, else cap minimum damage at 3
            rExtraDmg = in_Seed.NextDouble();
            if (rExtraDmg > 0.5)
            {
                if (damage < 4)
                {
                    damage = 4;
                }
            }
            else
            {
                if (damage < 3)
                {
                    damage = 3;
                }
            }

            return damage;
        }

        private static Int32 GetWeaponIndexFromAddress(EDmgVsBoss weaponAddress)
        {
            if (weaponAddress == EDmgVsBoss.U_DamageP)
            {
                return 0;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageH)
            {
                return 1;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageA)
            {
                return 2;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageW)
            {
                return 3;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageB)
            {
                return 4;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageQ)
            {
                return 5;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageF)
            {
                return 6;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageM)
            {
                return 7;
            }
            else if (weaponAddress == EDmgVsBoss.U_DamageC)
            {
                return 8;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void RandomizeWilyUJ(Patch in_Patch, ISeed in_Seed)
        {
                // List of special weapon damage tables for enemies
                List<EDmgVsEnemy> dmgPtrEnemies = EDmgVsEnemy.GetTables(false);
                EDmgVsEnemy enemyWeak1;
                EDmgVsEnemy enemyWeak2;
                EDmgVsEnemy enemyWeak3;

                // List of special weapon damage tables for bosses (no flash or buster)
                List<EDmgVsBoss> dmgPtrBosses = EDmgVsBoss.GetTables(false, false);
                EDmgVsBoss bossWeak1;
                EDmgVsBoss bossWeak2;
                EDmgVsBoss bossWeak3;
                EDmgVsBoss bossWeak4;

                #region Dragon

                // Dragon
                // 25% chance to have a buster vulnerability
                Double rBuster = in_Seed.NextDouble();
                Byte busterDmg = 0x00;

                if (rBuster > 0.75)
                {
                    busterDmg = 0x01;
                }

                in_Patch.Add(EDmgVsBoss.U_DamageP + EDmgVsBoss.Offset.Dragon, busterDmg, "Buster Damage to Dragon");
                WilyWeaknesses[0, 0] = busterDmg;

                // Choose 2 special weapon weaknesses
                List<EDmgVsBoss> dragon = new List<EDmgVsBoss>(dmgPtrBosses);
                Int32 rInt = in_Seed.NextInt32(dragon.Count);
                bossWeak1 = dragon[rInt];
                dragon.RemoveAt(rInt);
                rInt = in_Seed.NextInt32(dragon.Count);
                bossWeak2 = dragon[rInt];

                // For each weapon, apply the weaknesses and immunities
                for (Int32 i = 0; i < dmgPtrBosses.Count; i++)
                {
                    EDmgVsBoss weapon = dmgPtrBosses[i];

                    // Dragon weak
                    if (weapon == bossWeak1 || weapon == bossWeak2)
                    {
                        // Deal 1 damage with weapons that cost 1 or less ammo
                        Byte damage = 0x01;

                        // Deal damage = ammoUsage - 1, minimum 2 damage
                        if (RWeaponBehavior.AmmoUsage[i + 1] > 1)
                        {
                            Int32 tryDamage = (Int32)RWeaponBehavior.AmmoUsage[i + 1] - 0x01;
                            damage = (tryDamage < 2) ? (Byte)0x02 : (Byte)tryDamage;
                        }
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Dragon, damage, String.Format("{0} Damage to Dragon", weapon.WeaponName));
                        WilyWeaknesses[0, i + 1] = damage;
                    }
                    // Dragon immune
                    else
                    {
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Dragon, 0x00, String.Format("{0} Damage to Dragon", weapon.WeaponName));
                        WilyWeaknesses[0, i + 1] = 0x00;
                    }
                }

                #endregion

                #region Picopico-kun

                // Picopico-kun
                // 20 HP each
                // 25% chance for buster to deal 3-7 damage
                rBuster = in_Seed.NextDouble();
                busterDmg = 0x00;
                if (rBuster > 0.75)
                {
                    busterDmg = (Byte)(in_Seed.NextInt32(5) + 3);
                }
                in_Patch.Add(EDmgVsEnemy.DamageP + EDmgVsEnemy.Offset.PicopicoKun, busterDmg, String.Format("Buster Damage to Picopico-Kun"));
                WilyWeaknesses[1, 0] = busterDmg;

                // Deal ammoUse x 10 for the main weakness
                // Deal ammoUse x 6 for another
                // Deal ammoUse x 3 for another
                List<EDmgVsEnemy> pico = new List<EDmgVsEnemy>(dmgPtrEnemies);
                rInt = in_Seed.NextInt32(pico.Count);
                enemyWeak1 = pico[rInt];
                pico.RemoveAt(rInt);
                rInt = in_Seed.NextInt32(pico.Count);
                enemyWeak2 = pico[rInt];
                pico.RemoveAt(rInt);
                rInt = in_Seed.NextInt32(pico.Count);
                enemyWeak3 = pico[rInt];
                for (Int32 i = 0; i < dmgPtrEnemies.Count; i++)
                {
                    EDmgVsEnemy weapon = dmgPtrEnemies[i];
                    Byte damage = 0x00;
                    Char level = ' ';

                    if (weapon == enemyWeak1)
                    {
                        damage = (Byte)(RWeaponBehavior.AmmoUsage[i + 1] * 10);

                        if (damage < 2)
                        {
                            damage = 3;
                        }

                        level = '^';
                    }
                    else if (weapon == enemyWeak2)
                    {
                        damage = (Byte)(RWeaponBehavior.AmmoUsage[i + 1] * 6);

                        if (damage < 2)
                        {
                            damage = 2;
                        }

                        level = '*';
                    }
                    else if (weapon == enemyWeak3)
                    {
                        damage = (Byte)(RWeaponBehavior.AmmoUsage[i + 1] * 3);

                        if (damage < 2)
                        {
                            damage = 2;
                        }
                    }

                    // If any weakness is Atomic Fire, deal 20 damage
                    //if (weapon == EDmgVsEnemy.DamageH && (enemyWeak1 == weapon || enemyWeak2 == weapon || enemyWeak3 == weapon))
                    //{
                    //    damage = 20;
                    //}

                    // Bump up already high damage values to 20
                    if (damage >= 14)
                    {
                        damage = 20;
                    }
                    in_Patch.Add(weapon + EDmgVsEnemy.Offset.PicopicoKun, damage, String.Format("{0} Damage to Picopico-Kun{1}", weapon.WeaponName, level));
                    WilyWeaknesses[1, i + 1] = damage;
                    WilyWeaknessInfo[1, i + 1] = level;
                }

                #endregion

                #region Guts

                // Guts
                // 25% chance to have a buster vulnerability
                rBuster = in_Seed.NextDouble();
                busterDmg = 0x00;

                if (rBuster > 0.75)
                {
                    busterDmg = 0x01;
                }

                in_Patch.Add(EDmgVsBoss.U_DamageP + EDmgVsBoss.Offset.Guts, busterDmg, String.Format("Buster Damage to Guts Tank"));
                WilyWeaknesses[2, 0] = busterDmg;

                // Choose 2 special weapon weaknesses
                List<EDmgVsBoss> guts = new List<EDmgVsBoss>(dmgPtrBosses);
                rInt = in_Seed.NextInt32(guts.Count);
                bossWeak1 = guts[rInt];
                guts.RemoveAt(rInt);
                rInt = in_Seed.NextInt32(guts.Count);
                bossWeak2 = guts[rInt];

                for (Int32 i = 0; i < dmgPtrBosses.Count; i++)
                {
                    EDmgVsBoss weapon = dmgPtrBosses[i];

                    // Guts weak
                    if (weapon == bossWeak1 || weapon == bossWeak2)
                    {
                        // Deal 1 damage with weapons that cost 1 or less ammo
                        Byte damage = 0x01;

                        // Deal damage = ammoUsage - 1, minimum 2 damage
                        if (RWeaponBehavior.AmmoUsage[i + 1] > 1)
                        {
                            Int32 tryDamage = (Int32)RWeaponBehavior.AmmoUsage[i + 1] - 0x01;
                            damage = (tryDamage < 2) ? (Byte)0x02 : (Byte)tryDamage;
                        }
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Guts, damage, String.Format("{0} Damage to Guts Tank", weapon.WeaponName));
                        WilyWeaknesses[2, i + 1] = damage;
                    }
                    // Guts immune
                    else
                    {
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Guts, 0x00, String.Format("{0} Damage to Guts Tank", weapon.WeaponName));
                        WilyWeaknesses[2, i + 1] = 0x00;
                    }
                }

                #endregion

                #region Buebeam Trap

                // Buebeam
                // 5 Orbs + 3 Required Barriers (5 total barriers, 4 in speedrun route)
                // Choose a weakness for both Barriers and Orbs, scale damage to have plenty of energy
                // If the same weakness for both, scale damage further
                // If any weakness is Atomic Fire, ensure that there's enough ammo
                
                // Randomize Crash Barrier weakness
                List<EDmgVsEnemy> dmgBarrierList = EDmgVsEnemy.GetTables(true);

                // Remove Heat as possibility if it costs too much ammo
                if (RWeaponBehavior.AmmoUsage[1] > 5)
                {
                    dmgBarrierList.RemoveAt(1);
                    WilyWeaknesses[3, 1] = 0;
                }

                // Get Barrier weakness
                Int32 rBarrierWeakness = in_Seed.NextInt32(dmgBarrierList.Count);
                EDmgVsEnemy wpnBarrier = dmgBarrierList[rBarrierWeakness];

                // Scale damage to be slightly more capable than killing 5 barriers at full ammo
                Int32 dmgW4 = 0x01;
                if (wpnBarrier != EDmgVsEnemy.DamageP)
                {
                    Int32 totalShots = (Int32)(28 / RWeaponBehavior.GetAmmoUsage(wpnBarrier));
                    Int32 numHitsPerBarrier = (Int32)(totalShots / 5);

                    if (numHitsPerBarrier > 1)
                    {
                        numHitsPerBarrier--;
                    }

                    if (numHitsPerBarrier > 8)
                    {
                        numHitsPerBarrier = 8;
                    }

                    dmgW4 = (Int32)Math.Ceiling(20d / numHitsPerBarrier);
                }
                for (Int32 i = 0; i < dmgBarrierList.Count; i++)
                {
                    // Deal damage with weakness, and 0 for everything else
                    Byte damage = (Byte)dmgW4;
                    EDmgVsEnemy wpn = dmgBarrierList[i];
                    if (wpn != wpnBarrier)
                    {
                        damage = 0;
                    }
                    in_Patch.Add(wpn.Address + EDmgVsEnemy.Offset.ClashBarrier_W4, damage, String.Format("{0} Damage to Clash Barrier 1", wpn.WeaponName));
                    in_Patch.Add(wpn.Address + EDmgVsEnemy.Offset.ClashBarrier_Other, damage, String.Format("{0} Damage to Clash Barrier 2", wpn.WeaponName));
                }

                // Remove Barrier weakness from list first (therefore, different Buebeam weakness)
                dmgBarrierList.RemoveAt(rBarrierWeakness);

                // Get Buebeam weakness
                rInt = in_Seed.NextInt32(dmgBarrierList.Count);
                EDmgVsEnemy wpnBuebeam = dmgBarrierList[rInt];

                // Add Barrier weakness back to list for counting later
                dmgBarrierList.Insert(rBarrierWeakness, wpnBarrier);

                // Scale damage to be slightly more capable than killing 5 buebeams at full ammo
                dmgW4 = 0x01;
                if (wpnBuebeam != EDmgVsEnemy.DamageP)
                {
                    Int32 totalShots = (Int32)(28 / RWeaponBehavior.GetAmmoUsage(wpnBuebeam));
                    Int32 numHitsPerBuebeam = (Int32)(totalShots / 5);

                    if (numHitsPerBuebeam > 1)
                    {
                        numHitsPerBuebeam--;
                    }

                    if (numHitsPerBuebeam > 8)
                    {
                        numHitsPerBuebeam = 8;
                    }

                    dmgW4 = (Int32)Math.Ceiling(20d / numHitsPerBuebeam);
                }

                // Add Buebeam damage values to patch, as well as array for use by Text and other modules later
                for (Int32 i = 0; i < dmgBarrierList.Count; i++)
                {
                    Byte damage = (Byte)dmgW4;
                    EDmgVsEnemy wpn = dmgBarrierList[i];
                    if (wpn != wpnBuebeam)
                    {
                        damage = 0;
                    }
                    in_Patch.Add(wpn.Address + EDmgVsEnemy.Offset.Buebeam, damage, String.Format("{0} Damage to Buebeam Trap", wpnBuebeam.WeaponName));

                    // Add to damage table (skipping heat if necessary)
                    if (RWeaponBehavior.AmmoUsage[1] > 5 && i >= 1)
                    {
                        WilyWeaknesses[3, i + 1] = damage;
                    }
                    else
                    {
                        WilyWeaknesses[3, i] = damage;
                    }
                }

                #endregion

                #region Wily Machine

                // Machine
                // Will have 4 weaknesses and potentially a Buster weakness
                // Phase 1 will disable 2 of the weaknesses, taking no damage
                // Phase 2 will re-enable them, but disable 1 other weakness
                // Mega Man 2 behaves in a similar fashion, disabling Q and A in phase 1, but only disabling H in phase 2

                // 75% chance to have a buster vulnerability
                rBuster = in_Seed.NextDouble();
                busterDmg = 0x00;

                if (rBuster > 0.25)
                {
                    busterDmg = 0x01;
                }

                in_Patch.Add(EDmgVsBoss.U_DamageP + EDmgVsBoss.Offset.Machine, busterDmg, String.Format("Buster Damage to Wily Machine"));
                WilyWeaknesses[4, 0] = busterDmg;

                // Choose 4 special weapon weaknesses
                List<EDmgVsBoss> machine = new List<EDmgVsBoss>(dmgPtrBosses);
                rInt = in_Seed.NextInt32(machine.Count);
                bossWeak1 = machine[rInt];
                machine.RemoveAt(rInt);
                rInt = in_Seed.NextInt32(machine.Count);
                bossWeak2 = machine[rInt];
                machine.RemoveAt(rInt);
                rInt = in_Seed.NextInt32(machine.Count);
                bossWeak3 = machine[rInt];
                machine.RemoveAt(rInt);
                rInt = in_Seed.NextInt32(machine.Count);
                bossWeak4 = machine[rInt];

                for (Int32 i = 0; i < dmgPtrBosses.Count; i++)
                {
                    EDmgVsBoss weapon = dmgPtrBosses[i];

                    // Machine weak
                    if (weapon == bossWeak1 || weapon == bossWeak2 || weapon == bossWeak3 || weapon == bossWeak4)
                    {
                        // Deal 1 damage with weapons that cost 1 or less ammo
                        Byte damage = 0x01;

                        // Deal damage = ammoUsage
                        if (RWeaponBehavior.AmmoUsage[i + 1] > 1)
                        {
                            damage = (Byte)RWeaponBehavior.AmmoUsage[i + 1];
                        }
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Machine, damage, String.Format("{0} Damage to Wily Machine", weapon.WeaponName));
                        WilyWeaknesses[4, i + 1] = damage;
                    }
                    // Machine immune
                    else
                    {
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Machine, 0x00, String.Format("{0} Damage to Wily Machine", weapon.WeaponName));
                        WilyWeaknesses[4, i + 1] = 0x00;
                    }

                    // Get index of this weapon out of all weapons 0-8;
                    Byte wIndex = (Byte)(i + 1);

                    if (weapon == EDmgVsBoss.ClashBomber || weapon == EDmgVsBoss.MetalBlade)
                    {
                        wIndex++;
                    }

                    // Disable weakness 1 and 2 on Wily Machine Phase 1
                    if (weapon == bossWeak1)
                    {
                        in_Patch.Add(0x02DA2E, wIndex, String.Format("Wily Machine Phase 1 Resistance 1 ({0})", weapon.WeaponName));
                    }
                    if (weapon == bossWeak2)
                    {
                        in_Patch.Add(0x02DA32, wIndex, String.Format("Wily Machine Phase 1 Resistance 2 ({0})", weapon.WeaponName));
                    }
                    // Disable weakness 3 on Wily Machine Phase 2
                    if (weapon == bossWeak3)
                    {
                        in_Patch.Add(0x02DA3A, wIndex, String.Format("Wily Machine Phase 2 Resistance ({0})", weapon.WeaponName));
                    }
                }

                #endregion

                #region Alien

                // Alien
                // Buster Heat Air Wood Bubble Quick Clash Metal
                Byte alienDamage = 1;
                List<EDmgVsBoss> alienWeapons = EDmgVsBoss.GetTables(true, false);
                Int32 rWeaponIndex = in_Seed.NextInt32(alienWeapons.Count);

                // Deal two damage for 1-ammo weapons (or buster)
                if (RWeaponBehavior.AmmoUsage[rWeaponIndex] == 1)
                {
                    alienDamage = 2;
                }
                // For 2+ ammo use weapons, deal 20% more than that in damage, rounded up
                else if (RWeaponBehavior.AmmoUsage[rWeaponIndex] > 1)
                {
                    alienDamage = (Byte)Math.Ceiling(RWeaponBehavior.AmmoUsage[rWeaponIndex] * 1.2);
                }

                // Apply weakness and erase others (flash will remain 0xFF)
                for (Int32 i = 0; i < alienWeapons.Count; i++)
                {
                    EDmgVsBoss weapon = alienWeapons[i];

                    if (i == rWeaponIndex)
                    {
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Alien, alienDamage, String.Format("{0} Damage to Alien", weapon.WeaponName));
                        WilyWeaknesses[5, i] = alienDamage;
                    }
                    else
                    {
                        in_Patch.Add(weapon + EDmgVsBoss.Offset.Alien, 0xFF, String.Format("{0} Damage to Alien", weapon.WeaponName));
                        WilyWeaknesses[5, i] = 0xFF;
                    }
                }

                #endregion

                debug.AppendLine("Wily Boss Weaknesses:");
                debug.AppendLine("P\tH\tA\tW\tB\tQ\tF\tM\tC:");
                debug.AppendLine("--------------------------------------------");
                for (Int32 i = 0; i < WilyWeaknesses.GetLength(0); i++)
                {
                    for (Int32 j = 0; j < WilyWeaknesses.GetLength(1); j++)
                    {
                        debug.Append(String.Format("{0}\t", WilyWeaknesses[i, j]));

                        if (j == 5)
                        {
                            debug.Append("X\t"); // skip flash
                        }
                    }
                    String bossName = "";
                    switch (i)
                    {
                        case 0:
                            bossName = "dragon";
                            break;
                        case 1:
                            bossName = "picopico-kun";
                            break;
                        case 2:
                            bossName = "guts";
                            break;
                        case 3:
                            bossName = "boobeam";
                            break;
                        case 4:
                            bossName = "machine";
                            break;
                        case 5:
                            bossName = "alien";
                            break;
                        default: break;
                    }
                    debug.AppendLine("< " + bossName);
                }
                debug.Append(Environment.NewLine);

        } // End method RandomizeWilyUJ


    } 
}
