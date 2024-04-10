using UnityEngine;

public class Ditection : MonoBehaviour
{
    [SerializeField] private string charactertag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(charactertag))
        {
            collision.GetComponent<HealthManager>().TakeDame();
        }
    }
}


