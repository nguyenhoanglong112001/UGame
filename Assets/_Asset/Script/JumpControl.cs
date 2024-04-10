using UnityEngine;

public class JumpControl : MonoBehaviour
{
    public bool Alive = true;
    [SerializeField] private int jumpforce;
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private KeyCode jumpcontrol;
    [SerializeField] private GroundCheck groundcheck;

    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }
    public void Jump()
    {
        if (Alive)
        {
            if (Input.GetKeyDown(jumpcontrol) && groundcheck.IsGround)
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
    private void Update()
    {
        Jump();
    }
}
