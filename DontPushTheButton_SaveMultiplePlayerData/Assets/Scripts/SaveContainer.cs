using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveContainer
{
    public List<Profile> players; // List of active profiles
    public TopScore[] leaders; // Array of top five scorers

    public int currentIndex;
    public SaveContainer()
    {
        players = new List<Profile>();
        leaders = new TopScore[5];

        for (int i = 0; i < leaders.Length; ++i)
        {
            leaders[i] = new TopScore();
        }
    }
    public void AddProfile()
    {
        players.Add(new Profile("Profile" + (players.Count + 1), 0, 0, 0));
    }
    public void RemoveProfile(int index)
    {
        players.RemoveAt(index);
    }
}
