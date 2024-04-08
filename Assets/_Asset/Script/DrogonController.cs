using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrogonController : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
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
    public int currentHP;
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
            if (Input.GetKeyDown(KeyCode.Keypad0))
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
            else
            {
                animator.SetBool("IsCrouching", false);
                Iscrouch = false;
            }
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
}
