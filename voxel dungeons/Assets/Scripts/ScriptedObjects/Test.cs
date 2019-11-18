using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void OnNearby()
    {
        Debug.Log("You walked nearby a White Cube");
    }
    public void Use()
    {
        Debug.Log("You have used the white cube");
    }
    public void NoLongerNearby() // does not work
    {
        Debug.Log("You are no longer nearby a white cube");
    }
}
