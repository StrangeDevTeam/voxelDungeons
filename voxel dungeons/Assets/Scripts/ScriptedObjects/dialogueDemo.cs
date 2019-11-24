using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueDemo : MonoBehaviour
{
    Dialogue test3;
    Dialogue test2;
    Dialogue testDialogue;


    DialogueChoice test4;
    DialogueChoice testChoice;

    void Start()
    {
        test3 = new Dialogue("okay bye");
        test2 = new Dialogue("And this is another test", test3);
        testDialogue = new Dialogue("Hello there, This is a test", test2);



        string[] choices2 = { "yes, let mt buy something already", "nevermind" };
        Dialogue[] dChoices2 = { test3, test3 };
        test4 = new DialogueChoice("are you sure?", choices2, dChoices2);

        string[] choices = { "yes", "no, fuck off"};
        Dialogue[] dChoices = { test4, test3 };
        testChoice = new DialogueChoice("would you like to buy something", choices, dChoices);

    }

    public void OnNearby()
    {
        UIController.ShowInteractionTooltip();
    }
    public void Use()
    {
        UIController.HideInteractionTooltip();
        testChoice.ShowDialogue();
    }
    public void NoLongerNearby()
    {
        testDialogue.HideDialogue();
        UIController.HideInteractionTooltip();
    }
}
