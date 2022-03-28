using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace CarterGames.Assets.LeaderboardManager.Demo
{
    public class ExampleManager : MonoBehaviour
    {
        [SerializeField] private InputField boardID;
        [SerializeField] private InputField playerName;
        [SerializeField] private InputField playerScore;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] public TextMeshProUGUI Score;
        public int Score1;
         //GameStatus game;
        //public string curtScore;
        //public GameStatus script;
        
        //string sc;

        private void Start()
        {
            //script = GameObject.Find("Score").GetComponent<GameStatus>();
            //game.CurtScore(curtScore);
            //Debug.Log(curtScore);
             Score1 = PlayerPrefs.GetInt("score");
        }
        public void AddToBoard()
        {
            //playerScore = PlayerPrefs.GetInt("score");
            //Score1.text = game.scoreText.text;
            //game.CurtScore(curtScore);
            //Score1 = script.scoreText.text;
             //game.LOAD(game.playerScore);
            //Debug.Log(playerScore);

            //game.

            boardID.text = "Example";
            //Score.text = "22";
            if (playerName.text.Length <= 0 || Score1 <= 0)
            {
                Debug.Log($"<color=D6BA64><b>Leaderboard Manager Example</b> | Either the name or score fields were blank, please ensure the fields are filled before using this option.</color>");
                return;
            }

            LeaderboardManager.AddEntryToBoard(boardID.text, playerName.text, Score1);
            playerName.text = string.Empty;
            Score1 = 0;
        }
        public void loadPrefs()
        {
           

        }
        public void RemoveFromBoard()
        {
            boardID.text = "Example";
            if (playerName.text.Length <= 0 || Score.text.Length <= 0)
            {
                Debug.Log($"<color=D6BA64><b>Leaderboard Manager Example</b> | Either the name or score fields were blank, please ensure the fields are filled before using this option.</color>");
                return;
            }
                
            LeaderboardManager.DeleteEntryFromBoard(boardID.text, playerName.text, double.Parse(Score.text));
            playerName.text = string.Empty;
            playerScore.text = string.Empty;
        }

        public void ClearBoard()
        {
            LeaderboardManager.ClearLeaderboard(boardID.text);
        }

        public void ClearAll()
        {
            boardID.text = "Example";
            LeaderboardManager.DeleteLeaderboard(boardID.text);
        }
    }
}