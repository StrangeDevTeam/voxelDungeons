using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueDemo : MonoBehaviour
{
    DialogueChoice haveAnyQuests;

    Dialogue killQuestDemo;
    Dialogue bye;

    TalkQuest killtask;
    Quest killCylinder;





    public Enemy Slime; 



    void Start()
    {
        //create killQuest (Queststep)
        killtask = new TalkQuest("talk to cylinder", Demo2.test);
        //create blank array and add killquest (queststep) to it
        List<QuestStep> questSteps = new List<QuestStep>();
        questSteps.Add(killtask);
        //create quest using Queststeps
        killCylinder = new Quest("talk to cylinder", "talk to the cylinder", questSteps);

        //create dialogue to trigger quest
        killQuestDemo = new Dialogue("talk to  that  cylinder over there", killCylinder);
        bye = new Dialogue("Okay bye");



        string[] replies = new string[] { "Yes", "No, go away" };
        Dialogue[] branches = new Dialogue[] { killQuestDemo, bye };
        haveAnyQuests = new DialogueChoice("Hey, i have a quest for you, will you help?", replies, branches);
    }

    public void OnNearby()
    {
        UIController.ShowInteractionTooltip();
    }
    public void Use()
    {
        UIController.HideInteractionTooltip();
        haveAnyQuests.ShowDialogue();
    }
    public void NoLongerNearby()
    {
        haveAnyQuests.HideDialogue();
        UIController.HideInteractionTooltip();
    }
}
