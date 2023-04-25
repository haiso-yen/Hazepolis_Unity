using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue Data")]
public class DialougeData_SO : ScriptableObject
{

    public List<DialoguePiece> dialoguePieces = new List<DialoguePiece>();
    public Dictionary<string, DialoguePiece> dialogueIndex = new Dictionary<string, DialoguePiece>();



    public Quest GetQuest()
    {
        Quest currentQuest = null;
        //循環對話中的任務，找到該任務並返回
        foreach (var piece in dialoguePieces)
        {
            if (piece.quest != null)
                currentQuest = piece.quest;
        }
        return currentQuest;
    }


    //如果是在Unity編輯器中，則字典隨時改變時則進行修改，如果是打包則字典信息不會更改
#if UNITY_EDITOR
    void OnValidate()//一旦這個腳本中的數據被更改時會自動調用
    {
        dialogueIndex.Clear();
        //一旦信息有所更新，就會將信息存儲在字典中
        foreach (var piece in dialoguePieces)
        {
            if (!dialogueIndex.ContainsKey(piece.ID))
                dialogueIndex.Add(piece.ID, piece);
        }
    }
#else
    void Awake()//保證在打包執行的遊戲裡第一時間獲得對話的所有字典匹配 
    {
        dialogueIndex.Clear();
        foreach (var piece in dialoguePieces)
        {
            if (!dialogueIndex.ContainsKey(piece.ID))
                dialogueIndex.Add(piece.ID, piece);
        }
    }
#endif




}