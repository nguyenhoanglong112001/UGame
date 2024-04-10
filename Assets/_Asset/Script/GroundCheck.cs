using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Animator animator;
    public bool IsGround = false;
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
        animator = GetComponent<Animator>();
    }
}
