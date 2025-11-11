using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEditor;

public class ARModelManager : MonoBehaviour
{
    public List<GameObject> modelprefabs; // a list of posible prefabs for the player to pick
    public GameObject selectedprefab; // the prefab the player has picked

    private ARRaycastManager raycastManager; //this handles plane detection raycasts
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); // this stores the raycast results

    public SpawnMenuController menuController; 

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>(); //Gets the RaycastManager on the same object

        if (raycastManager == null)
        {
            raycastManager = FindAnyObjectByType<ARRaycastManager>();
            if (raycastManager == null)
                Debug.LogError("No ARRaycastManager found in the scene");
        }
    }

    private void Update()
    {
        if (selectedprefab == null) return; //if there is no model selected, do nothing...

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Detected");
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon)) // Raycasts from screen pos into AR world and looks for planes
                {
                    Pose hitPose = hits[0].pose; 
                    Debug.Log("Plane hit at" + hitPose.position);
                    Instantiate(selectedprefab, hitPose.position, hitPose.rotation); //spawns the selected prefab at that position and rotation
                }
                else
                {
                    Debug.Log("No plane hit!");
                }
            }
        }
    }

    public void SelectModel(int index)
    {
        if (index < 0 || index >= modelprefabs.Count) return;
        selectedprefab = modelprefabs[index];
        Debug.Log("Selected Model" + modelprefabs[index]);
        if (menuController != null)
        {
            menuController.HideMenu();
        }
    }
}
