using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayListController : MonoBehaviour
{
    [Tooltip("Default amount of prefab to spawn")]
    [SerializeField] private int option_pool_max = 20;
    [Tooltip("Reference to the Scriptable Object that contains the objectives")]
    [SerializeField] private ObjectiveData_SO objectives_SO;
    [Tooltip("Prefab for the Text Holder (TMPro Button is preferred)")]
    [SerializeField] private GameObject text_holder_prefab;

    [Tooltip("The private to this class list to objectives that we're working with.")]
    private List<string> objective_list;


    private void OnEnable()
    {
        //Resizes pooling for objectives.
        int option_pool = objectives_SO.objectives[ObjType.PUNISHMENT].Count;

        //makes a new list based on an Objective Type provided.
        objective_list = new List<string>(objectives_SO.objectives[ObjType.PUNISHMENT]);

        //Instantiates the Prefab with the text from the objective.
        foreach (string objective in objective_list)
        {
            GameObject obj = Instantiate(text_holder_prefab, this.transform);
            obj.GetComponentInChildren<TMP_Text>().text = objective;
        }

        float prefab_height = text_holder_prefab.GetComponent<RectTransform>().sizeDelta.y;
        RectTransform currentTransform = this.GetComponent<RectTransform>();
        currentTransform.sizeDelta = new Vector2(currentTransform.sizeDelta.x, prefab_height * this.transform.childCount);
    }

    public void clearAllObjects()
    {

    }
}
