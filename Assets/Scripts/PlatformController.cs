using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private bool movementDirectionLeft = true;

    private void Update()
    {
        transform.position += (movementDirectionLeft ? -1 : 1) * new Vector3(speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() == null)
        {
            // not the player
            movementDirectionLeft = !movementDirectionLeft;
        }
    }

    public float platformSpeedX()
    {
        return speed * (movementDirectionLeft ? -1 : 1);
    }
}
