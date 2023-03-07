using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvents : MonoBehaviour
{
    public UnityEvent Events;

    // Start is called before the first frame update
    void Start()
    {
        Events.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
