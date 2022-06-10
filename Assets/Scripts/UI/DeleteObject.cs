using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] private ObjectiveData_SO objectives;
    //[SerializeField] private TMP_Text WarningText;
    [SerializeField] private ObjType type;


    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void CheckValue()
    {
        if (EventSingleton.Instance.KS_events != null)
        {
            KeyStringEvent get_event;
            if (EventSingleton.Instance.KS_events.TryGetValue("DeleteObjective", out get_event))
            {
                get_event.Invoke(type, GetComponent<TMP_InputField>().text);
            }
        }
        this.GetComponent<TMP_InputField>().text = "";
        this.gameObject.SetActive(false);
    }

    public void setObjType(ObjType new_type)
    {
        type = new_type;
    }
}
