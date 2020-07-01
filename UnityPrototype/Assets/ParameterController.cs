using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterController : MonoBehaviour
{
    public List<Parameter> parameters = new List<Parameter>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createParameter(string[] data)
    {
        // name, category, event1, actors, event2
        Debug.Log("Create Parameter: " + data[0]);

        GameObject newParameterGO = new GameObject();
        Parameter newParameter = newParameterGO.AddComponent<Parameter>();
        newParameterGO.transform.parent = this.gameObject.transform;
        newParameterGO.transform.name = data[0];
        newParameter.parameterName = data[0];
        newParameter.category = GetCategory(data[1]);
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
