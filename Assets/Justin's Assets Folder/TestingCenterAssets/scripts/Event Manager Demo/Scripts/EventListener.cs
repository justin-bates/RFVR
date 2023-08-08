using System;
using UnityEngine;
using UnityEngine.Events;

// Event Listener TEMPLATE
// In this example using the EventManager, we set up two events, a t event (triggered in our demo here by the t key)
// and a y event (triggered in our demo here by the y key). Anything can trigger an event, and then every obejct that is
// listening for that event will execute the function it has designated to handle that event, , see also Event Manager and 
// Event Trigger scripts.  
// ---------------------------------------------------------------------------------------------------------------------
// If you need to pass parameters with the trigger functions see this: "Pass parameters with UnityAction"
// https://stackoverflow.com/questions/44615452/pass-parameters-with-unityaction
// it's a little more complicated if you need to add paramenter handling

namespace EventManagerDemo
{

public class EventListener: MonoBehaviour
{
    private UnityAction tListener;
    private UnityAction yListener;

    // we need to set up OnEnable and OnDisable this becuase you don't destroy the reference when you destroy the game  object, 
    // the reference to the listener will remain after the destruction of the game object
    // so this system has the possibility of memory leaks if you don't manage it correctly! 
    // Any Destroy Function should OnDisable() before destroying the object

    void Awake()
    {
        tListener = new UnityAction(tFunction);
        yListener = new UnityAction(yFunction);
    }

    private void OnEnable()
    {
            // Enable events, we have two in this example, it can be as many as you need
            EventManager.StartListening("tEvent", tListener);
            EventManager.StartListening("yEvent", yListener);
    }

    private void OnDisable()
    {
        // Disable events this makes sure we don't have a memory leak problem 
        EventManager.StopListening("tEvent", tListener);
        EventManager.StopListening("yEvent", yListener);
    }

    private void tFunction()
    {
            // Here is where you do what you want to do when the event is triggered 
            Debug.Log("tFunction called as a result of a t event");
    }

    private void yFunction()
    {
            // Here is where you do what you want to do when the event is triggered 
            Debug.Log("yFunction called as a result of a y event");
        }
    }

}
