using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueUI : Singleton<DialogueUI>
{
    [Header("Basic Elements")]
    //public Image icon;
    public Text mainText;
    public Button nextButton;

    public GameObject dialoguePanel;

    [Header("Data")]
    public DialougeData_SO currentData;

    int currentIndex = 0;

    [Header("Options")]
    public RectTransform optionPanel;
    public OptionUI optionPrefab;


    protected override void Awake()
    {
        base.Awake();
        nextButton.onClick.AddListener(ContinueDialogue);//點擊時如果後續還有對話則繼續進行
    }

    void ContinueDialogue()
    {
        if (currentIndex < currentData.dialoguePieces.Count)
        {
            UpdateMainDialogue(currentData.dialoguePieces[currentIndex]);
        }
        else dialoguePanel.SetActive(false);
    }

    public void UpdateDialogueData(DialougeData_SO data)
    {
        currentData = data;
        currentIndex = 0;//保證每次都是從頭開始對話
    }


    public void UpdateMainDialogue(DialoguePiece piece)
    {
        dialoguePanel.SetActive(true);
        currentIndex++;

        mainText.text = "";
        //mainText.text = piece.text;
        mainText.DOText(piece.text, 1f);

        //如果後續還有對話就按next，沒有就不按next
        if (piece.options.Count == 0 && currentData.dialoguePieces.Count > 0)
        {
            nextButton.interactable = true;
            nextButton.gameObject.SetActive(true);
            //currentIndex++;//不應該放在這裡++，應該每運行一次都讓index++，因此應該放在上面
        }
        else
        {
            //nextButton.gameObject.SetActive(false);
            nextButton.transform.GetChild(0).gameObject.SetActive(false);//讓字看不見
            nextButton.interactable = false;//並且刪除交互功能 
        }
        CreateOptions(piece);//根據對話來創建選項
    }

    void CreateOptions(DialoguePiece piece)
    {
        if (optionPanel.childCount > 0)//銷毀舊的選項
        {
            for (int i = 0; i < optionPanel.childCount; i++)
            {
                Destroy(optionPanel.GetChild(i).gameObject);
            }
        }

        //生成新的選項，並且調用選項，傳入對話的選項信息，來更新option所顯示的信息
        for (int i = 0; i < piece.options.Count; i++)
        {
            var option = Instantiate(optionPrefab, optionPanel);
            option.UpdateOption(piece, piece.options[i]);
        }

    }
}