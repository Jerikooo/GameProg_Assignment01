using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 playerVelocity;
    Vector3 move;

    public float walkSpeed = 5;
    public float runSpeed = 8; 
    public float jumpHeight = 1;
    public float gravity = -9.18f;

    private CharacterController controller;
    private bool hasDoubleJumped = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessGravity();
    }

    public void LateUpdate()
    {
       UpdateAnimator();
    }

    void UpdateAnimator()
    {
        bool isGrounded = controller.isGrounded;
        
        if(move != Vector3.zero)
        {
            if(GetMovementSpeed() == runSpeed) 
            {
                animator.SetFloat("Speed", 1.0f);
            }
            else
            {
                animator.SetFloat("Speed", 0.5f);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        animator.SetBool("IsGrounded", isGrounded);

        
        
    }

    void ProcessMovement()
    { 
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX, 0));
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    public void ProcessGravity()
    {
        bool isGrounded = controller.isGrounded;
        animator.SetBool("IsDoubleJumping", false);
        
        if (isGrounded )
        {
            hasDoubleJumped = false;
            if (playerVelocity.y < 0.0f) // we want to make sure the players stays grounded when on the ground
            {
                playerVelocity.y = -1.0f;
            }
            
            if (Input.GetButtonDown("Jump")) // Code to jump
            {
                playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }

        if (animator.GetBool("CanDoubleJump") == true && !isGrounded && !hasDoubleJumped) {
            if (Input.GetButtonDown("Jump")) // Code to jump
            {
                hasDoubleJumped = true;
                playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                animator.SetBool("IsDoubleJumping", true);
            }
            else {
                playerVelocity.y += gravity * Time.deltaTime;
            }
        }
        
        
        else // if not grounded
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }       

        controller.Move(move * Time.deltaTime * GetMovementSpeed() + playerVelocity * Time.deltaTime);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
