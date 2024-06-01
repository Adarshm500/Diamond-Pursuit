using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string IS_JUMPING = "IsJumping";

    private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CharacterController2D characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController.OnJump += characterControllerOnJump;
        characterController.OnGroundLanding += characterControllerOnGroundLanding;
        characterController.OnPlatformLanding += characterControllerOnPlatformLanding;
    }

    private void characterControllerOnJump(object sender, EventArgs e)
    {
        animator.SetBool(IS_JUMPING, true);
    }

    private void characterControllerOnGroundLanding(object sender, EventArgs e)
    {
        animator.SetBool(IS_JUMPING, false);
    }

    private void characterControllerOnPlatformLanding(object sender, EventArgs e)
    {
        animator.SetBool(IS_JUMPING, false);
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
    }
}
