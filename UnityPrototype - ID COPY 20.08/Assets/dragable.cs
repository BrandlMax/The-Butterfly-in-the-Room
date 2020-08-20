using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class dragable : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Camera uiCam;
    public Canvas uiCanvas;
    public ID_UI id_ui;
    public float maxScale = 3;
    RectTransform rT;
    public bool wasScaledUp = false;
    public Vector3 oldPosition;
    [Range(0, 100)]
    public int dropAreaInPercent = 30;

    public void OnDrag(PointerEventData eventData)
    {
        rT = gameObject.GetComponent<RectTransform>();
        // Vector2 pos;
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(uiCanvas.transform as RectTransform, eventData.position, uiCanvas.worldCamera, out pos);
        //GetComponent<Image>().transform.position = uiCanvas.transform.TransformPoint(pos);
        GetComponent<Image>().transform.position = Input.mousePosition;
        id_ui.ShowCardCTA(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        oldPosition = gameObject.GetComponent<RectTransform>().localPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (wasScaledUp)
        {
            Debug.Log("In Center");
            GameObject card = id_ui.getCardGameObject(gameObject.name);
            id_ui.tableController.addCardToTable(card.GetComponent<Card>());
            card.transform.localPosition = id_ui.dropPosition.transform.localPosition;
            card.GetComponent<Rigidbody>().useGravity = true;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Reset Position");
            gameObject.GetComponent<RectTransform>().localPosition = oldPosition;
        }
        id_ui.ShowCardCTA(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        uiCanvas = transform.parent.parent.GetComponent<Canvas>();
        id_ui = uiCanvas.GetComponent<ID_UI>();
        uiCam = GetComponentInParent<Camera>();
        rT = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {        
        float distanceInPixel = Screen.width / 100 * dropAreaInPercent;
        // Map Size of Card to Screen Center
        if(rT.localPosition.x < distanceInPixel && rT.localPosition.x > -distanceInPixel)
        {
            // Scale Card up and show CTA
            float newScale = Mathf.Lerp(rT.sizeDelta.x, maxScale, 2f);
            rT.localScale = new Vector2(newScale, newScale);
            wasScaledUp = true;
        } else
        {
            if (wasScaledUp)
            {
                // Scale Card down and hide CTA
                rT.localScale = new Vector2(1f, 1f);
                wasScaledUp = false;
            }            
        }
    }

    public void toMouse()
    {
        GetComponent<RectTransform>().position = Input.mousePosition;
    }
}