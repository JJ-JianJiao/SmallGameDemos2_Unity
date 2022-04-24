using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LocalizationData", menuName = "InClassLocalization/MenuData")]
public class MenuData : ScriptableObject
{
    public string startText; 
    public string optionText; 
    public string exitText; 
    public string backText; 
}
