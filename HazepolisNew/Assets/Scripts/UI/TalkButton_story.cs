using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton_story : MonoBehaviour
{
    public GameObject DialogHint;

    public DialougeData_SO currentData;
    bool canTalk = false;

    //�a��NpC��ܹ�ܲŸ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        DialogHint.SetActive(true);
        if (other.CompareTag("Player") && currentData != null)
        {
            canTalk = true;
            Debug.Log("can talk is true");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DialogHint.SetActive(false);
        if (other.CompareTag("Player"))
        {
            DialogueUI.Instance.dialoguePanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.T))//TODO:���B�O�_�i�H��s���ϥΨƥ󪺧Φ��H
        {
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
        DialogueUI.Instance.UpdateDialogueData(currentData);
        DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    }
}
