using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSingleton : MonoBehaviour
{
    public static EventSingleton Instance { get; private set; }
    public Dictionary<string, KeyEvent> events = new Dictionary<string,KeyEvent>();
    public Dictionary<string, KeyStringEvent> KS_events = new Dictionary<string, KeyStringEvent>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
