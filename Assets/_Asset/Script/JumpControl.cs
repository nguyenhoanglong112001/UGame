using UnityEngine;

public class JumpControl : MonoBehaviour
{
    public bool Alive = true;
    [SerializeField] private int jumpforce;
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private KeyCode jumpcontrol;
    private bool IsGround = false;

    public void Jump()
    {
        if (Alive)
        {
            if (Input.GetKeyDown(jumpcontrol) && IsGround)
            {
                rigi2d.velocity = Vector2.up * jumpforce;
                animator.SetBool("IsJumping", true);
            }
            if (rigi2d.velocity.y < 0)
            {
                animator.SetBool("IsFalling", true);
                animator.SetBool("IsJumping", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
            animator.SetBool("IsGround", true);
            animator.SetBool("IsFalling", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGround = false;
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
        Jump();
    }
}
