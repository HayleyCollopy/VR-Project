using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.GADVRMini;

namespace Example3
{
    public class Example3Ball : MonoBehaviour
    {
        [Range(0, 5.0f)]
        public float dist = 0.0f;
        public void OnGrabbed(Draggable d)
        {
            GADManager.Instance.minigame.PullToHand(d.currentGrabber, dist);
        }
    }

}
