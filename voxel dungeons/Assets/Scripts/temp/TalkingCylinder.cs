using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingCylinder : MonoBehaviour
{
	public static Dialogue cylinderTalking;

	// Start is called before the first frame update
	void Start()
    {
		cylinderTalking = new Dialogue("Hello there!");
	}

	public void OnNearby()
	{
		UIController.ShowInteractionTooltip();
	}

	public void NoLongerNearby()
	{
		UIController.HideInteractionTooltip();
		cylinderTalking.HideDialogue();
	}

	public void Use()
	{
		cylinderTalking.ShowDialogue();
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
