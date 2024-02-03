using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovePlayer : MonoBehaviour {
    float v;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        v = CrossPlatformInputManager.GetAxis("Vertical");
        v = Input.GetAxis("Vertical");

        if (v > 0.2f)
        {
           
           // transform.position = transform.position + Camera.main.transform.forward * 5 * Time.deltaTime;
        }
        else
        {
         
        }
    }
}
