using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int id;

    [Header("Actor Details")]
    public string actorName;
    public string[] data;

    [Header("Conditions")]
    public List<bool> conditions = new List<bool>();

    [Header("Relations")]
    public List<Interaction> interactions = new List<Interaction>();
    public List<Actor> parents = new List<Actor>();
    public List<Actor> children = new List<Actor>();
    public List<Event> events = new List<Event>();

    [Header("Visualisation")]
    public GameObject label;
    public bool labelLookAtCamera = false;
    // ToDo: Values

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(label != null && labelLookAtCamera)
        {
            label.transform.LookAt(Camera.main.transform);
        }   
    }

    public void addData(string[] data)
    {
        this.data = data;
    }
}
