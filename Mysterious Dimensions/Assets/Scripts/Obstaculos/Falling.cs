using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D target;

    private BoxCollider2D boxColl;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
        
    }

   void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.tag == "Player")
       {
           Invoke("Fallings", fallingTime);
       }
   }

   void Fallings()
   {        
       target.enabled = false;
       boxColl.isTrigger = true;
   }
   
}
