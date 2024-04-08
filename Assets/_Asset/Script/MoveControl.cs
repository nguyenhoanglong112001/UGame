using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public bool Alive = true;
    [SerializeField] private int speed;
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private KeyCode leftcontrol;
    [SerializeField] private KeyCode rightcontrol;
    public void Move()
    {
        if (Alive)
        {
            if (Input.GetKey(rightcontrol))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                animator.SetBool("IsWalking", true);
                spriterender.flipX = false;
            }
            else if (Input.GetKey(leftcontrol))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                animator.SetBool("IsWalking", true);
                spriterender.flipX = true;
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
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
        Move();
    }
}
