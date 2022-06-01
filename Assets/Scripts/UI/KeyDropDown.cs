using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class KeyDropDown : MonoBehaviour
{
    [SerializeField] private GameObject deleteInputField;
    private TMP_Dropdown dropdown;
    private void OnEnable()
    {

        dropdown = this.GetComponent<TMP_Dropdown>();

        dropdown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < (int)ObjType.TOTALCOUNT; i++)
        {
            ObjType getInt = (ObjType)i;
            options.Add(getInt.ToString());
            Debug.Log("Added " + getInt.ToString());
        }

        dropdown.AddOptions(options);
        BaseEventData event_data = new BaseEventData(EventSystem.current);
        dropdown.OnSubmit(event_data);
    }

    public void testFunction()
    {
/*        deleteInputField.SetActive(true);
        ObjType val = (ObjType)System.Enum.Parse(typeof(ObjType), dropdown.)
        deleteInputField.GetComponent<DeleteObject>().setObjType()
        this.gameObject.SetActive(false);*/
    }

}
