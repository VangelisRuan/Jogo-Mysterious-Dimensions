﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarLvl : MonoBehaviour
{

    public Jogador _itemsPegos;

    public GameControler moedaPp;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Anotaçoes.pontuacao = moedaPp.pontuaçaoGeral;
            GuardarItems._itemsDeInventario = _itemsPegos._itemsDeInventario;
            SceneManager.LoadScene("Nivel1D2");
        }
       
    }
}