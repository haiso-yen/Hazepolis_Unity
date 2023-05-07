using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton_story : MonoBehaviour
{
    public GameObject DialogHint;

    public DialougeData_SO currentData;
    bool canTalk = false;

    //靠近NpC顯示對話符號
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
        if (canTalk && Input.GetKeyDown(KeyCode.T))//TODO:此處是否可以改編成使用事件的形式？
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
        //打開UI面板
        //傳輸對話內容信息
        DialogueUI.Instance.UpdateDialogueData(currentData);
        DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePieces[0]);
    }
}
