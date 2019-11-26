using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public Enemy enemyReference;


    public void Use()
    {
        enemyReference.health = 0;
        enemyReference.CheckforKill();
    }
}
