﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.GADVRMini;

namespace ClearTable
{
    public class ClearTable : Minigame
    {
        public GameObject go;
        int targetObjCount = 4;
        int objsDetected = 0;
        // Start is called before the first frame update
        void Start()
        {
            InitVR();
            //StartGame(); //comment this out to test without timer
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void HitFloor(GameObject floor, GameObject obj)
        {
            objsDetected += 1;
            //Destroy(obj);
            if (objsDetected == targetObjCount)
            {
                WinGame();
            }
        }

    }
}
