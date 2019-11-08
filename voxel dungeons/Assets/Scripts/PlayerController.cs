using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // NavMeshAgent agent; //uses pathfinding to move the character to where the user clicks, assigned in Start()
    Rigidbody rb;
    CharacterController cc;
    public float speed = 50f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIController.isCursorVisible)
            player.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*180.0f * 0.02f, 0));

        Vector3 moveDirection = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
             moveDirection = transform.TransformDirection(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = transform.TransformDirection(-Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = transform.TransformDirection(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = transform.TransformDirection(-Vector3.left * speed);
        }
        cc.SimpleMove(moveDirection);
        //   if (Input.GetMouseButtonDown(0))                                  //when mouse is clicked
        //   {
        //       var ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //Draw a ray to get the co-ordinates 
        //       RaycastHit hit = new RaycastHit();                            //of where the player clicked
        //
        //       if (Physics.Raycast(ray, out hit))                            //if the user clicked an object with a collider
        //           agent.destination = hit.point;                            //use path finding to move the player to the coirdinates
        //   }
    }
}
