using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool JeuEnPause = false;
    public GameObject menuPauseUI;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(JeuEnPause){
                Resume();
            }
            else{
                Pause();
            }
        }
        
    }

    public void Resume(){
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        JeuEnPause = false;
    }

    void Pause(){
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        JeuEnPause = true;
    }

    public void ChargerMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); // Scene du menu
        menuPauseUI.SetActive(false);
    }

    public void QuitterJeu(){
        Debug.Log("Jeu quitté");
        Application.Quit();
    }
}
