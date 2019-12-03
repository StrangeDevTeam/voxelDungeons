using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    CharacterController cc; //used to move player. defined in Start()
    public float speed = 50f; //the speed at which the player moves
    public const float gravity = 0.25f; // used for somewhat realistic gravity. Default 0.25f

    void Start()
    {
        cc = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        //if the player isnt using cursor to navigate menus, use it to rotate player
        if(!UIController.isCursorVisible)                                                     
            this.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*180.0f * 0.02f, 0));

        //translate character down to imitate gravity
        cc.Move(transform.TransformDirection(Vector3.down * gravity));

        //WASD keys to move character
        Vector3 moveDirection = new Vector3();                                      
        if (Input.GetKey(KeyCode.W))                                                
             moveDirection += transform.TransformDirection(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.S))                                                
            moveDirection += transform.TransformDirection(-Vector3.forward * speed);
        if (Input.GetKey(KeyCode.A))                                                
            moveDirection += transform.TransformDirection(Vector3.left * speed);    
        if (Input.GetKey(KeyCode.D))                                                
            moveDirection += transform.TransformDirection(-Vector3.left * speed);   
        cc.SimpleMove(moveDirection);                                               
    }
}
