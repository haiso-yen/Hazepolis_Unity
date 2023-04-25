using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffeeholic : Quest
{
    private void Start()
    {
        Debug.Log("Coffeeholic assigned");
        QuestName = "Coffeeholic";
        Description = "No coffee, No life.";

        //ItemReward = ItemDatabase.Instance.GetItem("coffee_log");
        //CoinReward = 100;

        //Goals.Add(new CollectionGoal(this, "coffee_log", "Find a Log Coffee.", false, 0, 1));

        //Goals.ForEach(g => g.Init());
    }
}
