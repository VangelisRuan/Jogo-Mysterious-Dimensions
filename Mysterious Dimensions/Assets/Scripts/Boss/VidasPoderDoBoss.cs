using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasPoderDoBoss : MonoBehaviour
{

    [SerializeField]
    private int _vida = 3;
    [SerializeField]
    private GameObject _efeitoImpacto;

    [SerializeField]
    private AudioClip _som;

    public void TomaDano(int dano)
    {
        _vida -= dano;

        if (_vida <= 0)
        {
            Morre();
        }
    }

    private void Morre()
    {
        Instantiate(_efeitoImpacto, transform.position, transform.rotation);
        if (_som)
            AudioSource.PlayClipAtPoint(_som, transform.position);
        Destroy(gameObject);
    }

}
