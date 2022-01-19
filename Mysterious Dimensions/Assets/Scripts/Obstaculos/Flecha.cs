using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{

    [SerializeField]
    private Transform _posicaoDeFlecha;
    [SerializeField]
    private GameObject _flechaPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Atira()
    {
        Instantiate(_flechaPrefab, _posicaoDeFlecha.position, _posicaoDeFlecha.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Atira();
        }
        else
        {
            return;
        }
    }
}