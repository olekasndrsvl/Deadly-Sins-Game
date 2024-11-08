using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForJoyStick : MonoBehaviour
{
    public Joystick joystick;

    public bool IsPaused = false;
    public float PlayerSpeed;
    public float JumpForce;
    public float HorizontalVectoring;
    bool FacingRight = true;
    private Rigidbody2D Rigidbody;
    public Animator MortAnim;


    bool IsGrounded;
    public Transform feetPos;
    public Transform PlayerBody;
    public float CheckRadius;
    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        MortAnim = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(IsPaused) return;
        float Verticalvetoring = joystick.Vertical;
        HorizontalVectoring = joystick.Horizontal;

        if (IsGrounded && Verticalvetoring > .5f)
        {
            Rigidbody.linearVelocity = Vector2.up * JumpForce;
           // MortAnim.SetBool("IsJumped", !IsGrounded);
        }

        if(HorizontalVectoring != 0)
        {
            MortAnim.SetBool("IsWalking", true);
            if (FacingRight && HorizontalVectoring < 0)
            {
                Flip();
            }

            if (!FacingRight && HorizontalVectoring > 0)
            {
                Flip();
            }

        }
        else
        {
            MortAnim.SetBool("IsWalking", false);
        }

        if (IsGrounded)
        {
            
            Rigidbody.linearVelocity = new Vector2(HorizontalVectoring * PlayerSpeed, Rigidbody.linearVelocity.y);
        }

       
        
       



    }

    void Flip()
    {
        FacingRight = !FacingRight;
        PlayerBody.localScale = new Vector3(PlayerBody.localScale.x * -1, PlayerBody.localScale.y, PlayerBody.localScale.z);
    }

    private void Update()
    {

        MortAnim.SetBool("IsJumped", !IsGrounded);
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);

    }


}
