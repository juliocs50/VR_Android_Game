using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerEric_Animation : MonoBehaviour{
    public Animator playerAnimation;
    float w8time;
    bool PlayerPodeAndar = true;
    void Update() {
        CheckForPlayerInput();
    }

    void CheckForPlayerInput()
    {

      

        if ((Mathf.Abs(Input.GetAxis("Vertical")) > 0 )&& PlayerPodeAndar)
        {
            //criar animator
          //  playerAnimation.SetBool("Andou", true);
        }
        else
        {
          //  playerAnimation.SetBool("Andou", false);
        }

        if (PlayerPodeAndar == false)
        {
            w8time = w8time - Time.deltaTime;
            if (w8time < 0)
            {
                PlayerPodeAndar = true;
            }
        }

        

        if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.JoystickButton0)) )
        {
          //  if (PlayerPodeAndar)
          //  {
             //   PlayerPodeAndar = false;
                //    playerAnimation.SetBool("pegar", true);
              //  w8time = 1.5f;
           // }
          

        }
        else
        {
           // playerAnimation.SetBool("pegar", false);
        }




        if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.JoystickButton3)))
        {
            
           // PlayerPodeAndar = false;
            //playerAnimation.SetBool("olhar", true);
            //w8time = 1.5f;
          
        }
        else
        {
           // playerAnimation.SetBool("olhar", false);
        }

    }


    private void FixedUpdate()
    {
    }
}
