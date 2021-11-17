using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    public GameObject child;
    public GameObject placedObject;
    public ARRaycastManager raycastManager;
    public bool soilPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> objectsHit = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, objectsHit, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
            if (objectsHit.Count > 0 && !soilPlaced)
            {             
                GameObject.Instantiate(placedObject, objectsHit[0].pose.position, objectsHit[0].pose.rotation);
                soilPlaced = true;
            }
        }
    }

}
