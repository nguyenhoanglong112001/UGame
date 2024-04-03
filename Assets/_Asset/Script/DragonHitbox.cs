using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            collision.GetComponent<JuggController>().TakeDame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.GetComponent<JuggController>().TakeDame();
        }
        else if (collision.gameObject.CompareTag("Ward"))
        {
            collision.gameObject.GetComponent<WardController>().StartDestroy();
        }
    }
}
