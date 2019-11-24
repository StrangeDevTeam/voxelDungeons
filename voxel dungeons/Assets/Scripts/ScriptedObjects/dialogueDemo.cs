using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueDemo : MonoBehaviour
{
    Dialogue test3;
    Dialogue test2;
    Dialogue testDialogue;


    DialogueChoice testChoice;

    void Start()
    {
        test3 = new Dialogue("testes");
        test2 = new Dialogue("And this is another test", test3);
        testDialogue = new Dialogue("Hello there, This is a test", test2);

        string[] choices = { "option 1", "option 2"};
        Dialogue[] dChoices = { testDialogue, test3 };
        testChoice = new DialogueChoice("make your choice", choices, dChoices);

    }

    public void OnNearby()
    {
        UIController.ShowInteractionTooltip();
    }
    public void Use()
    {
        UIController.HideInteractionTooltip();
        testDialogue.ShowDialogue();
    }
    public void NoLongerNearby()
    {
        testDialogue.HideDialogue();
        UIController.HideInteractionTooltip();
    }
}
