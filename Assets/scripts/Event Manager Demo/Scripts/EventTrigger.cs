using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManagerDemo
{

// Event Trigger TEMPLATE
// This shows how to set up an event trigger, assumes you have an Event Manager
// in the scene and you've attached a Listener to each object that needs to listen
// and this script is connected to objects that trigger events, see also
// Event Manager and Event Listener scripts. 

public class EventTrigger : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            EventManager.TriggerEvent("tEvent");
        }

        if (Input.GetKeyDown("y"))
        {
            EventManager.TriggerEvent("yEvent");
        }
    }
}

}   
