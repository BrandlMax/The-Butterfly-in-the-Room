using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public ActorGenerator actorGenerator;
    public int activeEventsCount = 0;
    public UIController uIController;

    public enum EventType {
        NoEventTypeSet,
        Hazard,
        Issue,
        Positive
    };

    public void changeEventCounter(int i)
    {
        activeEventsCount += i;
        uIController.updateEventCounter(activeEventsCount);
    }

    public void createEvent(string[] data)
    {
        // 0     1        2      3           4       5                     6
        // Name, Message, Video, Event Type, Actors, Required Conditition, Disable Condition

        GameObject newEventGO = new GameObject();
        Event newEvent = newEventGO.AddComponent<Event>();
        newEventGO.transform.parent = this.gameObject.transform;
        newEventGO.transform.name = data[0];
        newEvent.eventName = data[0];
        newEvent.eventMessage = data[1];
        newEvent.AddVideo(data[2]);
        newEvent.eventType = GetEventType(data[3]);
        newEvent.eventController = this;        

        string[] actorsInData = data[4].Split(',');
        
        foreach(string entry in actorsInData)
        {
            if(actorGenerator.findRelative(entry) != null)
            {
                newEvent.actors.Add(actorGenerator.findRelative(entry));
            }            
        }

        Parameter requiredCondition = GetParameter(data[5]);
        if(requiredCondition != null)
        {
            if(GetParameter(data[5]) != null)
            {
                newEvent.requiredConditions.Add(GetParameter(data[5]));
                GetParameter(data[5]).events.Add(newEvent);
            }
        }
    }

    /*
    List<Actor> GetActors(string data)
    {
        if(data.Contains)
    }
    */

    public Parameter GetParameter(string para)
    {
        GameObject gO = GameObject.Find(para);
        if(gO != null)
        {
            Parameter result = gO.GetComponent<Parameter>();
            if(result == null)
            {
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
            case "Positive":
                return EventType.Positive;
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
