using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo2 : MonoBehaviour
{

    public static Dialogue test;

    void Start()
    {
        test = new Dialogue("hello there");
    }

    public void Use()
    {
        test.ShowDialogue();
    }
}
