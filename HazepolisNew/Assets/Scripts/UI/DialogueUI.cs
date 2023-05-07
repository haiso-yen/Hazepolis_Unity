using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueUI : Singleton<DialogueUI>
{
    [Header("Basic Elements")]
    //public Image icon;
    public Text mainText;
    public Button nextButton;

    public GameObject dialoguePanel;

    [Header("Data")]
    public DialougeData_SO currentData;

    int currentIndex = 0;

    [Header("Options")]
    public RectTransform optionPanel;
    public OptionUI optionPrefab;


    protected override void Awake()
    {
        base.Awake();
        nextButton.onClick.AddListener(ContinueDialogue);//�I���ɦp�G�����٦���ܫh�~��i��
    }

    void ContinueDialogue()
    {
        if (currentIndex < currentData.dialoguePieces.Count)
        {
            UpdateMainDialogue(currentData.dialoguePieces[currentIndex]);
        }
        else dialoguePanel.SetActive(false);
    }

    public void UpdateDialogueData(DialougeData_SO data)
    {
        currentData = data;
        currentIndex = 0;//�O�ҨC�����O�q�Y�}�l���
    }


    public void UpdateMainDialogue(DialoguePiece piece)
    {
        dialoguePanel.SetActive(true);
        currentIndex++;

        mainText.text = "";
        //mainText.text = piece.text;
        mainText.DOText(piece.text, 1f);

        //�p�G�����٦���ܴN��next�A�S���N����next
        if (piece.options.Count == 0 && currentData.dialoguePieces.Count > 0)
        {
            nextButton.interactable = true;
            nextButton.gameObject.SetActive(true);
            //currentIndex++;//�����ө�b�o��++�A���ӨC�B��@������index++�A�]�����ө�b�W��
        }
        else
        {
            //nextButton.gameObject.SetActive(false);
            nextButton.transform.GetChild(0).gameObject.SetActive(false);//���r�ݤ���
            nextButton.interactable = false;//�åB�R���椬�\�� 
        }
        CreateOptions(piece);//�ھڹ�ܨӳЫؿﶵ
    }

    void CreateOptions(DialoguePiece piece)
    {
        if (optionPanel.childCount > 0)//�P���ª��ﶵ
        {
            for (int i = 0; i < optionPanel.childCount; i++)
            {
                Destroy(optionPanel.GetChild(i).gameObject);
            }
        }

        //�ͦ��s���ﶵ�A�åB�եοﶵ�A�ǤJ��ܪ��ﶵ�H���A�ӧ�soption����ܪ��H��
        for (int i = 0; i < piece.options.Count; i++)
        {
            var option = Instantiate(optionPrefab, optionPanel);
            option.UpdateOption(piece, piece.options[i]);
        }

    }
}