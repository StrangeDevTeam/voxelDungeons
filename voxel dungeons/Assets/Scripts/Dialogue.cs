using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    /// Static
    public static bool isInDialogue = false; // is the user currently in a dialogue with an entitiy?
    public static KeyCode nextKey = KeyCode.F; // the key the user presses to move on to the next dialogue
    public static Dialogue currentDialogue; // a link to the current or last dialogue the user has active

    /// public 
    [HideInInspector]
    public string text; // the contents of the dialogue
    [HideInInspector]
    public Dialogue nextDialogue = null; // the link to the next dialogue if there is one
    [HideInInspector]
    public bool pauseForFrame = true; // stops the program from ruching ahead, when true the program will wait 1 frame before monitoring inputs
    public Quest triggeredQuest = null;

    void LateUpdate()
    {

        try
        {
            DialogueChoice currentDialogueChoice = (DialogueChoice)currentDialogue;
            if (!currentDialogue.pauseForFrame)
            {
                if (isInDialogue)
                {
                    try
                    {
                        if (Input.GetKeyDown(DialogueChoice.option1))
                        {
                            try
                            {
                                DialogueChoice castedChoice = (DialogueChoice)currentDialogueChoice.nextBranches[0];
                                castedChoice.ShowDialogue();
                            }
                            catch (Exception)
                            {
                                currentDialogueChoice.nextBranches[0].ShowDialogue();
                            }
                        }
                        else if (Input.GetKeyDown(DialogueChoice.option2))
                        {
                            try
                            {
                                DialogueChoice castedChoice = (DialogueChoice)currentDialogueChoice.nextBranches[1];
                                castedChoice.ShowDialogue();
                            }
                            catch (Exception)
                            {
                                currentDialogueChoice.nextBranches[1].ShowDialogue();
                            }
                        }
                        else if (Input.GetKeyDown(DialogueChoice.option3))
                        {
                            try
                            {
                                DialogueChoice castedChoice = (DialogueChoice)currentDialogueChoice.nextBranches[2];
                                castedChoice.ShowDialogue();
                            }
                            catch (Exception)
                            {
                                currentDialogueChoice.nextBranches[2].ShowDialogue();
                            }
                        }
                        else if (Input.GetKeyDown(DialogueChoice.option4))
                        {
                            try
                            {
                                DialogueChoice castedChoice = (DialogueChoice)currentDialogueChoice.nextBranches[3];
                                castedChoice.ShowDialogue();
                            }
                            catch (Exception)
                            {
                                currentDialogueChoice.nextBranches[3].ShowDialogue();
                            };
                        }
                        else if (Input.GetKeyDown(DialogueChoice.option5))
                        {
                            try
                            {
                                DialogueChoice castedChoice = (DialogueChoice)currentDialogueChoice.nextBranches[4];
                                castedChoice.ShowDialogue();
                            }
                            catch (Exception)
                            {
                                currentDialogueChoice.nextBranches[4].ShowDialogue();
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                currentDialogue.pauseForFrame = false;
            }
        }

        catch (Exception)
        {
            try
            {
                if (!currentDialogue.pauseForFrame)
                {
                    if (isInDialogue)
                    {
                        if (Input.GetKeyDown(nextKey))
                        {
                            try
                            {
                                currentDialogue.nextDialogue.ShowDialogue();
                            }
                            catch (Exception)
                            {
                                currentDialogue.HideDialogue();
                            }
                        }
                    }
                }
                else
                {
                    currentDialogue.pauseForFrame = false;
                }
            }
            catch (Exception)
            { }
        }


    }

    public Dialogue(string dialogueText)
    {
        text = dialogueText;
    }
    public Dialogue(string dialogueText, Quest QuestLinkedToDialogue)
    {
        text = dialogueText;
        triggeredQuest = QuestLinkedToDialogue;
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
        UIController.HideDialogueChoices();
        isInDialogue = true;
        pauseForFrame = true;
        if(triggeredQuest != null)
        {
            Quest.ActiveQuest = triggeredQuest;
            Debug.Log("Quest triggered: " + triggeredQuest.title);
        }
    }
    public void HideDialogue()
    {
        UIController.HideDialogueBox();
        isInDialogue = false;
    }
}
public class DialogueChoice : Dialogue
{

    public static KeyCode option1 = KeyCode.Alpha1;
    public static KeyCode option2 = KeyCode.Alpha2;
    public static KeyCode option3 = KeyCode.Alpha3;
    public static KeyCode option4 = KeyCode.Alpha4;
    public static KeyCode option5 = KeyCode.Alpha5;


    [HideInInspector]
    public string[] choices;
    [HideInInspector]
    public Dialogue[] nextBranches;

    public DialogueChoice( string dialogueText, string[] dialogueChoices , Dialogue[] nextDialogueBranches) : base(dialogueText)
    {
        choices = dialogueChoices;
        nextBranches = nextDialogueBranches;
    }

    public void ShowDialogue()
    {
        currentDialogue = this;
        UIController.ShowDialogueBox(text);
        isInDialogue = true;
        pauseForFrame = true;
        string choiceText = "";

        for(int i = 0; i< choices.Length; i++)
        {
            choiceText = choiceText + (i+1) + " -  "+ choices[i] + "\n";
        }


        UIController.ShowDialogueChoices(choiceText);
    }
}
