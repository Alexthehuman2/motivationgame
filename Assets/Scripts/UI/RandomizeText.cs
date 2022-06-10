using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RandomizeText : MonoBehaviour
{
    private KeyEvent get_event;
    [SerializeField] private int minCount = 20;
    [SerializeField] private int maxCount = 30;
    [SerializeField] private float delay = 0.25f;
    public void randomizeText()
    {
        if (EventSingleton.Instance.events != null)
        {
            //for loop here
            if (EventSingleton.Instance.events.TryGetValue("RandomizeText", out get_event))
            {
                this.GetComponent<Button>().interactable = false;
                StartCoroutine(generateRandomObj(Random.Range(minCount,maxCount), delay));
            }
        }
    }

    IEnumerator generateRandomObj(float max_count, float on_screen_time)
    {
        //go down 1 count every randomize, make it stay on screen for on_screen_time seconds
        float current_count = max_count;
        
        while (current_count > 0)
        {
            yield return new WaitForSeconds(on_screen_time);
            current_count--;
            get_event.Invoke(ObjType.PUNISHMENT);
        }
        this.GetComponent<Button>().interactable = true;
    }
}
