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

    public void CheckforKill()
    {

        Debug.Log("test");
        if (health <= 0)
        {
            onKill();
        }
    }



    void onKill()
    {
         Destroy(this);
    }
}
