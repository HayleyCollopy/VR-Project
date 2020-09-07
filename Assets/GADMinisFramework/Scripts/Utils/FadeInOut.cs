using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdoch.GAD361.GADVRMini
{
    public class FadeInOut : MonoBehaviour
    {
        Animator animator;
        
        void Awake()
        {
            animator = GetComponent<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void FadeOut()
        {
            animator.SetTrigger("FadeOut");
        }

        public void FadeIn()
        {
            animator.SetTrigger("FadeIn");
        }

        public void FadeOutComplete()
        {
            GADManager.Instance.FadeOutComplete();
        }
    }
}