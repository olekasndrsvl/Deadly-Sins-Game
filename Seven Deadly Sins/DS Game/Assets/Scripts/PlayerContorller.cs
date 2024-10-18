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
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnLeftButtonDown()
    {
        Vectoring = -1;
        if (FacingRight && Vectoring < 0)
        {
            Flip();
        }
    }
    public void OnRightButtonDown() 
    {
        Vectoring = 1;
        if (!FacingRight && Vectoring > 0)
        {
            Flip();
        }
    }
    public void OnUpButtonDown()
    {
        if (IsGrounded)
        {
            Rigidbody.velocity = Vector2.up * JumpForce;
        }
    }


    public void OnControllerButtonUp()
    {
        Vectoring = 0;
    }

    private void FixedUpdate()
    {
        //Vectoring = Input.GetAxis("Horizontal");
        Rigidbody.velocity = new Vector2(Vectoring * PlayerSpeed, Rigidbody.velocity.y);
        
        
      
   
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
