using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinCourse : MonoBehaviour
{
	public GameObject affichageGagnantUI;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "BlueCar")
		{
			affichageGagnantUI.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
		if (collision.tag == "A*")
		{
			affichageGagnantUI.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
	}		

	public void OpenMenuFromGagnant(){
		SceneManager.LoadScene(1);
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
