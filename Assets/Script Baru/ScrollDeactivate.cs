using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDeactivate : MonoBehaviour
{
    [SerializeField]
    private string tagToDeactivate;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0f)
        {
            DeactivateWithTag(tagToDeactivate);
        }
    }

    void DeactivateWithTag(string tag)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objs)
        {
            obj.SetActive(false);
        }
    }
}
