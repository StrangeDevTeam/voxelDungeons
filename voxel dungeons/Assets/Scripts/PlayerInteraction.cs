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
        Collider[] copyOfNearbyColliders = nearbyColliders; // make a copy of the nearby colliders that can be maipulated
        /*//NoLongerNearby()                                                                
        for (int h = 0; h < previousColliders.Count; h++)               // loop through the previous colliders
        {                                                               //
            for(int g = 0; g < copyOfNearbyColliders.Length; g++)       // loop through the current colliders (copy)
            {                                                           //
                if( copyOfNearbyColliders[g] == previousColliders[h])   // if a collider belongs to both
                {                                                       //
                    copyOfNearbyColliders[g] = null;                    // set it to null
                }                                                       //  this means any colliders in the copy
            }                                                           //  must be ones the player has walked away from
        }                                                               
        for(int f = 0; f < copyOfNearbyColliders.Length; f++)                                                               // loop through those (see above)
        {                                                                                                                   //
            if(copyOfNearbyColliders[f] != null)                                                                            // if it is not set to null
            {                                                                                                               //
                copyOfNearbyColliders[f].gameObject.SendMessage("NoLongerNearby", SendMessageOptions.DontRequireReceiver);  // run NoLongerNearby() on the collider
            }
        }*/
        ///WhileNearby()
        for (int i = 0; i < nearbyColliders.Length; i++)                                                // loop through all the colliders the player is nearby
        {                                                                                               // 
            GameObject NearbyObject = nearbyColliders[i].gameObject;                                    // get the gameobject of the colliders
            NearbyObject.SendMessage("WhileNearby", SendMessageOptions.DontRequireReceiver);            // run the WhileNearby() function on that gameobject if possible
            ///Use()
            if (Input.GetKeyDown(useKey))                                                               // if the user presses the key to use an item
            {                                                                                           //
                NearbyObject.SendMessage("Use", SendMessageOptions.DontRequireReceiver);                // run the Use() function on the class
            }                                                                                           // only if it has one
            /*//OnNearby()
            for(int j = 0; (j < previousColliders.Count) && (j < nearbyColliders.Length); j++)  // loop through both the neraby colliders and the previous colliders
            {                                                                                   //
                if(nearbyColliders[i] == previousColliders[j])                                  // if there is a collider in both 
                {                                                                               //
                    previousColliders.Remove(previousColliders[j]);                             // remove it from the previousColliders list
                }                                                                               // this means the only remaining colliders are ones which the player
            }                                                                                   // wasnt already nearby
            for(int k = 0; k < previousColliders.Count; k++)                                                         // loop through those remaining colliders (see above)
            {                                                                                                        //
                previousColliders[k].gameObject.SendMessage("OnNearby", SendMessageOptions.DontRequireReceiver);     // run the OnNearby() function on that collider
            }   */                                                                                                     //

        }

        previousColliders = new List<Collider>();  // empty previous colliders
        foreach(Collider Coll in nearbyColliders)  // loop through nearby colliders
        {                                          //
            previousColliders.Add(Coll);           // add them to previousColliders
        }                                          // previousColliders is now ready for the next frame
    }
}
