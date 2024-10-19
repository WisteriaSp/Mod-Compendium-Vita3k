using System.Xml.Linq;

namespace ModCompendiumLibrary.Configuration
{
    public abstract class PersonaPortableGameConfig : GameConfig
    {
        protected PersonaPortableGameConfig()
        {
            CpkRootOrPath = string.Empty;
            Compression = "True";
            Extract = "True";
        }

        /// <summary>
        /// Path to either a directory or a CPK file containing the game's files.
        /// </summary>
        public string CpkRootOrPath { get; set; }
        public string Compression { get; set; }
        public string Extract { get; set; }

        protected override void DeserializeCore(XElement element)
        {
            CpkRootOrPath = element.GetElementValueOrEmpty(nameof(CpkRootOrPath));
            Compression = element.GetElementValueOrEmpty(nameof(Compression));
            Extract = element.GetElementValueOrEmpty(nameof(Extract));
        }

        protected override void SerializeCore( XElement element )
        {
            element.AddNameValuePair(nameof(CpkRootOrPath), CpkRootOrPath);
            element.AddNameValuePair(nameof(Compression), Compression);
            element.AddNameValuePair(nameof(Extract), Extract);
        }

        public class Persona4DancingConfig : PersonaPortableGameConfig
        {
            public override Game Game => Game.Persona4Dancing;
        }

        public class Persona3DancingConfig : PersonaPortableGameConfig
        {
            public override Game Game => Game.Persona3Dancing;
        }

        public class Persona5DancingConfig : PersonaPortableGameConfig
        {
            public override Game Game => Game.Persona5Dancing;
        }

        public class CatherineFullBodyGameConfig : PersonaPortableGameConfig
        {
            public override Game Game => Game.CatherineFullBody;
        }
    }
}