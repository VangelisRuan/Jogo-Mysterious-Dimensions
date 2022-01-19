using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroArmadilha2 : MonoBehaviour
{
    public Vector3 velocidade;

    // Start is called before the first frame update
    void Update()
    {
        Movimentar();
    }

    void Movimentar()
    {
        this.transform.position += velocidade * Time.deltaTime;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            var jogador = collision.GetComponent<Jogador>();
            jogador.TomaDano(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Poderzinho"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("AreaDeAtaque"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Chao"))
        {
            Destroy(gameObject);
        }
    }
}
