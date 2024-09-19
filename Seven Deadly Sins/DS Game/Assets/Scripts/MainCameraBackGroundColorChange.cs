using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraBackGroundColorChange : MonoBehaviour
{
    public Camera camera;
    public bool IsWhite;
    // Start is called before the first frame update
    void Start()
    {
       if(IsWhite){
         camera.backgroundColor = new Color(1,1,1);
       }
       else{
        camera.backgroundColor = new Color(0,0,0);
       }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
