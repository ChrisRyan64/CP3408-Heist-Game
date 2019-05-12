using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    Vector2 movement;
    Animator anim;
    bool playerDetected;
    // Spawn point
    float startPosition;
    // Point they travel to
    float endPosition;
    // Movement speed
    float moveHorizontal;
    // true = moving left, false = moving right
    bool patrolReturning;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        // Testing
        playerDetected = false;
        // Get starting x position
        startPosition = transform.position.x;
        // Set how far will be travelled
        endPosition = startPosition - 15;
        // Set speed of movement
        moveHorizontal = 0.75f;
        // Starts going left
        patrolReturning = false;
        // Currently always walking
        Walking();
    }

    private void FixedUpdate()
    {
        if (!playerDetected)
        {
            // If Enemy has reached end position, flag to reverse direction
            if (transform.position.x <= endPosition)
            {
                patrolReturning = true;
            }
            // If Enemy has passed starting position, flag to reverse direction
            if (transform.position.x > startPosition)
            {
                patrolReturning = false;
            }
            // Move left if heading left
            if (!patrolReturning)
            {
                transform.Translate(-moveHorizontal * 15f * Time.deltaTime, 0f, 0f);
            }
            else
            // Move right if heading right
            {
                transform.Translate(moveHorizontal * 15f * Time.deltaTime, 0f, 0f);
            }

            Vector3 characterScale = transform.localScale;
            // Used instead of input as patrolReturning indicates direction
            if (!patrolReturning)
            {
                characterScale.x = -1;
            }
            if (patrolReturning)
            {
                characterScale.x = 1;
            }
            transform.localScale = characterScale;
        }
        if (playerDetected)
        {
            // Insert Hunter Killer mode
        }
    }

    void Walking()
    {
        anim.SetBool("IsWalking", true);
    }
}
