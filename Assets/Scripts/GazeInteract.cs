using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GazeInteract : MonoBehaviour
{
    List<InfoBehaviour> infos = new List<InfoBehaviour>();

    void Start()
    {
        infos = Object.FindObjectsByType<InfoBehaviour>(FindObjectsSortMode.None).ToList();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                OpenInfo(go.GetComponent<InfoBehaviour>());
                print("HERE");
            }
            else
            {
                CloseAll();
                Debug.LogWarning("Closing Info via Update");
            }
        }
    }
    void OpenInfo(InfoBehaviour desiredInfo)
    {
        foreach (InfoBehaviour info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo();
                Debug.LogWarning("Opening Info via Gazeinteract");
            }
            else
            {
                info.CloseInfo();
                Debug.LogWarning("Closing Info via Gazeinteract");
            }
        }
    }

    void CloseAll()
    {
        foreach(InfoBehaviour info in infos)
        {
            info.CloseInfo();
            Debug.LogWarning("Closing Info via GazeInteract");

        }
    }
}
