using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

namespace Murdoch.GAD361.GADVRMini
{
    public static class ExportPackage
    {
        [MenuItem("GADVRMinis/Export Framework Package")]
        public static void export()
        {
            string[] projectContent = new string[] {"Assets/GADMinisFramework", "Assets/Minigames", "Assets/TextMesh Pro", "ProjectSettings/TagManager.asset"};
            //AssetDatabase.ExportPackage(projectContent, "GADVRMinis_Base.unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse |ExportPackageOptions.IncludeDependencies);
            AssetDatabase.ExportPackage(projectContent, "GADVRMinis_Base.unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse);
            Debug.Log("Project Exported");
        }
    }
}

#endif
