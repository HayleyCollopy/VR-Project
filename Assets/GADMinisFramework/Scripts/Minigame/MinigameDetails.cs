using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Murdoch.GAD361.GADVRMini
{
    [System.Serializable]
    [CreateAssetMenu (fileName="NewMinigame", menuName="GADVR/Minigame")]
    
    public class MinigameDetails : ScriptableObject
    {
        public string gameName;
        public Sprite gameImage;
        public string instructionText;
        public float timeAllowed = 7.0f;
    }
}