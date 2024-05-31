using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed = .2f;
    [SerializeField] private PlayerMovement playerMovement;
    private bool movementDirectionLeft = true;

    private void Update()
    {
        if (movementDirectionLeft)
        {
            transform.position -= new Vector3(speed, 0);
        }
        else
        {
            transform.position += new Vector3(speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() == null)
        {
            // not the player
            movementDirectionLeft = !movementDirectionLeft;
        }
    }
}
