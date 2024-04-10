using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    [SerializeField] private GameObject[] hitbox;
    [SerializeField] private GameObject[] kickbox;
    [SerializeField] private GameObject[] strikebox;
    private SpriteRenderer spriterender;

    private void Start()
    {
        spriterender = GetComponent<SpriteRenderer>();
    }
    public void SAttackbox()
    {

        hitbox[0].SetActive(true);
        hitbox[1].SetActive(false);

    }

    private void attackbox()
    {
        if (!spriterender.flipX)
        {
            hitbox[2].SetActive(true);
            hitbox[3].SetActive(false);
        }
        if (spriterender.flipX)
        {
            hitbox[2].SetActive(false);
            hitbox[3].SetActive(true);
        }
    }

    private void KickBox()
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

    private void Strikebox()
    {
        if (gameObject.CompareTag("Dragon"))
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

    private void FalseKickbox()
    {
        kickbox[0].SetActive(false);
        kickbox[1].SetActive(false);
    }

    private void FalseStrikeBox()
    {
        if (gameObject.CompareTag("Dragon"))
        {
            strikebox[0].SetActive(false);
            strikebox[1].SetActive(false);
        }
    }

    private void FalseAttackBox()
    {
        hitbox[0].SetActive(false);
        hitbox[1].SetActive(false);
        hitbox[2].SetActive(false);
        hitbox[3].SetActive(false);
    }
}
