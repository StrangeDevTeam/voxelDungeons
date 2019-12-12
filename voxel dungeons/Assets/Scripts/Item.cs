using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID;
    public string itemName;
    public string info;
    public int worth;
    public bool isStackable = false;
    //public Sprite icon;
    public Dictionary<string, int> itemStats = new Dictionary<string, int>(); // "stats" that come in pairs, a name (string) and a number. for example ("weight", 22)

    public Item(int pID, string pName, string pInfo, int pWorth, Dictionary<string,int> pStats)
    {
        ID = pID;
        itemName = pName;
        info = pInfo;
        worth = pWorth;
        itemStats = pStats;
    }
    public Item(int pID, string pName, string pInfo, int pWorth, Dictionary<string, int> pStats, bool pIsStackable)
    {
        ID = pID;
        itemName = pName;
        info = pInfo;
        worth = pWorth;
        itemStats = pStats;
        isStackable = pIsStackable;
    }

}
