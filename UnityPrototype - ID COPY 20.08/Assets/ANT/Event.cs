using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int id;
    public EventController eventController;

    [Header("Content")]
    public string eventName;
    public string eventMessage;
    public VideoClip video;
    public EventController.EventType eventType;
    public List<Actor> actors = new List<Actor>();
    public List<Parameter> requiredConditions = new List<Parameter>();    
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddVideo(string fileName)
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ActivateEvent()
    {
        Debug.Log("Event activated");
        foreach(Actor actor in actors)
        {
            actor.events.Add(this);
        }
        eventController.changeEventCounter(1);
    }

    public void DeactivateEvent()
    {
        Debug.Log("Event deactivated");
        foreach (Actor actor in actors)
        {
            actor.events.Remove(this);
        }
        eventController.changeEventCounter(-1);
    }
}
