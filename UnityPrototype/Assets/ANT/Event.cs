using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int id;
    public string eventName;
    public enum EventType { Hazard, Issue }; 
    public EventType eventType = EventType.Hazard;
    public string eventMessage;
    // ToDo: Condition 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
