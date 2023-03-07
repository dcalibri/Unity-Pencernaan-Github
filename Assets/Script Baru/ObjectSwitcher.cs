using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] objectsToSwitch;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Activate the first object in the array
        objectsToSwitch[currentIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for up/down arrow key presses
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Deactivate current object
            objectsToSwitch[currentIndex].SetActive(false);

            // Move to previous object in the array (or wrap around if at beginning)
            currentIndex = (currentIndex - 1 + objectsToSwitch.Length) % objectsToSwitch.Length;

            // Activate new current object
            objectsToSwitch[currentIndex].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Deactivate current object
            objectsToSwitch[currentIndex].SetActive(false);

            // Move to next object in the array (or wrap around if at end)
            currentIndex = (currentIndex + 1) % objectsToSwitch.Length;

            // Activate new current object
            objectsToSwitch[currentIndex].SetActive(true);
        }
    }
}
