﻿// Copyright(c) 2020 arcturus125 & StrangeDevTeam
// Free to use and modify as you please, Not to be published, distributed, licenced or sold without permission from StrangeDevTeam
// Requests for the above to be made here: https://www.reddit.com/r/StrangeDev/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public List<InventorySlot> inv = new List<InventorySlot>();

    //search for an item in the inventory and return its index
    public int searchInvByItem(Item pItem)
    {
        for(int i = 0; i< inv.Count; i++)
        {
            if(inv[i].item == pItem)
            {
                return i;
            }
        }
        return -1;
    }

    //add an item to the inventory
    public void AddItem(Item pItem)
    {
        //if the item is stackable, the increase it's quantiy
        if (pItem.isStackable)
        {
            //search for item
            int found = -1;
            for( int i = 0; i < inv.Count;i++ )
            {
                if(inv[i].item == pItem)
                {
                    found = i;
                }
            }
            //if found
            if(found != -1)
            {
                inv[found].quantity++;
            }
            //if not found
            else
            {
                InventorySlot newSlot = new InventorySlot(pItem);
                inv.Add(newSlot);
            }
        }
        //if the item is not stackable then add another to the inventory
        else
        {
            InventorySlot newSlot = new InventorySlot(pItem);
            inv.Add(newSlot);
        }
    }
    //remove and item from the inventory
    public void RemoveItem(Item pItem)
    {
        //if the item is stackable then reduce it's quantity
        if(pItem.isStackable)
        {
            //search for item
            int found = -1;
            for(int i = 0; i< inv.Count; i++)
            {
                if(inv[i].item == pItem)
                {
                    found = i;
                }
            }
            if(found != -1)
            {
                if(inv[found].quantity > 1)
                {
                    inv[found].quantity--;
                }
                else
                {
                    inv.Remove(inv[found]);
                }
            }
        }
        //if the item is not stackable then remove it from the inventory
        else
        {
            inv.Remove(inv[searchInvByItem(pItem)]);
        }
    }
}
public class InventorySlot
{
    public Item item;
    public bool isStackable = false;
    public int quantity = 1;

    public InventorySlot(Item pItem)
    {
        item = pItem;
        if (pItem.isStackable)
        {
            isStackable = true;
        }
    }
}
