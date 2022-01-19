using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{

    public float JumpForce;

    private Animator anim;

    [SerializeField]
    private AudioClip _som;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Estica");
            if (_som)
                AudioSource.PlayClipAtPoint(_som, transform.position);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

        }
    }
}
