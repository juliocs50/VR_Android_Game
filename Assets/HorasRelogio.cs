using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HorasRelogio : MonoBehaviour {
    float tempo;
    int minutos= 50;
   public int horas=19;

 
	
	// Update is called once per frame
	void FixedUpdate () {


        tempo = tempo + Time.deltaTime;

        GetComponent<Text>().text = horas + ":"+minutos+ ":"+ Mathf.FloorToInt(tempo);

        if (tempo>60)
        {
            tempo = 0;
            minutos++;

        }
        if (minutos>60)
        {
            horas++;

        }

        if (minutos>54)
        {
            SceneManager.LoadScene(0);
        }
	}
}
