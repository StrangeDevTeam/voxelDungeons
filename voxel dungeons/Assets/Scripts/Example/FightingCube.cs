using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void OnNearby()
	{
		UIController.ShowInteractionTooltip();
	}

	public void NoLongerNearby()
	{
		UIController.HideInteractionTooltip();
	}

	public void Use()
	{
		
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
