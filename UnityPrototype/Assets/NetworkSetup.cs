using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSetup : MonoBehaviour
{
    public List<Actor> actors = new List<Actor>();
    ActorGenerator ag;

    public List<Dictionary<string, object>> data;

    // Start is called before the first frame update
    void Start()
    {
        ag = this.GetComponent<ActorGenerator>();

        // Safe all Actors that are children of this gameobject
        foreach (Transform child in transform)
        {
            actors.Add(GetComponentInChildren<Actor>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void connectActors()
    {
        ag.startConnectingActors();
    }
}
