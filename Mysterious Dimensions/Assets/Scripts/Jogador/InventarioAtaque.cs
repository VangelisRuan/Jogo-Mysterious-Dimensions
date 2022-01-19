using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioAtaque : MonoBehaviour
{

    [SerializeField]
    private ControleDoJogador _controleDoJogador;

    [SerializeField]
    private bool _deveChecarInventario;

    [SerializeField]
    private GameObject _inventarioSemItem;

    [SerializeField]
    private GameObject _item;

    [SerializeField]
    private GameObject _item2;

    private List<GameObject> _items = new List<GameObject>();

    void Start()
    {

        for(int indice = 0; indice < 1 ; indice++){

             var posXCalculada = transform.position.x + (indice * 50);
             var go = Instantiate(_inventarioSemItem, new Vector3(posXCalculada, transform.position.y, 0), Quaternion.identity, this.transform);
        }
    }

    public void AtualizaInventarioAtaque(string nome_do_item)
    {

        GameObject itemParaAdicionar = _item;
        int indice = 0;

        if (nome_do_item == "LuvaDeFogo")
        {
            itemParaAdicionar = _item;
            ResetaLista();
            _controleDoJogador.LimparItemsAtaque();
        }

        if (nome_do_item == "LuvaDeChoque")
        {
            itemParaAdicionar = _item2;
            ResetaLista();
            _controleDoJogador.LimparItemsAtaque();
        }

        var posXCalculada = transform.position.x + (indice * 1.75f);

        var go = Instantiate(itemParaAdicionar, new Vector3(posXCalculada, transform.position.y, 0), Quaternion.identity, this.transform);
        _items.Add(go);
    }

    public void ResetaLista()
    {
        foreach (var _item in _items)
        {
            Destroy(_item);
        }
    }

}
