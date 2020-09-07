using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.GADVRMini;

namespace Example3
{
    public class Example3 : Minigame
    {
        public GameObject prefabBall;
        public Transform spawnPoint;
        float ballCount;
        int spawnCount = 1;
        // Start is called before the first frame update
        void Start()
        {
            ballCount = 0;
            InitVR();
            StartGame(); //comment this out to test without timer
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void HitTarget(GameObject target, GameObject ball)
        {
            Destroy(ball);
            ballCount += 1;
            if (ballCount == 3)
            {
                WinGame();
            }
        }

        public void HitGround(GameObject ground, GameObject ball)
        {
            Destroy(ball);
        }

        public void BallMoved(GameObject table, GameObject ball)
        {
            RespawnBall();
        }

        void RespawnBall()
        {
            Instantiate(prefabBall, spawnPoint.position, spawnPoint.rotation);
        }

    }
}