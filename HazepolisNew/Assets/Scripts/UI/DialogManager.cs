using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Image npcImage;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Npc[] currentNpcs;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialog(Message[] messages, Npc[] npcs)
    {
        currentMessages = messages;
        currentNpcs = npcs;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started coversation! Loaded messages: " + messages.Length);
        DisplayMessage();

        //UI
        backgroundBox.LeanScale(Vector3.one, 0.3f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Npc npcToDisplay = currentNpcs[messageToDisplay.npcId];
        npcName.text = npcToDisplay.name;
        npcImage.sprite = npcToDisplay.sprite;

        AnimateTextColor();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("ConversationEnded");
            
            backgroundBox.LeanScale(Vector3.zero, 0.3f).setEaseInOutExpo();
            isActive = false;
        }
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextMessage();
        }
    }
}