using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConroller : MonoBehaviour
{ 
    Rigidbody2D rb; 
    Animator animator;
    bool isGround;
    public float velocity; 
    public float jumpHeight; 
    public Transform groundCheck; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();   
    }
    
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetAxis("Horizontal") == 0 && isGround) 
        {
            animator.SetInteger("State", 1);
        }
        Flip(); 
        if (Input.GetKeyDown(KeyCode.Space) && isGround) 
        {
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        } 
        GroundCheck();
    } 

    void Flip() 
        
    
    {
       if (Input.GetAxis("Horizontal") > 0) 
       {
           transform.localRotation = Quaternion.Euler(0, 0, 0); 
       }
        else if (Input.GetAxis("Horizontal") < 0)
        {
           transform.localRotation = Quaternion.Euler(0, 180, 0); 
        }
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocity, rb.velocity.y);
    } 

    void GroundCheck() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        isGround = colliders.Length > 1;
    } 

}

