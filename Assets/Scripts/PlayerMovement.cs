using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D characterController;
    [SerializeField] private float runSpeed = 40f;
    private float horizontalMove;
    private bool jump = false;

    private bool isWalking;
    private bool isJumping;

    private float jumpTimer = 0;

    private void Update()
    {
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            Debug.Log(jumpTimer);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        isWalking = horizontalMove != 0;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if (jumpTimer >= 0.133) 
        { 
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        if (isJumping && jumpTimer >= 0.14)
        {
            jump = false;
            isJumping = false;
            jumpTimer = 0;
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public bool IsJumping()
    {
        return isJumping;
    }
}
