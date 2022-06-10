using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum AddDeleteState
{
    ADD = 0,
    DELETE = 1
}
public class NewObjective : MonoBehaviour
{
    private string finished_text;

    [SerializeField] private ObjType selectedType = ObjType.PUNISHMENT;
    [SerializeField] private AddDeleteState state;
    [SerializeField] private ObjectiveData_SO objectives;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void userEntered()
    {
        finished_text = this.GetComponent<TMP_InputField>().text;
        if (finished_text != "")
        {
            AddOrDeleteObjective(selectedType, finished_text);
            this.GetComponent<TMP_InputField>().text = "";
        }
    }

    public void cancel()
    {
        finished_text = "";
        this.GetComponent<TMP_InputField>().text = "";
    }
    public void AddOrDeleteObjective(ObjType type,string objective)
    {
        switch(state)
        {
            case AddDeleteState.ADD:
                if (EventSingleton.Instance.KS_events != null)
                {
                    KeyStringEvent get_KS_event;
                    if (EventSingleton.Instance.KS_events.TryGetValue("AddObjective", out get_KS_event))
                    {
                        get_KS_event.Invoke(type, objective);
                    }
                }
                break;
            case AddDeleteState.DELETE:
                if (EventSingleton.Instance.KS_events != null)
                {
                    KeyStringEvent get_event;
                    if (EventSingleton.Instance.KS_events.TryGetValue("DeleteObjective", out get_event))
                    {
                        get_event.Invoke(type, GetComponent<TMP_InputField>().text);
                    }
                }
                this.GetComponent<TMP_InputField>().text = "";
                break;
            default:
                break;
        }
    }
    public void setObjType(ObjType new_type)
    {
        selectedType = new_type;
    }
}
