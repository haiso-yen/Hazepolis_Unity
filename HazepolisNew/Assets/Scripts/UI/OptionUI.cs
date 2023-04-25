using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public Text optionText;
    private Button thisButton;
    private DialoguePiece currentPiece;


    private bool takeQuest;
    private string nextPieceID;
    void Awake()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnOptionClicked);
    }

    public void UpdateOption(DialoguePiece piece, DialogueOption option)
    {
        currentPiece = piece;
        optionText.text = option.text;
        nextPieceID = option.targetID;
        takeQuest = option.takeQuest;
    }


    public void OnOptionClicked()
    {
        if (currentPiece.quest != null)//如果當前選項含有任務
        {
            //則獲取該任務
            var newTask = new QuestManager.QuestTask
            {
                questData = Instantiate(currentPiece.quest)//將quest信息實例化然後賦值給QuestTask類裡面的questData
            };
            if (takeQuest)
            {
                Debug.Log("takeQuest is true");
                //------有錯誤
                //判斷是否在列表中
                //if (QuestManager.Instance.HaveQuest(newTask.questData))
                //{
                //    Debug.Log("Quest in list");

                //    //判斷是否完成，若完成則給予獎勵
                //    if (QuestManager.Instance.GetTask(newTask.questData).Completed)
                //    {
                //        Debug.Log("任務完成,給予獎勵");
                //        newTask.questData.GiveReward();
                //        QuestManager.Instance.GetTask(newTask.questData).IsFinished = true;
                //    }
                //}
                //else
                //{
                //    QuestManager.Instance.tasks.Add(newTask);
                //    //newTask.IsStarted = true;這樣的做法並沒有用，這樣只是修改的臨時變量
                //    QuestManager.Instance.GetTask(newTask.questData).IsStarted = true;
                //    //添加到任務列表

                //    //foreach (var requireItem in newTask.questData.RequireTargetName())
                //    //{
                //    //    InventoryController.Instance.CheckQuestItemInBag(requireItem);
                //    //}
                //}
            }
        }

        if (nextPieceID == "")
        {
            DialogueUI.Instance.dialoguePanel.SetActive(false);
            return;
        }
        else
        {
            //用ID去獲取下一個對話
            DialogueUI.Instance.UpdateMainDialogue(DialogueUI.Instance.currentData.dialogueIndex[nextPieceID]);
        }
    }

}