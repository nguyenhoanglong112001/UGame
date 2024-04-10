using UnityEngine;

public class StrikeControll : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private Collider2D rollcollider;
    [SerializeField] private Collider2D standcollider;
    [SerializeField] private int rollspeed;
    [SerializeField] private KeyCode strikekey;
    [SerializeField] private string herotag;
    [SerializeField] private Transform[] strikebox;
    [SerializeField] private LayerMask targetlayer;
    [SerializeField] private float attackrange;
    private bool isstrike = false;
    private void CheckStrike()
    {
        if (Input.GetKeyDown(strikekey))
        {
            animator.SetTrigger("Roll");
            rollcollider.enabled = true;
            standcollider.enabled = false;
            isstrike = true;
            if (spriterender.flipX == false)
            {
                rigi2d.velocity = Vector2.right * rollspeed;
            }
            else if (spriterender.flipX == true)
            {
                rigi2d.velocity = Vector2.left * rollspeed;
            }
        }
        else
        {
            isstrike = false;
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
        CheckStrike();
    }

    private void Strike()
    {
        if (spriterender.flipX == false)
        {
            var hit = Physics2D.CircleCast(strikebox[0].position, attackrange, transform.right, 0f, targetlayer);
            if (hit.collider != null)
            {
                HealthManager targetheralth = hit.collider.GetComponent<HealthManager>();
                targetheralth.TakeDame();
            }
        }
        else if (spriterender.flipX == true)
        {
            var hit = Physics2D.CircleCast(strikebox[1].position, attackrange, transform.right * -1, 0f, targetlayer);
            if (hit.collider != null)
            {
                HealthManager targetheralth = hit.collider.GetComponent<HealthManager>();
                targetheralth.TakeDame();
            }
        }
    }
}
