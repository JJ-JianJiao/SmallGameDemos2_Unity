using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingPanel;

    public Button startBtn;
    public Button optionsBtn;
    public Button exitBtn;
    public Button backBtn;

    public Dropdown languageDropDown;
    int index;
    public List<MenuData> datas;

    private void Awake()
    {
        startBtn.onClick.AddListener(StartBtn_OnClick);
        optionsBtn.onClick.AddListener(OptionBtn_OnClick);
        exitBtn.onClick.AddListener(ExitBtn_OnClick);
        backBtn.onClick.AddListener(BackBtn_OnClick);


    }

    void StartBtn_OnClick() {
        Debug.Log("......");
    }
    void OptionBtn_OnClick()
    {
        settingPanel.SetActive(true);
    }
    void ExitBtn_OnClick()
    {
        Application.Quit();
    }
    void BackBtn_OnClick()
    {
        settingPanel.SetActive(false);
    }

    public void SelectedLanguage(int value) {
        index = value;
        //TODO 
        //Update the language
        UpdateLanguageData(index);
    }

    void UpdateLanguageData(int index) {
        startBtn.transform.GetChild(0).GetComponent<Text>().text = datas[index].startText;
        optionsBtn.transform.GetChild(0).GetComponent<Text>().text = datas[index].optionText;
        exitBtn.transform.GetChild(0).GetComponent<Text>().text = datas[index].exitText;
        backBtn.transform.GetChild(0).GetComponent<Text>().text = datas[index].backText;
    }
}
