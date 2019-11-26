using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public static Quest ActiveQuest = null;

    public bool complete = false;
    public string title = "quest title";
    public string info = "quest info";
    public List<QuestStep> steps = new List<QuestStep>();
    //Item[] rewards = new Item[];

    public Quest(string pTitle, string pInfo, List<QuestStep> pSteps)
    {
        complete = false;
        title = pTitle;
        info = pInfo;
        steps = pSteps;
        foreach(QuestStep step in pSteps)
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
    void OnComplete()
    {
        Debug.Log(title+" Completed");
    }
}
public class QuestStep
{
    public Quest ParentQuest = null;
    public bool stepComplete = false;
    public string title = "task title";
    public bool showTitle = true;

    public QuestStep(string pTitle)
    {
        title = pTitle;
    }
    public void attachParent(Quest pParentQuest)
    {
        ParentQuest = pParentQuest;
    }
}
public class KillQuest : QuestStep
{
    public List<Enemy> targets = new List<Enemy>();
    public int killsNeeded = 1;
    public int amountKilled = 0;

    public KillQuest(string pTitle, Enemy pTarget, int pKillsNeeded) : base (pTitle)
    {
        targets.Clear();
        targets.Add(pTarget);
        killsNeeded = pKillsNeeded;
    }
    public KillQuest(string pTitle, List<Enemy> pTargets, int pKillsNeeded) : base(pTitle)
    {
        targets = pTargets;
        killsNeeded = pKillsNeeded;
    }

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
