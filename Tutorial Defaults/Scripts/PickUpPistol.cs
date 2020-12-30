using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour
{
	public float TheDistance;
 	public GameObject FakePistol;
	public GameObject RealPistol;
	public TextHints textHints;



	void Update()
	{
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver()
	{
		if (TheDistance <= 2)
		{
			Debug.Log("is less than 2");
			textHints.SendMessage("ShowHint", " E Pick Up Pistol");
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (TheDistance <= 2)
			{
				this.GetComponent<BoxCollider>().enabled = false;
				FakePistol.SetActive(false);
				RealPistol.SetActive(true);
			}
		}
	}

	void OnMouseExit()
	{
	
 	}
}
