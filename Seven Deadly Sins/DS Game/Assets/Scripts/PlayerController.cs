using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsPaused = false;
    public float VerticalSpeed;
    public float HorizontalSpeed;

    public Rigidbody2D Rigidbody;
    public Joystick joystick;
    public Animator MortAnim;
    public Transform PlayerBody;

    public AudioSource moveAudio;

    float HorizontalVectoring;
    float VerticalVectoring;
    bool FacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        PlayerBody.localScale = new Vector3(PlayerBody.localScale.x * -1, PlayerBody.localScale.y, PlayerBody.localScale.z);
    }

    private void FixedUpdate()
    {
        HorizontalVectoring = joystick.Horizontal * HorizontalSpeed;
        VerticalVectoring = joystick.Vertical * VerticalSpeed;
    }
    // Update is called once per frame
    void Update()
    {

       if (IsPaused)
        {

            Rigidbody.linearVelocity = new Vector2(0,0);
        }
        else
        {
            Rigidbody.linearVelocity = new Vector2(HorizontalVectoring, VerticalVectoring);
            if (HorizontalVectoring != 0)
            {
                MortAnim.SetBool("IsWalking", true);
                if (FacingRight && HorizontalVectoring < 0)
                {
                    moveAudio.Play();
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
            if (VerticalVectoring != 0)
            {
                if (!moveAudio.isPlaying)
                {
                    moveAudio.Play();
                }
                MortAnim.SetBool("IsWalking", true);
            }
            else
            {
                if (moveAudio.isPlaying)
                {
                    moveAudio.Stop();
                }
                MortAnim.SetBool("IsWalking", false);
            }

        }



    }
}
