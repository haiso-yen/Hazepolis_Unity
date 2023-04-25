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
        //�`����ܤ������ȡA���ӥ��Ȩê�^
        foreach (var piece in dialoguePieces)
        {
            if (piece.quest != null)
                currentQuest = piece.quest;
        }
        return currentQuest;
    }


    //�p�G�O�bUnity�s�边���A�h�r���H�ɧ��ܮɫh�i��ק�A�p�G�O���]�h�r��H�����|���
#if UNITY_EDITOR
    void OnValidate()//�@���o�Ӹ}�������ƾڳQ���ɷ|�۰ʽե�
    {
        dialogueIndex.Clear();
        //�@���H�����ҧ�s�A�N�|�N�H���s�x�b�r�夤
        foreach (var piece in dialoguePieces)
        {
            if (!dialogueIndex.ContainsKey(piece.ID))
                dialogueIndex.Add(piece.ID, piece);
        }
    }
#else
    void Awake()//�O�Ҧb���]���檺�C���̲Ĥ@�ɶ���o��ܪ��Ҧ��r��ǰt 
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