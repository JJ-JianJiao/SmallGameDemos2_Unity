using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueUI : MonoBehaviour
{
    static public DialogueUI instance;

    [Header("Basic Elements")]
    public Text mainText;
    public Button nextBtn;

    public GameObject dialoguePanel;
    public RectTransform optionPanel;

    public OptionUI optionPrefab;

    [Header("Data")]
    public DialogueData_SO currentData;

    int currentIndex = 0;

    GameObject currentObj;

    private void Awake()
    {
        if (instance != null) {
            Destroy(instance);
        }
        instance = this;
        nextBtn.onClick.AddListener(ContinueDialogue);
    }

    void ContinueDialogue() {
        if (currentIndex < currentData.dialoguePieces.Count)
        {
            UpdateMainDialogue(currentData.dialoguePieces[currentIndex]);
        }
        else {
            if (currentData.dialoguePieces[currentIndex-1].isEnd)
            {
                currentObj.GetComponent<DialogueController>().SwitchToNextDialogue(0);
            }
            else {
                currentObj.GetComponent<DialogueController>().SwitchToNextDialogue();
            }
            dialoguePanel.SetActive(false);
        }
    }

    public void UpdateDialogueData(DialogueData_SO data, GameObject obj) {
        currentData = data;
        currentIndex = 0;
        currentObj = obj;
    }

    public void UpdateMainDialogue(DialoguePiece piece) {
        dialoguePanel.SetActive(true);
        currentIndex++;
        mainText.text = "";

        mainText.text = piece.text;

        if (piece.options.Count == 0 && currentData.dialoguePieces.Count > 0)
        {
            nextBtn.interactable = true;
            nextBtn.gameObject.SetActive(true);
            nextBtn.transform.GetChild(0).gameObject.SetActive(true);

        }
        else {
            //nextBtn.gameObject.SetActive(false);
            nextBtn.interactable = false;
            nextBtn.transform.GetChild(0).gameObject.SetActive(false);
        }

        //Crate Options
        CreateOptions(piece);
    }

    void CreateOptions(DialoguePiece piece) {
        if (optionPanel.childCount > 0) {
            for (int i = 0; i < optionPanel.childCount; i++)
            {
                Destroy(optionPanel.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < piece.options.Count; i++)
        {
            var option = Instantiate(optionPrefab, optionPanel);
            option.UpdateOption(piece, piece.options[i], currentObj);
        }
    }
}
