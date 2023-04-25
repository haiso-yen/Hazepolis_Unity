using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public Item ItemReward { get; set; }
    public int CoinReward { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed) GiveReward();
    }

    public void GiveReward()
    {
        if (ItemReward != null)
            InventoryController.Instance.GiveItem(ItemReward);
    }

    public class QuestTask
    {
        //¥ô°Èª¬ºA¬d¸ß
        public QuestData_SO questData;
        public bool IsStarted
        {
            get { return questData.isStarted; }
            set { questData.isStarted = value; }
        }

        public bool IsComplete
        {
            get { return questData.isComplete; }
            set { questData.isComplete = value; }
        }

        public bool IsFinished
        {
            get { return questData.isFinished; }
            set { questData.isFinished = value; }
        }

    }




}
