using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpadorDeItems : MonoBehaviour
{

    [SerializeField]
    public Jogador _jogador;

    [SerializeField]
    public Inventario _inventario;

    public bool _podeExecutar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_podeExecutar)
        {
            _jogador.LimparItems();
            _inventario.ResetaLista();
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
