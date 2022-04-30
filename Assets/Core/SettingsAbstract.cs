using Assets.Core.Interfases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Core
{
    public abstract class SettingsAbstract<T> : ISettingsInit where T : SettingsAbstract<T>
    {
        private static T _instance;
        private static T _defualtInstance;
        private readonly string _path;
        public SettingsAbstract(string path)
        {
            _path = path;
        }

        public static T Instance => _instance;
        public static T DefualtInstance => _defualtInstance;
        void ISettingsInit.Init(bool resetDefualt)
        {
            _defualtInstance = CreateDefualt(_path);
            _instance = CreateDefualt(_path);

            if (resetDefualt)
            {
                Instance.Save();
                return;
            }

            if (File.Exists(_path))
            {
                JsonUtility.FromJsonOverwrite(File.ReadAllText(_path), _instance);
            }
            else
            {
                Instance.Save();
            }
        }

        protected abstract T CreateDefualt(string path);

        public void Save()
        {
            var json = JsonUtility.ToJson(Instance);

            if (!File.Exists(_path))
                File.Create(_path).Close();

            File.WriteAllText(_path, json);
        }

    }

}
