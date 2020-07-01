using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public enum EventType {
        NoEventTypeSet,
        Hazard,
        Issue
    };

    public void createEvent(string[] data)
    {
        // name, message, video, event type, actors, required condition, disable condition
        Debug.Log("Create Event: " + data[0]);

        GameObject newEventGO = new GameObject();
        Event newEvent = newEventGO.AddComponent<Event>();
        newEventGO.transform.parent = this.gameObject.transform;
        newEventGO.transform.name = data[0];
        newEvent.eventName = data[0];
        newEvent.eventType = GetEventType(data[3]);

        Parameter requiredCondition = GetParameter(data[5]);
        if(requiredCondition != null)
        {
            newEvent.requiredConditions.Add(GetParameter(data[5]));
        }
    }

    public Parameter GetParameter(string para)
    {
        Debug.Log("Searching for Parameter '" + para + "'");
        GameObject gO = GameObject.Find(para);
        if(gO != null)
        {
            Parameter result = gO.GetComponent<Parameter>();
            if(result == null)
            {
                Debug.Log("No Parameter found");
                return null;
            } else
            {
                return gO.GetComponent<Parameter>();
            }
        }
        return null;
    }

    public EventType GetEventType(string type)
    {
        switch (type)
        {
            case "Hazard":
                return EventType.Hazard;
            case "Issue":
                return EventType.Issue;
        }
        return EventType.NoEventTypeSet;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
