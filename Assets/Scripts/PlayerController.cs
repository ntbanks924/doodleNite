using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = calculateVelocity();

        anim.SetBool("isRunning", Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);

        // updatePlayerDirection();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Calculates the velocity at which the movement should occur
    /// </summary>
    /// <returns>Vector2 of movement velocity</returns>
    private Vector2 calculateVelocity() 
    {
        // Determine the current horizontal and vertical vector
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        return moveInput.normalized * speed;
    }

    /// <summary>
    /// Determines which direction the character should face, currently only handles left (which may be all you need).
    /// </summary>
    // void updatePlayerDirection() 
    // {
    //     switch (Input.GetAxisRaw("Horizontal")) {
    //         case 1: // right
    //             transform.localScale = new Vector3(1,1);
    //             break;
    //         case 0: // neutral - no direction
    //             break;
    //         case -1: // left
    //             transform.localScale = new Vector3(-1, 1);
    //             break;
    //     }
    // }
}