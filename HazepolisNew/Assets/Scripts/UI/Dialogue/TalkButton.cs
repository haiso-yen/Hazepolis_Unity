using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject DialogUI;
    public DialogTrigger trigger;

    //靠近NpC顯示對話符號
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
        DialogUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
        DialogUI.SetActive(false);
    }

    void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.T))
        {
            DialogUI.SetActive(true);
            trigger.StartDialog();
            Debug.Log("Conversation");
        }
    }
}
