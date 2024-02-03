using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoletuto : MonoBehaviour {
    public int score = 0;
    Animator anim;
    public Animator AnimA;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

       if (((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))))
        {

            

            RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit))
        {
                AnimA.SetBool("apertou", true);
                anim.SetBool("martela", true);
                if (hit.transform.GetComponent<Moletuto>()!=null)
                {
                    Moletuto mole = hit.transform.GetComponent<Moletuto>();
                    mole.OnHit();
                    score++;

                }
         

        }
        }


        if (((Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.JoystickButton0)))) {
            anim.SetBool("martela", false);
            AnimA.SetBool("apertou", false);
        }

    }
}
