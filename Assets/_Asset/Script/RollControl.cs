using UnityEngine;

public class RollControl : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private int rollspeed;
    [SerializeField] private KeyCode strikekey;

    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void Roll()
    {
        if (Input.GetKeyDown(strikekey))
        {
            animator.SetTrigger("Roll");
            if (spriterender.flipX == false)
            {
                rigi2d.velocity = Vector2.right * rollspeed;
            }
            else if (spriterender.flipX == true)
            {
                rigi2d.velocity = Vector2.left * rollspeed;
            }
        }
    }

    private void Update()
    {
        Roll();
    }
}