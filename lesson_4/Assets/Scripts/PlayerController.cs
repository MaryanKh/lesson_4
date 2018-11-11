using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool attack = false;

    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) {
            animator.SetBool("IsJump", true);
            jump = true;
            controller.jump = true;
        }
        if (!attack) {
            if (Input.GetButtonDown("Fire1")) {
                animator.SetBool("IsAttack", true);
                attack = true;
            }
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void OnLanding() {
        animator.SetBool("IsJump", false);
    }

    public void OnAttackEnd() {
        animator.SetBool("IsAttack", false);
        attack = false;
    }
}
