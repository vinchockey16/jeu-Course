using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject courseTermineeUI;
    
    public void CourseTerminee()
    {
         courseTermineeUI.SetActive(true);
    }
}
