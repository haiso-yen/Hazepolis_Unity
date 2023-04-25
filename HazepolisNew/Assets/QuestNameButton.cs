using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNameButton : MonoBehaviour
{
    public Text questNameText;
    //public Text questContentText;
    public Quest currentData;

    public void SetupNameButton(Quest quesData)
    {
        currentData = quesData;

        if (quesData.Completed)
            questNameText.text = quesData.QuestName + "(完成)";
        else
            questNameText.text = quesData.QuestName;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(UpdateQuestContent);
    }
    void UpdateQuestContent()
    {
        Debug.Log("任務更新");
        //questContentText.text = currentData.Description;
        QuestUI.Instance.SetupRequireList(currentData);

        foreach (Transform item in QuestUI.Instance.rewardTransform)
        {
            Destroy(item.gameObject);
        }


        foreach (var item in currentData.rewards)//獎勵可能不止一個所以需要循環列表
        {
            QuestUI.Instance.SetupRewardItem(item.item);
        }
    }
}