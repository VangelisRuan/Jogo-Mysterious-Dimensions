using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public float distanceAttack;
    
    public float speed;
    protected Rigidbody2D rb2d;

    protected bool isMoving = false; 
    protected Transform player;
    protected SpriteRenderer sprite;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
         player = GameObject.FindWithTag("Player").GetComponent<Transform>();
         sprite = GetComponent<SpriteRenderer>();
    }

  protected float PlayerDistance()
  {
      return Vector2.Distance(player.position, transform.position);
  }
  protected void Flip ()
  {
      sprite.flipX = !sprite.flipX;
      speed *= -1;
  }
  protected virtual void Update()
  {
      float distance = PlayerDistance ();

        isMoving = (distance <= distanceAttack);

        if (isMoving)
        {
            if (player.position.x < transform.position.x && !sprite.flipX)
            {

            }
        }
  }
  


 
}