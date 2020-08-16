using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int id;

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
