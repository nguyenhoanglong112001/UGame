using UnityEngine;

public class KickControl : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private KeyCode kickkey;
    [SerializeField] private GameObject[] kickbox;
    private void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }
    private void EnableKickBox()
    {
        if (spriterender.flipX == true)
        {
            kickbox[0].SetActive(false);
            kickbox[1].SetActive(true);
        }
        else if (spriterender.flipX == false)
        {
            kickbox[0].SetActive(true);
            kickbox[1].SetActive(false);
        }
    }

    private void DiasbleKickbox()
    {
        kickbox[0].SetActive(false);
        kickbox[1].SetActive(false);
    }

    private void Kick()
    {
        if (Input.GetKeyDown(kickkey))
        {
            animator.SetTrigger("Kick");
        }
    }    
    private void Update()
    {
        Kick();
    }
}
