using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption
{
    public string text;
    public string targetID;
    public bool takeQuest;

    [Header("Anim")]
    public string takeAction;

    [Header("Give")]
    public bool giveItem;
    public int gold;

    [Header("Jump Weight")]
    public int weight;
}