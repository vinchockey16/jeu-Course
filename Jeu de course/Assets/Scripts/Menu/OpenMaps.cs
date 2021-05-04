using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMaps : MonoBehaviour
{
    public void OpenMap1()
	{
		SceneManager.LoadScene(3);
	}

	public void OpenMap2()
	{
		SceneManager.LoadScene(4);
	}

	public void OpenMap3()
	{
		SceneManager.LoadScene(5);
	}

	public void OpenMap4()
	{
		SceneManager.LoadScene(6);
	}
}
