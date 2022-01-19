using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateMelee : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Inimigo"))
        {
            var inimigo = collision.gameObject.GetComponent<CompInimigo>();
            inimigo.TomaDano(999);
        }
        if (collision.gameObject.tag.Equals("PoderDoBoss"))
        {
            var poderDoBossObj = collision.GetComponent<VidasPoderDoBoss>();
            poderDoBossObj.TomaDano(999);
        }
    }
}
