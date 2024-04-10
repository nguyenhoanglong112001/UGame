using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugSkill : MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private List<Transform> sumonpoint;
    [SerializeField] private GameObject wardPrefab;
    private GameObject objectspawn;
    // Start is called before the first frame update
    void Start()
    {
        rigi2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("Summon");
            SummonWard();
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
}
