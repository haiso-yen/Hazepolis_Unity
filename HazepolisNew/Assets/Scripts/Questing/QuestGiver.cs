using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TalkButton_story))]
public class QuestGiver : MonoBehaviour
{
    TalkButton_story controller;
    Quest currentQuest;

    public DialougeData_SO startDialogue;
    public DialougeData_SO progressDialogue;
    public DialougeData_SO completeDialogue;
    public DialougeData_SO finishDialogue;

    private void Awake()
    {
        controller = GetComponent<TalkButton_story>();
    }

    #region 獲得任務狀態
    //public bool isStarted
    //{
    //    get
    //    {
    //        Debug.Log("任務開始");

    //        if (QuestManager.Instance.HaveQuest(currentQuest))
    //        {
    //            return QuestManager.Instance.GetTask(currentQuest).IsStarted;
    //        }
    //        else return false;
    //    }
    //}

    //public bool Completed
    //{
    //    get
    //    {
    //        if (QuestManager.Instance.HaveQuest(currentQuest))
    //        {
    //            return QuestManager.Instance.GetTask(currentQuest).Completed;
    //        }
    //        else return false;
    //    }
    //}

    //public bool isFinished
    //{
    //    get
    //    {
    //        if (QuestManager.Instance.HaveQuest(currentQuest))
    //        {
    //            return QuestManager.Instance.GetTask(currentQuest).IsFinished;
    //        }
    //        else return false;
    //    }
    }
    #endregion

//    private void Start()
//    {
//        controller.currentData = startDialogue;
//        currentQuest = controller.currentData.GetQuest();
//    }

//    //根據狀態切換對話
//    void Update()
//    {
//        if (isStarted)
//        {
//            if (Completed)
//            {
//                controller.currentData = completeDialogue;
//            }
//            else
//            {
//                controller.currentData = progressDialogue;
//            }
//        }

//        if (isFinished)
//        {
//            controller.currentData = finishDialogue;
//        }
//    }
//}
//public class QuestGiver : NPC
//{
//    public bool AssignedQuest { get; set; }
//    public bool Helped { get; set; }

//    [SerializeField]
//    private GameObject quests;

//    [SerializeField]
//    private string questType;
//    private Quest Quest { get; set; }
//    public override void Interact()
//    {
//        if(!AssignedQuest && !Helped)
//        {
//            base.Interact();
//            AssignQuest();
//        }
//        else if(AssignedQuest && !Helped)
//        {
//            CheckQuest();
//        }
//        else
//        {
//            Debug.Log("DialogueSystem: Thanks for that");
//        }
//    }

//    void AssignQuest()
//    {
//        AssignedQuest = true;
//        Quest = (Quest)quests.AddComponent(Type.GetType(questType));
//    }

//    void CheckQuest()
//    {
//        if (Quest.Completed)
//        {
//            Quest.GiveReward();
//            Helped = true;
//            AssignedQuest = false;
//            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping", "here you go" }, name);
//            Debug.Log("DialogueSystem: Thanks");
//        }
//        else
//        {
//            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping", "here you go" }, name);
//            Debug.Log("DialogueSystem: Still undone");
//        }
//    }
//}