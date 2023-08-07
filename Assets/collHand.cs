using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnColliderEnter(Collider collider)
    {
        Debug.Log("collision now with - " + collider.gameObject.name);

        
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision with" + other.gameObject.name);
    }
}
