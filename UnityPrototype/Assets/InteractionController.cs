using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public List<Interaction> interactions = new List<Interaction>();
    public ActorGenerator actorGenerator;
    public Material lineMaterial;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void createInteraction(string[] data)
    {
        // Debug.Log("Interactions: " + data[0] + ", " + data[1] + ", " + data[2]);

        // name, actor a, actor b
        Actor a = actorGenerator.findRelative(data[1]);
        Actor b = actorGenerator.findRelative(data[2]);


        if (a != null && b != null)
        {
            // Create Interaction
            GameObject newInteractionGO = new GameObject();
            newInteractionGO.transform.name = data[0];
            newInteractionGO.transform.parent = transform;
            Interaction newInteraction = newInteractionGO.AddComponent<Interaction>();
            this.interactions.Add(newInteraction);
            newInteraction.actor1 = a;
            newInteraction.actor2 = b;

            // Add to actors
            a.interactions.Add(newInteraction);
            b.interactions.Add(newInteraction);
            

            // Setup line
            LineRenderer lr = newInteraction.gameObject.AddComponent<LineRenderer>();
            newInteraction.line = lr;
            lr.SetPosition(0, a.gameObject.transform.position);
            lr.SetPosition(1, b.gameObject.transform.position);
            lr.startWidth = 0.05f;
            lr.endWidth = 0.05f;
            lr.material = lineMaterial;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
