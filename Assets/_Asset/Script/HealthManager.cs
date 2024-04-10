using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]private int HP ;
    public int currentHP;

    public int Health { get => currentHP; private set => currentHP = value; }
    public bool Alive => Health > 0;

    [SerializeField] private Image[] Heart;

    [SerializeField] private Animator heroanimator;

    [SerializeField]private Animator animator;

    private void Awake()
    {
        HP = Heart.Length;
        currentHP = HP;
    }

    public void TakeDame()
    {
        if(!Alive)
        {
            return;
        }
        Heart[currentHP - 1].enabled = false;
        currentHP -= 1;
        if (!Alive)
        {
            animator.SetTrigger("Death");
            heroanimator.SetBool("Win", true);
            return;
        }
        animator.SetTrigger("Hurt");
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
