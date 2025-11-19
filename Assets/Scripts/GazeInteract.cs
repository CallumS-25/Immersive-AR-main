using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GazeInteract : MonoBehaviour
{
    List<InfoBehaviour> infos = new List<InfoBehaviour>();

    void Start()
    {
        infos = FindObjectsOfType<InfoBehaviour>().ToList();
    }

    public void ListItem(InfoBehaviour thisInfo)
    {
        infos.Add(thisInfo);
        print(thisInfo);
    }


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                OpenGaze(go.GetComponent<InfoBehaviour>());
                //print("HERE");
            }
            else
            {
                CloseGaze();
                //Debug.LogWarning("Closing Info via Update");
            }
        }
    }
    void OpenGaze(InfoBehaviour desiredInfo)
    {
        print("OpenGaze Active!!");
        foreach (InfoBehaviour info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo();
                //Debug.LogWarning("Opening Info via Gazeinteract");
            }
            else
            {
                info.CloseInfo();
                //Debug.LogWarning("Closing Info via Gazeinteract");
            }
        }
    }

    void CloseGaze()
    {
        foreach(InfoBehaviour info in infos)
        {
            info.CloseInfo();
            //Debug.LogWarning("Closing Info via GazeInteract");

        }
    }
}
