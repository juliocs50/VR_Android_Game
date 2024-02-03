using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaCameraScript : MonoBehaviour {
    public Animator playerAnimation;
    // Use this for initialization
    void Start () {
        playerAnimation = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
        //    playerAnimation.SetBool("pegou", true);


        }
        else
        {
           // playerAnimation.SetBool("pegou", false);

        }
    }
}
