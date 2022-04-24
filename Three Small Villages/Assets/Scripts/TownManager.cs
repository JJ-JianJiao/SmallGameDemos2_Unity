using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownManager : MonoBehaviour
{
    [SerializeField]
    Transform spawnLocation;
    PlayerController player;
    GameObject playerOb;
    bool transition = false;
    const float DistanceScale = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerOb = GameObject.FindGameObjectWithTag("Player");
        //playerOb.transform.position = spawnLocation.position;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        playerOb.transform.position = this.transform.position + PlayerInfo.piInstance.offset_n.normalized * DistanceScale;
        player.Fade(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transition && !player.Fading())
        {
            SceneManager.LoadScene("Overworld", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(PlayerInfo.piInstance.currentScene);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        player = other.GetComponent<PlayerController>();

        Vector3 offset = other.transform.position - this.transform.position;

        PlayerInfo.piInstance.offset_n = offset.normalized;


        player.Fade(true);
        transition = true;        
    }
}
