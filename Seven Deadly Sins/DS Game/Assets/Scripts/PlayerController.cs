using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float VerticalSpeed;
    public float HorizontalSpeed;

    public Rigidbody2D Rigidbody;
    public Joystick joystick;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Rigidbody.velocity = new Vector2(joystick.Horizontal*HorizontalSpeed,joystick.Vertical*VerticalSpeed);
      
    }
}
