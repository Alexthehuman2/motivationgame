using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public enum ObjType
{
    PUNISHMENT,
    DAILIES,
    STREAMIDEAS
}
[CreateAssetMenu(fileName = "ObjectiveDataSO", menuName = "ScriptableObjects/SpawnObjectiveSO", order = 1)]
public class ObjectiveData_SO : ScriptableObject
{
    public Dictionary<ObjType, List<string>> objectives;
    public List<string> punish = new List<string>();
    public List<string> dailies = new List<string>();

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/data.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/data.txt", FileMode.Open);
            objectives = (Dictionary<ObjType, List<string>>)bf.Deserialize(file);
        }
            //Load in Data from Text
        if (objectives == null) objectives = new Dictionary<ObjType, List<string>>();
        objectives.Add(ObjType.PUNISHMENT, punish);
        objectives.Add(ObjType.DAILIES, dailies);
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (!File.Exists(Application.persistentDataPath + "/data.txt"))
        {
            file = File.Create(Application.persistentDataPath + "/data.txt");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + "/data.txt", FileMode.Open);
        }
        bf.Serialize(file, objectives);
        file.Close();
    }

    //SaveToFile
}
