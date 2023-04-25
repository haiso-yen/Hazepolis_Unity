using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Quest Data")]

public class Quest : ScriptableObject
{
    //public List<Goal> Goals { get; set; } = new List<Goal>();
    //public string QuestName { get; set; }
    //public string Description { get; set; }
    //public Item ItemReward { get; set; }
    //public int CoinReward { get; set; }
    //public bool Completed { get; set; }

    //public void CheckGoals()
    //{
    //    Completed = Goals.All(g => g.Completed);
    //    if (Completed) GiveReward();
    //}

    //public void GiveReward()
    //{
    //    if (ItemReward != null)
    //        InventoryController.Instance.GiveItem(ItemReward);
    //}

    //public class QuestTask
    //{
    //    //任務狀態查詢
    //    public QuestData_SO questData;
    //    public bool IsStarted
    //    {
    //        get { return questData.isStarted; }
    //        set { questData.isStarted = value; }
    //    }

    //    public bool IsComplete
    //    {
    //        get { return questData.isComplete; }
    //        set { questData.isComplete = value; }
    //    }

    //    public bool IsFinished
    //    {
    //        get { return questData.isFinished; }
    //        set { questData.isFinished = value; }
    //    }

    //}

    [System.Serializable]
    public class QuestRequire
    {
        public string name;
        public int requireAmount;
        public int currentAmount;
    }

    public string QuestName;
    [TextArea]
    public string Description;
    [TextArea]
    public string goalname;

    //需要三種任務完成的狀態，npc才會有不同的反應
    public bool isStarted;
    public bool Completed;
    public bool isFinished;

    public List<QuestRequire> questRequires = new List<QuestRequire>();
    public List<InventoryUIItem> rewards = new List<InventoryUIItem>();

    public void CheckGoals()
    {
        var finishRequires = questRequires.Where(r => r.requireAmount <= r.currentAmount);
        Completed = finishRequires.Count() == questRequires.Count;

        if (Completed)
        {
            Debug.Log("任務完成");
        }
    }


    //當前任務需要收集/消滅的目標名字列表
    public List<string> RequireTargetName()
    {
        List<string> targetNameList = new List<string>();
        foreach (var require in questRequires)
        {
            targetNameList.Add(require.name);
        }
        return targetNameList;
    }


    public void GiveReward()
    {
        foreach (var reward in rewards)
        {
            //if (reward.amount < 0)
            //{
            //    int requireCount = Mathf.Abs(reward.amount);

            //    //優先在背包裡找是否有該物品，
            //    if (InventoryManager.Instance.QuestItemInBag(reward.itemData) != null)
            //    {
            //        //這種情況是背包裡的東西不夠，那就先在背包裡扣除一部分，
            //        if (InventoryManager.Instance.QuestItemInBag(reward.itemData).amount <= requireCount)
            //        {
            //            requireCount -= InventoryManager.Instance.QuestItemInBag(reward.itemData).amount;//所需的數量減少
            //            InventoryManager.Instance.QuestItemInBag(reward.itemData).amount = 0;//背包裡的商品扣除為0

            //            //背包里東西不夠，剩下的部分從行動欄裡扣除
            //            //if (InventoryManager.Instance.QuestItemInAction(reward.itemData) != null)
            //            //    InventoryManager.Instance.QuestItemInAction(reward.itemData).amount -= requireCount;

            //        }
            //        //這種情況就是背包裡的東西直接夠，那直接扣除就好
            //        else
            //        {
            //            InventoryManager.Instance.QuestItemInBag(reward.itemData).amount -= requireCount;
            //        }

            //    }
            //    //這種情況是背包裡一點東西都沒有，那就直接扣除行動欄裡的物品
            //    //else
            //    //{
            //    //    InventoryManager.Instance.QuestItemInAction(reward.itemData).amount -= requireCount;
            //    //}
            //}
            //else
            //{
                
            //}
            InventoryController.Instance.GiveItem(reward.item);
            //InventoryController.Instance.GiveItem();
            //InventoryManager.Instance.actionUI.RefreshUI();
        }
    }

}
