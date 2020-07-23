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

    public void OnDrag(PointerEventData eventData)
    {
        rT = gameObject.GetComponent<RectTransform>();
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(uiCanvas.transform as RectTransform, eventData.position, uiCanvas.worldCamera, out pos);
        GetComponent<Image>().transform.position = uiCanvas.transform.TransformPoint(pos);
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
        }
        else
        {
            Debug.Log("Reset Position");
            gameObject.GetComponent<RectTransform>().localPosition = oldPosition;
        }
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
        // Map Size of Card to Screen Center
        if(rT.position.x < 0.5 && rT.position.x > -0.5)
        {
            // Scale Card up and show CTA
            float newScale = Mathf.Lerp(rT.sizeDelta.x, maxScale, 2f);
            rT.localScale = new Vector2(newScale, newScale);
            id_ui.ShowCardCTA(true);
            wasScaledUp = true;
        } else
        {
            if (wasScaledUp)
            {
                // Scale Card down and hide CTA
                rT.localScale = new Vector2(1f, 1f);
                id_ui.ShowCardCTA(false);
                wasScaledUp = false;
            }            
        }
    }

    public void toMouse()
    {
        GetComponent<RectTransform>().position = Input.mousePosition;
    }
}