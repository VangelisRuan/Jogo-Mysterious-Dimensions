using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poderzinho2 : MonoBehaviour
{

    [SerializeField]
    private Transform _posicaoDePoder;
    [SerializeField]
    private GameObject _poderPrefab;

    // Update is called once per frame
    void Update()
    {

    }

    public void Atira()
    {
        Instantiate(_poderPrefab, _posicaoDePoder.position, _posicaoDePoder.rotation);
    }
}