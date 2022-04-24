using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    //public DialogueData_SO currentData;
    //public DialogueData_SO currentData2;

    public List<DialogueData_SO> dialogues;

    public bool clickTalk = false;
    public bool rightDistance = false;

    public int dialogueIndex = 0;



    private void OnMouseEnter()
    {
        if (dialogues.Count != 0)
        {
            clickTalk = true;
        }
    }

    private void OnMouseExit()
    {
        if (dialogues.Count != 0)
        {
            clickTalk = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dialogues.Count != 0 && other.CompareTag("Player"))
        {
            rightDistance = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (dialogues.Count != 0 && other.CompareTag("Player"))
        {
            rightDistance = false;
        }
        if (DialogueUI.instance.dialoguePanel.activeInHierarchy) {
            DialogueUI.instance.dialoguePanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (rightDistance && clickTalk && Input.GetMouseButtonDown(1) && !DialogueUI.instance.dialoguePanel.activeInHierarchy) {
            Debug.Log("Active Talk box");
            OpenDialogue();
        }
    }

    private void OpenDialogue()
    {
        //Open UI board
        //get the dialogue info
        DialogueUI.instance.UpdateDialogueData(dialogues[dialogueIndex], this.gameObject);
        DialogueUI.instance.UpdateMainDialogue(dialogues[dialogueIndex].dialoguePieces[0]);
    }

    public void SwitchToNextDialogue(int weight = 1) {
        dialogueIndex += weight;
        if (dialogueIndex >= dialogues.Count) {
            dialogueIndex = dialogues.Count - 1;
        }
    }
}
