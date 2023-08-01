using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverActionScript : MonoBehaviour
{
    public XROrigin player;
    public float moveSpeed = 0.01f;
    private bool isHovering = false;

    // Called once per frame
    void Update()
    {
        if (isHovering)
        {
            // Get the player's gaze direction
            Vector3 gazeDirection = Camera.main.transform.forward;

            // Compute the new position
            Vector3 newPosition = player.transform.position + gazeDirection * moveSpeed;

            // Update the player's position
            player.transform.position = newPosition;
        }
    }

    // Called when hand starts hovering over the object
    public void OnHandHovering()
    {
        Debug.Log("Hand is hovering over the capsule.");
        isHovering = true;
    }

    // Called when hand stops hovering over the object
    public void OnHandHoveringExit()
    {
        Debug.Log("Hand has stopped hovering over the capsule.");
        isHovering = false;
    }
}
