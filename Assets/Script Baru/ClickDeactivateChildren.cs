using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickDeactivateChildren : MonoBehaviour
{
    [Header("Click Event")]
    public UnityEvent TrueClickEvent;
    public UnityEvent FalseClickEvent;
    bool ClickStatus;

    // Start is called before the first frame update
    void Start()
    {
        ClickStatus = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        ClickStatus = !ClickStatus;
        if (ClickStatus)
        {
            TrueClickEvent?.Invoke();
            DeactivateChildren();
        }
        else
        {
            FalseClickEvent?.Invoke();
        }
    }

    void DeactivateChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void InvokeTrueEvent()
    {
        TrueClickEvent.Invoke();
    }

    void InvokeFalseEvent()
    {
        FalseClickEvent.Invoke();
    }
}
