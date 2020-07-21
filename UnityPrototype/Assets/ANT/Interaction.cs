using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public int id;
    public string interactionName;
    public Actor actor1;
    public Actor actor2;
    public LineRenderer line;
    // ToDo: Interactiontype

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    void UpdateLine()
    {
        line.SetPosition(0, actor1.gameObject.transform.position);
        line.SetPosition(1, actor2.gameObject.transform.position);
    }
}
