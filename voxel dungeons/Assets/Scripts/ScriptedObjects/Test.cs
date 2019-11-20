using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Will run once when the player walks up to the collider
    public void OnNearby()
    {
        Debug.Log("You walked nearby a White Cube");
        UIController.ShowInteractionTooltip();
    }

    // Will run continuously while the player is within interaction Distance
    public void WhileNearby()
    {

    }

    // Will run once when the plaeyr preses the Use key (default: f) while nearby
    public void Use()
    {
        Debug.Log("You have used the white cube");
    }

    // Will run once when the player walks away from a collider
    public void NoLongerNearby()
    {
        Debug.Log("You are no longer nearby a white cube");
        UIController.HideInteractionTooltip();
    }
}
