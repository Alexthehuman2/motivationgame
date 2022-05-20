using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

//Scripting reference: https://answers.unity.com/questions/175931/perform-action-on-saveload-in-editor.html
public class SaveDictionaryToText : AssetModificationProcessor
{
    
    public static string[] OnWillSaveAssets(string[] paths)
    {
        string scenePath = string.Empty;
        string sceneName = string.Empty;

        foreach (string path in paths)
        {
            if (path.Contains(".unity"))
            {
                scenePath = Path.GetDirectoryName(path);
                sceneName = Path.GetFileNameWithoutExtension(path);
            }
        }

        if (sceneName.Length == 0)
        {
            return paths;
        }

        //dostuff here
        //ObjectiveDataSO
        Debug.Log("works");
        string[] guids1 = AssetDatabase.FindAssets("ObjectiveDataSO", new[] { "Assets/Scripts/ScriptableObjects" });
        string obj_data_path = AssetDatabase.GUIDToAssetPath(guids1[0]);
        var obj_data = (ObjectiveData_SO)AssetDatabase.LoadAssetAtPath(obj_data_path, typeof(ObjectiveData_SO));

        //Save data of obj_data into Text, dictated by a path? Idk. 
        return paths;
    }
}
