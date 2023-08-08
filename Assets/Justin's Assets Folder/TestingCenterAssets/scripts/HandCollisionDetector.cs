using UnityEngine;

public class HandCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rHand")
        {
            Debug.Log("Hand has entered the capsule object.");
            // Perform the action you want to trigger on collision.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "rHand")
        {
            Debug.Log("Hand has left the capsule object.");
            // Perform the action you want to trigger on collision end.
        }
    }
}
