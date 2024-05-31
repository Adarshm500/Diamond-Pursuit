using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string IS_JUMPING = "IsJumping";

    private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
        animator.SetBool(IS_JUMPING, playerMovement.IsJumping());
    }
}
