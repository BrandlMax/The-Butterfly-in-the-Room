using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("SelectionView")]
    public GameObject selectionViewCanvas;
    public GameObject actorListContainer;
    public List<TMP_Text> actorList = new List<TMP_Text>();
    public GameObject actorListItemPrefab;
    public TMP_Text selected;

    [Header("DetailView")]
    public GameObject detailViewCanvas;

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

    public void zoomOut()
    {
        Debug.Log("zoomOut()");
        if(currentState == 2)
        {
            detailViewCanvas.SetActive(false);
            selectionViewCanvas.SetActive(true);
            currentState = 1;
        }
    }

    public void zoomIn()
    {
        Debug.Log("zoomIn()");
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
            selected = actorList[actorList.IndexOf(selected) + axis * -1];
            selected.color = Color.white;
            cameraManager.lookAtActor(index+1);
        }

        // Move up or down
        Vector3 pos = actorListContainer.GetComponent<RectTransform>().localPosition;
        actorListContainer.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y + (amount * axis), pos.z);
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
