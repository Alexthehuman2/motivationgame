using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TextRandomization : MonoBehaviour
{
    [SerializeField] private ObjectiveData_SO objective_data;
    //needs something the duties read from.

    private TMP_Text tm_text;

    private void OnEnable()
    {
        objective_data.LoadData();
        tm_text = this.gameObject.GetComponent<TMP_Text>();
        List<string> _punishment;
        if (objective_data.objectives.TryGetValue(ObjType.PUNISHMENT, out _punishment))
        {
            tm_text.text = _punishment[Random.Range(0, _punishment.Count)];
        }
        KeyEvent get_event;
        if (EventSingleton.Instance.events.TryGetValue("RandomizeText", out get_event))
        {
            //Debug.Log("Listener Added");
            get_event.AddListener(NewDutyFromKey);
        }
        KeyStringEvent get_KS_event;
        if (EventSingleton.Instance.KS_events.TryGetValue("AddObjective", out get_KS_event))
        {
            //Debug.Log("AddObjective Listener Added");
            get_KS_event.AddListener(AddSingleDutyToListFromKey);
        }


    }

    private void OnDisable()
    {
        //EventSingleton.Instance.text_event.RemoveListener(NewDuty);
    }

    public void NewDutyFromKey(ObjType key)
    {
        List<string> objective_list;
        if (objective_data.objectives.TryGetValue(key, out objective_list))
        {
            tm_text.text = objective_list[Random.Range(0, objective_list.Count)];
        }
    }

    //Adds a single duty using an Objective Type as a Key.
    public void AddSingleDutyToListFromKey(ObjType key,string new_duty) 
    {
        Debug.Log("Added a Duty to the List");
        if (objective_data.objectives.ContainsKey(key)) //Checks if Key is valid
        {
            objective_data.objectives[key].Add(new_duty); //Adds a new duty using that Key.
        }
    }

    public void AddMultipleDutiesToListFromKey(string key, List<string> new_duties)
    {
        foreach (var duty in new_duties)
        {
            //objective_data.punish_objectives.Add(duty);
        }
    }

    //Deletes a single duty using an Objective Type as a Key.
    public bool TryDeleteDutyFromStringWithKey(string key, string duty_to_delete)
    {
        //return objective_data.punish_objectives.Remove(duty_to_delete);
        return false;
    }

    public bool TryDeleteDutyFromGameObjectWithKey(string key, GameObject obj_to_delete)
    {
        //return obj_to_delete.GetComponent<TMP_Text>() != null ? objective_data.punish_objectives.Remove(obj_to_delete.GetComponent<TMP_Text>().text) : false;
        return false;
    }
}
