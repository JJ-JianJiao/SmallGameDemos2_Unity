using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TopScore // Saves the name and score for the top five all time scorers.
{
    public string name;
    public int score;
 

    public TopScore()
    {
        name = "Empty";
        score = 0;
    }
    public TopScore(string changeName, int changeScore)
    {
        name = changeName;
        score = changeScore;
    }
    public string GetName()
    {
        return name;
    }
    public void SetName(string changeName)
    {
        name = changeName;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value)
    {
        score = value;
    }
}
