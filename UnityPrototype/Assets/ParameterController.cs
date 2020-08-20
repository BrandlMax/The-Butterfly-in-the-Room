using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterController : MonoBehaviour
{
    [Header("Other")]
    public TableController tableController;
    public List<Parameter> parameters = new List<Parameter>();
    public List<Parameter> activeParameters = new List<Parameter>();
    public ActorGenerator actorGenerator;
    Parameter wildcard;
    [Range(0, 10)]
    public float distanceCheck = 0.2f;

    [Header("Cards on Table")]
    public List<GameObject> cardGameObjects = new List<GameObject>();
    public List<CardML> cardsOnTable = new List<CardML>();
    public List<GameObject> notOnTable = new List<GameObject>();

    [Header("Karten Texturen")]
    public Texture2D texture_Ads;
    public Texture2D texture_Cat;
    public Texture2D texture_Cloud;
    public Texture2D texture_Connection;
    public Texture2D texture_Aluminium;
    public Texture2D texture_Gamification;
    public Texture2D texture_Bamboo;
    public Texture2D texture_Home;
    public Texture2D texture_OnDevice;
    public Texture2D texture_AI;
    public Texture2D texture_Plastic;
    public Texture2D texture_Social;
    public Texture2D texture_Speech;
    public Texture2D texture_Touch;
    public Texture2D texture_Inclusive;
    public Texture2D texture_Capital;
    public Texture2D texture_Wearable;

    [Header("Karten Sprites")]
    public Sprite sprite_Ads;
    public Sprite sprite_Cat;
    public Sprite sprite_Cloud;
    public Sprite sprite_Connection;
    public Sprite sprite_Aluminium;
    public Sprite sprite_Gamification;
    public Sprite sprite_Bamboo;
    public Sprite sprite_Home;
    public Sprite sprite_OnDevice;
    public Sprite sprite_AI;
    public Sprite sprite_Plastic;
    public Sprite sprite_Social;
    public Sprite sprite_Speech;
    public Sprite sprite_Touch;
    public Sprite sprite_Inclusive;
    public Sprite sprite_Capital;
    public Sprite sprite_Wearable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCardsOnTable();
        activateWildcard();
    }

    public void UpdateCardsOnTable()
    {
        notOnTable.Clear();

        foreach(GameObject entry in cardGameObjects)
        {
            notOnTable.Add(entry);
        }

        foreach(CardML entry in cardsOnTable)
        {
            GameObject card;
            switch (entry.name)
            {
                case "Social":
                    card = FindCardGameObjectByName("social integration");
                    UpdateCardPosition(card, entry.x, entry.y);
                    break;
                case "Wearable":
                    card = FindCardGameObjectByName("Wearable");
                    UpdateCardPosition(card, entry.x, entry.y);
                    break;
                case "Speech":
                    card = FindCardGameObjectByName("Speech Recognition");
                    UpdateCardPosition(card, entry.x, entry.y);
                    break;
                case "Gaming":
                    card = FindCardGameObjectByName("Gamification Aspect");
                    UpdateCardPosition(card, entry.x, entry.y);
                    break;
                case "onDevice":
                    card = FindCardGameObjectByName("On Device Storage");
                    UpdateCardPosition(card, entry.x, entry.y);
                    break;
                case "Plastic":
                    card = FindCardGameObjectByName("PVC Plastic");
                    UpdateCardPosition(card, entry.x, entry.y);
                    break;
                case "Cloud":
                    card = FindCardGameObjectByName("Cloud Storage");
                    UpdateCardPosition(card, entry.x, entry.y);
                    break;
                default:
                    card = null;
                    break;
            }
            if (notOnTable.Contains(card))
            {
                notOnTable.Remove(card);
                card.SetActive(true);
            }
        }
        foreach(GameObject entry in notOnTable)
        {
            entry.SetActive(false);
        }
    }

    public GameObject FindCardGameObjectByName(string name)
    {
        foreach(GameObject card in cardGameObjects)
        {
            if(card.GetComponent<Parameter>().parameterName == name)
            {
                return card;
            }
        }
        Debug.Log("Cant find '" + name + "'");
        return null;
    }

    public double Map(double x, double in_min, double in_max, double out_min, double out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    //public void cleanUpTable()
    //{
    //    Debug.Log("Clean up table");
    //    foreach(CardML card in cardsOnTable)
    //    {
    //        GameObject cardGO;
    //        switch (card.name)
    //        {
    //            case "Social":
    //                cardGO = FindCardGameObjectByName("social integration");                    
    //                break;
    //            case "Wearable":
    //                cardGO = FindCardGameObjectByName("Wearable");                    
    //                break;
    //            case "Speech":
    //                cardGO = FindCardGameObjectByName("Speech Recognition");                    
    //                break;
    //            case "Gaming":
    //                cardGO = FindCardGameObjectByName("Gamification Aspect");                    
    //                break;
    //            case "onDevice":
    //                cardGO = FindCardGameObjectByName("On Device Storage");                    
    //                break;
    //            case "Plastic":
    //                cardGO = FindCardGameObjectByName("PVC Plastic");                    
    //                break;
    //            case "Cloud":
    //                cardGO = FindCardGameObjectByName("Cloud Storage");                    
    //                break;
    //            default: //
    //                cardGO = null;
    //                break;
    //        }
    //        if(cardGO != null)
    //        {
    //            Parameter p = cardGO.GetComponent<Parameter>();
    //            Debug.Log("Lifetime of " + p.parameterName + ": " + p.lifetime);
    //            if (p.lifetime > 2)
    //            {
    //                removeActiveParameter(p);
    //            }
    //        }
    //    } 
    //}

    public void UpdateCardPosition(GameObject card, float x, float y)
    {
        if(card != null)
        {         
            Debug.Log("Updating card: " + card.name);
            card.SetActive(true);
            float x_mapped = (float)Map(y, 320f, 70f, -0.06f, 0.43f);            
            float y_mapped = (float)Map(x, 450f, 70f, -1.5f, -2.273f);
            Vector3 pos = new Vector3(x_mapped, 0.9f, y_mapped);
            if(Vector3.Distance(card.transform.localPosition, pos) > distanceCheck)
            {
                Debug.Log("Distance: " + Vector3.Distance(card.transform.position, pos));
                card.transform.localPosition = pos;
            }
            tableController.addCardToTable(card.GetComponent<Card>());
            // card.GetComponent<Parameter>().lifetime = 0f;
        } else
        {
            Debug.Log("Card is null");
        }
    }

    public void addActiveParameter(Parameter parameter)
    {
        if(activeParameters.Contains(parameter) == false)
        {
            parameter.gameObject.SetActive(true);

            // Add to List
            activeParameters.Add(parameter);

            // Activate Events
            parameter.isActive = true;
            foreach(Event e in parameter.events)
            {
                e.ActivateEvent();
            }
        }
    }

    public void removeActiveParameter(Parameter parameter)
    {
        activeParameters.Remove(parameter);
        parameter.isActive = false;
        // parameter.gameObject.SetActive(false);

        // Remove lines
        //LineRenderer[] lrs = parameter.gameObject.GetComponentsInChildren<LineRenderer>();
        //foreach(LineRenderer lr in lrs)
        //{
        //    lr.gameObject.SetActive(false);
        //}
    }

    public void createParameter(string[] data)
    {
        // name, category, actors, event1, event2

        GameObject newParameterGO = new GameObject();
        Parameter newParameter = newParameterGO.AddComponent<Parameter>();
        newParameterGO.transform.parent = this.gameObject.transform;
        newParameterGO.transform.name = data[0];

        newParameter.parameterController = this;

        // Fill with data
        newParameter.parameterName = data[0];
        newParameter.category = GetCategory(data[1]);
        
        // Texture & Sprite
        newParameter.texture = GetTexture(data[0]);
        newParameter.sprite = GetSprite(data[0]);

        // Line Color
        newParameter.color = getColorByCardname(data[0]);

        // Add to list
        parameters.Add(newParameter);

        if (newParameter.parameterName == "WILDCARD")
        {
            wildcard = newParameter;
        }
    }

    public Color getColorByCardname(string name)
    {
        switch (name)
        {
            case "social integration":
                return getColor(cardColor.Gray);
            case "Wearable":
                return getColor(cardColor.Green);
            case "Speech Recognition":
                return getColor(cardColor.Green);
            case "Gamification Aspect":
                return getColor(cardColor.Gray);
            case "On Device Storage":
                return getColor(cardColor.Yellow);
            case "PVC Plastic":
                return getColor(cardColor.Violet);
            case "Cloud Storage":
                return getColor(cardColor.Yellow);
            default:
                return new Color(0, 0, 0, 0);
        }
    }

    public void activateWildcard()
    {
            addActiveParameter(wildcard);    
    }

    public enum category
    {
        NoCategorySet,
        Sensoren,
        Medium,
        Datenspeicher,
        AI,
        Energie,
        Betriebssystem,
        Connections,
        Community,
        Material,
        Funding
    }

    public enum cardColor
    {
        Blue,
        Red,
        Gray,
        Violet,
        Green,
        Yellow
    }

    [Header("Colors")]
    public List<Color> cardColors = new List<Color>(6);

    public Color getColor(cardColor c)
    {
        switch (c)
        {
            case cardColor.Blue:
                return cardColors[0];
            case cardColor.Red:
                return cardColors[1];
            case cardColor.Gray:
                return cardColors[2];
            case cardColor.Violet:
                return cardColors[3];
            case cardColor.Green:
                return cardColors[4];
            case cardColor.Yellow:
                return cardColors[5];
        }
        return new Color(0,0,0);
    }

    public Texture2D GetTexture(string name)
    {
        switch (name)
        {
            case "Ads Funded":
                return texture_Ads;
            case "Cat Content":
                return texture_Cat;
            case "Cloud Storage":
                return texture_Cloud;
            case "Connection to Smarthome":
                return texture_Connection;
            case "Fancy Aluminium":
                return texture_Aluminium;
            case "Gamification Aspect":
                return texture_Gamification;
            case "Hipster Bamboo":
                return texture_Bamboo;
            case "Home placed":
                return texture_Home;
            case "On Device Storage":
                return texture_OnDevice;
            case "Personalized Character":
                return texture_AI;
            case "PVC Plastic":
                return texture_Plastic;
            case "Social Integration":
                return texture_Social;
            case "Speech Recognition":
                return texture_Speech;
            case "Touch Screen":
                return texture_Touch;
            case "Using Inclusive Design Kit":
                return texture_Inclusive;
            case "VC Capital":
                return texture_Capital;
            case "Wearable":
                return texture_Wearable;
            default:
                return null;
        }
    }

    public Sprite GetSprite(string name)
    {
        switch (name)
        {
            case "Ads Funded":
                return sprite_Ads;
            case "Cat Content":
                return sprite_Cat;
            case "Cloud Storage":
                return sprite_Cloud;
            case "Connection to Smarthome":
                return sprite_Connection;
            case "Fancy Aluminium":
                return sprite_Aluminium;
            case "Gamification Aspect":
                return sprite_Gamification;
            case "Hipster Bamboo":
                return sprite_Bamboo;
            case "Home Stationed":
                return sprite_Home;
            case "On Device Storage":
                return sprite_OnDevice;
            case "personalized character":
                return sprite_AI;
            case "PVC Plastic":
                return sprite_Plastic;
            case "social integration":
                return sprite_Social;
            case "Speech Recognition":
                return sprite_Speech;
            case "Touch Screen":
                return sprite_Touch;
            case "Using Inclusive Design Kit":
                return sprite_Inclusive;
            case "VC Capital":
                return sprite_Capital;
            case "Wearable":
                return sprite_Wearable;
            default:
                return null;
        }
    }

    public category GetCategory(string name)
    {
        switch (name)
        {
            case "Sensoren":
                return category.Sensoren;
            case "Medium":
                return category.Medium;
            case "Datenspeicher":
                return category.Datenspeicher;
            case "AI":
                return category.AI;
            case "Energie":
                return category.Energie;
            case "Betriebssystem":
                return category.Betriebssystem;
            case "Connections":
                return category.Connections;
            case "Community":
                return category.Community;
            case "Material":
                return category.Material;
            case "Funding":
                return category.Funding;
            default:
                return category.NoCategorySet;
        }
    }
}
