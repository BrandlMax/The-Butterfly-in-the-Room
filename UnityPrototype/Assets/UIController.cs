using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Canvases")]
    public GameObject canvas_front;
    public GameObject canvas_left;
    public GameObject canvas_right;

    [Header("Front UI")]
    public TMP_Text ui_front_prevActor;
    public TMP_Text ui_front_nextActor;
    public TMP_Text ui_front_currentActor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCurrentActor(string t)
    {
        ui_front_currentActor.text = t;
    }

    public void setPrevActor(string t)
    {
        ui_front_prevActor.text = t;
    }

    public void setNextActor(string t)
    {
        ui_front_nextActor.text = t;
    }
}
