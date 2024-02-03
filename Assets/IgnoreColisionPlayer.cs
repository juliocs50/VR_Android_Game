using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColisionPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<Collider>());
        }
        if (collision.gameObject.tag == "Maxado")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<Collider>());
        }
    }

 }
