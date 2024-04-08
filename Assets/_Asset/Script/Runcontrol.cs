using UnityEngine;

public class Runcontrol : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    public bool Alive = true;
    [SerializeField] private int runspeed;
    [SerializeField] private KeyCode leftcontrol;
    [SerializeField] private KeyCode rightcontrol;
    [SerializeField] private KeyCode runcontrol;

    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void RunControl()
    {
        if (Alive)
        {
            if (Input.GetKey(rightcontrol))
            {
                if (Input.GetKey(runcontrol))
                {
                    transform.Translate(Vector2.right * runspeed * Time.deltaTime);
                    animator.SetBool("IsRunning", true);
                    spriterender.flipX = false;
                }
                else
                {
                    animator.SetBool("IsRunning", false);
                }
            }
            else if (Input.GetKey(leftcontrol))
            {
                if (Input.GetKey(runcontrol))
                {
                    transform.Translate(Vector2.left * runspeed * Time.deltaTime);
                    animator.SetBool("IsRunning", true);
                    spriterender.flipX = true;
                }
                else
                {
                    animator.SetBool("IsRunning", false);
                }
            }
        }
    }

    private void Update()
    {
        RunControl();
    }
}
