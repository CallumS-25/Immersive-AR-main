using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    const float Speed = 6f;
    [SerializeField]
    Transform ArtworkInfo;

    Vector3 desiredScale = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        ArtworkInfo.localScale = Vector3.Lerp(ArtworkInfo.localScale, desiredScale, Time.deltaTime * Speed);
    }

    public void OpenInfo()
    {
        desiredScale = Vector3.one;
        
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
    }
}
