using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class FaceCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Canvas _canvas;

    //[SerializeField]
    //private List<Canvas> _canvasList;

    Transform cam;
    Vector3 targetAngle = Vector3.zero;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        _canvas.transform.LookAt(_canvas.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
