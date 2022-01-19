using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsoInimigo : MonoBehaviour
{

    public float JumpForce;

    private float _tempoDaMorte = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Morre()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.y < collision.gameObject.transform.position.y && collision.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            _tempoDaMorte += Time.deltaTime;

            if (_tempoDaMorte >= 0.0001)
            {
                Morre();
            }
        }
    }
}
