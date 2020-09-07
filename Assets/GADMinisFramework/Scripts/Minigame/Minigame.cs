using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTC.UnityPlugin.Utility;
using HTC.UnityPlugin.PoseTracker;
using HTC.UnityPlugin.Vive;

namespace Murdoch.GAD361.GADVRMini
{
    public class Minigame : MonoBehaviour
    {
        public MinigameDetails details;

        protected VRContext VR;

        public void InitVR()
        {
            VR = GADManager.Instance.VR;
            GADManager.Instance.minigame = this;
        }

        public void StartGame()
        {
            
            if (details == null)
            {
                GADManager.Instance.StartMiniGame("Didn't Set Details", 7.0f);
            }
            else
            {
                GADManager.Instance.StartMiniGame(details.instructionText, details.timeAllowed);
            }
        }

        public virtual void WinGame()
        {
            //Means stop the clock and do win animation.
            GADManager.Instance.WinGame();
        }

        public void ShowMessage(string msg, float time)
        {

        }

        public void PullToHand(Draggable.Grabber g, float dist = 0.0f)
        {
            //StartCoroutine("LerpHitDistance", time);
            g.hitDistance = dist;
        }

        /*
        This function is going to need the currentGrabber as well as the
        time to pull. Then we need to worry about if the object is 
        released in the interim. This might make the grabber == null, 
        but easier to not lerp for now.

        public IEnumerator LerpHitDistance(float time)
        {
            float timer = 0.0f;
            while (timer < time)
            {

            }
            return;
        }
        */

        /* Unused Code
        float rdist = Vector3.Distance( d.currentGrabber.grabberOrigin.pos, GADManager.Instance.VR.right.position);
        float ldist = Vector3.Distance( d.currentGrabber.grabberOrigin.pos, GADManager.Instance.VR.left.position);

        //Debug.Log(d.draggedEvent);
        //Debug.Log(d.currentGrabber);
        //Debug.Log(d.currentGrabber.grabberOrigin);
        //Debug.Log(d.currentGrabber.grabOffset);
        //Debug.Log(d.grabberOrigin);

        //transform.position = d.currentGrabber.grabberOrigin.pos;
        //transform.position = GADManager.Instance.VR.left.position;
        
        //d.currentGrabber.grabOffset = RigidPose.identity;

        //poseTracker.target = GADManager.Instance.VR.left.transform;
        //Debug.Log(GADManager.Instance.VR.right.position);

        
        if (rdist < 0.1f)
        {
            
            poseTracker.role = HandRole.RightHand;
            poseTracker.
        }
        if (ldist < 0.1f)
        {
            poseTracker.role = HandRole.LeftHand;
        }
        
        d.currentGrabber.hitDistance = 0.0f;
        
        
         */

    }
}
