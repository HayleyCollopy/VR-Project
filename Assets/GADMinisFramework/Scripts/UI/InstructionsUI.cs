using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Murdoch.GAD361.GADVRMini
{
    public class InstructionsUI : BaseUI
    {
        public TextMeshProUGUI instructionText;
     
        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(transform.position.x, 
                                            GADManager.Instance.VR.cam.transform.position.y, 
                                            transform.position.z);    
        }

        public void SetText(string txt)
        {
            instructionText.text = txt;
        }

    }
}