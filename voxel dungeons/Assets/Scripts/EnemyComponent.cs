using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    public Enemy enemyReference;


    public void Use()
    {
        enemyReference.health = 0;
        bool isDed = enemyReference.CheckforKill();
        if (isDed)
        {
            Kill();
        }
    }
    void Kill()
    {
        Destroy(this.gameObject);
        PlayerInteraction.previousColliders.Remove(this.gameObject.GetComponent<Collider>());
    }
}
