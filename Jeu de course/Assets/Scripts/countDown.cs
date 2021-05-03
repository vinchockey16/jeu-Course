using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countDown : MonoBehaviour
{
    public int countdownTemps;
    public TextMeshProUGUI countdownAffichage;

    public void Start()
    {
        StartCoroutine(CountDownDepart());
    }
    IEnumerator CountDownDepart(){
        Time.timeScale = 0;
        while(countdownTemps > 0){
            countdownAffichage.text = countdownTemps.ToString();
            yield return new WaitForSecondsRealtime(1);

            countdownTemps--;
        }

        countdownAffichage.text = "GO!";
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);

        countdownAffichage.gameObject.SetActive(false);
        
    }
}
