﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    CharacterController cc; //used to move player. defined in Start()
    public float speed = 50f; //the speed at which the player moves

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIController.isCursorVisible)                                                         //if the player is not using their cursor to navigate menus
            this.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*180.0f * 0.02f, 0));    // take mouse inputs and rotate the player

        Vector3 moveDirection = new Vector3();                                       //
        if (Input.GetKey(KeyCode.W))                                                 //
             moveDirection = transform.TransformDirection(Vector3.forward * speed);  //
        if (Input.GetKey(KeyCode.S))                                                 // take wasd inputs and use them to move the player
            moveDirection = transform.TransformDirection(-Vector3.forward * speed);  // using the character controller
        if (Input.GetKey(KeyCode.A))                                                 //
            moveDirection = transform.TransformDirection(Vector3.left * speed);      //
        if (Input.GetKey(KeyCode.D))                                                 //
            moveDirection = transform.TransformDirection(-Vector3.left * speed);     //
        cc.SimpleMove(moveDirection);                                                //
    }
}
