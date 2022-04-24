using System.Collections;
using UnityEngine;
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo piInstance = null;
    public Vector3 spawnLocation;
    public string currentScene;
    public Vector3 offset_n;

    private void Awake()
    {
        if (piInstance == null) // If there is not yet a gamemanager then this object
                                // will be the gamemanager.
        {
            piInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (piInstance != this) // If there is already a gamemanager then destroy
                                     // this object. There should only ever be one.
        {
            Destroy(gameObject);
        }
    }
}
