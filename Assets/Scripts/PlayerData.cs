using System;

[Serializable]
public class PlayerData
{
    public int TotalScore;

    public PlayerData(int totalScore)
    {
        TotalScore = totalScore;
    }
}
