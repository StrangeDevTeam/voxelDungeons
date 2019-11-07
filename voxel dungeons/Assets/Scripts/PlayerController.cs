using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent; //uses pathfinding to move the character to where the user clicks, assigned in Start()


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                                  //when mouse is clicked
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //Draw a ray to get the co-ordinates 
            RaycastHit hit = new RaycastHit();                            //of where the player clicked

            if (Physics.Raycast(ray, out hit))                            //if the user clicked an object with a collider
                agent.destination = hit.point;                            //use path finding to move the player to the coirdinates
        }
    }
}
