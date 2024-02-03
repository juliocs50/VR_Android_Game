using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tempoDeTerminar : MonoBehaviour {
    public float tempo = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempo = tempo - Time.deltaTime;
        if (tempo<0)
        {
            SceneManager.LoadScene("RVFinal");
        }
	}
}
