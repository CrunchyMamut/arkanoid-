using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData
{
    public int score;

    public PlayerData (GameStatus status)
    {
        score = status.currentScore;
     }
}
