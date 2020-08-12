using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ID_UI : MonoBehaviour
{
    public List<Parameter> parameters = new List<Parameter>();
    public GameObject cardUIPrefab;
    public GameObject cta_card;
    public GameObject cardContainer;
    public ID_Setup id_setup;
    public GameObject dropPosition;
    public TableController tableController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCardCTA(bool b)
    {
        if(cta_card.activeSelf != b)
        {
            cta_card.SetActive(b);
        }        
    }

    public void ScrollCards(int axis)
    {
        int amount = 200;
        Vector3 pos = cardContainer.GetComponent<RectTransform>().localPosition;
        cardContainer.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y + (amount * axis), pos.z);
    }

    public void GenerateUICards(List<Parameter> paras)
    {
        parameters = paras;
        int i = 0;
        foreach(Parameter card in paras)
        {
            GameObject cardElement = Instantiate(cardUIPrefab);
            cardElement.transform.SetParent(cardContainer.transform);
            cardElement.name = card.name;
            RectTransform rt = cardElement.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(900, i * rt.sizeDelta.y, 0);
            rt.localScale = new Vector3(1,1,1);
            cardElement.GetComponent<Image>().sprite = card.sprite;
            i++;
        }
    }

    public GameObject getCardGameObject(string name)
    {
        return id_setup.kartenContainer.transform.Find(name).gameObject;
    }
}
