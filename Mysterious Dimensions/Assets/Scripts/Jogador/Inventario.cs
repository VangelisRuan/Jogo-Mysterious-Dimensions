using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    [SerializeField]
    private Jogador _jogador;

    [SerializeField]
    private bool _deveChecarInventario;

    [SerializeField]
    private string _nomeDoItem;

    [SerializeField]
    private string _nomeDoItem2;

    [SerializeField]
    private string _nomeDoItem3;

    [SerializeField]
    private string _nomeDoItem4;

    [SerializeField]
    private GameObject _item;

    [SerializeField]
    private GameObject _item2;

    [SerializeField]
    private GameObject _item3;

    [SerializeField]
    private GameObject _item4;

    private List<GameObject> _items = new List<GameObject>();

    public void AtualizaInventario(string nome_do_item)
    {
        GameObject itemParaAdicionar = _item;

        int indice = 0;
        if(nome_do_item == "ChaveDimensao1")
        {
            itemParaAdicionar = _item;
        }
        if (nome_do_item == "ChaveDimensao2")
        {
            indice = 1;
            itemParaAdicionar = _item2;
        }
        if (nome_do_item == "ChaveDimensao3")
        {
            indice = 2;
            itemParaAdicionar = _item3;
        }
        if (nome_do_item == "AcessoASaida")
        {
            indice = 3;
            itemParaAdicionar = _item4;
        }

        var posXCalculada = transform.position.x + (indice * 1.45f);

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
