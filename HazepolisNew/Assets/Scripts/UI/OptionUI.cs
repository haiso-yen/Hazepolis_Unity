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
        if (currentPiece.quest != null)//�p�G��e�ﶵ�t������
        {
            //�h����ӥ���
            var newTask = new QuestManager.QuestTask
            {
                questData = Instantiate(currentPiece.quest)//�Nquest�H����ҤƵM���ȵ�QuestTask���̭���questData
            };
            if (takeQuest)
            {
                Debug.Log("takeQuest is true");
                //------�����~
                //�P�_�O�_�b�C��
                //if (QuestManager.Instance.HaveQuest(newTask.questData))
                //{
                //    Debug.Log("Quest in list");

                //    //�P�_�O�_�����A�Y�����h�������y
                //    if (QuestManager.Instance.GetTask(newTask.questData).Completed)
                //    {
                //        Debug.Log("���ȧ���,�������y");
                //        newTask.questData.GiveReward();
                //        QuestManager.Instance.GetTask(newTask.questData).IsFinished = true;
                //    }
                //}
                //else
                //{
                //    QuestManager.Instance.tasks.Add(newTask);
                //    //newTask.IsStarted = true;�o�˪����k�èS���ΡA�o�˥u�O�ק諸�{���ܶq
                //    QuestManager.Instance.GetTask(newTask.questData).IsStarted = true;
                //    //�K�[����ȦC��

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
            //��ID�h����U�@�ӹ��
            DialogueUI.Instance.UpdateMainDialogue(DialogueUI.Instance.currentData.dialogueIndex[nextPieceID]);
        }
    }

}