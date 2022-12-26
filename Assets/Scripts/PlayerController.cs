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
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        inputHorizontal = Input.GetAxisRaw("Horizontal");
    
        if (moveInput.x == 0 && moveInput.y == 0) {
            anim.SetBool("isRunning",false);
        }
        else {  
            anim.SetBool("isRunning",true);
        }

        //movement to the right will cause 
        if (inputHorizontal > 0) {
            transform.localScale = new Vector3 (1,1);                    
        }
        else {
            transform.localScale = new Vector3 (-1,-1);
        }

    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
}
