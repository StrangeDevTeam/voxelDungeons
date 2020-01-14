using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Inventory inv = new Inventory(); // create an inventory for the player
    

	public enum PlayerClasses // this needs to be moved to another class. other entities can also have these classes
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

	public PlayerClasses playerClass = PlayerClasses.None; // players class is defaulted to None. at level 5 they choose their first class

	public Stats playerStats;

    void Start()
    {
		playerStats = new Stats(playerClass);
    }

    void Update()
    {
        
    }
}
