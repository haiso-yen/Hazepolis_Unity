using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{ 
    public static QuestUI Instance { get; set; } 

    [Header("Elements")]
    public GameObject quesPanel;
    //public ItemToolTip tooltip;
    bool isOpen;

    [Header("Quest Name")]
    public RectTransform questListTransform;
    public QuestNameButton questNameButton;

    [Header("Text Content")]
    public Text questContentText;

    [Header("Requirement")]
    public RectTransform requireTransform;
    public QuestRequirement requirement;

    [Header("Reward Panel")]
    public RectTransform rewardTransform;
    public InventoryUIItem rewardUI;

   

    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOpen = !isOpen;
            quesPanel.SetActive(isOpen);
            //questContentText.text = string.Empty;
            //SetupQuestList();
        }
    }
    public void SetupQuestList()
    {
        //�M����Ӥw��������
        foreach (Transform item in questListTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in rewardTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in requireTransform)
        {
            Destroy(item.gameObject);
        }

        //�M���C����list�A��������
        foreach (var task in QuestManager.Instance.tasks)
        {
            var newTask = Instantiate(questNameButton, questListTransform);
            newTask.SetupNameButton(task.questData);
            //newTask.questContentText = questContentText;
        }


    }

    public void SetupRequireList(Quest questData)
    {
        questContentText.text = questData.Description;
        //�N�A�Ψ�QuestNameButton�����T�BquestContentText�����A���ϥΦb�̭��ǪF��M���Ȫ��Φ��F�A�אּ�b���B�����ק�

        foreach (Transform item in requireTransform)
        {
            Destroy(item.gameObject);
        }
        foreach (var require in questData.questRequires)
        {
            var q = Instantiate(requirement, requireTransform);
            if (questData.Completed)
                q.SetupRequirement(require.name, true);
            else
                q.SetupRequirement(require.name, require.requireAmount, require.currentAmount);
        }
    }

    public void SetupRewardItem(Item item)
    {
        var ITEM = Instantiate(rewardUI, rewardTransform);
        ITEM.SetItem(item);
    }

}
