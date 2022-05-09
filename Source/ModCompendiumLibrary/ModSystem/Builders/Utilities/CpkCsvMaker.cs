﻿using ModCompendiumLibrary.Logging;
using ModCompendiumLibrary.VirtualFileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ModCompendiumLibrary.ModSystem.Builders.Utilities
{
    public class CpkCsvMaker
    {
        public static string MakeCsv( string tempDirectory, string game, string hostOutputPath )
        {
            //Get CSV template from Config folder
            var baseCsv = $"Dependencies\\Compression\\{game}.csv";
            if (!File.Exists(baseCsv))
                Log.Config.Error($"Failed to load CSV file: {baseCsv}");
            else
            {
                //Create new CSV, delete old one if it eists
                Directory.CreateDirectory(hostOutputPath);
                if (File.Exists($"{hostOutputPath}\\mod.csv"))
                {
                    File.Delete($"{hostOutputPath}\\mod.csv");
                }

                //If a file is listed, include it in new CSV
                int line = 0;
                DirectoryInfo directory = new DirectoryInfo(tempDirectory);
                foreach (var file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    string match = file.FullName.Replace(directory.FullName, "").Replace(@"\", "/").Remove(0, 1);
                    bool matchFound = false;
                    string[] csvEntries = File.ReadAllLines(baseCsv);
                    foreach (string csvEntry in csvEntries)
                    {
                        string[] entry = csvEntry.Split(',');
                        if (match == entry[0])
                        {
                            File.AppendAllText($"{hostOutputPath}\\mod.csv", $"{entry[0]},{entry[0]},{line},{entry[1]}" + Environment.NewLine);
                            line++;
                            matchFound = true;
                            break;
                        }
                    }
                    if (!matchFound)
                    {
                        File.AppendAllText($"{hostOutputPath}\\mod.csv", $"{match},{match},{line},Uncompress" + Environment.NewLine);
                        line++;
                    }
                }
                return $"{hostOutputPath}\\mod.csv";
            }
            return "";
        }
    }
}