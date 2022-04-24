using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Profile // Saves the profile name, preferences, and highscore
{
    public string name;
    public int colorIndex;
    public int shapeIndex;
    public int score;

    public Profile()
    {
        name = "New Profile";
        colorIndex = 0;
        shapeIndex = 0;
        score = 0;
    }
    public Profile(string changeName, int changeColor, int changeShape, int changeScore)
    {
        name = changeName;
        colorIndex = changeColor;
        shapeIndex = changeShape;
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
    public int GetColor()
    {
        return colorIndex;
    }
    public void SetColor(int changeColor)
    {
        colorIndex = changeColor;
    }
    public int GetShape()
    {
        return shapeIndex;
    }
    public void SetShape(int changeShape)
    {
        shapeIndex = changeShape;
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
