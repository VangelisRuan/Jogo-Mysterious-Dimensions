using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TiroPoderzinho : MonoBehaviour
{
    [SerializeField]
    private float _velocidade;
    [SerializeField]
    private int _dano = 3;
    [SerializeField]
    private GameObject _efeitoImpacto;

    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * _velocidade;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Flecha"))
        {
            Instantiate(_efeitoImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Parede"))
        {
            Instantiate(_efeitoImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Extremidade"))
        {
            Instantiate(_efeitoImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Inimigo"))
        {
            var inimigoObj = collision.GetComponent<CompInimigo>();
            inimigoObj.TomaDano(_dano);
            Instantiate(_efeitoImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Boss"))
        {
            var bossObj = collision.GetComponent<BossVidas>();
            bossObj.TomaDano(_dano);
            Instantiate(_efeitoImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("PoderDoBoss"))
        {
            var poderDoBossObj = collision.GetComponent<VidasPoderDoBoss>();
            poderDoBossObj.TomaDano(_dano);
            Instantiate(_efeitoImpacto, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
