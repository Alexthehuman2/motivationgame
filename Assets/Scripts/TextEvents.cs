using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeyEvent : UnityEvent<ObjType> { }
public class KeyStringEvent : UnityEvent<ObjType, string> { }
public class TextEvents : MonoBehaviour
{
    [SerializeField] private GameObject randomizedText;
    [SerializeField] private GameObject randomizeButton;
    [SerializeField] private GameObject addNewText;
    [SerializeField] private GameObject saveButton;
    [SerializeField] private GameObject loadButton;
    private void Start()
    {
        if (EventSingleton.Instance.events == null)
        {
            EventSingleton.Instance.events = new Dictionary<string, KeyEvent>();
        }
        if (EventSingleton.Instance.KS_events == null)
        {
            EventSingleton.Instance.KS_events = new Dictionary<string, KeyStringEvent>();
        }
        EventSingleton.Instance.events.Add("RandomizeText", new KeyEvent());
        EventSingleton.Instance.KS_events.Add("AddObjective", new KeyStringEvent());
        randomizedText.SetActive(true);
        randomizeButton.SetActive(true);
        addNewText.SetActive(true);
        saveButton.SetActive(true);
        loadButton.SetActive(true);
    }
}
