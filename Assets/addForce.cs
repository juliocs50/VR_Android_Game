using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour {
    public Rigidbody rid;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        rid.AddForce(-transform.forward * speed/4);
        if ((Mathf.Abs(Input.GetAxis("Vertical")) > 0))
        {
            rid.AddForce(-transform.forward * speed );
            // this.transform.position = this.transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }
        else
        {
           
        }
    }
}
