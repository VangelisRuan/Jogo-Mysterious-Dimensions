using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempoResetBug : MonoBehaviour
{

    public float timerDois;

    public void Start()
    {
       
    }

    public void Update()
    {
        if (Time.timeScale == 1)
        {
            timerDois += Time.timeScale;
        }
        else
        {
            Time.timeScale = 0;
        }

        timerDois += Time.timeScale;

        GameControler.instance.escoreAndando = timerDois;
    }

}