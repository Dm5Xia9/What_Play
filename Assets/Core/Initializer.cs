using Assets;
using Assets.Core;
using Assets.Core.Interfases;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Initializer : MonoBehaviour
{

    [SerializeField] public bool ResetDefualt = false;

    private void Awake()
    {
        string pathSettings;
#if UNITY_EDITOR
        pathSettings = Path.Combine(AssetDatabase.GetAssetPath(this.GetInstanceID()), "Assets", "settings.json");
#else
//save document
#endif
        var setting = Settings.InstanceDefualt(pathSettings);

        (setting as ISettingsInit).Init(ResetDefualt);
    }
}
