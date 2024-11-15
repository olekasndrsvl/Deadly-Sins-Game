using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
   
    public float PlayerSpeed;
    public float JumpForce;
    public float Vectoring;
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

    public void OnLeftButtonDown()
    {
        Vectoring = -1;
        MortAnim.SetBool("IsWalking", true);
        if (FacingRight && Vectoring < 0)
        {
            Flip();
        }
    }
    public void OnRightButtonDown() 
    {
        Vectoring = 1;
        MortAnim.SetBool("IsWalking", true);
        if (!FacingRight && Vectoring > 0)
        {
            Flip();
        }
    }
    public void OnUpButtonDown()
    {
        if (IsGrounded)
        {
            MortAnim.SetBool("IsJumped", true);
            Rigidbody.linearVelocity = Vector2.up * JumpForce;
        }
    }


    public void OnControllerButtonUp()
    {
        MortAnim.SetBool("IsWalking", false);
        Vectoring = 0;
    }

    private void FixedUpdate()
    {
        
        //Vectoring = Input.GetAxis("Horizontal");
        Rigidbody.linearVelocity = new Vector2(Vectoring * PlayerSpeed, Rigidbody.linearVelocity.y);
        if(IsGrounded)
        {
            MortAnim.SetBool("IsJumped", false);
        }
        
      
   
    }

    void Flip()
    {
        FacingRight= !FacingRight;
        PlayerBody.localScale = new Vector3(PlayerBody.localScale.x * -1, PlayerBody.localScale.y, PlayerBody.localScale.z);
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);
        
    }


}
