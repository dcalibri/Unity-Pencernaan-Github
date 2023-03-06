using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeactivateWithTagKey : MonoBehaviour
{
    [SerializeField] private string tagToDeactivate;
    [SerializeField] private KeyCode deactivationKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(deactivationKey))
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToDeactivate);
            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(false);
            }
        }
    }
}
