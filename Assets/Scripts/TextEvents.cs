using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class KeyEvent : UnityEvent<string> { }
public class TextEvents : MonoBehaviour
{
    [SerializeField] private GameObject randomizedText;

    private KeyEvent randomize_event = new KeyEvent();

    private void Start()
    {
        if (EventSingleton.Instance.events == null)
        {
            EventSingleton.Instance.events = new Dictionary<string, KeyEvent>();
        }
        EventSingleton.Instance.events.Add("RandomizeText", randomize_event);
        randomizedText.SetActive(true);
    }
}
