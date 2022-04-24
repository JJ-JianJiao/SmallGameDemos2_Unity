using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController playerController;
    public Transform startPoint;

    private int totalPoint = 0;

    public int GetTotalPoint
    {
        get { return totalPoint; }
    }

    public bool isPause;

    public TMP_Text TimerText;
    public bool playing = false;
    public float Timer;
    private float realTimer;

    public TMP_Text scoreText;

    public GameObject redCoinProfab;
    public GameObject blueCoinProfab;
    public GameObject yellowCoinProfab;
    public GameObject greenCoinProfab;

    private float generateRange = 25;

    List<GameObject> redCoinList;
    List<GameObject> yellowCoinList;
    List<GameObject> blueCoinList;
    List<GameObject> greenCoinList;


    public int redCoinNum;
    public int yellowCoinNum;
    public int blueCoinNum;
    public int greenCoinNum;

    public GameObject endGamePanel;

    public AudioSource coinAS;
    public AudioSource backgroundAS;
    public List<AudioClip> coinClips;


    private void Awake()
    {
        if (Instance != null) {
            Destroy(this);
        }
        Instance = this;

        GenerateAllCoins();
        realTimer = Timer;
    }

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        isPause = true;
        scoreText.text = "Score:" + totalPoint;
    }

    private void Update()
    {
        if (isPause != true && realTimer >= 0)
        {

            int minutes = Mathf.FloorToInt(realTimer / 60F);
            int seconds = Mathf.FloorToInt(realTimer % 60F);
            int milliseconds = Mathf.FloorToInt((realTimer * 100F) % 100F);
            TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");

            realTimer -= Time.deltaTime;
        }
        else if(isPause != true && Mathf.Round(realTimer) == 0) {
            endGamePanel.SetActive(true);
            endGamePanel.GetComponent<EndMenu>().IsContinue = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !endGamePanel.activeInHierarchy) {
            endGamePanel.SetActive(true);
            endGamePanel.GetComponent<EndMenu>().IsContinue = true;
        }

        if (isPause && backgroundAS.isPlaying)
        {
            backgroundAS.Stop();
        }
        else if(!isPause && !backgroundAS.isPlaying) {
            backgroundAS.Play();
        }
    }

    public void AddPoint(int point, AudioClip clip)
    {

        coinAS.clip = clip;
        coinAS.Play();

        totalPoint += point;
        scoreText.text = "Score:" + totalPoint;
        //Debug.Log("total point is" + totalPoint);
    }


    void GenerateAllCoins()
    {
        for (int i = 0; i < yellowCoinNum; i++)
        {
            GenerateCoin(yellowCoinProfab);
        }
        for (int i = 0; i < redCoinNum; i++)
        {
            GenerateCoin(redCoinProfab);
        }
        for (int i = 0; i < blueCoinNum; i++)
        {
            GenerateCoin(blueCoinProfab);
        }
        for (int i = 0; i < greenCoinNum; i++)
        {
            GenerateCoin(greenCoinProfab);
        }
    }

    private void GenerateCoin(GameObject coinProfab)
    {
        float randomX = UnityEngine.Random.Range(-generateRange, generateRange);
        float randomZ = UnityEngine.Random.Range(-generateRange, generateRange);

        Vector3 randomPoint = new Vector3(randomX, transform.position.y + 1.1f, randomZ);

        NavMeshHit hit;
        while (!NavMesh.SamplePosition(randomPoint, out hit, generateRange, 1)){}


        Instantiate(coinProfab, hit.position + Vector3.up,Quaternion.identity);
    }

    public void GenerateCoin(string type) {
        switch (type)
        {
            case "Red":
                GenerateCoin(redCoinProfab);
                break;
            case "Green":
                GenerateCoin(greenCoinProfab);
                break;
            case "Blue":
                GenerateCoin(blueCoinProfab);
                break;
            case "Yellow":
                GenerateCoin(yellowCoinProfab);
                break;
            default:
                break;
        }

    }

    

    public void Reset()
    {
        totalPoint = 0;
        realTimer = Timer;

    }

    public void ResetPlayer() {

        playerController.transform.position = startPoint.position;
        playerController.transform.rotation = startPoint.rotation;
    }
}
