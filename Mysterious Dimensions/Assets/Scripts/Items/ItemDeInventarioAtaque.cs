using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeInventarioAtaque : MonoBehaviour
{

    [SerializeField]
    private string _nome;

    [SerializeField]
    private AudioClip _som;

    private BoxCollider2D _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            var _controleDoJogador = collision.gameObject.GetComponent<ControleDoJogador>();
            _controleDoJogador.AdicionaItemAtaque(_nome);
            _controleDoJogador.AtualizaInventarioAtaqueUI();
            if (_som)
                AudioSource.PlayClipAtPoint(_som, transform.position);
            Destroy(this.gameObject);
        }
    }

}