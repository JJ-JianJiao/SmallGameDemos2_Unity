using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldLoad : MonoBehaviour
{
    GameObject player;

    public GameObject Town1;
    public GameObject Town2;
    public GameObject Town3;

    // Start is called before the first frame update
    void Awake()
    {
        if (!SceneManager.GetSceneByName("Player").isLoaded)
        {
            SceneManager.LoadScene("Player",LoadSceneMode.Additive);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //if (PlayerInfo.piInstance.spawnLocation != Vector3.zero)
        //{
        //    player.transform.position = PlayerInfo.piInstance.spawnLocation;

        //}
        if (PlayerInfo.piInstance.offset_n != Vector3.zero)
        {

            switch (PlayerInfo.piInstance.currentScene)
            {
                case "Town1":
                    player.transform.position = Town1.transform.position + PlayerInfo.piInstance.offset_n * 4f;
                    break;
                case "Town2":
                    player.transform.position = Town2.transform.position + PlayerInfo.piInstance.offset_n * 4f;
                    break;
                case "Town3":
                    player.transform.position = Town3.transform.position + PlayerInfo.piInstance.offset_n * 4f;
                    break;
                default:
                    break;
            }

        }
        else
        {
            player.transform.position = transform.position;
        }
        player.GetComponent<PlayerController>().Fade(false);
    }
}
