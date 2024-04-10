using UnityEngine;

public class KickControl : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private KeyCode kickkey;
    [SerializeField] private Transform[] kickbox;
    [SerializeField] private LayerMask targetlayer;
    [SerializeField] private float attackrange;
    private bool iskicking;
    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }


    private void CkeckKickInput()
    {
        if (Input.GetKeyDown(kickkey))
        {
            iskicking = true;
            animator.SetTrigger("Kick");
        }
        else
        {
            iskicking = false;
        }
    }    
    private void Update()
    {
        CkeckKickInput();
    }

    private void Kick()
    {
        if (spriterender.flipX == false)
        {
            var hit = Physics2D.CircleCast(kickbox[0].position, attackrange, transform.right, 0f, targetlayer);
            if (hit.collider != null)
            {
                HealthManager targetheralth = hit.collider.GetComponent<HealthManager>();
                targetheralth.TakeDame();
            }
        }
        else if (spriterender.flipX == true)
        {
            var hit = Physics2D.CircleCast(kickbox[1].position, attackrange, transform.right * -1, 0f, targetlayer);
            if (hit.collider != null)
            {
                HealthManager targetheralth = hit.collider.GetComponent<HealthManager>();
                targetheralth.TakeDame();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Color color = Color.red;
        Gizmos.DrawWireSphere(kickbox[1].position, attackrange);
        Gizmos.DrawWireSphere(kickbox[0].position, attackrange);
    }
}
