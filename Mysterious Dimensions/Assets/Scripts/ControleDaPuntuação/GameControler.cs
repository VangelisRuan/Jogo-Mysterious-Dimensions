using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControler : MonoBehaviour
{
    public int pontuaçaoGeral;

    public static GameControler instance;

    public Text Morte;
    public Text Pontos;
    public Text Movement;
    public Text hightScore;


    private int totalScore;
    public float escoreAndando;

    private float vaRiavelVazia;

    void Start()

    {


        escoreAndando++;


        hightScore.text = PlayerPrefs.GetFloat("numEscore", 0).ToString();

        instance = this;
        totalScore = PlayerPrefs.GetInt("pontuaçaoGeral");
        escoreAndando = PlayerPrefs.GetFloat("pontosAndando");

        if (Application.loadedLevelName == "Score")
        {

            Pontos.text = totalScore.ToString();
            Movement.text = escoreAndando.ToString();

        }

        if (Application.loadedLevelName == "Nivel1Retorno")
        {
            pontuaçaoGeral = Anotaçoes.pontuacao;
            Pontos.text = pontuaçaoGeral.ToString();
            Movement.text = escoreAndando.ToString();
        }

        if (Application.loadedLevelName == "Nivel1D1")
        {
            pontuaçaoGeral = Anotaçoes.pontuacao;
            Pontos.text = pontuaçaoGeral.ToString();
            Movement.text = escoreAndando.ToString();
        }


        if (Application.loadedLevelName == "Nivel1D2")
        {
            pontuaçaoGeral = Anotaçoes.pontuacao;
            Pontos.text = pontuaçaoGeral.ToString();
            Movement.text = escoreAndando.ToString();
        }

        if (Application.loadedLevelName == "Nivel1D3" )
        {
            pontuaçaoGeral = Anotaçoes.pontuacao;
            Pontos.text = pontuaçaoGeral.ToString();
            Movement.text = escoreAndando.ToString();
        }

        if (Application.loadedLevelName == "Boss")
        {
            pontuaçaoGeral = Anotaçoes.pontuacao;
            Pontos.text = pontuaçaoGeral.ToString();
            Movement.text = escoreAndando.ToString();
        }



    }

    public void Update()
    {

        if (escoreAndando > PlayerPrefs.GetFloat("numEscore", 0))

        {
            PlayerPrefs.SetFloat("numEscore", escoreAndando);
            hightScore.text = escoreAndando.ToString();
        }

        if (Time.timeScale == 1)

        {
            Movement.text = escoreAndando.ToString();
            PlayerPrefs.SetFloat("pontosAndando", escoreAndando);
        }

        if (Application.loadedLevelName == "Nivel1Retorno")
        {

            if (Time.timeScale == 1)

            {
                escoreAndando++;
            }

        }

        if (Application.loadedLevelName == "Nivel1D1")
        {

            if (Time.timeScale == 1)

            {
                escoreAndando++;
            }

        }

        if (Application.loadedLevelName == "Nivel1D2")
        {

            if (Time.timeScale == 1)

            {
                escoreAndando++;
            }

        }

        if (Application.loadedLevelName == "Nivel1D3" )
        {

            if (Time.timeScale == 1)

            {
                escoreAndando++;
            }

        }

        if (Application.loadedLevelName == "Boss")
        {

            if (Time.timeScale == 1)

            {
                escoreAndando++;
            }

        }

        Morte.text = escoreAndando.ToString();

    }

    public void UpdateScoreText()
    {

        totalScore++;
        Pontos.text = pontuaçaoGeral.ToString();
        PlayerPrefs.SetInt("pontuaçaoGeral", totalScore);

    }

}

