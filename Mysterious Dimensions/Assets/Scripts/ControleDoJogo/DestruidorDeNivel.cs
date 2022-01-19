using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruidorDeNivel : MonoBehaviour
{

    public GameObject pontoDeDestruicaoDeNivel;

    // Start is called before the first frame update
    void Start()
    {

        pontoDeDestruicaoDeNivel = GameObject.Find("PontoDeDestruicaoDeNivel");

    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < pontoDeDestruicaoDeNivel.transform.position.x)
        {

            gameObject.SetActive(false);

        }

    }
}
