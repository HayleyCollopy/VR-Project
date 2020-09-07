using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Murdoch.GAD361.GADVRMini
{
    public class MinigameButton : MonoBehaviour
    {
        public TextMeshProUGUI buttonText;
        Button button;
        MinigameInfo minigameInfo;

        void Awake()
        {
            button = GetComponent<Button>();
        } 
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        public void SetButtonInfo(MinigameInfo m)
        {
            minigameInfo = m;
            buttonText.text = m.gameName;
            button.onClick.AddListener(LoadGame);
        }

        void LoadGame()
        {
            GADManager.Instance.SwitchToMiniGame(minigameInfo.sceneIndex);
        }
    }
}