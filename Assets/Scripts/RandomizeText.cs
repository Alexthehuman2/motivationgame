using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomizeText : MonoBehaviour
{
    public void randomizeText()
    {
        if (EventSingleton.Instance.text_event != null)
        {
            EventSingleton.Instance.text_event.Invoke();
            Debug.Log("Invoking");
        }
    }
}
