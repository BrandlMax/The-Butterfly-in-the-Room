using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public CameraManager cameraManager;
    // 0 = Nothing
    // 1 = SelectionView
    // 2 = DetailView
    public int currentState = 1;

    [Header("Canvases")]
    public GameObject canvas_front;
    public GameObject canvas_left;
    public GameObject canvas_right;

    [Header("Front UI")]
    public TMP_Text ui_front_prevActor;
    public TMP_Text ui_front_nextActor;
    public TMP_Text ui_front_currentActor;
    public TMP_Text ui_front_activeIssues;

    [Header("Left UI")]
    public Image ui_left_image;

    [Header("SelectionView")]
    public GameObject selectionViewCanvas;
    public GameObject actorListContainer;
    public List<TMP_Text> actorList = new List<TMP_Text>();
    public GameObject actorListItemPrefab;
    public TMP_Text selected;

    [Header("DetailView")]
    public GameObject detailViewCanvas;
    public TMP_Text positive;
    public TMP_Text hazard;
    public TMP_Text issue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            scrollActorList(-1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            scrollActorList(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            zoomOut();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            zoomIn();
        }
    }

    public void updateEventCounter(int c)
    {
        if(c > 0)
        {
            ui_front_activeIssues.text = c + " active issues";
        } else
        {
            ui_front_activeIssues.text = " ";
        }
    }

    public void setLeftImage(Sprite sprite)
    {
        ui_left_image.sprite = sprite;
    }

    public void zoomOut()
    {        
        if(currentState == 2)
        {
            detailViewCanvas.SetActive(false);
            selectionViewCanvas.SetActive(true);
            currentState = 1;
        }
    }

    public void zoomIn()
    {     
        if (currentState == 1)
        {
            detailViewCanvas.SetActive(true);
            selectionViewCanvas.SetActive(false);
            currentState = 2;
        }
    }

    public void generateActorList(List<Actor> actors)
    {
        int i = 0;
        foreach(Actor actor in actors)
        {
            GameObject newListItem = Instantiate(actorListItemPrefab);
            string name = actor.actorName;
            newListItem.name = name;
            newListItem.GetComponent<TMPro.TMP_Text>().text = name;
            actorList.Add(newListItem.GetComponent<TMPro.TMP_Text>());
            if(selected == null)
            {
                selected = newListItem.GetComponent<TMPro.TMP_Text>();
            }
            newListItem.transform.SetParent(actorListContainer.transform);
            RectTransform rt = newListItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, i * rt.sizeDelta.y, 0);
            rt.localScale = new Vector3(1, 1, 1);
            i++;
        }
    }

    public void scrollActorList(int axis)
    {        
        int amount = (int)selected.GetComponent<RectTransform>().sizeDelta.y;

        // New selection
        int index = actorList.IndexOf(selected);
        if (index >= 0 && index < actorList.Count)
        {
            selected.color = Color.gray;
            if(axis != -1 && index == 0)
            {
                // last item
            } else
            {
                Debug.Log("Selected Index: " + actorList.IndexOf(selected));
                Debug.Log("Actor: " + actorList[actorList.IndexOf(selected)]);
                selected = actorList[actorList.IndexOf(selected) + (axis * -1)];

                selected.color = Color.white;
                cameraManager.lookAtActor(actorList.IndexOf(selected));
                if(index < actorList.Count-1)
                {
                    setNextActor(actorList[index + 1]);
                }
                if (index > 0)
                {
                    setPrevActor(actorList[index - 1]);
                }
            }
        }

        // Move up or down
        Vector3 pos = actorListContainer.GetComponent<RectTransform>().localPosition;
        actorListContainer.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y + (amount * axis), pos.z);
    }

    public void setCurrentActor(Actor actor)
    {
        ui_front_currentActor.text = actor.actorName;
        string s_positive = "";
        string s_hazard = "";
        string s_issue = "";

        foreach(Event e in actor.events)
        {
            switch (e.eventType)
            {
                case (EventController.EventType.Hazard):
                    s_hazard += e.eventMessage;
                    break;
                case (EventController.EventType.Issue):
                    s_issue += e.eventMessage;
                    break;
                case (EventController.EventType.Positive):
                    s_positive += e.eventMessage;
                    break;
            }
        }

        setLeftImage(actor.GetComponentInChildren<SpriteRenderer>().sprite);
        positive.text = s_positive;
        hazard.text = s_hazard;
        issue.text = s_issue;
    }

    public void setPrevActor(TMP_Text t)
    {
        ui_front_prevActor.text = t.text;
    }

    public void setNextActor(TMP_Text t)
    {
        ui_front_nextActor.text = t.text;
    }
}
