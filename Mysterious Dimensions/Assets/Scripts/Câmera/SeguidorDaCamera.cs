using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorDaCamera : MonoBehaviour
{

    public float velocidade = 1.25f;
    private Transform target;

    public bool maximoMinimo;
    public float xMinimo;
    public float yMinimo;
    public float yMaximo;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target)
        {

            transform.position = Vector3.Lerp(transform.position, target.position, velocidade) + new Vector3(0,0, target.position.z);

            if (maximoMinimo)
            {
                transform.position = new Vector3(Mathf.Clamp(target.position.x + 2.5f, xMinimo, target.position.x + 7.5f), Mathf.Clamp(target.position.y, yMinimo, yMaximo), 2 * target.position.z - 10);
            }

        }

    }
}
