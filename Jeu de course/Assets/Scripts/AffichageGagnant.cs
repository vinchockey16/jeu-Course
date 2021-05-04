using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffichageGagnant : MonoBehaviour
{
    public GameObject PanelGagnantUI;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "BlueCar"){
            PanelGagnantUI.gameObject.SetActive(true);
        }
    }
}
