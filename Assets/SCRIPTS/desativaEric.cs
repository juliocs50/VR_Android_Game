using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desativaEric : MonoBehaviour {
    public GameObject eric;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      //  print(transform.rotation.eulerAngles.x);
        //print(transform.rotation.eulerAngles.z);

        if ((transform.rotation.eulerAngles.x > 80)&& (transform.rotation.eulerAngles.x < 90))
        {
            eric.SetActive(false);
        }
        else {
            eric.SetActive(true);
        }
	}
}
