using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Murdoch.GAD361.GADVRMini
{
    public class GameUI : BaseUI
    {
        public delegate void TimerDelegate(bool didwin);
        public TimerDelegate OnTimeUp;

        public TextMeshProUGUI secondsText;
        public TextMeshProUGUI millisecondsText;
        public LifeUI lifeUI;
        public InstructionsUI instructionsUI;

        float timeLeft = 0.0f;
        int secondsLeft; //seconds left
        int uiSecondsLeft; //seconds shown on UI
        int millisecondsLeft; //milliseconds left (as int, 00-99)
        bool gameStarted = false;
        // Start is called before the first frame update
        void Start()
        {
            ShowLives(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (gameStarted)
            {
                timeLeft -= Time.deltaTime;
                secondsLeft = (int)timeLeft;
                millisecondsLeft = (int)(100*(timeLeft-secondsLeft));
                UpdateUI();

                if (timeLeft <=0.0f)
                {
                    gameStarted = false;
                    if (OnTimeUp != null)
                    {
                        //call with false because we're out of time.
                        OnTimeUp(false);
                    }
                }
            }
        }

        public void StartGame(float time)
        {
            Reset(time);
            gameStarted  = true;
            HideInstructionText();
        }

        public void PauseGame()
        {
            gameStarted = false;
        }
        public void UnPauseGame()
        {
            gameStarted = true;
        }

        public void Reset(float time = 7.0f)
        {
            gameStarted = false;
            timeLeft = time;
            secondsLeft = (int)timeLeft;
            millisecondsLeft = 0;
            UpdateUI();

        }

        public void UpdateUI()
        {
            if (secondsLeft != uiSecondsLeft)
            {   
                uiSecondsLeft = secondsLeft;
                secondsText.text = "" + uiSecondsLeft;
            }
            millisecondsText.text = "." + millisecondsLeft;

        }

        public void ShowInstructions(string txt, float time)
        {
            instructionsUI.SetText(txt);
            instructionsUI.Show(true);
        }

        public void HideInstructionText()
        {
            instructionsUI.Show(false);
        }

        public void ShowLives(bool show)
        {
            lifeUI.Show(show);
        }
    }
}