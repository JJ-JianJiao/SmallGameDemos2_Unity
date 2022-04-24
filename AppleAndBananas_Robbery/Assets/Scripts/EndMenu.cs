using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    Button reStartBtn;
    [SerializeField]
    Button continueBtn;
    [SerializeField]
    Button quitBtn2;
    Image endPanelImage;

    private bool isContinue;
    public bool IsContinue { set => isContinue = value; }

    public GameObject scorePanel;

    public TMP_Text scoreText;
    public TMP_Text endGameScore;


    private void Awake()
    {
        endPanelImage = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        reStartBtn.onClick.AddListener(StartBtn_OnClick);
        quitBtn2.onClick.AddListener(quitBtn_OnClick);
        continueBtn.onClick.AddListener(ContinueBtn_OnClick);
        scorePanel.SetActive(false);
    }

 
    private void OnEnable()
    {
        StartCoroutine("DisplayEndGameUI");
    }

    private void StartBtn_OnClick()
    {
        StartCoroutine("ReStartNewGame");
    }

    private void quitBtn_OnClick()
    {
        Application.Quit();
    }

    private void ContinueBtn_OnClick()
    {
        StartCoroutine("ContinueGame");
    }

    IEnumerator ContinueGame()
    {
        reStartBtn.gameObject.SetActive(false);
        quitBtn2.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        endGameScore.gameObject.SetActive(false);

        while (endPanelImage.fillAmount != 0)
        {
            endPanelImage.fillAmount -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        GameManager.Instance.isPause = false;
        //GameManager.Instance.Reset();
        scorePanel.SetActive(true);

        this.gameObject.SetActive(false);
    }
    IEnumerator ReStartNewGame()
    {
        reStartBtn.gameObject.SetActive(false);
        quitBtn2.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        endGameScore.gameObject.SetActive(false);
        GameManager.Instance.ResetPlayer();
        while (endPanelImage.fillAmount != 0)
        {
            endPanelImage.fillAmount -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        GameManager.Instance.isPause = false;
        GameManager.Instance.Reset();
        scorePanel.SetActive(true);
        scoreText.text = "Score: 0";

        this.gameObject.SetActive(false);
    }

    IEnumerator DisplayEndGameUI()
    {
        reStartBtn.gameObject.SetActive(false);
        quitBtn2.gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        endGameScore.gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerController>().StopAnimation();

        GameManager.Instance.isPause = true;
        scorePanel.SetActive(false);
        yield return new WaitForSeconds(Time.deltaTime);


        while (endPanelImage.fillAmount < 1)
        {
            endPanelImage.fillAmount += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        endGameScore.gameObject.SetActive(true);
        if (isContinue)
        {
            continueBtn.gameObject.SetActive(true);
            endGameScore.text = "PAUSE";
        }
        else {
            endGameScore.text = "You Get " + GameManager.Instance.GetTotalPoint;
        }
        reStartBtn.gameObject.SetActive(true);
        quitBtn2.gameObject.SetActive(true);
        yield return null;
    }

}
