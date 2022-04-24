using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button startBtn;
    [SerializeField]
    Button quitBtn;
    Image mainPanelImage;



    public GameObject scorePanel; 

    private void Awake()
    {
        startBtn.onClick.AddListener(StartBtn_OnClick);
        quitBtn.onClick.AddListener(quitBtn_OnClick);
        mainPanelImage = GetComponent<Image>();
        scorePanel.SetActive(false);
    }


    private void quitBtn_OnClick()
    {
        Application.Quit();
    }

    private void StartBtn_OnClick()
    {
        StartCoroutine("StartNewGame");
    }

    IEnumerator StartNewGame() {
        startBtn.gameObject.SetActive(false);
        quitBtn.gameObject.SetActive(false);

        while (mainPanelImage.fillAmount != 0) {
            mainPanelImage.fillAmount -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        GameManager.Instance.isPause = false;
        scorePanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
