using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Murdoch.GAD361.GADVRMini
{
    public class LobbyUI : BaseUI
    {
        public int gamesPerRow = 5;

        public GameObject rowPrefab;
        public MinigameButton vrMinigamePrefab;
        public GameObject miniGamesUI;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void AddMiniGames(List<MinigameInfo> games)
        {
            //Debug.Log("Buiding UI with " + games.Count + " games");
            int numrows = (games.Count / gamesPerRow) + 1;
            for (int row = 0; row < numrows; row++)
            {
                GameObject rowObj = Instantiate(rowPrefab, Vector3.zero, Quaternion.identity);
                int gamesThisRow = (row + 1 == numrows) ? games.Count % gamesPerRow : gamesPerRow; 
                for (int game = 0; game < gamesThisRow; game++)
                {
                    MinigameButton gameButton = Instantiate(vrMinigamePrefab, Vector3.zero, Quaternion.identity);
                    gameButton.SetButtonInfo(games[row*gamesPerRow + game]);
                    gameButton.transform.SetParent(rowObj.transform, false);
                    //Debug.Log("Added button");
                }
                rowObj.transform.SetParent(miniGamesUI.transform, false);
                //Debug.Log("Added row");
            } 
        }
    }
}