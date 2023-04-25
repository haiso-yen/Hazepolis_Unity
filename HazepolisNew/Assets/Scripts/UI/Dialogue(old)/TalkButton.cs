using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TalkButton : MonoBehaviour
{
    //public GameObject Button;
    public GameObject DialogUI;

    public DialougeData_SO currentData;
    bool canTalk = false;

    //靠近NpC顯示對話符號
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
        if (Input.GetKeyDown(KeyCode.T))//TODO:此處是否可以改編成使用事件的形式？
        {
            if (this.tag == "Interactable") {
                this.GetComponent<Interactable>().Interact();
            }
            OpenDialogue();
        }
    }
    void OpenDialogue()
    {
        //打開UI面板
        //傳輸對話內容信息
        DialogueUI.Instance.UpdateDialogueData(currentData);
        DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    }

}
