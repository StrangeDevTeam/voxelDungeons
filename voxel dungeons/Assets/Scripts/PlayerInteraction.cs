using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 5; // the distance in which the user can interact with a UsableObject
    public KeyCode useKey = KeyCode.F; // this is the key the user will press to use/ interact with an object. Default f
    public List<Collider> previousColliders = new List<Collider>();

    // Update is called once per frame
    void Update()
    {
        Collider[] nearbyColliders = Physics.OverlapSphere(this.transform.position, interactionDistance);  // get every collider within interactionDistance
        List<Collider> copyOfNearbyColliders =  ArrayToList(ref nearbyColliders); // make a copy of the nearby colliders that can be maipulated
        ///OnNearby()                                                                
        for (int h = 0; h < previousColliders.Count; h++)                   // loop through the previous frames colliders
        {                                                                   //
            for(int g = 0; g < copyOfNearbyColliders.Count; g++)            // loop through the current  frames colliders (copy)
            {                                                               //
                if( copyOfNearbyColliders[g] == previousColliders[h])       // if a collider belongs to both
                {                                                           //
                    copyOfNearbyColliders.Remove(copyOfNearbyColliders[g]); // remove it from the copyOfNearbyColliders list
                }                                                           // this means any colliders in the copyOfNearbyColliders
            }                                                               // must be ones the player has walked towards
        }                                                               
        for(int f = 0; f < copyOfNearbyColliders.Count; f++)                                                    // loop through those (see above)
        {                                                                                                       //
            copyOfNearbyColliders[f].gameObject.SendMessage("OnNearby", SendMessageOptions.DontRequireReceiver);// run OnNearby() on them
        }

        ///NoLongerNearby()
        for (int g = 0; g < previousColliders.Count; g++)               // loop through the previous frames colliders
        {                                                               //
            for (int h = 0; h < nearbyColliders.Length; h++)            // loop through the current frames colliders
            {                                                           //
                if (previousColliders[g] == nearbyColliders[h])         // if a collider belongs to both
                {                                                       //
                    previousColliders.Remove(previousColliders[g]);     // remove it from the previousColliders list
                }                                                       // this means any colliders in the previousColliders list
            }                                                           // must be ones the player has walked away from
        }
        for (int f = 0; f < previousColliders.Count; f++)                                                           // loop through those (see above)
        {                                                                                                           //
            previousColliders[f].gameObject.SendMessage("NoLongerNearby", SendMessageOptions.DontRequireReceiver);  // Run NoLongerNearby() on them
        }

        ///WhileNearby()
        for (int i = 0; i < nearbyColliders.Length; i++)                                                // loop through all the colliders the player is nearby
        {                                                                                               // 
            GameObject NearbyObject = nearbyColliders[i].gameObject;                                    // get the gameobject of the colliders
            NearbyObject.SendMessage("WhileNearby", SendMessageOptions.DontRequireReceiver);            // run the WhileNearby() function on that gameobject if possible
            ///Use()
            if (Input.GetKeyDown(useKey))                                                               // if the user presses the key to use an item
            {                                                                                           //
                NearbyObject.SendMessage("Use", SendMessageOptions.DontRequireReceiver);                // run the Use() function on the class
            }                                                                                           

        }

        previousColliders = ArrayToList(ref nearbyColliders); //at the end of the frame, set the current frame's collider to the previous frame's colliders ready for the next frame

    }

    List<Collider> ArrayToList(ref Collider[] array) // converts a Collider array to a list of Colliders
    {
        List<Collider> tempList = new List<Collider>();
        foreach(Collider coll in array)
        {
            tempList.Add(coll);
        }
        return tempList;
    }
}
