﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoMenu : MonoBehaviour
{
    public void Quit ()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
