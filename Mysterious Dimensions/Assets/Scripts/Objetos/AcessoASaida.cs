using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcessoASaida : MonoBehaviour
{

    public Vector3 velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimentar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("AcessoASaida"))
        {
            this.velocidade.x *= -1;
        }
    }

    void movimentar()
    {
        this.transform.position += velocidade * Time.deltaTime;
    }

}
