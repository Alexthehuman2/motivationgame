using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextEvents : MonoBehaviour
{
    [SerializeField] private GameObject randomizedText;

    private void Start()
    {
        randomizedText.SetActive(true);
        if (EventSingleton.Instance.text_event == null)
        {
            EventSingleton.Instance.text_event = new UnityEvent();
        }
    }
}
