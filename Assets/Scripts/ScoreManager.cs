using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    private void Awake()
    {
        sd = new ScoreData();
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    public void LoadScorr(Score score)
    {

    }
    public void OnDestroy()
    {
        
    }
}
