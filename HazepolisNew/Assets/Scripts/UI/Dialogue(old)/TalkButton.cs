using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TalkButton : MonoBehaviour
{
    //public GameObject Button;
    public GameObject DialogUI;

    public DialougeData_SO currentData;
    bool canTalk = false;

    //�a��NpC��ܹ�ܲŸ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Button.SetActive(true);
        DialogUI.SetActive(true);
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
        DialogUI.SetActive(false);

        if (other.CompareTag("Player"))
        {
            DialogueUI.Instance.dialoguePanel.SetActive(false);
        }
    }

    //    void Update()
    //{
    //    if (Button.activeSelf && Input.GetKeyDown(KeyCode.T))
    //    {
    //        DialogUI.SetActive(true);
    //        //trigger.StartDialog();
    //        Debug.Log("Conversation");
    //        if (this.tag == "Interactable")
    //        {
    //            this.GetComponent<Interactable>().Interact();
    //        }

    //    }
    //}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))//TODO:���B�O�_�i�H��s���ϥΨƥ󪺧Φ��H
        {
            if (this.tag == "Interactable") {
                this.GetComponent<Interactable>().Interact();
            }
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
