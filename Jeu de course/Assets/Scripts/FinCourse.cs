using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinCourse : MonoBehaviour
{
	public GameObject affichageGagnantUI;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "BlueCar")
		{
			affichageGagnantUI.gameObject.SetActive(true);
		}
	}		
}
