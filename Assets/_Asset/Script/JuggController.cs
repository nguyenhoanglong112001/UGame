using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggController : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    private bool isJumping;
    private bool IsGround = false;
    [SerializeField] private int speed;
    [SerializeField] private int jumpforce;
    [SerializeField] private int runspeed;
    [SerializeField] private int rollspeed;
    [SerializeField] private int HP;
    [SerializeField] private Collider2D rollcollider;
    [SerializeField] private Collider2D standcollider;
    [SerializeField] private GameObject[] hitbox;
    [SerializeField] private Animator dragonanimator;
    [SerializeField] private Transform heropoint;
    [SerializeField] private List<Transform> sumonpoint;
    [SerializeField] private GameObject wardPrefab;
    private int currentHP;
    private bool Alive = true;
    private GameObject objectspawn;

    [SerializeField] private LayerMask enemuLayer;
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private int attackrange;
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
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector2.right * runspeed * Time.deltaTime);
                    animator.SetBool("IsRunning", true);
                    animator.SetBool("IsWalking", false);
                    spriterender.flipX = false;
                }
                else
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsWalking", true);
                    spriterender.flipX = false;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector2.left * runspeed * Time.deltaTime);
                    animator.SetBool("IsRunning", true);
                    animator.SetBool("IsWalking", false);
                    spriterender.flipX = true;
                }
                else
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsWalking", true);
                    spriterender.flipX = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W) && IsGround)
            {
                rigi2d.velocity = Vector2.up * jumpforce;
                animator.SetBool("IsJumping", true);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("Attack");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                animator.SetTrigger("Attack2");
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                animator.SetTrigger("Summon");
                SummonWard();
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetTrigger("Roll");
                rollcollider.enabled = true;
                standcollider.enabled = false;
                if (spriterender.flipX == false)
                {
                    rigi2d.velocity = Vector2.right * rollspeed;
                }
                else if (spriterender.flipX == true)
                {
                    rigi2d.velocity = Vector2.left * rollspeed;
                }
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                animator.SetTrigger("Kick");
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", false);
                rollcollider.enabled = false;
                standcollider.enabled = true;
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

    void Death()
    {
        animator.SetTrigger("Death");
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
            Debug.Log("Jugg loose");
            Death();
            Alive = false;
            dragonanimator.SetTrigger("Win");
            return;
        }
        else
        {
            animator.SetTrigger("Hurt");
            Debug.Log($"Jugg: {currentHP}/{HP}");
        }
    }

    private void DisableHitbox()
    {
        hitbox[0].SetActive(false);
        hitbox[1].SetActive(false);
        hitbox[2].SetActive(false);
        hitbox[3].SetActive(false);        
        hitbox[4].SetActive(false);
        hitbox[5].SetActive(false);
    }

    private void EnableHitbox()
    {
        if (spriterender.flipX == true)
        {
            hitbox[0].SetActive(false);
            hitbox[1].SetActive(true);
        }
        else if (spriterender.flipX == false)
        {
            hitbox[0].SetActive(true);
            hitbox[1].SetActive(false);
        }
    }

    private void EnableHitbox2()
    {
        if (spriterender.flipX == true)
        {
            hitbox[2].SetActive(false);
            hitbox[3].SetActive(true);
        }
        else if (spriterender.flipX == false)
        {
            hitbox[2].SetActive(true);
            hitbox[3].SetActive(false);
        }
    }

    private void EnableKick()
    {
        if (spriterender.flipX == true)
        {
            hitbox[4].SetActive(false);
            hitbox[5].SetActive(true);
        }
        else if (spriterender.flipX == false)
        {
            hitbox[4].SetActive(true);
            hitbox[5].SetActive(false);
        }
    }

    private void SummonWard()
    {
        if (objectspawn == null)
        {
            if (spriterender.flipX)
            {
                objectspawn = Instantiate(wardPrefab, sumonpoint[1].position, Quaternion.identity);
                objectspawn.transform.parent = transform;
            }
            else if (!spriterender.flipX)
            {
                objectspawn = Instantiate(wardPrefab, sumonpoint[0].position, Quaternion.identity);
                objectspawn.transform.parent = transform;
            }
        }    
    }

    public void RestoreHP()
    {
        if (currentHP < HP)
        {
            currentHP += 1;
            Debug.Log($"{currentHP}/{HP}");
        }
    }
}
