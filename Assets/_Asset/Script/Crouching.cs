using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crouching:MonoBehaviour
{
    private Rigidbody2D rigi2d;
    private Animator animator;
    private SpriteRenderer spriterender;
    [SerializeField] private Collider2D crouchcollider;
    [SerializeField] private Collider2D standcollider;
    private bool Iscrouch = false;

    private void Crouch()
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
            crouchcollider.enabled = false;
            standcollider.enabled = true;
        }
    }
}
