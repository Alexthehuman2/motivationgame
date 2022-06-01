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
        //Load in Data from Text
        if (objectives == null)  //checks if the objectives are empty
        {
            objectives = new Dictionary<ObjType, List<string>>(); //Makes a new dictionary if it's empty
        }
        else
        {
            objectives.Clear(); //clears the objective in preparation for loading.
        }

        if (File.Exists(Application.persistentDataPath + "/data.txt")) //If file exists, Load data.
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/data.txt", FileMode.Open);
            objectives.Clear();
            objectives = (Dictionary<ObjType, List<string>>)bf.Deserialize(file);
            file.Close();
        }
        else //Otherwise start with default value.
        {
            objectives.Clear();
            objectives.Add(ObjType.PUNISHMENT, punish);
            objectives.Add(ObjType.DAILIES, dailies);
        }

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
