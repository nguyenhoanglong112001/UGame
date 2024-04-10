using UnityEngine;

public class SpecialAttackControl : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private KeyCode specialattack;
    [SerializeField] private float attackrange;
    [SerializeField] private Transform[] attackpoint;
    [SerializeField] private LayerMask targetlayer;
    public void CheckAttack()
    {
        if (Input.GetKeyDown(specialattack))
        {
            animator.SetTrigger("Attack2");
        }
    }

    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckAttack();
    }

    private void SpecialAttack()
    {
        if (spriterender.flipX == false)
        {
            var hit = Physics2D.CircleCast(attackpoint[0].position, attackrange, transform.right, 0f, targetlayer);
            if (hit.collider != null)
            {
                HealthManager targetheralth = hit.collider.GetComponent<HealthManager>();
                targetheralth.TakeDame();
            }
        }
        else if (spriterender.flipX == true)
        {
            var hit = Physics2D.CircleCast(attackpoint[1].position, attackrange, transform.right * -1, 0f, targetlayer);
            if (hit.collider != null)
            {
                HealthManager targetheralth = hit.collider.GetComponent<HealthManager>();
                targetheralth.TakeDame();
            }
        }
    }
}
