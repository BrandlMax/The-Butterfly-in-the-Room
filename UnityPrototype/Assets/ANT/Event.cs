using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int id;
    public string eventName;
    public EventController.EventType eventType;
    public string eventMessage;
    public List<Parameter> requiredConditions = new List<Parameter>();
    public List<Actor> actors = new List<Actor>();
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Parameter condition in requiredConditions)
        {
            if (condition.isActive)
            {
                if (!isActive)
                {
                    isActive = true;
                    Debug.Log("EVENT ACTIVE! -> " + eventName);
                }
            } else
            {
                if (isActive)
                {
                    isActive = false;
                    Debug.Log("EVENT INACTIVE! -> " + eventName);
                }
            }
        }
    }
}
