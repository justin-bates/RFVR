using UnityEngine;

public class FollowHand : MonoBehaviour
{
    public Transform handTransform;

    void Update()
    {
        transform.position = handTransform.position;
        transform.rotation = handTransform.rotation;
    }
}
