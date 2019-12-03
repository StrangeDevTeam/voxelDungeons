using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public static Quest ActiveQuest = null;

    public bool complete = false; // becomes true when all steps of the quest are complete
    public bool started = false; // becomes true when the quest has been given to the player
    public string title = "quest title";
    public string info = "quest info";
    public List<QuestStep> steps = new List<QuestStep>(); //the different objectives of the quest
    //Item[] rewards = new Item[]; // the items given to the user on completion of the quest 

    /// <summary>
    /// creates a Quest with a title info and a list of objectives
    /// </summary>
    /// <param name="pTitle">the title of the quest</param>
    /// <param name="pInfo">the information of the quest</param>
    /// <param name="pSteps"> the list of QuestSteps that are objectives for this quest</param>
    public Quest(string pTitle, string pInfo, List<QuestStep> pSteps)
    {
        complete = false;
        title = pTitle;
        info = pInfo;
        steps = pSteps;
        foreach (QuestStep step in pSteps)
        {
            step.attachParent(this);
        }
    }
    /// <summary>
    /// creates a Quest with a title info and a single objective
    /// </summary>
    /// <param name="pTitle">the title of the quest</param>
    /// <param name="pInfo">the information of the quest</param>
    /// <param name="pSteps"> the QuestStep that is an objective for this quest</param>
    public Quest(string pTitle, string pInfo, QuestStep pSteps)
    {
        complete = false;
        title = pTitle;
        info = pInfo;
        List<QuestStep> tempList = new List<QuestStep>();
        tempList.Add(pSteps);
        steps = tempList;
        foreach (QuestStep step in tempList)
        {
            step.attachParent(this);
        }
    }

    public static KillQuest convertToKillQuest(QuestStep pQuest)
    {
        try
        {
            KillQuest temp = (KillQuest)(pQuest);
            return temp;
        }
        catch(Exception)
        {
            return null;
        }
    }
    public static TalkQuest convertToTalkQuest(QuestStep pQuest){
        try
        {
            TalkQuest temp = (TalkQuest)(pQuest);
            return temp;
        }
        catch(Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// checks if all the queststeps are complete, if so complete this quest
    /// </summary>
    public void UpdateQuestStatus()
    {
        bool isQuestComplete = true;
        foreach(QuestStep step in steps)
        {
            if(step.stepComplete != true)
            {
                isQuestComplete = false;
                break;
            }
        }
        if (isQuestComplete)
        {
            complete = true;
            OnComplete();
        }
    }
    //run when the quest is complete
    void OnComplete()
    {
        Debug.Log(title+" Completed");
    }
}
// referred to as "objectives" sometimes to elliviate confusion
public class QuestStep
{
    public Quest ParentQuest = null; // the Quest that this QuestStep is a part of
    public bool stepComplete = false; // true when this objective is complete
    public string title = "task title"; // the title of the objective
    public bool showTitle = true; // whether or not the title should show on the UI
    public int ID = -1;
    public static int nextID = 0;


    
    public QuestStep(string pTitle)
    {
        title = pTitle;
        ID= nextID;
        nextID++;
    }
    //run when the Quest is created, attaches the parent Quest to these objectives
    public void attachParent(Quest pParentQuest)
    {
        ParentQuest = pParentQuest;
    }
}
public class KillQuest : QuestStep
{
    public List<Enemy> targets = new List<Enemy>(); // the target or targets to be tracked for this killQuest
    public int killsNeeded = 1; // the amount of kills needed for completion
    public int amountKilled = 0; // the amount of kills the player has

    /// <summary>
    /// create a Killquest with a singular target
    /// </summary>
    /// <param name="pTitle"> the title of the KillQuest</param>
    /// <param name="pTarget"> the target to kill</param>
    /// <param name="pKillsNeeded"> the amount needed to kill</param>
    public KillQuest(string pTitle, Enemy pTarget, int pKillsNeeded) : base (pTitle)
    {
        targets.Clear();
        targets.Add(pTarget);
        killsNeeded = pKillsNeeded;
    }
    /// <summary>
    /// create a killquest with multiple targets
    /// </summary>
    /// <param name="pTitle"> the title of the KillQuest</param>
    /// <param name="pTargets"> the targets to kill</param>
    /// <param name="pKillsNeeded"> the amount needed to kill</param>
    public KillQuest(string pTitle, List<Enemy> pTargets, int pKillsNeeded) : base(pTitle)
    {
        targets = pTargets;
        killsNeeded = pKillsNeeded;
    }

    //run when a target is killed
    public void TargetKilled()
    {
        amountKilled++;
        if(amountKilled >= killsNeeded)
        {
            stepComplete = true;
            ParentQuest.UpdateQuestStatus();
        }
    }
}
public class TalkQuest : QuestStep
{
    public Dialogue questedDialogue;

    public TalkQuest(string pTitle, Dialogue pQuestedDialogue)  : base(pTitle)
    {
        questedDialogue = pQuestedDialogue;
    }

    public void QuestedDialogueRun()
    {
        stepComplete = true;
        ParentQuest.UpdateQuestStatus();
    }
}
