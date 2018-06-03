﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ModCompendiumLibrary.ModSystem.Builders.Utilities
{
    public static class UltraISOUtility
    {
        private const string EXE_PATH = "Dependencies\\UltraISO\\UltraISO.exe";

        public static bool Available => File.Exists( EXE_PATH );

        public static void ModifyIso( string inIsoPath, string outIsoPath, IEnumerable<string> files )
        {
            // Build arguments
            var arguments = new StringBuilder();
            arguments.Append( $"-input \"{inIsoPath}\" " );

            foreach ( var file in files )
                arguments.Append( $"-file \"{file}\" " );

            arguments.Append( $"-output {outIsoPath}" );

            // Must delete the file if it exists, otherwise the program will fail
            if ( File.Exists( outIsoPath ) )
                File.Delete( outIsoPath );

            // Set up parameters
            var processStartInfo = new ProcessStartInfo( EXE_PATH, arguments.ToString() )
            {
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Run program
            var process = Process.Start( processStartInfo );
            process?.WaitForExit();
        }
    }
}
