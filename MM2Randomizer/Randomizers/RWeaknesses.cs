﻿using System.Collections.Generic;
using System.IO;

using MM2Randomizer.Enums;
using System;

namespace MM2Randomizer.Randomizers
{
    public class RWeaknesses
    {
        public static bool IsChaos = true;
        public static int[,] BotWeaknesses = new int[8, 9];
        public static int[,] WilyWeaknesses = new int[5, 8];

        public RWeaknesses(bool isChaos)
        {
            IsChaos = isChaos;

            if (RandomMM2.Settings.IsJapanese)
            {
                RandomizeJ();
            }
            else
            {
                RandomizeU();
            }
            RandomizeWilyUJ();
        }

        /// <summary>
        /// Modify the damage values of each weapon against each Robot Master for Rockman 2 (J).
        /// </summary>
        private static void RandomizeJ()
        {
            List<WeaponTable> Weapons = new List<WeaponTable>();

            Weapons.Add(new WeaponTable()
            {
                Name = "Buster",
                ID = 0,
                Address = EDmgVsBoss.Buster,
                RobotMasters = new int[8] { 2, 2, 1, 1, 2, 2, 1, 1 }
                // Heat = 2,
                // Air = 2,
                // Wood = 1,
                // Bubble = 1,
                // Quick = 2,
                // Flash = 2,
                // Metal = 1,
                // Clash = 1,
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Atomic Fire",
                ID = 1,
                Address = EDmgVsBoss.AtomicFire,
                // Note: These values only affect a fully charged shot.  Partially charged shots use the Buster table.
                RobotMasters = new int[8] { 0xFF, 6, 0x0E, 0, 0x0A, 6, 4, 6 }
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Air Shooter",
                ID = 2,
                Address = EDmgVsBoss.AirShooter,
                RobotMasters = new int[8] { 2, 0, 4, 0, 2, 0, 0, 0x0A }
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Leaf Shield",
                ID = 3,
                Address = EDmgVsBoss.LeafShield,
                RobotMasters = new int[8] { 0, 8, 0xFF, 0, 0, 0, 0, 0 }
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Bubble Lead",
                ID = 4,
                Address = EDmgVsBoss.BubbleLead,
                RobotMasters = new int[8] { 6, 0, 0, 0xFF, 0, 2, 0, 1 }
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Quick Boomerang",
                ID = 5,
                Address = EDmgVsBoss.QuickBoomerang,
                RobotMasters = new int[8] { 2, 2, 0, 2, 0, 0, 4, 1 }
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Time Stopper",
                ID = 6,
                Address = EDmgVsBoss.TimeStopper,
                // NOTE: These values affect damage per tick
                RobotMasters = new int[8] { 0, 0, 0, 0, 1, 0, 0, 0 }
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Metal Blade",
                ID = 7,
                Address = EDmgVsBoss.MetalBlade,
                RobotMasters = new int[8] { 1, 0, 2, 4, 0, 4, 0x0E, 0 }
            });

            Weapons.Add(new WeaponTable()
            {
                Name = "Clash Bomber",
                ID = 8,
                Address = EDmgVsBoss.ClashBomber,
                RobotMasters = new int[8] { 0xFF, 0, 2, 2, 4, 3, 0, 0 }
            });

            foreach (WeaponTable weapon in Weapons)
            {
                weapon.RobotMasters.Shuffle(RandomMM2.Random);
            }

            using (var stream = new FileStream(RandomMM2.DestinationFileName, FileMode.Open, FileAccess.ReadWrite))
            {
                foreach (WeaponTable weapon in Weapons)
                {
                    stream.Position = (long)weapon.Address;
                    for (int i = 0; i < 8; i++)
                    {
                        stream.WriteByte((byte)weapon.RobotMasters[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Identical to RandomWeaknesses() but using Mega Man 2 (U).nes offsets
        /// </summary>
        private static void RandomizeU()
        {
            // Chaos Mode Weaknesses
            if (IsChaos)
            {
                using (var stream = new FileStream(RandomMM2.DestinationFileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    List<EDmgVsBoss> bossPrimaryWeaknessAddresses = EDmgVsBoss.GetTables(false, true);
                    List<EDmgVsBoss> bossShuffled = new List<EDmgVsBoss>(bossPrimaryWeaknessAddresses);
                    bossShuffled.Shuffle(RandomMM2.Random);

                    // Preparation: Disable redundant Atomic Fire healing code
                    // (Note that 0xFF in any weakness table is sufficient to heal a boss)
                    stream.Position = 0x02EE6D;
                    stream.WriteByte(0xFF); // Normally "00" to indicate Heatman.

                    // Select 2 robots to be weak against Buster
                    int busterI1 = RandomMM2.Random.Next(8);
                    int busterI2 = busterI1;
                    while (busterI2 == busterI1)
                        busterI2 = RandomMM2.Random.Next(8);

                    // Foreach boss
                    for (int i = 0; i < 8; i++)
                    {
                        // First, fill in special weapon tables with a 50% chance to block or do 1 damage
                        for (int j = 0; j < bossPrimaryWeaknessAddresses.Count; j++)
                        {
                            double rTestImmune = RandomMM2.Random.NextDouble();
                            byte damage = 0;
                            if (rTestImmune > 0.5)
                            {
                                if (bossPrimaryWeaknessAddresses[j] == EDmgVsBoss.U_DamageH)
                                {
                                    // ...except for Atomic Fire, which will do some more damage
                                    damage = (byte)(RWeaponBehavior.AmmoUsage[1] / 2);
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
                            stream.Position = bossPrimaryWeaknessAddresses[j] + i;
                            stream.WriteByte(damage);

                            BotWeaknesses[i, j + 1] = damage;
                        }

                        // Write the primary weakness for this boss
                        stream.Position = bossShuffled[i] + i;
                        byte dmgPrimary = GetRoboDamagePrimary(bossShuffled[i]);
                        stream.WriteByte(dmgPrimary);

                        // Write the secondary weakness for this boss (next element in list)
                        // Secondary weakness will either do 2 damage or 4 if it is Atomic Fire
                        // Time Stopper cannot be a secondary weakness. Instead it will heal that boss.
                        // As a result, one Robot Master will not have a secondary weakness
                        int i2 = (i + 1 >= 8) ? 0 : i + 1;
                        EDmgVsBoss weakWeap2 = bossShuffled[i2];
                        stream.Position = weakWeap2 + i;
                        byte dmgSecondary = 0x02;
                        if (weakWeap2 == EDmgVsBoss.U_DamageH)
                        {
                            dmgSecondary = 0x04;
                        }
                        else if (weakWeap2 == EDmgVsBoss.U_DamageF)
                        {
                            dmgSecondary = 0x00;
                            long prevStreamPos = stream.Position;
                            stream.Position = 0x02C08F; // Address in Time-Stopper code that normally heals Flashman
                            stream.WriteByte((byte)i);  // Change to this Robot Master's byte

                            stream.Position = prevStreamPos;
                        }
                        stream.WriteByte(dmgSecondary);
                        
                        // Add buster damage
                        stream.Position = EDmgVsBoss.U_DamageP + i;
                        if (i == busterI1 || i == busterI2)
                        {
                            stream.WriteByte(0x02);
                            BotWeaknesses[i, 0] = 0x02;
                        }
                        else
                        {
                            stream.WriteByte(0x01);
                            BotWeaknesses[i, 0] = 0x01;
                        }

                        // Save info
                        int weapIndexPrimary = GetWeaponIndexFromAddress(bossShuffled[i]);
                        BotWeaknesses[i, weapIndexPrimary] = dmgPrimary;
                        int weapIndexSecondary = GetWeaponIndexFromAddress(weakWeap2);
                        BotWeaknesses[i, weapIndexSecondary] = dmgSecondary;
                    }

                    Console.WriteLine("Robot Master Weaknesses:");
                    Console.WriteLine("P\tH\tA\tW\tB\tQ\tF\tM\tC:");
                    Console.WriteLine("--------------------------------------------");
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            Console.Write("{0}\t", BotWeaknesses[i, j]);
                        }
                        Console.WriteLine("< " + ((EDmgVsBoss.Offset)i).ToString());
                    }
                    Console.WriteLine();
                }
            }

            // Easy Mode Weaknesses
            else
            {
                List<WeaponTable> Weapons = new List<WeaponTable>();

                Weapons.Add(new WeaponTable()
                {
                    Name = "Buster",
                    ID = 0,
                    Address = EDmgVsBoss.U_DamageP,
                    RobotMasters = new int[8] { 2, 2, 1, 1, 2, 2, 1, 1 }
                    // Heat = 2,
                    // Air = 2,
                    // Wood = 1,
                    // Bubble = 1,
                    // Quick = 2,
                    // Flash = 2,
                    // Metal = 1,
                    // Clash = 1,
                    // Dragon = 1
                    // Byte Unused = 0
                    // Gutsdozer = 1
                    // Unused = 0
                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Atomic Fire",
                    ID = 1,
                    Address = EDmgVsBoss.U_DamageH,
                    // Note: These values only affect a fully charged shot.  Partially charged shots use the Buster table.
                    RobotMasters = new int[8] { 0xFF, 6, 0x0E, 0, 0x0A, 6, 4, 6 }
                    // Dragon = 8
                    // Gutsdozer = 8
                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Air Shooter",
                    ID = 2,
                    Address = EDmgVsBoss.U_DamageA,
                    RobotMasters = new int[8] { 2, 0, 4, 0, 2, 0, 0, 0x0A }
                    // Dragon = 0
                    // Gutsdozer = 0
                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Leaf Shield",
                    ID = 3,
                    Address = EDmgVsBoss.U_DamageW,
                    RobotMasters = new int[8] { 0, 8, 0xFF, 0, 0, 0, 0, 0 }
                    // Dragon = 0
                    // Unused = 0
                    // Gutsdozer = 0
                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Bubble Lead",
                    ID = 4,
                    Address = EDmgVsBoss.U_DamageB,
                    RobotMasters = new int[8] { 6, 0, 0, 0xFF, 0, 2, 0, 1 }
                    // Dragon = 0
                    // Unused = 0
                    // Gutsdozer = 1
                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Quick Boomerang",
                    ID = 5,
                    Address = EDmgVsBoss.U_DamageQ,
                    RobotMasters = new int[8] { 2, 2, 0, 2, 0, 0, 4, 1 }
                    // Dragon = 1
                    // Unused = 0
                    // Gutsdozer = 2
                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Time Stopper",
                    ID = 6,
                    Address = EDmgVsBoss.U_DamageF,
                    // NOTE: These values affect damage per tick
                    // NOTE: This table only has robot masters, no wily bosses
                    RobotMasters = new int[8] { 0, 0, 0, 0, 1, 0, 0, 0 }

                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Metal Blade",
                    ID = 7,
                    Address = EDmgVsBoss.U_DamageM,
                    RobotMasters = new int[8] { 1, 0, 2, 4, 0, 4, 0x0E, 0 }
                    // Dragon = 0
                    // Unused = 0
                    // Gutsdozer = 0
                });

                Weapons.Add(new WeaponTable()
                {
                    Name = "Clash Bomber",
                    ID = 8,
                    Address = EDmgVsBoss.U_DamageC,
                    RobotMasters = new int[8] { 0xFF, 0, 2, 2, 4, 3, 0, 0 }
                    // Dragon = 1
                    // Unused = 0
                    // Gutsdozer = 1
                });

                foreach (WeaponTable weapon in Weapons)
                {
                    weapon.RobotMasters.Shuffle(RandomMM2.Random);
                }

                using (var stream = new FileStream(RandomMM2.DestinationFileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    foreach (WeaponTable weapon in Weapons)
                    {
                        stream.Position = (long)weapon.Address;
                        for (int i = 0; i < 8; i++)
                        {
                            stream.WriteByte((byte)weapon.RobotMasters[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Do 3 damage for high-ammo weapons, and ammo-damage + 1 for the others
        /// Time Stopper will always do 1 damage.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        private static byte GetRoboDamagePrimary(EDmgVsBoss weapon)
        {
            // Flat 25% chance to do 2 extra damage
            byte damage = 0;
            double rExtraDmg = RandomMM2.Random.NextDouble();
            if (rExtraDmg > 0.75)
            {
                damage = 2;
            }

            if (weapon == EDmgVsBoss.U_DamageH)
                damage += (byte)(RWeaponBehavior.AmmoUsage[1] + 1);
            else if (weapon == EDmgVsBoss.U_DamageA)
                damage += (byte)(RWeaponBehavior.AmmoUsage[2] + 1);
            else if (weapon == EDmgVsBoss.U_DamageW)
                damage += (byte)(RWeaponBehavior.AmmoUsage[3] + 1);
            else if (weapon == EDmgVsBoss.U_DamageF)
                return 1;
            else if (weapon == EDmgVsBoss.U_DamageC)
                damage += (byte)(RWeaponBehavior.AmmoUsage[7] + 1);
            
            if (damage < 3) damage = 3;
            return damage;
        }

        private static int GetWeaponIndexFromAddress(EDmgVsBoss weaponAddress)
        {
            if      (weaponAddress == EDmgVsBoss.U_DamageP)
                return 0;
            else if (weaponAddress == EDmgVsBoss.U_DamageH)
                return 1;
            else if (weaponAddress == EDmgVsBoss.U_DamageA)
                return 2;
            else if (weaponAddress == EDmgVsBoss.U_DamageW)
                return 3;
            else if (weaponAddress == EDmgVsBoss.U_DamageB)
                return 4;
            else if (weaponAddress == EDmgVsBoss.U_DamageQ)
                return 5;
            else if (weaponAddress == EDmgVsBoss.U_DamageF)
                return 6;
            else if (weaponAddress == EDmgVsBoss.U_DamageM)
                return 7;
            else if (weaponAddress == EDmgVsBoss.U_DamageC)
                return 8;
            else return -1;
        }

        /// <summary>
        /// TODO
        /// </summary>
        private static void RandomizeWilyUJ()
        {
            using (var stream = new FileStream(RandomMM2.DestinationFileName, FileMode.Open, FileAccess.ReadWrite))
            {
                if (IsChaos)
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

                    #region Dragon

                    // Dragon
                    // 25% chance to have a buster vulnerability
                    double rBuster = RandomMM2.Random.NextDouble();
                    byte busterDmg = 0x00;
                    if (rBuster > 0.75)
                        busterDmg = 0x01;
                    stream.Position = EDmgVsBoss.U_DamageP + EDmgVsBoss.Offset.Dragon;
                    stream.WriteByte(busterDmg);
                    WilyWeaknesses[0, 0] = busterDmg;

                    // Choose 2 special weapon weaknesses
                    List<EDmgVsBoss> dragon = new List<EDmgVsBoss>(dmgPtrBosses);
                    int rInt = RandomMM2.Random.Next(dragon.Count);
                    bossWeak1 = dragon[rInt];
                    dragon.RemoveAt(rInt);
                    rInt = RandomMM2.Random.Next(dragon.Count);
                    bossWeak2 = dragon[rInt];

                    // For each weapon, apply the weaknesses and immunities
                    for (int i = 0; i < dmgPtrBosses.Count; i++)
                    {
                        EDmgVsBoss weapon = dmgPtrBosses[i];
                        stream.Position = weapon + EDmgVsBoss.Offset.Dragon;

                        // Dragon weak
                        if (weapon == bossWeak1 || weapon == bossWeak2)
                        {
                            // Deal 1 damage with weapons that cost 1 or less ammo
                            byte damage = 0x01;
                            
                            // Deal damage = ammoUsage - 1, minimum 2 damage
                            if (RWeaponBehavior.AmmoUsage[i+1] > 1)
                            {
                                int tryDamage = (int)RWeaponBehavior.AmmoUsage[i+1] - 0x01;
                                damage = (tryDamage < 2) ? (byte)0x02 : (byte)tryDamage;
                            }
                            stream.WriteByte(damage);
                            WilyWeaknesses[0, i + 1] = damage;
                        }
                        // Dragon immune
                        else
                        {
                            stream.WriteByte(0x00);
                            WilyWeaknesses[0, i + 1] = 0x00;
                        }
                    }

                    #endregion

                    #region Picopico-kun

                    // Picopico-kun
                    // 20 HP each
                    // 25% chance for buster to deal 3-7 damage
                    rBuster = RandomMM2.Random.NextDouble();
                    busterDmg = 0x00;
                    if (rBuster > 0.75)
                    {
                        busterDmg = (byte)(RandomMM2.Random.Next(5) + 3);
                    }
                    stream.Position = EDmgVsEnemy.DamageP + EDmgVsEnemy.Offset.PicopicoKun;
                    stream.WriteByte(busterDmg);
                    WilyWeaknesses[1, 0] = busterDmg;

                    // Deal ammoUse x 6 for the main weakness
                    // Deal ammoUse x 2 for another
                    // Deal ammoUse x 1 for another
                    List<EDmgVsEnemy> pico = new List<EDmgVsEnemy>(dmgPtrEnemies);
                    rInt = RandomMM2.Random.Next(pico.Count);
                    enemyWeak1 = pico[rInt];
                    pico.RemoveAt(rInt);
                    rInt = RandomMM2.Random.Next(pico.Count);
                    enemyWeak2 = pico[rInt];
                    pico.RemoveAt(rInt);
                    rInt = RandomMM2.Random.Next(pico.Count);
                    enemyWeak3 = pico[rInt];
                    for (int i = 0; i < dmgPtrEnemies.Count; i++)
                    {
                        EDmgVsEnemy weapon = dmgPtrEnemies[i];
                        stream.Position = weapon + EDmgVsEnemy.Offset.PicopicoKun;
                        byte damage = 0x00;

                        // Pico weakness 1, deal ammoUse x6 damage
                        if (weapon == enemyWeak1)
                        {
                            damage = (byte)(RWeaponBehavior.AmmoUsage[i + 1] * 6);
                            if (damage < 2) damage = 2;
                        }
                        // weakness 2, deal ammoUse x2 damage
                        else if (weapon == enemyWeak2)
                        {
                            damage = (byte)(RWeaponBehavior.AmmoUsage[i + 1] * 2);
                            if (damage < 2) damage = 2;
                        }
                        // weakness 3, deal ammoUse x1 damage
                        else if (weapon == enemyWeak3)
                        {
                            damage = (byte)(RWeaponBehavior.AmmoUsage[i + 1]);
                            if (damage < 2) damage = 2;
                        }

                        // If any weakness is Atomic Fire, deal either 10 or 20 damage (1 shot or 2 shot)
                        if (weapon == EDmgVsEnemy.DamageH && ( enemyWeak1 == weapon || enemyWeak2 == weapon || enemyWeak3 == weapon ))
                        {
                            double rPicoHeat = RandomMM2.Random.Next(pico.Count);
                            damage = (rPicoHeat > 0.5) ? (byte)0x0A : (byte)0x14;
                        }

                        stream.WriteByte(damage);
                        WilyWeaknesses[1, i + 1] = damage;
                    }

                    #endregion

                    #region Guts

                    // Guts
                    // 25% chance to have a buster vulnerability
                    rBuster = RandomMM2.Random.NextDouble();
                    busterDmg = 0x00;
                    if (rBuster > 0.75)
                        busterDmg = 0x01;
                    stream.Position = EDmgVsBoss.U_DamageP + EDmgVsBoss.Offset.Guts;
                    stream.WriteByte(busterDmg);
                    WilyWeaknesses[2, 0] = busterDmg;

                    // Choose 2 special weapon weaknesses
                    List<EDmgVsBoss> guts = new List<EDmgVsBoss>(dmgPtrBosses);
                    rInt = RandomMM2.Random.Next(guts.Count);
                    bossWeak1 = guts[rInt];
                    guts.RemoveAt(rInt);
                    rInt = RandomMM2.Random.Next(guts.Count);
                    bossWeak2 = guts[rInt];

                    for (int i = 0; i < dmgPtrBosses.Count; i++)
                    {
                        EDmgVsBoss weapon = dmgPtrBosses[i];
                        stream.Position = weapon + EDmgVsBoss.Offset.Guts;

                        // Guts weak
                        if (weapon == bossWeak1 || weapon == bossWeak2)
                        {
                            // Deal 1 damage with weapons that cost 1 or less ammo
                            byte damage = 0x01;

                            // Deal damage = ammoUsage - 1, minimum 2 damage
                            if (RWeaponBehavior.AmmoUsage[i+1] > 1)
                            {
                                int tryDamage = (int)RWeaponBehavior.AmmoUsage[i+1] - 0x01;
                                damage = (tryDamage < 2) ? (byte)0x02 : (byte)tryDamage;
                            }
                            stream.WriteByte(damage);
                            WilyWeaknesses[2, i + 1] = damage;
                        }
                        // Guts immune
                        else
                        {
                            stream.WriteByte(0x00);
                            WilyWeaknesses[2, i + 1] = 0x00;
                        }
                    }

                    #endregion

                    #region Wily Machine

                    // Machine
                    // 75% chance to have a buster vulnerability
                    rBuster = RandomMM2.Random.NextDouble();
                    busterDmg = 0x00;
                    if (rBuster > 0.25)
                        busterDmg = 0x01;
                    stream.Position = EDmgVsBoss.U_DamageP + EDmgVsBoss.Offset.Machine;
                    stream.WriteByte(busterDmg);
                    WilyWeaknesses[2, 0] = busterDmg;

                    // Choose 3 special weapon weaknesses
                    List<EDmgVsBoss> machine = new List<EDmgVsBoss>(dmgPtrBosses);
                    rInt = RandomMM2.Random.Next(machine.Count);
                    bossWeak1 = machine[rInt];
                    machine.RemoveAt(rInt);
                    rInt = RandomMM2.Random.Next(machine.Count);
                    bossWeak2 = machine[rInt];
                    machine.RemoveAt(rInt);
                    rInt = RandomMM2.Random.Next(machine.Count);
                    EDmgVsBoss weakness3 = machine[rInt];

                    for (int i = 0; i < dmgPtrBosses.Count; i++)
                    {
                        EDmgVsBoss weapon = dmgPtrBosses[i];
                        stream.Position = weapon + EDmgVsBoss.Offset.Machine;

                        // Machine weak
                        if (weapon == bossWeak1 || weapon == bossWeak2 || weapon == weakness3)
                        {
                            // Deal 1 damage with weapons that cost 1 or less ammo
                            byte damage = 0x01;

                            // Deal damage = ammoUsage
                            if (RWeaponBehavior.AmmoUsage[i+1] > 1)
                            {
                                damage = (byte)RWeaponBehavior.AmmoUsage[i+1];
                            }
                            stream.WriteByte(damage);
                            WilyWeaknesses[3, i + 1] = damage;
                        }
                        // Machine immune
                        else
                        {
                            stream.WriteByte(0x00);
                            WilyWeaknesses[3, i + 1] = 0x00;
                        }
                    }

                    #endregion

                    #region Alien

                    // Alien
                    // Buster Heat Air Wood Bubble Quick Clash Metal
                    byte alienDamage = 1;
                    List<EDmgVsBoss> alienWeapons = EDmgVsBoss.GetTables(true, false);
                    int rWeaponIndex = RandomMM2.Random.Next(alienWeapons.Count);

                    // Deal two damage for 1-ammo weapons (or buster)
                    if (RWeaponBehavior.AmmoUsage[rWeaponIndex] == 1)
                    {
                        alienDamage = 2;
                    }
                    // For 2+ ammo use weapons, deal 20% more than that in damage, rounded up
                    else if (RWeaponBehavior.AmmoUsage[rWeaponIndex] > 1)
                    {
                        alienDamage = (byte)Math.Ceiling(RWeaponBehavior.AmmoUsage[rWeaponIndex] * 1.2);
                    }
                    
                    // Apply weakness and erase others (flash will remain 0xFF)
                    for (int i = 0; i < alienWeapons.Count; i++)
                    {
                        EDmgVsBoss weapon = alienWeapons[i];

                        stream.Position = weapon + EDmgVsBoss.Offset.Alien;
                        if (i == rWeaponIndex)
                        {
                            stream.WriteByte(alienDamage);
                            WilyWeaknesses[4, i] = alienDamage;
                        }
                        else
                        {
                            stream.WriteByte(0xFF);
                            WilyWeaknesses[4, i] = 0xFF;
                        }
                    }

                    #endregion

                    Console.WriteLine("Wily Boss Weaknesses:");
                    Console.WriteLine("P\tH\tA\tW\tB\tQ\tF\tM\tC:");
                    Console.WriteLine("--------------------------------------------");
                    for (int i = 0; i < WilyWeaknesses.GetLength(0); i++)
                    {
                        for (int j = 0; j < WilyWeaknesses.GetLength(1); j++)
                        {
                            Console.Write("{0}\t", WilyWeaknesses[i, j]);
                            if (j == 5) Console.Write("X\t"); // skip flash
                        }

                        string bossName = "";
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
                                bossName = "machine";
                                break;
                            case 4:
                                bossName = "alien";
                                break;
                            default: break;
                        }
                        Console.WriteLine("< " + bossName);
                    }

                } // end if

                #region Easy Weakness

                else
                {
                    // First address for damage (buster v heatman)
                    int address = (RandomMM2.Settings.IsJapanese) ? (int)EDmgVsBoss.Buster : (int)EDmgVsBoss.U_DamageP;

                    // Skip Time Stopper
                    // Buster Air Wood Bubble Quick Clash Metal
                    byte[] dragon = new byte[] { 1, 0, 0, 0, 1, 0, 1 };
                    byte[] guts = new byte[] { 1, 0, 0, 1, 2, 0, 1 };
                    byte[] machine = new byte[] { 1, 1, 0, 0, 1, 1, 4 };
                    byte[] alien = new byte[] { 0xff, 0xff, 0xff, 1, 0xff, 0xff, 0xff };

                    // TODO: Scale damage based on ammo count w/ weapon class instead of this hard-coded table
                    // Buster Air Wood Bubble Quick Clash Metal
                    //double[] ammoUsed = new double[] { 0, 2, 3, 0.5, 0.25, 4, 0.25 };

                    dragon.Shuffle(RandomMM2.Random);
                    guts.Shuffle(RandomMM2.Random);
                    machine.Shuffle(RandomMM2.Random);
                    alien.Shuffle(RandomMM2.Random);
                    
                    int j = 0;
                    for (int i = 0; i < 8; i++) // i = Buster plus 7 weapons, Time Stopper damage is located in another table (going to ignore it anyways)
                    {
                        //// Skip Atomic Fire
                        //if (i == 1) continue;

                        stream.Position = address + 14 * i + 8;
                        stream.WriteByte(dragon[j]);
                        stream.Position++; // Skip Picopico-kun byte, which does nothing
                        stream.WriteByte(guts[j]);
                        stream.Position++; // Skip Buebeam byte, which does nothing
                        stream.WriteByte(machine[j]);

                        // Scale damage against alien if using a high ammo usage weapon
                        if (alien[j] == 1)
                        {
                            if (RWeaponBehavior.AmmoUsage[j] >= 1)
                            {
                                alien[j] = (byte)((double)RWeaponBehavior.AmmoUsage[j] * 1.3);
                            }
                        }
                        stream.WriteByte(alien[j]);
                        j++;
                    }
                }

                #endregion

            } // End method RandomizeWilyUJ
            
        }
    }
}
