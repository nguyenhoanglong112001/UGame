using UnityEngine;

public class AttackControl : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private GameObject[] hitbox;
    [SerializeField] private KeyCode attackkey;
    [SerializeField] private KeyCode specialattack;
    public void Attack()
    {
        if (Input.GetKeyDown(attackkey))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(specialattack))
        {
            animator.SetTrigger("Attack2");
        }
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

    private void DiasbleHitbox()
    {
        hitbox[0].SetActive(false);
        hitbox[1].SetActive(false);
        hitbox[2].SetActive(false);
        hitbox[3].SetActive(false);
    }

    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Attack();
    }
}
