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

    //�ĤH���`�A�B�����~�ɽե�
    public void UpdateQuestProgress(string requireName, int amount)
    {
        foreach (var task in tasks)
        {

            if (task.IsFinished)
                continue;//���F�קK�w���������Ȩ���v�T

            var matchTask = task.questData.questRequires.Find(r => r.name == requireName);
            if (matchTask != null)
                matchTask.currentAmount += amount;

            task.questData.CheckGoals();
        }
    }

    public bool HaveQuest(Quest data)//�P�_�O�_���o�ӥ���
    {
        //�b�Y��󤤤ޤJLing�A�i�H�Ω�d������������e
        if (data != null)
            return tasks.Any(q => q.questData.QuestName == data.QuestName);
        else return false;
    }

    //�ھڥ��ȼƾڪ��W�r�d����������Y�@�ӥ���
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


    //�[���ƾڪ��覡�O�q�L���s�s�Ыؤ@��SO�A�M����SOŪ���ƾڡA�M��A�[�J��tasks�����
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

