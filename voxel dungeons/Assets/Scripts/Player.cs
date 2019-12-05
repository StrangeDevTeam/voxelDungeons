using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public enum PlayerClasses 
	{ 
		Barbarian,
		Bard,
		Cleric,
		Druid,
		Fighter,
		Monk,
		Paladin,
		Ranger,
		Rogue,
		Sorcerer,
		Warlock,
		Wizard,
		None
	}

	public PlayerClasses playerClass = PlayerClasses.None;

	public Stats playerStats;

	// Start is called before the first frame update
    void Start()
    {
		playerStats = new Stats(playerClass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
