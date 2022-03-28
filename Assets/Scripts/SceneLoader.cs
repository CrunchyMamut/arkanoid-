using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
   
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

   
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();

    }
    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("LoadSaved") == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        }    
    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene(4);
        

    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("LoadSaved", 1);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Application.Quit();
    }
}
