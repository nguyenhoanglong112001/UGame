using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuggController : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private int speed;
    [SerializeField] private int jumpforce;
    [SerializeField] private int runspeed;
    [SerializeField] private int rollspeed;
    private int HP;
    [SerializeField] private Collider2D rollcollider;
    [SerializeField] private Collider2D standcollider;
    [SerializeField] private Animator dragonanimator;
    [SerializeField] private Transform heropoint;
    [SerializeField] private List<Transform> sumonpoint;
    [SerializeField] private GameObject wardPrefab;
    [SerializeField] private Image[] Heart; 
    public int currentHP;
    public bool Alive = true;
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
        HP = Heart.Length;
        currentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                animator.SetTrigger("Summon");
                SummonWard();
            }
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
        if (CompareTag("Hero"))
        {
            Heart[currentHP - 1].enabled = false;
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
            Heart[currentHP - 1].enabled = true;
        }
    }
}
