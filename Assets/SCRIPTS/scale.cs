using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

        GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.z, GetComponent<BoxCollider>().size.z, GetComponent<BoxCollider>().size.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
