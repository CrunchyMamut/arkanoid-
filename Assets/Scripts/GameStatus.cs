using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameStatus : MonoBehaviour
{
    //configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 2;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    public string curtScore;
    //public TextMeshProUGUI curtScore;
    [SerializeField] public int currentScore;
    public ScoreManager scoreManager;

    Score savaData = new Score();
    public int playerScore;
    
    

private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        scoreText.text = currentScore.ToString();
        //scoreManager.AddScore(new Score(currentScore));
        //Debug.Log(scoreManager.LoadScore());
    }

    
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        //curtScore = currentScore.ToString();
        //curtScore.text = currentScore.ToString();
        playerScore = currentScore;
        SAVE();
        
    }

    public void SAVE()
    {
        PlayerPrefs.SetInt("score", playerScore);
        Debug.Log(PlayerPrefs.GetInt("score"));
    }
    /*public void LOAD(int playerScore)
    {
        playerScore = PlayerPrefs.GetInt("score");
    }*/
    public void CurtScore(string curtScore )
    {
        //game.curtScore = currentScore.ToString();
        curtScore = currentScore.ToString();

    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
