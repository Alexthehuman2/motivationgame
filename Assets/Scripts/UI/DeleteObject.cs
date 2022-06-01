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

    public void CheckValue()
    {
        if (type != null)
        {
            
        }
        //Before this, we need to check if text is valid for the invoke.
        if (EventSingleton.Instance.KS_events != null)
        {
            KeyStringEvent get_event;
            if (EventSingleton.Instance.KS_events.TryGetValue("DeleteText", out get_event))
            {
                get_event.Invoke(ObjType.PUNISHMENT, GetComponent<TMP_InputField>().text);
            }
        }
    }

    public void setObjType(ObjType new_type)
    {
        type = new_type;
    }
}
