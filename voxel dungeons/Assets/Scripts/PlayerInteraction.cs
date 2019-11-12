using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 5; // the distance in which the user can interact with a UsableObject
    public KeyCode useKey = KeyCode.F; // this is the key the user will press to use/ interact with an object. Default f

    // Update is called once per frame
    void Update()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(this.transform.position, interactionDistance);  // get every collider within interactionDistance
        for (int i = 0; i< nearbyColliders.Length; i++)                                                    // loop through all the colliders
        {                                                                                                  // 
            GameObject NearbyObject = nearbyColliders[i].gameObject;                                       // get the gameobject of the colliders
            NearbyObject.SendMessage("Nearby", SendMessageOptions.DontRequireReceiver);                    // run the Nearby() function on that gameobject if possible

            if (Input.GetKeyDown(useKey))                                                                  // if the user presses the key to use an item
            {                                                                                              //
                NearbyObject.SendMessage("Use", SendMessageOptions.DontRequireReceiver);                   // run the Use() function on the class
            }                                                                                              // only if it has one
        }
    }
}
