using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public ActorGenerator actorGenerator;
    public UIController uIController;

    Transform target;
    bool following = false;
    [Range(0f, 10f)]
    public float distanceToActor = 5;
    public float speed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            if(Vector3.Distance(target.position, transform.position) > distanceToActor && following)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
                transform.LookAt(target);
            } else
            {
                following = false;
                transform.parent = target.transform;
            }
        }
    }

    public void testInput()
    {
        Debug.Log("INPUT !!!!!");
    }

    public void lookAtNewActor()
    {
        following = true;
        int index = Random.Range(0, actorGenerator.actors.Count - 1);
        target = actorGenerator.actors[index].gameObject.transform;

        // Send data to UI
        uIController.setCurrentActor(target.transform.name);
    }

    public void lookAtActor(int index)
    {
        following = true;        
        target = actorGenerator.actors[index].gameObject.transform;

        // Send data to UI
        uIController.setCurrentActor(target.transform.name);
    }
}