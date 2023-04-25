using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestManager : Singleton<QuestManager>
{
    [System.Serializable]
    public class QuestTask
    {
        public Quest questData;
        public bool IsStarted
        {
            get { return questData.isStarted; }
            set { questData.isStarted = value; }
        }

        public bool Completed
        {
            get { return questData.Completed; }
            set { questData.Completed = value; }
        }

        public bool IsFinished
        {
            get { return questData.isFinished; }
            set { questData.isFinished = value; }
        }

    }

    public List<QuestTask> tasks = new List<QuestTask>();

    //敵人死亡，拾取物品時調用
    public void UpdateQuestProgress(string requireName, int amount)
    {
        foreach (var task in tasks)
        {

            if (task.IsFinished)
                continue;//為了避免已完成的任務受到影響

            var matchTask = task.questData.questRequires.Find(r => r.name == requireName);
            if (matchTask != null)
                matchTask.currentAmount += amount;

            task.questData.CheckGoals();
        }
    }

    public bool HaveQuest(Quest data)//判斷是否有這個任務
    {
        //在頭文件中引入Ling，可以用於查找鍊錶中的內容
        if (data != null)
            return tasks.Any(q => q.questData.QuestName == data.QuestName);
        else return false;
    }

    //根據任務數據的名字查找鍊錶中的某一個任務
    public QuestTask GetTask(Quest data)
    {
        return tasks.Find(q => q.questData.QuestName == data.QuestName);
    }

    private void Start()
    {
        LoadQuestManager();
    }


    public void SaveQuestManager()
    {
        PlayerPrefs.SetInt("QuestCount", tasks.Count);
        for (int i = 0; i < tasks.Count; i++)
        {
            // SaveManager.Instance.Save(tasks[i].questData, "task" + i);
        }
    }


    //加載數據的方式是通過重新新創建一個SO，然後讓SO讀取數據，然後再加入到tasks鍊錶當中
    public void LoadQuestManager()
    {
        var quesCount = PlayerPrefs.GetInt("QuestCount");
        for (int i = 0; i < quesCount; i++)
        {
            var newQuest = ScriptableObject.CreateInstance<Quest>();//
            //SaveManager.Instance.Load(newQuest, "task" + i);
            tasks.Add(new QuestTask { questData = newQuest });
        }
    }

}

