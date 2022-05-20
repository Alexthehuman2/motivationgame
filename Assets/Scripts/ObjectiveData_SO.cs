using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectiveDataSO", menuName = "ScriptableObjects/SpawnObjectiveSO", order = 1)]
public class ObjectiveData_SO : ScriptableObject
{
    public Dictionary<string, List<string>> objectives;
    public List<string> punish = new List<string>();
    public List<string> dailies = new List<string>();

    public void LoadData()
    {
        //Load in Data from Text
        if (objectives == null) objectives = new Dictionary<string, List<string>>();
        objectives.Add("punishment", punish);
        objectives.Add("dailies", dailies);
    }

}
