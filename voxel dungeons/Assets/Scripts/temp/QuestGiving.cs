using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiving : MonoBehaviour
{
	public Enemy target = null;
	DialogueChoice capsuleKillRequest;
	Quest cubeKillQuest;
	DialogueChoice capsuleTalkRequest;
	Quest cylinderTalkQuest;
	
	// Start is called before the first frame update
	void Start()
	{
        //KillQuest killCube = new KillQuest("iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii", target, 1);
        KillQuest killCube = new KillQuest("Kill the cube. please it really scary", target, 1);
        KillQuest killCube1 = new KillQuest("Kill the cube.", target, 1);
        KillQuest killCube2 = new KillQuest("Kill the cube. i really dont like it, please it really scary", target, 1);
        KillQuest killCube3 = new KillQuest("Kill the cube. please it really scary", target, 1);
        KillQuest killCube4 = new KillQuest("Kill the cube. please it really scary", target, 1);
        KillQuest killCube5 = new KillQuest("Kill the cube. please it really scary", target, 1);
        KillQuest killCube8 = new KillQuest("Kill the cube. please it really scary", target, 1);
        KillQuest killCube6 = new KillQuest("Kill the cube. please it really scary", target, 1);
        KillQuest killCube7 = new KillQuest("Kill the cube. please it really scary", target, 1);
        //KillQuest killCube = new KillQuest("Kill the cube. please it really scary",target, 1);
        TalkQuest talkCylinder = new TalkQuest("Talk to the cylinder.", TalkingCylinder.cylinderTalking);

        List<QuestObjective> qObjectives = new List<QuestObjective> { killCube, killCube1, killCube2, killCube3, talkCylinder };
        cubeKillQuest = new Quest("Cube murder go", "You're gonna slaughter this poor cube", qObjectives);

        Dialogue giveKillQuest = new Dialogue("I need you to banish that cube for me", cubeKillQuest);
		Dialogue bye = new Dialogue("Ah, I see...bye then.");
		string[] replies = new string[] { "Yes", "No, leave me be." };
		Dialogue[] branches = new Dialogue[] { giveKillQuest, bye };
		capsuleKillRequest = new DialogueChoice("Adventurer, I have a request to ask, help me will you?", replies, branches);
        
	
	}
	
	public void OnNearby()
	{
		UIController.ShowInteractionTooltip();
	}

	public void NoLongerNearby()
	{
		if (!cubeKillQuest.complete)
		{
			capsuleKillRequest.HideDialogue();
		}
		UIController.HideInteractionTooltip();
	}

	public void Use()
	{	
		if (!cubeKillQuest.complete)
		{
			capsuleKillRequest.ShowDialogue();
		}
		else
		{
			capsuleTalkRequest.ShowDialogue();
		}
	}

    // Update is called once per frame
    void Update()
    {
		
    }
}
