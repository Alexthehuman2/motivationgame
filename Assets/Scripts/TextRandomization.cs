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
        if (objective_data.objectives.TryGetValue("punishment", out _punishment))
        {
            tm_text.text = _punishment[Random.Range(0, _punishment.Count)];
        }
        KeyEvent get_event;
        if (EventSingleton.Instance.events.TryGetValue("RandomizeText", out get_event))
        {
            Debug.Log("Listener Added");
            get_event.AddListener(NewDutyFromKey);
        }
    }

    private void OnDisable()
    {
        //EventSingleton.Instance.text_event.RemoveListener(NewDuty);
    }

    public void NewDutyFromKey(string key)
    {
        List<string> objective_list;
        Debug.Log("Invoked");
        if (objective_data.objectives.TryGetValue(key, out objective_list))
        {
            Debug.Log(objective_list.Count);
            tm_text.text = objective_list[Random.Range(0, objective_list.Count)];
        }
    }

    public void AddSingleDutyToListFromKey(string key,string new_duty)
    {
        //objective_data.punish_objectives.Add(new_duty);
    }

    public void AddMultipleDutiesToListFromKey(string key, List<string> new_duties)
    {
        foreach (var duty in new_duties)
        {
            //objective_data.punish_objectives.Add(duty);
        }
    }

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
