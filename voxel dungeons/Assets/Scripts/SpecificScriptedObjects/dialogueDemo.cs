using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueDemo : MonoBehaviour
{
    DialogueChoice haveAnyQuests;

    Dialogue killQuestDemo;
    Dialogue bye;

    KillQuest killtask;
    Quest killCylinder;

    public Enemy target = null;

    void Start()
    {
        //create killQuest (Queststep)
        killtask = new KillQuest("kill cylinder",target, 1);
        //create blank array and add killquest (queststep) to it
        List<QuestStep> questSteps = new List<QuestStep>();
        questSteps.Add(killtask);
        //create quest using Queststeps
        killCylinder = new Quest("kill cylinder", "Kill the cylinder",questSteps);

        //create dialogue to trigger quest
        killQuestDemo = new Dialogue("Kill that fucking cylinder over there", killCylinder);
        bye = new Dialogue("Okay bye");



        string[]  replies = new string[] {"Yes" ,"No, Fuck off"};
        Dialogue[] branches = new Dialogue[] { killQuestDemo, bye };
        haveAnyQuests = new DialogueChoice("Hey, i have a quest for you, wil you help?", replies, branches);
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
