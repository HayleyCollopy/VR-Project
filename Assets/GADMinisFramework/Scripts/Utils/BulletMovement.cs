using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdoch.GAD361.GADVRMini
{
    [RequireComponent(typeof(Rigidbody)) ]
    public class BulletMovement : MonoBehaviour
    {
        [Header ("Initial Speed of Bullet")]
        [Range(0.0f, 300f)]
        public float speed = 20.0f;

        [Header ("Uses Gravity?")]
        [Tooltip("This will override the rigidbody gravity selection")]
        public bool useGravity = false;

        [Header ("Destroy Bullet After")]
        [Tooltip("A value of zero means don't destroy!")]
        [Range(0.0f, 7.0f)]
        public float destroyAfter = 0.0f;
        
        Rigidbody rb;
        
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (useGravity)
                rb.useGravity = true;
            else
                rb.useGravity = false;

            rb.velocity = transform.forward * speed;
            
            if (destroyAfter > 0)
            {
                Destroy(gameObject, destroyAfter);
            }
        }

    }
}
