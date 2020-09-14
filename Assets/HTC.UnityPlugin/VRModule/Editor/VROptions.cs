using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class VROptions
{
    private const string MenuName = "VR Options/Validate Scripts";
    private const string ValidateSetting = "Validate Scripts";

    public static bool isEnabled;
    static VROptions()
    {
        isEnabled = EditorPrefs.GetBool(MenuName, true);
    }
    
    [MenuItem(MenuName)]
    private static void ToggleAction()
    {
        isEnabled = !isEnabled;
        EditorPrefs.SetBool(MenuName, isEnabled);
    }
 
    [MenuItem(MenuName, true)]
    private static bool ToggleActionValidate()
    {
        Menu.SetChecked(MenuName, isEnabled);
        return true;
    }
}
