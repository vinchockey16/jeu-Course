using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool JeuEnPause = false;
    public GameObject menuPauseUI;

    void Start(){
        menuPauseUI.SetActive(false);
    }
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

    void Resume(){
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        JeuEnPause = false;
    }

    void Pause(){
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        JeuEnPause = true;
    }
}
