﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActorGenerator : MonoBehaviour
{
    public List<Actor> actors = new List<Actor>();
    public GameObject sphere;
    public GameObject textPrefab;
    [Range(0f, 20f)]
    public int radius = 20;

    public void addActor(string[] data)
    {
        // Name,Parents,Children,Events,Required Parameter for Active
        // Instantiate
        GameObject newActor = new GameObject();

        // Add Actor Class
        Actor actor = newActor.AddComponent<Actor>();
        actor.addData(data);

        // Add to list
        actors.Add(actor);

        // Add as Child to Setup GameObject
        newActor.transform.parent = this.gameObject.transform;

        // Change Name
        // Debug.Log(data[0]);
        newActor.transform.name = data[0];
        actor.actorName = data[0];

        // Visualization
        GameObject visualization = Instantiate(sphere);
        visualization.transform.parent = newActor.transform;

        // Add floating label
        GameObject label = Instantiate(textPrefab);
        label.transform.SetParent(newActor.transform);
        label.transform.localPosition = new Vector3(0, 0, 0);
        label.name = "Label";
        label.GetComponent<TextMeshPro>().text = actor.actorName;
        actor.label = label;

        // Random Position
        Vector3 newPos = new Vector3(Random.Range(0, radius), Random.Range(0, radius), Random.Range(0, radius));
        newActor.transform.position = newPos;

        // Add Events
        // Is Event already there?
        // If not create
    }

    public void startConnectingActors()
    {
        foreach(Actor actor in this.actors)
        {
            // Find Children
            Actor child = findRelative(actor.data[2]);

            if (child != null)
            {
                actor.children.Add(child);
            }

            // Find Parents
            Actor parent = findRelative(actor.data[1]);

            if (parent != null)
            {
                actor.parents.Add(parent);
            }

            // Setup Interactions
        }        
    }

    public Actor findRelative(string name)
    {
        if(name != "")
        {
            name = name.Trim('"');
            GameObject relative = GameObject.Find(name);            
            if(relative != null)
            {
                return relative.GetComponent<Actor>();
            } else
            {
                return null;
            }
        }
        return null;
    }

}