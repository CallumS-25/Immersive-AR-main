using TMPro;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Canvas _canvas;
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
