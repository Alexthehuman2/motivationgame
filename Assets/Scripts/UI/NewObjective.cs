using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewObjective : MonoBehaviour
{
    private string finished_text;

    [SerializeField] private ObjType selectedType = ObjType.PUNISHMENT;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void userEntered()
    {
        finished_text = this.GetComponent<TMP_InputField>().text;
        AddObjective(selectedType, finished_text);
    }
    public void AddObjective(ObjType type,string objective)
    {
        if (EventSingleton.Instance.KS_events != null)
        {
            KeyStringEvent get_KS_event;
            if (EventSingleton.Instance.KS_events.TryGetValue("AddObjective", out get_KS_event))
            {
                get_KS_event.Invoke(type,objective);
            }
        }
    }
}
