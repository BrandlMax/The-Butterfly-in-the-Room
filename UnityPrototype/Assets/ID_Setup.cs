using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_Setup : MonoBehaviour
{
    public GameObject parameters;
    public GameObject karte;
    public GameObject kartenContainer;
    public bool cardsGenerated = false;
    public ID_UI id_ui;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!cardsGenerated && parameters.transform.childCount >= 16)
        {
            GenerateCards();
            id_ui.GenerateUICards(parameters.GetComponent<ParameterController>().parameters);            
        }
    }

    void GenerateCards()
    {
        cardsGenerated = true;
        for (int i = 0; i < parameters.transform.childCount; i++)
        {
            GameObject entry = parameters.transform.GetChild(i).gameObject;
            GameObject newCard = Instantiate(karte);
            Parameter para = entry.GetComponent<Parameter>();
            newCard.GetComponent<Parameter>().parameterName = para.parameterName;
            newCard.GetComponent<Parameter>().category = para.category;
            newCard.GetComponent<Parameter>().actors = para.actors;
            newCard.GetComponent<Parameter>().events = para.events;
            newCard.GetComponent<Parameter>().isActive = para.isActive;
            newCard.GetComponent<Parameter>().texture = para.texture;
            newCard.GetComponent<Parameter>().sprite = para.sprite;
            newCard.GetComponent<Renderer>().material.SetTexture("_BaseColorMap", newCard.GetComponent<Parameter>().texture);                
            newCard.transform.position = kartenContainer.transform.position;
            newCard.transform.parent = kartenContainer.transform;
            // newCard.GetComponent<Rigidbody>().useGravity = true;
            newCard.transform.name = entry.GetComponent<Parameter>().parameterName;
        }
    }
}
