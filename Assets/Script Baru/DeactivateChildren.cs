using UnityEngine;

public class DeactivateChildren : MonoBehaviour
{
    void OnMouseDown()
    {
        // find all child objects with the "Tanah" tag
        GameObject[] children = GameObject.FindGameObjectsWithTag("Tanah");

        // deactivate all child objects
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
    }
}
