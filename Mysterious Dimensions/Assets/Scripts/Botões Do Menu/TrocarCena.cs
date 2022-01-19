using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class TrocarCena : MonoBehaviour
{

    public string nomeDaCena;

    public void changeS()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void sair()
    {   
        Application.Quit();
    }
}
