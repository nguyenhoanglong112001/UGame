using UnityEngine;

public class StrikeControll : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private Collider2D rollcollider;
    [SerializeField] private Collider2D standcollider;
    [SerializeField] private int rollspeed;
    [SerializeField] private KeyCode strikekey;
    [SerializeField] private GameObject[] strikebox;
    private void Strike()
    {
        if (Input.GetKeyDown(strikekey))
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
    }

    private void EnableStrikebox()
    {
        if(gameObject.CompareTag("Dragon"))
        {
            if (spriterender.flipX == true)
            {
                strikebox[0].SetActive(false);
                strikebox[1].SetActive(true);
            }
            else if (spriterender.flipX == false)
            {
                strikebox[0].SetActive(true);
                strikebox[1].SetActive(false);
            }
        }
    }

    private void DisableStrikeBox()
    {
        if(gameObject.CompareTag("Dragon"))
        {
            strikebox[0].SetActive(false);
            strikebox[1].SetActive(false);
        }
    }

    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Strike();
    }
}
