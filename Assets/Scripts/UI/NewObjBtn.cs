using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjBtn : MonoBehaviour
{
    public void changeInputState(GameObject obj)
    {
        obj.SetActive(obj.activeInHierarchy ? false : true);
    }
}
