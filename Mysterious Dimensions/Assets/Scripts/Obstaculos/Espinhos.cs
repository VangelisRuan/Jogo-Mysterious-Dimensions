using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            var jogador = collision.GetComponent<Jogador>();
            jogador.TomaDano(1);
        }
    }
}
