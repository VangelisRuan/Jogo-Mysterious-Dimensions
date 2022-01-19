using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeVida : MonoBehaviour
{

    [SerializeField]
    private AudioClip _som;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            var jogador = collision.GetComponent<Jogador>();
            Destroy(gameObject);
            if (_som)
                AudioSource.PlayClipAtPoint(_som, transform.position);
            jogador.GanhaVida(1);
        }
    }
}
