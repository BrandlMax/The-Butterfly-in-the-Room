using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeWebSocket;

[Serializable]
public class CardML
{
    public string name;
    public float x;
    public float y;
    public float width;
    public float height;
}

[Serializable]
public class Cards
{
    public CardML[] cards;
}


public class WebsocketConnect : MonoBehaviour
{
    WebSocket websocket;
    public string ServerUrl = "ws://localhost:1337";
    public Cards cards;
    public ParameterController parameterController;

    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("Websocket Connect on Server: " + ServerUrl);

        websocket = new WebSocket(ServerUrl);

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        websocket.OnMessage += (bytes) =>
        {
            // getting the message as a string
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            //Debug.Log("OnMessage! " + message);

            var jsonString = System.Text.Encoding.UTF8.GetString(bytes);
            //Debug.Log("OnMessage! " + jsonString);

            if(message == "empty")
            {
                Debug.Log("No Message");
                cards.cards = new CardML[0];
            } else
            {
                // JSON to Object
                cards = JsonUtility.FromJson<Cards>(message);
            }
        };

        // Keep sending messages at every 0.3s
        // InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

        // waiting for messages
        await websocket.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
                websocket.DispatchMessageQueue();
#endif

        parameterController.cardsOnTable.Clear();

        foreach (CardML entry in cards.cards)
        {
            parameterController.cardsOnTable.Add(entry);
        }     
    }

    async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            await websocket.SendText("plain text message");
        }
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }
}
