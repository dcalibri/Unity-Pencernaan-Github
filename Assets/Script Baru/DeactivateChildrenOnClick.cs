using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateChildrenOnClick : MonoBehaviour
{
    public string childTag;

    private void OnMouseDown()
    {
        DeactivateChildren();
    }

    private void DeactivateChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag(childTag))
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
