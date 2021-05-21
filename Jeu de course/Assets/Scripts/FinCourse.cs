using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinCourse : MonoBehaviour
{
	public GameObject affichageGagnant1UI;
	public GameObject affichageGagnant2UI;
	public GameObject affichageGagnant3UI;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "BlueCar")
		{
			affichageGagnant1UI.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
		if (collision.tag == "A*")
		{
			affichageGagnant2UI.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
		if (collision.tag == "Aleatoire")
		{
			affichageGagnant3UI.gameObject.SetActive(true);
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
