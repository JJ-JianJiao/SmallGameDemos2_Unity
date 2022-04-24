using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public Text optionText;
    Button thisBtn;

    private DialoguePiece currentPiece;

    string nextPieceID;
    string takeAction;

    GameObject currentObj;

    int jumpWeight;

    bool isGiveItem;
    int gold;

    private void Awake()
    {
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(OnOptionClicked);
    }

    public void UpdateOption(DialoguePiece piece, DialogueOption option,GameObject obj) {
        currentPiece = piece;
        optionText.text = option.text;
        nextPieceID = option.targetID;
        takeAction = option.takeAction;
        currentObj = obj;
        jumpWeight = option.weight;
        isGiveItem = option.giveItem;
        gold = option.gold;
        isGiveItem = option.giveItem;
        
    }

    public void OnOptionClicked() {
        if (nextPieceID == "")
        {
            if (takeAction.Length != 0)
            {
                Debug.Log(currentObj);
                //currentObj.GetComponent<DialogueController>().SwitchToNextDialogue(jumpWeight);

                if (currentObj.GetComponent<NPCController>()) {
                    currentObj.GetComponent<NPCController>().ActiveAnimTrigger(takeAction);
                }
            }

            if (isGiveItem) {
                //currentObj.GetComponent<DialogueController>().SwitchToNextDialogue(jumpWeight);

                var player = GameObject.Find("Player");
                if (player.GetComponent<PlayerController_Dialog>())
                {
                    if (gold != 0)
                    {

                        player.GetComponent<PlayerController_Dialog>().GetGold(gold);
                    }
                }
            }
            if(jumpWeight != 0)
                currentObj.GetComponent<DialogueController>().SwitchToNextDialogue(jumpWeight);
            DialogueUI.instance.dialoguePanel.SetActive(false);
            return;
        }
        else {
            DialogueUI.instance.UpdateMainDialogue(DialogueUI.instance.currentData.dialogueIndex[nextPieceID]);
        }
    }
}
