using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.GADVRMini;


namespace Example2
{
    public class Example2 : Minigame
    {
        public GameObject bulletPrefab;
        public int damage = 0;
        // Start is called before the first frame update
        void Start()
        {
            InitVR();
            StartGame(); //comment this out to test without timer
        }

        // Update is called once per frame
        void Update()
        {
            if (VR.right.triggerPressed)
            {
                Instantiate(bulletPrefab, VR.right.position, VR.right.rotation);
            }
            if (VR.left.triggerPressed)
            {
                Instantiate(bulletPrefab, VR.left.position, VR.left.rotation);
            }
        }

        public void HitTarget(GameObject target, GameObject bullet)
        {
            Destroy(bullet);
            damage += 1;
            if (damage > 10)
            {
                WinGame();
            }
        }
    }
}
