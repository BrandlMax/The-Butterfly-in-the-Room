using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter : MonoBehaviour
{
    public string parameterName;
    public ParameterController parameterController;
    public ParameterController.category category;
    public List<Actor> actors = new List<Actor>();
    public List<Event> events = new List<Event>();
    public bool isActive = false;
    public Texture texture;
    public Sprite sprite;    
    public Color color;
    public float lifetime = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }


}
