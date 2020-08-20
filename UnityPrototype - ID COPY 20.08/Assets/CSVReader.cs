using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    // raw stings
    public List<string> stringList = new List<string>();

    // parsed data
    public List<Actor> actors = new List<Actor>();
    public List<Interaction> interactions = new List<Interaction>();
    public List<Parameter> parameters = new List<Parameter>();
    public List<Event> events = new List<Event>();

    // Scripts
    public ActorGenerator actorGenerator;
    public NetworkSetup networkSetup;
    public InteractionController interactionController;
    public ParameterController parameterController;
    public EventController eventController;

    // Start is called before the first frame update
    void Start()
    {
        
        // Get actorGenerator Script
        actorGenerator = GetComponent<ActorGenerator>();
        networkSetup = GetComponent<NetworkSetup>();

        // Read Actors
        /*
        List<string[]> actorsList = readCSV("actors");
        foreach (string[] actor in actorsList)
        {
            actorGenerator.addActor(actor);
        }
        */
        List<Dictionary<string, object>> data_actor = CSVReaderC.Read("Actors");
        for (var i = 0; i < data_actor.Count; i++)
        {
            string[] actor = new string[] {
                data_actor[i]["Name"].ToString(),
                data_actor[i]["Parents"].ToString(),
                data_actor[i]["Children"].ToString(),
                data_actor[i]["Events"].ToString(),
                data_actor[i]["Required Parameter for Active"].ToString(),
                data_actor[i]["Interaction"].ToString(),
                data_actor[i]["Interaction 2"].ToString()
            };
            actorGenerator.addActor(actor);
        }

        // Read Parameters
        /*
        List<string[]> parametersList = readCSV("parameters");
        foreach(string[] parameter in parametersList)
        {
            parameterController.createParameter(parameter);
        }
        */
        List<Dictionary<string, object>> data_parameter = CSVReaderC.Read("Parameters");
        for (var i = 0; i < data_parameter.Count; i++)
        {
            string[] parameter = new string[] {
                data_parameter[i]["Name"].ToString(),
                data_parameter[i]["Description"].ToString(),
                data_parameter[i]["Category"].ToString(),
                data_parameter[i]["Actors"].ToString(),
                data_parameter[i]["Events"].ToString(),
                data_parameter[i]["Events 2"].ToString()
            };
            parameterController.createParameter(parameter);
        }

        // Read Events
        /*
        List<string[]> eventList = readCSV("events");
        foreach(string[] entry in eventList)
        {
            eventController.createEvent(entry);
        }
        */
        List<Dictionary<string, object>> data_events = CSVReaderC.Read("Events");
        for (var i = 0; i < data_events.Count; i++)
        {
            string[] e = new string[] {
                data_events[i]["Name"].ToString(),
                data_events[i]["Message"].ToString(),
                data_events[i]["Video"].ToString(),
                data_events[i]["Event Type"].ToString(),
                data_events[i]["Actors"].ToString(),
                data_events[i]["Required Conditition"].ToString(),
                data_events[i]["Disable Condition"].ToString()
            };
            eventController.createEvent(e);
        }

        // Tell Network when finished
        networkSetup.connectActors();
        startReadingInteractions();
    }

    public void startReadingInteractions()
    {
        // Read Interactions
        // List<string[]> interactionList = readCSV("Interactions");
        List<Dictionary<string, object>> data = CSVReaderC.Read("Interactions");
        /* foreach (string[] interaction in interactionList)
        {
            if (interaction[0] != string.Empty || interaction[0] != null)
            {
                interactionController.createInteraction(interaction);
            }
        }
        */
        for (var i = 0; i < data.Count; i++)
        {
            string[] interaction = new string[] { data[i]["Name"].ToString(), data[i]["Actor A"].ToString(), data[i]["Actor B"].ToString() };
            interactionController.createInteraction(interaction);
        }
    }
    /*
    List<string[]> readCSV(string fileName)
    {
        stringList.Clear();
        StreamReader csv_stream = new StreamReader("Assets/Data/" + fileName + ".csv");
        while (!csv_stream.EndOfStream)
        {
            string inp_line = csv_stream.ReadLine();
            stringList.Add(inp_line);
        }
        csv_stream.Close();
        return parseList();
    }

    List<string[]> parseList()
    {
        List<string[]> parsedList = new List<string[]>();

        for (int i = 0; i < stringList.Count; i++)
        {
            string[] temp = stringList[i].Split(',');
            
            for (int j = 0; j < temp.Length; j++)
            {
                temp[j] = temp[j].Trim();  //removed the blank spaces
            }
            parsedList.Add(temp);
        }

        // parsedList[Zeile][Spalte]

        return parsedList;
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
