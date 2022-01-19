using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public int pontuação;
    

    public static Moeda pts;

    [SerializeField]
    private AudioClip _som;

    void Start()
    {
        pts = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameControler.instance.pontuaçaoGeral += pontuação;
            GameControler.instance.UpdateScoreText();
            if (_som)
                AudioSource.PlayClipAtPoint(_som, transform.position);
            Destroy(gameObject);
        }

    }
}


