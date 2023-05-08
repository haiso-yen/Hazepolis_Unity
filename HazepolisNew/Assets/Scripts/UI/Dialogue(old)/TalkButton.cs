using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TalkButton : MonoBehaviour
{
    //public GameObject Button;
    public GameObject DialogHint;
    public RectTransform dialoguePanel;

    public DialougeData_SO currentData;
    bool canTalk = false;

    //�a��NpC��ܹ�ܲŸ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Button.SetActive(true);
        DialogHint.SetActive(true);
        ///
        if (other.CompareTag("Player") && currentData != null)
        {
            canTalk = true;
            Debug.Log("can talk is true");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Button.SetActive(false);
        DialogHint.SetActive(false);

        if (other.CompareTag("Player"))
        {
            DialogueUI.Instance.dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (DialogHint.activeSelf && Input.GetKeyDown(KeyCode.T))
        {
            DialogHint.SetActive(true);
            //trigger.StartDialog();
            Debug.Log("Conversation");
            //if (this.tag == "Interactable")
            //{
            //    this.GetComponent<Interactable>().Interact();
            //}
            OpenDialogue();
        }
    }
    void OpenDialogue()
    {
        //���}UI���O
        //�ǿ��ܤ��e�H��
        dialogueapear();
        DialogueUI.Instance.UpdateDialogueData(currentData);
        DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    }

    public void dialogueapear()
    {
        dialoguePanel.DOAnchorPos(new Vector2(-49, -300), 0.25f);
    }
}
