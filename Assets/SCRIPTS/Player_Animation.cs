using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Animation : NetworkBehaviour {
    public Animation playerAnimation;

    void Update() {
        CheckForPlayerInput();
    }

    void CheckForPlayerInput()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal"))>0)
        {
            //criar animator
           // playerAnimation.SetBool("Moving", true);
        }
        else
        {
            //playerAnimation.SetBool("Moving", false);
        }

    }
}
