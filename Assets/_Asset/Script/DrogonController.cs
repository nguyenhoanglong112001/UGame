using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrogonController : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    private bool isJumping;
    private bool IsGround = false;
    [SerializeField] private int speed;
    [SerializeField] private int jumpforce;
    private int HP;
    [SerializeField] private int strikespeed;
    [SerializeField] private Collider2D crouchcollider;
    [SerializeField] private Collider2D standcollider;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int bulletspeed;
    [SerializeField] private Transform bulletposition;
    [SerializeField] private Transform attackpoint;
    [SerializeField] private LayerMask herolayer;
    [SerializeField] private GameObject[] dragonhitbox;
    [SerializeField] private Animator heroanimator;
    [SerializeField] private Image[] Heart;
    public bool Alive = true;
    private int currentHP;
    private bool Iscrouch = false;
    // Start is called before the first frame update
    void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
        HP = Heart.Length;
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
                if (!Iscrouch)
                {
                    animator.SetTrigger("Attack");
                    Debug.Log(1);
                }    
                else if (Iscrouch)
                {
                    animator.SetTrigger("CrouchAtk");
                    Launch();
                }
            }
            else if (Input.GetKey(KeyCode.RightControl))
            {
                animator.SetBool("IsCrouching", true);
                crouchcollider.enabled = true;
                standcollider.enabled = false;
                Iscrouch = true;
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
                Iscrouch = false;
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
        if (CompareTag("Dragon"))
        {
            Heart[currentHP - 1].enabled = false;
        }
        currentHP -= 1;
        if (currentHP <= 0)
        {
            Die();
            Alive = false;
            heroanimator.SetBool("Win", true);
            Debug.Log(Alive);
            return;
        }
        else
        {
            animator.SetTrigger("Hurt");
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
    private void EnableHitbox()
    {
        if (spriterender.flipX == true)
        {
            dragonhitbox[0].SetActive(false);
            dragonhitbox[1].SetActive(true);
        }
        else if (spriterender.flipX == false)
        {
            dragonhitbox[0].SetActive(true);
            dragonhitbox[1].SetActive(false);
        }
    }

    private void Enablekickbox()
    {
        if (spriterender.flipX == true)
        {
            dragonhitbox[2].SetActive(false);
            dragonhitbox[3].SetActive(true);
        }
        else if (spriterender.flipX == false)
        {
            dragonhitbox[2].SetActive(true);
            dragonhitbox[3].SetActive(false);
        }
    }

    private void falseHitbox()
    {
        dragonhitbox[0].SetActive(false);
        dragonhitbox[1].SetActive(false);
        dragonhitbox[2].SetActive(false);
        dragonhitbox[3].SetActive(false);
    }
}
