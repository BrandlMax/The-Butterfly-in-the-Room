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

    // Movement
    Vector3 currentTarget;
    public int maxTargetDistance = 10;
    public float maxSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        getNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(label != null && labelLookAtCamera)
        {
            label.transform.LookAt(Camera.main.transform);
        }

        if(Vector3.Distance(this.gameObject.transform.position, this.currentTarget) > 1.5f)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.currentTarget, maxSpeed);
        } else
        {
            getNewTarget();
        }

    }

    void getNewTarget()
    {
        currentTarget = new Vector3(Random.Range(gameObject.transform.position.x - maxTargetDistance, gameObject.transform.position.x + maxTargetDistance), Random.Range(gameObject.transform.position.y - maxTargetDistance, gameObject.transform.position.y + maxTargetDistance), Random.Range(gameObject.transform.position.z - maxTargetDistance, gameObject.transform.position.z + maxTargetDistance));
    }

    public void addData(string[] data)
    {
        this.data = data;
    }
}
