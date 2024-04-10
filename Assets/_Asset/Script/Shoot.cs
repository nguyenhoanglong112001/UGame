using UnityEngine;

public class Shoot :MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int bulletspeed;
    [SerializeField] private Transform bulletposition;
    [SerializeField] private KeyCode shootkey;
    [SerializeField] private string shootparameter;
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;

    void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckShootInput();
    }

    void CheckShootInput()
    {
        if(Input.GetKeyDown(shootkey))
        {
            animator.SetTrigger(shootparameter);
        }
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, bulletposition.position, Quaternion.identity);
        Rigidbody2D iblast = projectileObject.GetComponent<Rigidbody2D>();
        if (iblast != null)
        {
            if (spriterender.flipX)
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
