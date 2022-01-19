using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteragirComAMorteDoBoss : MonoBehaviour
{

    [SerializeField]
    public Jogador _jogador;

    [SerializeField]
    public Inventario _inventario;

    [SerializeField]
    public bool _deveChecarInventario;

    [SerializeField]
    public string _nomeDoItem4;

    [SerializeField]
    public UnityEvent _saidaAberta;

    public bool _podeExecutar;

    // Update is called once per frame
    void Update()
    {
        if (_podeExecutar)
        {

            if (_deveChecarInventario)
            {
                if (_jogador.TemItem(_nomeDoItem4))
                {
                    _jogador.LimparItems();
                    _inventario.ResetaLista();
                    _saidaAberta.Invoke();
                }
            }

            else
            {
                _saidaAberta.Invoke();
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
