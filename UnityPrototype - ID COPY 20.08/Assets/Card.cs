using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Card : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Camera camera;
    private float mZCoord;

    private Vector3 screenPoint;
    private Vector3 offset;

    public LineRenderer lr_1;
    public LineRenderer lr_2;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DRAGGING");
        Vector3 cursorPoint = new Vector3(eventData.position.x, eventData.position.y, screenPoint.z);
        Vector3 cursorPosition = camera.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position += Vector3.up * 0.1f;
        // transform.LookAt(camera.gameObject.transform, Vector3.up);
        GetComponent<Rigidbody>().useGravity = false;
        screenPoint = camera.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, screenPoint.z));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().useGravity = true;
        Debug.Log("UP");
    }

    /*
    private Vector3 GetMouseWorldPos(Vector3 mousePos)
    {
        Vector3
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectsWithTag("ID_Camera")[0].GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
