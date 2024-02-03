using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaAnimacaoCama : MonoBehaviour {
    Animator ani;


	// Use this for initialization
	void Start () {
        ani = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ani.enabled = true;
        }
    }

}
