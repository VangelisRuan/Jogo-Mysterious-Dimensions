using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVidas : MonoBehaviour
{

    [SerializeField]
    private int _vida = 30;

    private float _tempoDeAnimacaoLevandoDano = 0.5f;

    public SpriteRenderer sprite;

    [SerializeField]
    private GameObject _animacaoDeMorte;

    [SerializeField]
    private AudioClip _som;

    [SerializeField]
    private AudioClip _som2;

    private void start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.enabled = true;

        sprite.color = new Color(1f, 1f, 1f, 1f);

        _tempoDeAnimacaoLevandoDano += Time.deltaTime;

        if (_tempoDeAnimacaoLevandoDano <= 0.5f)
        {
            sprite.color = new Color(1f, 0, 0, 1f);
        }

        if (_tempoDeAnimacaoLevandoDano >= 0.10f && _tempoDeAnimacaoLevandoDano <= 0.20f ||
            _tempoDeAnimacaoLevandoDano >= 0.30f && _tempoDeAnimacaoLevandoDano <= 0.40f)
        {
            sprite.enabled = false;
        }

    }

    public void TomaDano(int dano)
    {

        _vida -= dano;

        if (_som)
            AudioSource.PlayClipAtPoint(_som, transform.position);

        _tempoDeAnimacaoLevandoDano = 0;

        if (_vida <= 0)
        {
            Morre();
        }
    }

    public void Morre()
    {
        Instantiate(_animacaoDeMorte, transform.position, transform.rotation);
        if (_som2)
            AudioSource.PlayClipAtPoint(_som2, transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            var jogador = collision.GetComponent<Jogador>();
            jogador.TomaDano(1);
        }
    }

}