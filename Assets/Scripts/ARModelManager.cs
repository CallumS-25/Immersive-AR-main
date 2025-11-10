using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEditor;

public class ARModelManager : MonoBehaviour
{
    public List<GameObject> modelprefabs;
    private GameObject selectedprefab;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public SpawnMenuController menuController;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();

        if (raycastManager == null)
        {
            raycastManager = FindAnyObjectByType<ARRaycastManager>();
            if (raycastManager == null)
                Debug.LogError("No ARRaycastManager found in the scene");
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

    private void Update()
    {
        if (selectedprefab == null)
        {
            Debug.LogError("NO ARRaycastManager Found!");
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Detected");
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;
                    Debug.Log("Plane hit at" + hitPose.position);
                    Instantiate(selectedprefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    Debug.Log("No plane hit!");
                }
            }
        }
    }
}
