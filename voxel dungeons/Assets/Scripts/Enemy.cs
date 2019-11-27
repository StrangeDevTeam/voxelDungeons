using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "VD/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public int health = 100;
    public string name = "geoff";


    public Enemy(int pHealth, string pName)
    {
        health = pHealth;
        name = pName;
    }

    public bool CheckforKill()
    {
        if (health <= 0)
        {
            OnKill();
            return true;
        }
        return false;
    }



    void OnKill()
    {
        Quest q = Quest.ActiveQuest;
        for (int i = 0; i <q.steps.Count; i++)
        {
            KillQuest kq = converttoKillQuest(q.steps[i]);
            if(kq != null)
            {
                for(int j = 0; j < kq.targets.Count; j++)
                {
                    if (this == kq.targets[j])
                    {
                        kq.TargetKilled();
                    }
                }
            }
        }
        
    }

    KillQuest converttoKillQuest (QuestStep pQuestStep)
    {
        try
        {
            KillQuest temp = (KillQuest)pQuestStep;
            return temp;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
