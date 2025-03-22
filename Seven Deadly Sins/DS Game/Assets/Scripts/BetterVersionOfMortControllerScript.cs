using UnityEngine;


public class BetterVersionOfMortControllerScript : MonoBehaviour
{
     public Joystick joystick;
     public GameObject HP;
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

    public AudioSource jumpAudio, moveAudio;

    // Start is called before the first frame update
    void Start()
    {
        MortAnim = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(IsPaused) return;
        int i = Random.Range(0, 2);
        float Verticalvetoring = joystick.Vertical*i;
        i = Random.Range(0, 2);
        HorizontalVectoring = -joystick.Horizontal*i;

        if (IsGrounded && Verticalvetoring > .5f)
        {
            Rigidbody.linearVelocity = Vector2.up * JumpForce;
            // MortAnim.SetBool("IsJumped", !IsGrounded);

            if (!jumpAudio.isPlaying)
            {
                jumpAudio.Play();
            }
        }

        if(HorizontalVectoring != 0)
        {
            MortAnim.SetBool("IsWalking", true);

            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }

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

            if (moveAudio.isPlaying)
            {
                moveAudio.Stop();
            }

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
        HP.GetComponent<Transform>().localScale = new Vector3(HP.GetComponent<Transform>().localScale.x*-1, HP.GetComponent<Transform>().localScale.y, HP.GetComponent<Transform>().localScale.z);
    }

    private void Update()
    {

        MortAnim.SetBool("IsJumped", !IsGrounded);
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, CheckRadius, whatIsGround);

    }

}
