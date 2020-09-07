using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Murdoch.GAD361.GADVRMini
{
    public class FaceCamera : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Camera camera = Camera.main;

            //transform.LookAt(transform.position - Camera.main.transform.position, Vector3.up);
            transform.LookAt(transform.position + 
                            camera.transform.rotation * Vector3.forward, 
                            camera.transform.rotation * Vector3.up);

        }
    }
}