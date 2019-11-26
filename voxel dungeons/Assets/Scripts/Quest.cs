using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public static Quest ActiveQuest = null;

    bool complete = false;
    string title = "quest title";
    string info = "quest info";
    List<QuestStep> steps = new List<QuestStep>();
    //Item[] rewards = new Item[];

    public static KillQuest convertToKillQuest(Quest pQuest)
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
}
public class QuestStep : Quest
{
    bool stepComplete = false;
    string title = "task title";
    bool showTitle = true;
}
public class KillQuest : QuestStep
{
    List<Enemy> targets = new List<Enemy>();
    int killsNeeded = 1;
    int amountKilled = 0;
}
