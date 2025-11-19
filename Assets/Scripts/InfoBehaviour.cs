using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    const float Speed = 6f;
    [SerializeField]
    Transform ArtworkInfo;

    Vector3 desiredScale = Vector3.zero;

    private  GazeInteract gazeInteract;
   


    void Start()
    {
        gazeInteract = GameObject.FindWithTag("MainCamera").GetComponent<GazeInteract>();
        gazeInteract.ListItem(this);
    }


    // Update is called once per frame
    void Update()
    {//this code is contstantly closing the information when it spawns in.
        ArtworkInfo.localScale = Vector3.Lerp(ArtworkInfo.localScale, desiredScale, Time.deltaTime * Speed);
        //Debug.LogWarning("InfoBehaviour is changing scale");

        Debug.LogError("Scale is currently: " + desiredScale);

    }

    public void OpenInfo()
    {
        Debug.LogWarning("Test");
        desiredScale = Vector3.one;
        //Debug.LogWarning("Opening Info via InfoBehaviour");
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
        //Debug.LogWarning("Closing Info via InfoBehaviour");
    }
}
