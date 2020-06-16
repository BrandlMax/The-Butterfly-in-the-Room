using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int id;
    public string actorName;
    public List<Interaction> interactions = new List<Interaction>();
    public List<Actor> parents = new List<Actor>();
    public List<Actor> children = new List<Actor>();
    public List<Event> events = new List<Event>();
    // ToDo: Values

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
