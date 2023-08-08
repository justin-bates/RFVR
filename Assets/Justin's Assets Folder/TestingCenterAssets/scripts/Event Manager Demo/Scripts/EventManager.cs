using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace EventManagerDemo
{

    // EventManager: Implementation of an Event Manager
    //
    // Based, in part, on the the tutorial "Live Training April 13th, 2015: Creating a Simple Messaging System"
    // https://youtu.be/0AqG1fDhPT8 We create a simple messaging system to reduce dependencies and allow for
    // easier maintenance of our projects since not every object needs to know about every other object. We set
    // up Event Listeners in our objects to listen for Events that are sent to it via the Event Manager
    // and triggered by scripts that initiated triggers. 
    // Architecture:
    // Event Manager = handles the dictionary of events and functions to be called when events are invoked
    // Listeners = sets up listening for a particular event (see EventListener script for a simple example)
    // Triggers = triggers events that will be handled by any object listening for that event (see EventTrugger script for a simple example)

    public class EventManager : MonoBehaviour
    {
        private Dictionary<string, UnityEvent> OurEventDictionary;
        private static EventManager eventManager; // our instance of the  Event Manager 

        public static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                    // if we don't have a reference to our instance so we need to go out and find it
                    if (eventManager)
                    {
                        eventManager.Init();
                    }
                    else
                    {
                        Debug.LogError("An active EventManager script was not found in the scene.");
                    }
                }
                return eventManager;
            }
        }

        // Init: Initialize our dictionary 

        void Init()
        {
            if (OurEventDictionary == null)
            {
                OurEventDictionary = new Dictionary<string, UnityEvent>();
            }
        }

        // Start Listening: start listening for our event

        public static void StartListening(string eventName, UnityAction listener)
        {
            // create a new Unity Event
            UnityEvent thisEvent = null;

            // Do we have an entry in our dictionary?
            if (instance.OurEventDictionary.TryGetValue(eventName, out thisEvent))
            // Note: We are using TryGetValue here because it makes it possible to grab value and returns null
            // if does not exists and we avoind having to handle a KeyNotFound exception
            {
                thisEvent.AddListener(listener);  // add the unity action to the event
            }
            else
            {
                thisEvent = new UnityEvent(); // create a new Unity Event
                thisEvent.AddListener(listener); // add the listener
                instance.OurEventDictionary.Add(eventName, thisEvent); // push it to the dictionary
            }
        }

        // Stop Listening: stop listening for our event

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (eventManager == null) return;
            UnityEvent thisEvent = null;
            if (instance.OurEventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        // Trigger Event:  will call all of the functions that are on those listeners

        public static void TriggerEvent(string eventName)
        {
            UnityEvent thisEvent = null;
            if (instance.OurEventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }

}
