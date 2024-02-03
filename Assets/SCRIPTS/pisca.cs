using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisca : MonoBehaviour {

    float random_time = 1.0f;
    bool liga = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        random_time = random_time - Time.deltaTime;
        if (random_time < 0)
        {
           

            random_time = Random.Range(0.4f, 2.0f);
            
            liga = !liga;

        }
        if(liga)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            transform.GetChild(1).transform.gameObject.SetActive(false);
           
          

        }
        else
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
            transform.GetChild(1).transform.gameObject.SetActive(true);
            

        }


	}
}
