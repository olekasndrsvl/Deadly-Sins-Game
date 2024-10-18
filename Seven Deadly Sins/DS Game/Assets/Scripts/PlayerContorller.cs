using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{

    public float PlayerSpeed;
    public float JumpForce;
    public float Vectoring;
    bool FacingRight = true;
    private Rigidbody2D Rigidbody;
    public Animator MortAnim;
  
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
        Vector3 scale = transform.localScale;
        scale.x *= -1;
    }


   
}
