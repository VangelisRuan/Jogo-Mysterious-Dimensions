using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteragirComObjeto : MonoBehaviour
{

    [SerializeField]
    public Jogador _jogador;

    [SerializeField]
    public Inventario _inventario;

    [SerializeField]
    public bool _deveChecarInventario;

    [SerializeField]
    public string _nomeDoItem;

    [SerializeField]
    public string _nomeDoItem2;

    [SerializeField]
    public string _nomeDoItem3;

    [SerializeField]
    public UnityEvent _portaAberta;

    public bool _podeExecutar;

    // Update is called once per frame
    void Update()
    {
        if (_podeExecutar)
        {
            
            if (_deveChecarInventario)
            {
                if(_jogador.TemItem(_nomeDoItem) && _jogador.TemItem(_nomeDoItem2) && _jogador.TemItem(_nomeDoItem3))
                {
                    _jogador.LimparItems();
                    _inventario.ResetaLista();
                    _portaAberta.Invoke();
                }
            }

            else
            {
                _portaAberta.Invoke();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _podeExecutar = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _podeExecutar = false;
    }
}
