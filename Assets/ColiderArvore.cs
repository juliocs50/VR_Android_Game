using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderArvore : MonoBehaviour {
    public GameObject madeira;
    bool podeCriar;
    float tempo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!podeCriar)
        {
            tempo = tempo - Time.deltaTime;

            if (tempo<0)
            {
                podeCriar = !podeCriar;
            }
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (podeCriar)
        {
            if (other.tag == "arvore")
            {
                tempo = 2.5f;
                Instantiate(madeira, this.transform.position, this.transform.rotation);
                podeCriar = false;

            }

        }
      
        
    }



}
