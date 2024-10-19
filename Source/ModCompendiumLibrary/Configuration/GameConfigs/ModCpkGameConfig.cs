﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModCompendiumLibrary.Configuration
{
    public abstract class ModCpkGameConfig : GameConfig
    {
        protected ModCpkGameConfig()
        {
            Compression = "True";
            PC = "False";
        }

        public string Compression { get; set; }
        public string PC { get; set; }

        protected override void DeserializeCore(XElement element)
        {
            Compression = element.GetElementValueOrEmpty(nameof(Compression));
            PC = element.GetElementValueOrEmpty(nameof(PC));
        }

        protected override void SerializeCore(XElement element)
        {
            element.AddNameValuePair(nameof(Compression), Compression);
            element.AddNameValuePair(nameof(PC), PC);
        }
    }

    public class Persona3PortableConfig : ModCpkGameConfig
    {
        public override Game Game => Game.Persona3Portable;
    }

    public class Persona4GoldenGameConfig : ModCpkGameConfig
    {
        public override Game Game => Game.Persona4Golden;
    }

    public class Persona5GameConfig : ModCpkGameConfig
    {
        public override Game Game => Game.Persona5;
    }

    public class Persona5RoyalGameConfig : ModCpkGameConfig
    {
        public override Game Game => Game.Persona5Royal;
    }

    public class PersonaQ2Config : ModCpkGameConfig
    {
        public override Game Game => Game.PersonaQ2;
    }

    public class PersonaQConfig : ModCpkGameConfig
    {
        public override Game Game => Game.PersonaQ;
    }
}
