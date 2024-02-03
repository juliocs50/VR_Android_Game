using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalasCreditos : MonoBehaviour {
    bool inicia = false;
    int filhos;
    int i=0;
    float tempo=2.0f;
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
                    transform.GetChild(i).gameObject.SetActive(true);
                    i++;
                    tempo = 2.0f;
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
                Application.Quit();
            }
           
        }

	}
}
