using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase 
{
    public static List<Item> itemDatabase = new List<Item>();

    public Item SearchDatabaseByID(int ID)
    {
        for(int i = 0; i < itemDatabase.Count; i++)
        {
            if(ID == itemDatabase[i].ID)
            {
                return itemDatabase[i];
            }
        }
        return null;
    }

    public Item SearchDatabaseByName(string Name)
    {
        for(int i = 0; i< itemDatabase.Count; i++)
        {
            if(Name == itemDatabase[i].itemName)
            {
                return itemDatabase[i];
            }
        }
        return null;
    }
}
