using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour {
    public float tempoRecarga = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        tempoRecarga = tempoRecarga - Time.deltaTime;
        if (tempoRecarga<0)
        {
            SceneManager.LoadScene(0);

        }

	}
}
