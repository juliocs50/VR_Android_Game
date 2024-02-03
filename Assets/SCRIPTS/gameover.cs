using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameover : MonoBehaviour {
    float tempo = 0.3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempo = tempo - Time.deltaTime;
        if (tempo<0)
        {
            SceneManager.LoadScene(0);
        }
       
    }
}
