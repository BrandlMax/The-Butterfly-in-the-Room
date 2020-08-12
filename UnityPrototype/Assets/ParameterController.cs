using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterController : MonoBehaviour
{
    [Header("Other")]
    public TableController tableController;
    public List<Parameter> parameters = new List<Parameter>();
    public List<Parameter> activeParameters = new List<Parameter>();

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
        
    }

    public void addActiveParameter(Parameter parameter)
    {
        activeParameters.Add(parameter);
    }

    public void removeActiveParameter(Parameter parameter)
    {
        activeParameters.Remove(parameter);
    }

    public void createParameter(string[] data)
    {
        // name, category, event1, actors, event2
        // Debug.Log("Create Parameter: " + data[0]);

        GameObject newParameterGO = new GameObject();
        Parameter newParameter = newParameterGO.AddComponent<Parameter>();
        newParameterGO.transform.parent = this.gameObject.transform;
        newParameterGO.transform.name = data[0];
        newParameter.parameterName = data[0];
        newParameter.category = GetCategory(data[1]);
        newParameter.texture = GetTexture(data[0]);
        newParameter.sprite = GetSprite(data[0]);
        parameters.Add(newParameter);
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
