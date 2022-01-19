using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeNivel : MonoBehaviour
{

    public GameObject aParteDoNivel;
    public Transform pontoDeGeracao;
    public float aDistanciaEntre;

    private float larguraDaParte;

    public float aDistanciaMinimaEntreParte;
    public float aDistanciaMaximaEntreParte;

    public GameObject[] asPartesDoNivel;
    private int selecionadorDeParte;

    public GameObject portalUm;
    public GameObject portalDois;
    public GameObject bordaDoPortao;
    public GameObject anubis;
    public GameObject portaoDeSaida;
    public GameObject saida;

    // Start is called before the first frame update
    void Start()
    {

        larguraDaParte = aParteDoNivel.GetComponent<BoxCollider2D>().size.x;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < pontoDeGeracao.position.x)
        {

            aDistanciaEntre = Random.Range(aDistanciaMinimaEntreParte, aDistanciaMaximaEntreParte);

            transform.position = new Vector3(transform.position.x + larguraDaParte + aDistanciaEntre, transform.position.y, transform.position.z);

            selecionadorDeParte = Random.Range(0, asPartesDoNivel.Length);
            


            GameObject clone_de_nivel = Instantiate (asPartesDoNivel[selecionadorDeParte], transform.position, transform.rotation);

            if (asPartesDoNivel[selecionadorDeParte].name == "Nivel1_Dimensao1_parte16")
            {
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl>()._itemsPegos = portalUm.GetComponent<TrocarLvl>()._itemsPegos;
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl>().moedaPp = portalUm.GetComponent<TrocarLvl>().moedaPp;
                clone_de_nivel.transform.GetChild(10).GetComponent<InteragirComObjeto>()._jogador = bordaDoPortao.GetComponent<InteragirComObjeto>()._jogador;
                clone_de_nivel.transform.GetChild(10).GetComponent<InteragirComObjeto>()._inventario = bordaDoPortao.GetComponent<InteragirComObjeto>()._inventario;
                clone_de_nivel.transform.GetChild(11).GetComponent<Boss>().moedaPp = anubis.GetComponent<Boss>().moedaPp;
            }

            if (asPartesDoNivel[selecionadorDeParte].name == "Nivel1_Dimensao1_parte17")
            {
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl2>()._itemsPegos = portalDois.GetComponent<TrocarLvl2>()._itemsPegos;
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl2>().moedaPp = portalDois.GetComponent<TrocarLvl2>().moedaPp;
                clone_de_nivel.transform.GetChild(10).GetComponent<InteragirComObjeto>()._jogador = bordaDoPortao.GetComponent<InteragirComObjeto>()._jogador;
                clone_de_nivel.transform.GetChild(10).GetComponent<InteragirComObjeto>()._inventario = bordaDoPortao.GetComponent<InteragirComObjeto>()._inventario;
                clone_de_nivel.transform.GetChild(11).GetComponent<Boss>().moedaPp = anubis.GetComponent<Boss>().moedaPp;
            }

            if (asPartesDoNivel[selecionadorDeParte].name == "Nivel1_Dimensao2_parte16")
            {
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl2>()._itemsPegos = portalUm.GetComponent<TrocarLvl2>()._itemsPegos;
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl2>().moedaPp = portalUm.GetComponent<TrocarLvl2>().moedaPp;
            }

            if (asPartesDoNivel[selecionadorDeParte].name == "Nivel1_Dimensao2_parte17")
            {
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl3>()._itemsPegos = portalDois.GetComponent<TrocarLvl3>()._itemsPegos;
                clone_de_nivel.transform.GetChild(9).GetComponent<TrocarLvl3>().moedaPp = portalDois.GetComponent<TrocarLvl3>().moedaPp;
            }

            if (asPartesDoNivel[selecionadorDeParte].name == "Nivel1_Dimensao3_parte16")
            {
                clone_de_nivel.transform.GetChild(10).GetComponent<TrocarLvl>()._itemsPegos = portalUm.GetComponent<TrocarLvl>()._itemsPegos;
                clone_de_nivel.transform.GetChild(10).GetComponent<TrocarLvl>().moedaPp = portalUm.GetComponent<TrocarLvl>().moedaPp;
            }

            if (asPartesDoNivel[selecionadorDeParte].name == "Nivel1_Dimensao3_parte17")
            {
                clone_de_nivel.transform.GetChild(10).GetComponent<TrocarLvl3>()._itemsPegos = portalDois.GetComponent<TrocarLvl3>()._itemsPegos;
                clone_de_nivel.transform.GetChild(10).GetComponent<TrocarLvl3>().moedaPp = portalDois.GetComponent<TrocarLvl3>().moedaPp;
            }

            if (asPartesDoNivel[selecionadorDeParte].name == "Nivel1BossSaida")
            {
                clone_de_nivel.transform.GetChild(5).GetComponent<InteragirComAMorteDoBoss>()._jogador = portaoDeSaida.GetComponent<InteragirComAMorteDoBoss>()._jogador;
                clone_de_nivel.transform.GetChild(5).GetComponent<InteragirComAMorteDoBoss>()._inventario = portaoDeSaida.GetComponent<InteragirComAMorteDoBoss>()._inventario;
                clone_de_nivel.transform.GetChild(6).GetComponent<ProximoLvl>().moedaPp = saida.GetComponent<ProximoLvl>().moedaPp;
            }

        }

    }

}
