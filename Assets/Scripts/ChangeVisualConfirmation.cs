using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ConfirmationType
{
    SAVE = 0,
    LOAD = 1,
    ADD = 2,
    REMOVE = 3
}

public class ChangeVisualConfirmation : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ConfirmationType c_type = 0;
    public void changeText()
    {
        switch (c_type)
        {
            case ConfirmationType.SAVE:
                _text.gameObject.SetActive(true);
                _text.text = "You have successfully saved.";
                _text.GetComponent<Animator>().Play("TextFade", -1, 0f);
                break;
            case ConfirmationType.LOAD:
                _text.gameObject.SetActive(true);
                _text.text = "You have successfully loaded.";
                _text.GetComponent<Animator>().Play("TextFade", -1, 0f);
                break;
            case ConfirmationType.ADD:
                _text.gameObject.SetActive(true);
                _text.text = "You have successfully added an Object to the List.";
                _text.GetComponent<Animator>().Play("TextFade", -1, 0f);
                break;
            case ConfirmationType.REMOVE:
                _text.gameObject.SetActive(true);
                _text.text = "You have successfully deleted an object from the list.";
                _text.GetComponent<Animator>().Play("TextFade", -1, 0f);
                break;
        }
    }

}
