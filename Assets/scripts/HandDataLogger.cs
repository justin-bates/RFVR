using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;

public class HandDataLogger : MonoBehaviour
{
    XRHandSubsystem handSubsystem;
    List<XRHandSubsystem> handSubsystems = new List<XRHandSubsystem>();

    void Start()
    {
        SubsystemManager.GetSubsystems(handSubsystems);
        if (handSubsystems.Count > 0)
        {
            handSubsystem = handSubsystems[0];
            handSubsystem.updatedHands += OnUpdatedHands;
        }
    }

    void OnUpdatedHands(XRHandSubsystem subsystem,
        XRHandSubsystem.UpdateSuccessFlags updateSuccessFlags,
        XRHandSubsystem.UpdateType updateType)
    {
        PrintJointData(subsystem.leftHand, "Left");
        PrintJointData(subsystem.rightHand, "Right");
    }

    void PrintJointData(XRHand hand, string handSide)
    {
        if (!hand.isTracked)
            return;

        for (var i = XRHandJointID.BeginMarker.ToIndex();
                i < XRHandJointID.EndMarker.ToIndex();
                i++)
        {
            var jointData = hand.GetJoint(XRHandJointIDUtility.FromIndex(i));
            if (jointData.TryGetPose(out Pose pose))
            {
                Debug.Log("Hand: " + handSide +
                    ", Joint: " + XRHandJointIDUtility.FromIndex(i).ToString() +
                    ", Position: " + pose.position +
                    ", Rotation: " + pose.rotation);
            }
        }
    }
}
