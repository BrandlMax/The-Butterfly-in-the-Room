using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class RunwayConnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RestClient.Get("http://localhost:8000/data").Then(response => {
            Debug.Log(response.Text);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
