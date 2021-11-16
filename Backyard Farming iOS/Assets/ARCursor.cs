using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    public GameObject child;
    public GameObject testObject;
    public ARRaycastManager raycastManager;
    public bool displayCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        child.SetActive(displayCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayCursor)
        {
            UpdateCursor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (displayCursor)
            {
                GameObject.Instantiate(testObject, transform.position, transform.rotation);
            }
            else
            {
                List<ARRaycastHit> objectsHit = new List<ARRaycastHit>();
                raycastManager.Raycast(Input.GetTouch(0).position, objectsHit, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                if (objectsHit.Count > 0)
                {
                    GameObject.Instantiate(testObject, objectsHit[0].pose.position, objectsHit[0].pose.rotation);
                }
            }
        }

    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> objectsHit = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, objectsHit, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (objectsHit.Count > 0)
        {
            transform.position = objectsHit[0].pose.position;
            transform.rotation = objectsHit[0].pose.rotation;
        }
    }
}
