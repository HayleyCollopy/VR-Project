using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Murdoch.GAD361.GADVRMini
{
    public class BaseUI : MonoBehaviour
    {
        bool shown = true;
        
        protected virtual void Awake()
        {
            //shown shoud reflect whatever has been set in the inspector.
            shown = gameObject.activeSelf;
        }

        public void Toggle()
        {
            shown = !shown;
            gameObject.SetActive(shown);
        }

        public void Show(bool show = true)
        {
            shown = show;
            gameObject.SetActive(shown);
        }
    }
}