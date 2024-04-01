using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iblast : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi2d;
    [SerializeField] private int speed;
    // Start is called before the first frame update
    private void Awake()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z >0)
        {
            rigi2d.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
        }
        else
        {
            rigi2d.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hero"))
        {
            collision.GetComponent<JuggController>().TakeDame();
            Destroy(gameObject);
        }    
    }
}
