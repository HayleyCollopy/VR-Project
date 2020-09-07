using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.Utility;

namespace Murdoch.GAD361.GADVRMini
{
    public class VRControllerInfo
    {
        HandRole role;
        RigidPose pose;

        public Vector3 position { get { return pose.pos; } }
        public Quaternion rotation { get { return pose.rot; } }
        //Vector3 velocity;
        //Raycast hit?
        //forward vector?
        bool triggerPressedDown;
        bool triggerPressedUp;
        bool triggerPressedAtAll;

        public bool triggerPressed { get {return triggerPressedDown; }}
        public bool triggerReleased { get {return triggerPressedUp; }}
        public bool triggerHeld { get {return triggerPressedAtAll; }}

        //constructor
        public VRControllerInfo(HandRole r)
        {
            role = r;
        }

        public void UpdateState()
        {
            pose = VivePose.GetPoseEx(role);
            if (ViveInput.GetPressDownEx(role, ControllerButton.Trigger))
            {
                triggerPressedDown = true;
            }
            else
            {
                triggerPressedDown = false; 
            }
            if (ViveInput.GetPressUpEx(role, ControllerButton.Trigger))
            {
                triggerPressedUp = true;
            }
            else
            {
                triggerPressedUp = false;
            }
            if (ViveInput.GetPressEx(role, ControllerButton.Trigger))
            {
                triggerPressedAtAll = true;
            }
            else
            {
                triggerPressedAtAll = false;
            }
        }

                    //ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Trigger, ButtonEventType.Down, TriggerRightListener);
            //ViveInput.AddListenerEx(HandRole.LeftHand, ControllerButton.Trigger, ButtonEventType.Down, TriggerLeftListener);

        /*
        private void OnDestroy()
        {
            //ViveInput.RemoveListenerEx(HandRole.RightHand, ControllerButton.Trigger, ButtonEventType.Down, TriggerRightListener);
            //ViveInput.RemoveListenerEx(HandRole.LeftHand, ControllerButton.Trigger, ButtonEventType.Down, TriggerLeftListener);
        }
        */


    }
    public class VRContext : MonoBehaviour
    {
        public VRControllerInfo right
        {
            get { return rController; }
        }
        public VRControllerInfo left
        {
            get { return lController; }
        }
        public Camera cam
        {
            get
            {
                if (vrCamera == null)
                    vrCamera = Camera.main;
                return vrCamera;
            }
        }

        
        public bool active = true;
        private VRControllerInfo rController;
        private VRControllerInfo lController;
        private Camera vrCamera;

        private void Awake()
        {
            rController = new VRControllerInfo(HandRole.RightHand);
            lController = new VRControllerInfo(HandRole.LeftHand);
            vrCamera = Camera.main;
        }
        
       
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        public void Update()
        {   
            if (active)
            {
                rController.UpdateState();
                lController.UpdateState();

                // set transform to the mid point between them
                /*
                if (VivePose.IsValidEx(HandRole.RightHand) && VivePose.IsValidEx(TrackerRole.Tracker1))
                {
                transform.localPosition = Vector3.Lerp(pose1.pos, pose2.pos, 0.5f);
                transform.localRotation = Quaternion.Lerp(pose1.rot, pose2.rot, 0.5f);
                }
                */
            }
        }
    }
}
