using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static bool isInDialogue = false;
    public static KeyCode nextKey = KeyCode.G;
    public static Dialogue currentDialogue;

    [HideInInspector]
    public string text;
    [HideInInspector]
    public Dialogue nextDialogue = null;


    void LateUpdate()
    {
        if (isInDialogue)
        {
            if (Input.GetKeyDown(KeyCode.F)) 
            {
                try
                {
                    currentDialogue.nextDialogue.ShowDialogue();
                }
                catch (Exception exc)
                {
                    currentDialogue.HideDialogue();
                }
            }
        }
    }

    public Dialogue(string dialogueText)
    {
        text = dialogueText;
    }
    public Dialogue(string dialogueText, Dialogue next)
    {
        text = dialogueText;
        nextDialogue = next;
    }
    public void ShowDialogue()
    {
        currentDialogue = this;
        UIController.ShowDialogueBox(text);
        isInDialogue = true;
    }
    public void HideDialogue()
    {
        UIController.HideDialogueBox();
        isInDialogue = false;
    }
}
