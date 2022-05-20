using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectiveDataSO", menuName = "ScriptableObjects/SpawnObjectiveSO", order = 1)]
public class ObjectiveData_SO : ScriptableObject
{
    public List<string> punish_objectives = new List<string>();
    public List<string> IRL_dailies = new List<string>();
}
