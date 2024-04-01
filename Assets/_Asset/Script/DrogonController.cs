using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrogonController : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    private bool isJumping;
    private bool IsGround = false;
    [SerializeField] private int speed;
    [SerializeField] private int jumpforce;
    [SerializeField] private int HP;
    [SerializeField] private int strikespeed;
    [SerializeField] private Collider2D crouchcollider;
    [SerializeField] private Collider2D standcollider;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int bulletspeed;
    [SerializeField] private Transform bulletposition;
    [SerializeField] private Transform attackpoint;
    [SerializeField] private LayerMask herolayer;
    [SerializeField] private Collider2D attackcollider1;
    [SerializeField] private Collider2D attackcollider2;
    private bool Alive = true;
    private int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
        currentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                animator.SetBool("IsWalking", true);
                spriterender.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                animator.SetBool("IsWalking", true);
                spriterender.flipX = false;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && IsGround)
            {
                rigi2d.velocity = Vector2.up * jumpforce;
                animator.SetBool("IsJumping", true);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                animator.SetTrigger("Attack");
            }
            else if (Input.GetKey(KeyCode.RightControl))
            {
                animator.SetBool("IsCrouching", true);
                crouchcollider.enabled = true;
                standcollider.enabled = false;
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    animator.SetTrigger("Attack");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                animator.SetTrigger("Kick");
            }
            else if (Input.GetKeyDown(KeyCode.RightShift))
            {
                animator.SetTrigger("Strike");
            }
            else
            {
                animator.SetBool("IsWalking", false);
                crouchcollider.enabled = false;
                standcollider.enabled = true;
                animator.SetBool("IsCrouching", false);
            }

            if (rigi2d.velocity.y < 0)
            {
                animator.SetBool("IsFalling", true);
                animator.SetBool("IsJumping", false);
            }
        }
    }

    void Strike()
    {
        if (spriterender.flipX == false)
        {
            rigi2d.velocity = Vector2.right * strikespeed;
        }
        else if (spriterender.flipX == true)
        {
            rigi2d.velocity = Vector2.left * strikespeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
            animator.SetBool("IsGround", true);
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGround = false;
        }
    }
    private void Die()
    {
        animator.SetTrigger("Die");
    }    

    public void TakeDame()
    {
        if (!Alive)
        {
            return;
        }
        currentHP -= 1;
        if (currentHP <= 0)
        {
            Die();
            Alive = false;
            return;
        }
        else
        {
            animator.SetTrigger("Hurt");
            Debug.Log($"{currentHP}/{HP}");
        }
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, bulletposition.position, Quaternion.identity);
        Rigidbody2D iblast = projectileObject.GetComponent<Rigidbody2D>();
        if (iblast != null)
        {
            if(spriterender.flipX)
            {
                projectileObject.GetComponent<SpriteRenderer>().flipX = true;
                iblast.velocity = Vector2.left * bulletspeed;
            }
            else if (!spriterender.flipX)
            {
                projectileObject.GetComponent<SpriteRenderer>().flipX = false;
                iblast.velocity = Vector2.right * bulletspeed;
            }
        }
    }
    void EnableAttack()
    {
        if (spriterender.flipX == true)
        {
            attackcollider1.enabled = true;
            attackcollider2.enabled = false;
        }
        else if (spriterender.flipX == false)
        {
            attackcollider2.enabled = true;
            attackcollider1.enabled = false;
        }
    }

    private void DisableCollider()
    {
        attackcollider2.enabled = false;
        attackcollider1.enabled = false;
    }
}

public class Temporary
{
    public int damage;
    public float radius;
}
