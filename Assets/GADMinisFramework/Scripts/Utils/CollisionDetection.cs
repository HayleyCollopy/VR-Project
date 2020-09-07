using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Murdoch.GAD361.GADVRMini
{
    public enum CollisionType
    {
        COLLISION,
        TRIGGER
    }

    [System.Serializable]
    public class CollisionAction : UnityEvent<GameObject, GameObject>
    {
        public GameObject arg1;
        public GameObject arg2;
    }

    public class CollisionDetection : MonoBehaviour
    {
        public string tagOfInterest = "";
        public CollisionType colType = CollisionType.TRIGGER;
        
        public CollisionAction OnEnter = new CollisionAction();
        public CollisionAction OnExit = new CollisionAction();
        public CollisionAction OnStay = new CollisionAction();
        
        bool trigger;

        void Start()
        {
            trigger = false;
            if (colType == CollisionType.TRIGGER)
                trigger = true;
        }

        void OnTriggerEnter(Collider col)
        {
            if (!trigger || tagOfInterest == "")
                return;
            if (col.tag == tagOfInterest)
            {
                OnEnter.Invoke(gameObject, col.gameObject);
            }
        }
        void OnTriggerExit(Collider col)
        {
            if (!trigger || tagOfInterest == "")
                return;
            if (col.tag == tagOfInterest)
            {
                OnExit.Invoke(gameObject, col.gameObject);
            }
        }
        void OnTriggerStay(Collider col)
        {
            if (!trigger || tagOfInterest == "")
                return;
            if (col.tag == tagOfInterest)
            {
                OnStay.Invoke(gameObject, col.gameObject);
            }
        }
        void OnCollisionEnter(Collision col)
        {
            if (trigger || tagOfInterest == "")
                return;
            if (col.collider.tag == tagOfInterest)
            {
                OnEnter.Invoke(gameObject, col.gameObject);
            }
        }
        void OnCollisionExit(Collision col)
        {
            if (trigger || tagOfInterest == "")
                return;
            if (col.collider.tag == tagOfInterest)
            {
                OnExit.Invoke(gameObject, col.gameObject);
            }
        }
        void OnCollisionStay(Collision col)
        {
            if (trigger || tagOfInterest == "")
                return;
            if (col.collider.tag == tagOfInterest)
            {
                OnStay.Invoke(gameObject, col.gameObject);
            }
        }
   }

}