using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetourAccueil : MonoBehaviour
{
    public void Retour()
	{
		SceneManager.LoadScene(0);
	}

	public void OpenInformations()
	{
		SceneManager.LoadScene(2);
	}
}
