using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	Stat STR;
	Stat DEX;
	Stat CON;
	Stat INT;
	Stat WIS;
	Stat CHA;

	public Stats(Player.PlayerClasses entityClass)
	{
		if (entityClass == Player.PlayerClasses.Barbarian || entityClass == Player.PlayerClasses.Fighter || entityClass == Player.PlayerClasses.Paladin)
		{
			STR = new Stat("Strength", true);
		}
		else
		{
			STR = new Stat("Strength", false);
		}

		if (entityClass == Player.PlayerClasses.Monk || entityClass == Player.PlayerClasses.Ranger || entityClass == Player.PlayerClasses.Rogue)
		{
			DEX = new Stat("Dexterity", true);
		}
		else
		{
			DEX = new Stat("Dexterity", false);
		}

		CON = new Stat("Constituition", false);

		if (entityClass == Player.PlayerClasses.Wizard)
		{
			INT = new Stat("Intelligence", true);
		}
		else
		{
			INT = new Stat("Intelligence", false);
		}

		if (entityClass == Player.PlayerClasses.Cleric || entityClass == Player.PlayerClasses.Druid)
		{
			WIS = new Stat("Wisdom", true);
		}
		else
		{
			WIS = new Stat("Wisdom", false);
		}

		if (entityClass == Player.PlayerClasses.Bard || entityClass == Player.PlayerClasses.Warlock || entityClass == Player.PlayerClasses.Sorcerer)
		{
			CHA = new Stat("Charisma", true);
		}
		else
		{
			CHA = new Stat("Charisma", false);
		}
	}
}

public class Stat
{
	public string name;
	public int value = 10;
	public int modifier;
	public bool isPrimary;

	public Stat(string pName, bool pIsPrimary)
	{
		name = pName;
		isPrimary = pIsPrimary;
		CalculateModifier(isPrimary);
	}

	public int CalculateModifier(bool isPrimary)
	{
		if (isPrimary)
		{
			return value - (10/*+(2*classLevel)*/);
		}
		else
		{
			return (value - 10) / 3;
		}
	}
}
