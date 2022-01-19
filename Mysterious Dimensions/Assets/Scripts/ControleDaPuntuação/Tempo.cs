using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tempo : MonoBehaviour
{
    public GameObject _menu;

    public float timer;

    public int objetoVazio;

    private Rigidbody2D rb2d;

    public bool tpp = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


       

    }


    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Parede")
        {
            timer += Time.deltaTime;

            if (timer >= 1)
            {
                _menu.SetActive(true);
                Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
                gameObject.SetActive(false);
            }

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        timer = objetoVazio;
    }

}

