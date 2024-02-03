using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falas : MonoBehaviour {
    bool inicia = false;
    int filhos;
    int i=0;
    public float tempo=2.0f;
    void Start () {
        inicia = true;
        filhos = this.transform.childCount;
    }
	
	
	void Update () {
        if (inicia)
        {
            tempo = tempo - Time.deltaTime;
            if (filhos!= i)
            {
                if (tempo < 0)
                {
                    if (i>0)
                    {
                        transform.GetChild(i-1).gameObject.SetActive(false);
                    }
                    transform.GetChild(i).gameObject.SetActive(true);
                    i++;
                    tempo = 4.0f;
                }
            }
            else
            {
                inicia = false;               
            }  
        }
        else
        {
            tempo = tempo - Time.deltaTime;
            if (tempo<0)
            {
                Destroy(this.gameObject);
            }
           
        }

	}
}
