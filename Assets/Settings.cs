using Assets.Core;
using Assets.Core.Interfases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class Settings : SettingsAbstract<Settings>
    {
        public int PositionCamera;

        public Settings(string path) : base(path)
        {
        }

        protected override Settings CreateDefualt(string path)
        {
            var settings = new Settings(path)
            {
                PositionCamera = 20,
            };

            return settings;
        }

        public static Settings InstanceDefualt(string path)
        {
            return new Settings(path).CreateDefualt(path);
        }
    }
}
