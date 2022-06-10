using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class KeyDropDown : MonoBehaviour
{
    [SerializeField] private GameObject deleteInputField;
    private TMP_Dropdown dropdown;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {

        dropdown = this.GetComponent<TMP_Dropdown>();

        dropdown.ClearOptions();

        List<string> options = new List<string>();
        options.Add("...");
        for (int i = 0; i < (int)ObjType.TOTALCOUNT; i++)
        {
            ObjType getInt = (ObjType)i;
            options.Add(getInt.ToString());
            Debug.Log("Added " + getInt.ToString());
        }

        dropdown.AddOptions(options);
    }

    public void testFunction()
    {
        Debug.Log("Selected option is " + (dropdown.value-1));
        deleteInputField.SetActive(true);
        deleteInputField.GetComponent<NewObjective>().setObjType((ObjType)(dropdown.value-1));
        this.gameObject.SetActive(false);
    }

}
