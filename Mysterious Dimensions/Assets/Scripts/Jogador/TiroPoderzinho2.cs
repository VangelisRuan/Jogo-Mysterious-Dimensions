using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPoderzinho2 : MonoBehaviour
{
    public Vector3 velocidade;

    [SerializeField]
    private int _dano = 2;

    [SerializeField]
    private GameObject _efeitoImpacto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movimentar();
    }

    void movimentar()
    {
        this.transform.position += velocidade * Time.deltaTime;
        if (this.transform.position.y >= 7 || this.transform.position.y <= -5)
        {
            this.velocidade.y *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Flecha"))
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

