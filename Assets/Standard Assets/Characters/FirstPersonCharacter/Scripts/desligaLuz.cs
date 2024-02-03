using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desligaLuz : MonoBehaviour {
    public GameObject[] luzOn,luzOff;

    

    public  bool on = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void swithlight()
    {

        if (on)
        {
            for (int i = 0; i < luzOn.Length; i++)
            {
                luzOn[i].SetActive(false);               
                
            }
            for (int i = 0; i < luzOff.Length; i++)
            {
               
                luzOff[i].SetActive(true);
               
            }



            on = !on;
        }
        else
        {
            for (int i = 0; i < luzOn.Length; i++)
            {
                luzOn[i].SetActive(true);
               
            }
            for (int i = 0; i < luzOff.Length; i++)
            {
                luzOff[i].SetActive(false);
              
            }

            on = !on;
        }

    }
}
