using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomizeText : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void randomizeText()
    {
        if (EventSingleton.Instance.events != null)
        {
            KeyEvent get_event;
            if (EventSingleton.Instance.events.TryGetValue("RandomizeText", out get_event))
            {
                get_event.Invoke(ObjType.PUNISHMENT);
            }
        }
    }
}
