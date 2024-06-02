using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Transform liftLowerLimit;
    [SerializeField] private Transform liftUpperLimit;
    private bool movementDirectionUp = true;
    private bool moving = false;
    private bool playerOnLift = false;
    

    private void Update()
    {
        Debug.Log("upper: ");
        Debug.Log(liftUpperLimit.position.y);
        Debug.Log("lift: ");
        Debug.Log(transform.position.y);

        if (moving)
        {
            transform.position += (movementDirectionUp ? 1 : -1) * new Vector3(0, speed * Time.deltaTime);
        }

        if (transform.position.y >= liftUpperLimit.position.y)
        {
            Debug.Log("above limit");
            if (playerOnLift)
            {
                moving = false;
                Debug.Log("above limit player on lift");
            }
            else
            {
                movementDirectionUp = false;
                moving = true;
            }
        }

        if (transform.position.y <= liftLowerLimit.position.y)
        {
            Debug.Log("below limit");
            movementDirectionUp = true;
            if (playerOnLift)
            {
                moving = true;
            }
            else
            {
                moving = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("player Collision");
            //the player
            playerOnLift = true;
            movementDirectionUp = true;
            moving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("player gone");
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //the player
            playerOnLift = false;
            movementDirectionUp = false;
        }
    }

    public float LiftSpeedY()
    {
        return speed * (movementDirectionUp ? -1 : 1);
    }

    public bool PlayerOnLift()
    {
        return playerOnLift;
    }
}
