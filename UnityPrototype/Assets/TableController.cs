using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public ParameterController parameterController;

    [Header("Cards")]
    public List<Card> cardsOnTable = new List<Card>();

    [Header("Positions")]
    public Transform ioT;
    public Transform user;

    [Header("Line")]
    public float lineWidth = 0.05f;
    public Material lineMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cardsOnTable != null)
        {
            foreach(Card card in cardsOnTable)
            {
                UpdateLine(card);
            }
        }
    }

    public void addCardToTable(Card card)
    {
        if (!cardsOnTable.Contains(card))
        {
            // Add to list
            cardsOnTable.Add(card);
            addLines(card);

            // Add to parameterController
            parameterController.addActiveParameter(card.GetComponent<Parameter>());
        }
    }

    void addLines(Card card)
    {
        // Add children with 2 lineRenderer

        // From IoT to Card
        GameObject lr_left = Instantiate(new GameObject());
        lr_left.transform.SetParent(card.gameObject.transform);
        lr_left.transform.name = "LineRenderer IOT";
        LineRenderer lr = lr_left.AddComponent<LineRenderer>();
        lr.SetPosition(0, card.gameObject.transform.position);
        lr.SetPosition(1, ioT.position);
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.material = lineMaterial;
        card.lr_1 = lr;

        // From Card to User
        GameObject lr_right = Instantiate(new GameObject());
        lr_right.transform.SetParent(card.gameObject.transform);
        lr_right.transform.name = "LineRenderer User";
        LineRenderer lr_r = lr_right.AddComponent<LineRenderer>();
        lr_r.SetPosition(0, card.gameObject.transform.position);
        lr_r.SetPosition(1, user.position);
        lr_r.startWidth = lineWidth;
        lr_r.endWidth = lineWidth;
        lr_r.material = lineMaterial;
        card.lr_2 = lr_r;

        // Colors
        Color c = card.GetComponent<Parameter>().color;
        card.lr_1.material.SetColor("_UnlitColor", c);
        card.lr_2.material.SetColor("_UnlitColor", c);
    }

    void UpdateLine(Card card)
    {
        card.lr_1.SetPosition(0, card.gameObject.transform.position);
        card.lr_1.SetPosition(1, ioT.position);

        card.lr_2.SetPosition(0, card.gameObject.transform.position);
        card.lr_2.SetPosition(1, user.position);
    }

    public void removeCardFromTable(Card card)
    {

    }
}
