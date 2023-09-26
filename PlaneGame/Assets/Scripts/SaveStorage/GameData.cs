using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int Score;
    public int Coins;

    public GameData(DataLoader dataLoader)
    {
        Score = dataLoader.Score.MaxScore;

    }
}
