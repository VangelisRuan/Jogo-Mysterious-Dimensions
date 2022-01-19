using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemDeInventario : MonoBehaviour
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
            var jogador = collision.gameObject.GetComponent<Jogador>();
            jogador.AdicionaItem(_nome);
            jogador.AtualizaInventarioUI();
            if (_som)
                AudioSource.PlayClipAtPoint(_som, transform.position);
            Destroy(this.gameObject);
        }
    }

}
