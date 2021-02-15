﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Avalonia.Controls;
using MM2Randomizer;
using MM2Randomizer.Extensions;
using RandomizerHost.Views;
using ReactiveUI;

namespace RandomizerHost.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        //
        // Constructor
        //

        public MainWindowViewModel()
        {
            RandoSettings = new RandoSettings();
            RandomMM2.Settings = RandoSettings;

            // Try to load "MM2.nes" if one is in the local directory already to save time
            String tryLocalpath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "MM2.nes");

            if (File.Exists(tryLocalpath))
            {
                this.mRandoSettings.SourcePath = tryLocalpath;
                IsShowingHint = false;
            }

            this.OpenContainingFolderCommand = ReactiveCommand.Create(this.OpenContainngFolder, this.WhenAnyValue(x => x.CanOpenContainngFolder));
            this.CreateFromGivenSeedCommand = ReactiveCommand.Create<Window>(this.CreateFromGivenSeed, this.WhenAnyValue(x => x.RandoSettings.IsSeedValid));
            this.CreateFromRandomSeedCommand = ReactiveCommand.Create<Window>(this.CreateFromRandomSeed, this.WhenAnyValue(x => x.RandoSettings.IsHashValid));
            this.OpenRomFileCommand = ReactiveCommand.Create<Window>(this.OpenRomFile);
        }


        //
        // Commands
        //

        public ICommand OpenRomFileCommand { get; }
        public ICommand CreateFromGivenSeedCommand { get; }
        public ICommand CreateFromRandomSeedCommand { get; }
        public ICommand OpenContainingFolderCommand { get; }


        //
        // Properties
        //

        public RandoSettings RandoSettings
        {
            get => this.mRandoSettings;
            set => this.RaiseAndSetIfChanged(ref this.mRandoSettings, value);
        }

        public Boolean IsShowingHint
        {
            get => this.mIsShowingHint;
            set => this.RaiseAndSetIfChanged(ref this.mIsShowingHint, value);
        }

        public Boolean CanOpenContainngFolder
        {
            get => this.mCanOpenContainngFolder;
            set => this.RaiseAndSetIfChanged(ref this.mCanOpenContainngFolder, value);
        }

        public Boolean IsCoreModulesChecked
        {
            get => RandoSettings.Is8StagesRandom &&
                   RandoSettings.IsWeaponsRandom &&
                   RandoSettings.IsTeleportersRandom;
        }


        //
        // Public Methods
        //

        public async void OpenRomFile(Window in_Window)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.AllowMultiple = false;

            openFileDialog.Filters.Add(
                new FileDialogFilter()
                {
                    Name = @"ROM Image",
                    Extensions = new List<String>()
                    {
                        @"nes"
                    }
                });

            openFileDialog.Title = @"Open Mega Man 2 (U) NES ROM File";

            // Call the ShowDialog method to show the dialog box.
            String exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            String exeDir = Path.GetDirectoryName(exePath);
            openFileDialog.Directory = exeDir;

            String[] dialogResult = await openFileDialog.ShowAsync(in_Window);

            // Process input if the user clicked OK.
            if (dialogResult.Length > 0)
            {
                String fileName = dialogResult[0];

                this.IsShowingHint = false;
                this.mRandoSettings.SourcePath = fileName;

                TextBox romFile = in_Window.FindControl<TextBox>("TextBox_RomFile");
                romFile.Focus();

                if (null != romFile.Text)
                {
                    romFile.SelectionStart = romFile.Text.Length;
                }
            }
        }


        public async void CreateFromGivenSeed(Window in_Window)
        {
            // First, clean the seed of non-alphanumerics.  This isn't for the
            // seed generation code, but to maintain safe file names
            String seedString = this.RandoSettings.SeedString.Trim().ToUpperInvariant().RemoveNonAlphanumericCharacters();

            if (true == String.IsNullOrEmpty(seedString))
            {
                this.CreateFromRandomSeed(in_Window);
            }
            else
            {
                try
                {
                    // Perform randomization based on settings, then generate the ROM.
                    this.PerformRandomization(seedString);
                    this.RandoSettings.SeedString = RandomMM2.Seed.SeedString;
                }
                catch (Exception e)
                {
                    await MessageBox.Show(in_Window, e.ToString(), "Error", MessageBox.MessageBoxButtons.Ok);
                }
            }
        }


        public async void CreateFromRandomSeed(Window in_Window)
        {
            try
            {
                this.PerformRandomization();
                this.RandoSettings.SeedString = RandomMM2.Seed.SeedString;
            }
            catch (Exception e)
            {
                await MessageBox.Show(in_Window, e.ToString(), "Error", MessageBox.MessageBoxButtons.Ok);
            }
        }


        public void OpenContainngFolder()
        {
            if (RandomMM2.RecentlyCreatedFileName != "")
            {
                try
                {
                    Process.Start("explorer.exe", String.Format("/select,\"{0}\"", RandomMM2.RecentlyCreatedFileName));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Process.Start("explorer.exe", String.Format("/select,\"{0}\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
                }
            }
            else
            {
                Process.Start("explorer.exe", String.Format("/select,\"{0}\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
            }
        }


        public void PerformRandomization(String in_SeedString = null)
        {
            // Perform randomization based on settings, then generate the ROM.
            RandomMM2.RandomizerCreate(in_SeedString);

            // Get A-Z representation of seed
            String seedBase26 = RandomMM2.Seed.Identifier;
            Debug.WriteLine("\nSeed: " + seedBase26 + "\n");

            // Create log file if left shift is pressed while clicking
            if (true == this.RandoSettings.CreateLogFile &&
                false == this.RandoSettings.IsSpoilerFree)
            {
                String logFileName = $"MM2RNG-{seedBase26}.log";

                using (StreamWriter sw = new StreamWriter(logFileName, false))
                {
                    sw.WriteLine("Mega Man 2 Randomizer");
                    sw.WriteLine($"Version {RandoSettings.AssemblyVersion.ToString()}");
                    sw.WriteLine($"Seed {seedBase26}\n");
                    sw.WriteLine(RandomMM2.randomStages.ToString());
                    sw.WriteLine(RandomMM2.randomWeaponBehavior.ToString());
                    sw.WriteLine(RandomMM2.randomEnemyWeakness.ToString());
                    sw.WriteLine(RandomMM2.randomWeaknesses.ToString());
                    sw.Write(RandomMM2.Patch.GetStringSortedByAddress());
                }
            }

            // Flag UI as having created a ROM, enabling the "open folder" button
            this.CanOpenContainngFolder = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }


        //
        // Private Data Members
        //

        private RandoSettings mRandoSettings;
        private Boolean mIsShowingHint = true;
        private Boolean mCanOpenContainngFolder = false;
    }
}
