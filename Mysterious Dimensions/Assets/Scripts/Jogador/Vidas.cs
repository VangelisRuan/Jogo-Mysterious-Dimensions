using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{

    [SerializeField]
    private Sprite _vidaCheia;

    [SerializeField]
    private Sprite _vidaVazia;

    [SerializeField]
    private GameObject _vida;

    private List<GameObject> _coracoes = new List<GameObject>();

    public void AtualizaVidas(int vidaRestante, int totalDeVidas)
    {
        ResetaLista();
        for (int i = 0; i < totalDeVidas; i++)
        {
            if(vidaRestante <= i)
            {
                _vida.GetComponent<Image>().sprite = _vidaVazia;
            }
            else
            {
                _vida.GetComponent<Image>().sprite = _vidaCheia;
            }

            var posXCalculada = transform.position.x + (i * 1.55f);
            var go = Instantiate(_vida, new Vector3(posXCalculada, transform.position.y, 0), Quaternion.identity, this.transform);
            _coracoes.Add(go);
        }
    }

    private void ResetaLista()
    {
        foreach (var coracao in _coracoes)
        {
            Destroy(coracao);
        }
    }

}
