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
    //    //���Ȫ��A�d��
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

    //�ݭn�T�إ��ȧ��������A�Anpc�~�|�����P������
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
            Debug.Log("���ȧ���");
        }
    }


    //��e���Ȼݭn����/�������ؼЦW�r�C��
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

            //    //�u���b�I�]�̧�O�_���Ӫ��~�A
            //    if (InventoryManager.Instance.QuestItemInBag(reward.itemData) != null)
            //    {
            //        //�o�ر��p�O�I�]�̪��F�褣���A���N���b�I�]�̦����@�����A
            //        if (InventoryManager.Instance.QuestItemInBag(reward.itemData).amount <= requireCount)
            //        {
            //            requireCount -= InventoryManager.Instance.QuestItemInBag(reward.itemData).amount;//�һݪ��ƶq���
            //            InventoryManager.Instance.QuestItemInBag(reward.itemData).amount = 0;//�I�]�̪��ӫ~������0

            //            //�I�]���F�褣���A�ѤU�������q�����̦���
            //            //if (InventoryManager.Instance.QuestItemInAction(reward.itemData) != null)
            //            //    InventoryManager.Instance.QuestItemInAction(reward.itemData).amount -= requireCount;

            //        }
            //        //�o�ر��p�N�O�I�]�̪��F�誽�����A�����������N�n
            //        else
            //        {
            //            InventoryManager.Instance.QuestItemInBag(reward.itemData).amount -= requireCount;
            //        }

            //    }
            //    //�o�ر��p�O�I�]�̤@�I�F�賣�S���A���N�������������̪����~
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
