using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardController : MonoBehaviour
{
    private Rigidbody2D rig2d;
    [SerializeField] private Transform target;
    private Animator anima;
    [SerializeField] private int speed;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Rigidbody2D targetrigi2d;
    [SerializeField] private SpriteRenderer objsprite;
    private Vector3 lastposition;
    public HealthManager targetscript;
    private float dis;
    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        objsprite = GetComponent<SpriteRenderer>();
        lastposition = transform.position;
        targetscript = FindObjectOfType<HealthManager>();
        InvokeRepeating("CallMethod", 2.0f, 2.0f);
        StartCoroutine(RoutineMethod());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentposition = transform.position;
        if (lastposition != currentposition)
        {
            if((Input.GetKey(KeyCode.D)))
            {
                objsprite.flipX = false;
                anima.SetBool("Follow", true);
                lastposition = currentposition;
            }
            else if ((Input.GetKey(KeyCode.A)))
            {
                objsprite.flipX = true;
                anima.SetBool("Follow", true);
                lastposition = currentposition;
            }
        } 
        else
        {
            anima.SetBool("Follow", false);
        }
    }

    private void CallMethod()
    {
        if (targetscript != null)
        {
            targetscript.RestoreHP();
        }
    }
    IEnumerator RoutineMethod()
    {
        yield return new WaitForSeconds(8f);

        anima.SetTrigger("TimeUp");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    IEnumerator DiasbleWard()
    {
        anima.SetTrigger("TimeUp");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    public void StartDestroy()
    {
        StartCoroutine(DiasbleWard());
    }
}
