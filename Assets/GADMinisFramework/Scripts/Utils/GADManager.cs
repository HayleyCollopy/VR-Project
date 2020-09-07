using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Murdoch.GAD361.GADVRMini
{
    public class GADManager : MonoBehaviour
    {
        private static GADManager _instance;
        private static Minigame _minigame;

        public float instructionTime = 1.5f;
        public float winAnimationTime = 2.5f;
        public GameSound gameSound;

        public FadeInOut levelFader;
        public LobbyUI lobbyUI;
        public GameUI gameUI;

        private List<MinigameInfo> minigameScenes;
        private int lobbyIndex = -1;     //index of the lobby scene.
        private int gameOverIndex = 0;  //index of the game over scene
        private int gameWinIndex = 0;   //index of the game win scene
        private int currentMiniGameIndex = -1;
        private int nextSceneIndex;     //scene to load after fade.

        private const float standardMinigameTime = 7.0f;
        private float currentMinigameTime = 7.0f;

        private VRContext vrContext;

        public VRContext VR
        {
            get 
            { 
                if (vrContext == null)
                {
                    vrContext = GetComponent<VRContext>();
                    //AcquireSceneElements();
                }
                return vrContext;
            }
        }

        public Minigame minigame
        {
            get
            {
                return _minigame;
            }
            set 
            {
                _minigame = value;;
            }
        }

        public static GADManager Instance
        {
            get { return _instance; }
        }


        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
                SceneManager.sceneLoaded += OnLevelFinishedLoading;
                vrContext = GetComponent<VRContext>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            minigameScenes = new List<MinigameInfo>();
            ProcessScenes();
            lobbyUI.AddMiniGames(minigameScenes);

            //Debug.Log("Scene index is " + SceneManager.GetActiveScene().buildIndex);
            
            //AcquireSceneElements();

            if (SceneManager.GetActiveScene().buildIndex == lobbyIndex)
            {
                gameUI.Show(false);
                lobbyUI.Show(true);
            }
            else
            {
                gameUI.Show(true);
                lobbyUI.Show(false);
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("Enter debug mode.");
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                NextMiniGame();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Pause /unpause the timer");
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Reload the level");
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Back to lobby");
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                Debug.Log("Loop this scene");
            }
        }


        private void ProcessScenes()
        {
            //Debug.Log("Scenes...");
            int numScenes = SceneManager.sceneCountInBuildSettings;
            for (int i = 0; i< numScenes; i++)
            {
                //Scene s = SceneManager.GetSceneByBuildIndex(i);
                string spath = SceneUtility.GetScenePathByBuildIndex(i);
                //Debug.Log(spath);
                //Scene scene = SceneManager.GetSceneByName(spath);
                //Debug.Log(scene.name);
                string[] snames = spath.Split(new char[] {'/'});
                string scenename = snames[snames.Length-1];
                //Debug.Log(scenename);
                if (scenename.StartsWith("Mini") )
                {
                    MinigameInfo mgi = new MinigameInfo();
                    mgi.scenePath = spath;
                    mgi.sceneName = scenename;
                    mgi.gameName = scenename;
                    mgi.sceneIndex = i;

                    minigameScenes.Add(mgi);
                }
                if (scenename == "Lobby.unity")
                {
                    lobbyIndex = i;
                }
            }
        }

        private void NextMiniGame()
        {
            currentMiniGameIndex+=1;
            if (minigameScenes.Count > currentMiniGameIndex)
            {
                SwitchToMiniGame(minigameScenes[currentMiniGameIndex].sceneIndex);
            }
            else
            {
                Debug.Log("There Were No More Mini Games");
                SwitchToLobby();
            }
        }

        public void SwitchToMiniGame(int index)
        {
            nextSceneIndex = index;
            if (levelFader != null)
            {
                levelFader.FadeOut();
            }
        }

        public void SwitchToLobby()
        {
            nextSceneIndex = lobbyIndex;
            if (levelFader != null)
            {
                levelFader.FadeOut();
            }   
        }

        public void FadeOutComplete()
        {
            if (nextSceneIndex == lobbyIndex)
            {
                gameUI.Show(false);
                lobbyUI.Show(true);
            }
            else
            {
                lobbyUI.Show(false);
                gameUI.Show(true);
            }
            VR.active = false;
            SceneManager.LoadScene(nextSceneIndex);
        }

        private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            //Debug.Log("Loaded Level " + SceneManager.GetActiveScene());
            VR.active = true;
            if (levelFader != null)
            {
                levelFader.FadeIn();
            }
        }

        private void StartGame()
        {
            //subscribe to delegate
            gameUI.OnTimeUp += SetGameWon;
            //thell the UI to start
            gameUI.StartGame(currentMinigameTime);
        }

        private void SetGameWon(bool didwin)
        {
            //either the game was won or lost.
            //if they lost on time, this will be called as false.
            Debug.Log("Won Game? :" + didwin);
            //remove this delegate.
            gameUI.OnTimeUp -= SetGameWon;
            PauseMiniGame(); //stop the timer
            //If they won, wait a bit while the animation plays.
            //if they lost, show less lives.
            if (didwin)
            {
                gameSound.PlayWin();
                Invoke("NextMiniGame", winAnimationTime);
            }
            else
            {
                gameSound.PlayLose();
                NextMiniGame();
            }
        }

        //user calls this to start
        public void StartMiniGame(string instructionText, float time = standardMinigameTime)
        {
            currentMinigameTime = time;
            gameUI.ShowInstructions(instructionText, instructionTime);
            Invoke("StartGame", instructionTime);
        }

        public void PauseMiniGame()
        {
            gameUI.PauseGame();
        }
        public void UnPauseMiniGame()
        {
            gameUI.UnPauseGame();
        }

        //user calls this when game is won.
        public void WinGame()
        {
            SetGameWon(true);
        }
    }
}