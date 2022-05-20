using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRandomization : MonoBehaviour
{
    [SerializeField] private ScriptableObject objective_data;
    [SerializeField] private List<string> duties = new List<string>();
    //needs something the duties read from.

    private TMP_Text tm_text;

    private void OnEnable()
    {
        tm_text = this.gameObject.GetComponent<TMP_Text>();
        tm_text.text = duties[Random.Range(0, duties.Count)];
        EventSingleton.Instance.text_event.AddListener(GetComponentInChildren<TextRandomization>().NewDuty);
    }

    private void OnDisable()
    {
        EventSingleton.Instance.text_event.RemoveListener(NewDuty);
    }

    public void NewDuty()
    {
        tm_text.text = duties[Random.Range(0, duties.Count)];
    }

    public void AddSingleDutyToList(string new_duty)
    {
        duties.Add(new_duty);
    }

    public void AddMultipleDutiesToList(List<string> new_duties)
    {
        foreach (var duty in new_duties)
        {
            duties.Add(duty);
        }
    }

    public bool TryDeleteDutyFromString(string duty_to_delete)
    {
        return duties.Remove(duty_to_delete);
    }

    public bool TryDeleteDutyFromGameObject(GameObject obj_to_delete)
    {
        return obj_to_delete.GetComponent<TMP_Text>() != null ? duties.Remove(obj_to_delete.GetComponent<TMP_Text>().text) : false;
    }
}
