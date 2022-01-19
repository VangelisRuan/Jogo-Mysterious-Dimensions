using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompBoss : MonoBehaviour
{

    private Transform suporteParaInimigo;
    public float velocidade;

    public GameObject tiro;

    public float taxaDeTiro = 0.99f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Movimentar", 0.1f, 0.3f);
        suporteParaInimigo = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Movimentar()
    {
        suporteParaInimigo.position += Vector3.right * velocidade;

        foreach (Transform enemy in suporteParaInimigo)
        {

            if (Random.value > taxaDeTiro)
            {
                anim.SetTrigger("AtaqueBossTrigger");
                Instantiate(tiro, enemy.position, enemy.rotation);
            }

        }

        if (suporteParaInimigo.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("Movimentar", 0.1f, 0.25f);
        }

    }


}
