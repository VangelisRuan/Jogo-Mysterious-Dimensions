using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPoderDoBoss : MonoBehaviour

{
    public Vector3 velocidade;
    [SerializeField]
    private int _dano = 1;
    [SerializeField]
    private GameObject _efeitoImpacto;

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
            jogador.TomaDano(_dano);
        }
        if (collision.gameObject.tag.Equals("Extremidade"))
        {
            Instantiate(_efeitoImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
