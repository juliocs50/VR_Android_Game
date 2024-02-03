using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class controleMax : MonoBehaviour
{

    public GameObject MaxPos;
    public GameObject CameraOlho;
    public float offcet;
   public float waittime;
    Vector3 rotatio;
  public  bool pode;

   


    private void Start()
    {
     
    }
    public void FixedUpdate()
    {
        if (((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))) && (((Mathf.Abs(Input.GetAxis("Vertical")) == 0))))
        {
            pode = false;
                     
            waittime = 1.5f;
        }
    }
    // Update is called once per frame
    void Update()
    {





        if (pode)
        {



            transform.position = new Vector3(MaxPos.transform.position.x, offcet + MaxPos.transform.position.y, MaxPos.transform.position.z);

            float x = CameraOlho.transform.eulerAngles.x;
            float y = CameraOlho.transform.eulerAngles.y;
            rotatio = new Vector3(0, CameraOlho.transform.eulerAngles.y, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotatio), Time.deltaTime);







        }
        if (!pode)
        {
            waittime = waittime - Time.deltaTime;
            if (waittime<0)
            {
               // Playerr.PlayerPodeAndar = true;
                pode = !pode;
            }
        }
      


      

    }
}

           
         
        

