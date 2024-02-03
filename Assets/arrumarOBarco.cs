using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class arrumarOBarco : MonoBehaviour {


    public GameObject mao;
    public GameObject InfoCanvas;
	// Use this for initialization
	void Start () {
        InfoCanvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mao") {
            //   if (mao.transform.childCount >= 0)
            //  {
            // InfoCanvas.SetActive(true);
            // }
            if ((mao.transform.childCount > 0) && (mao.transform.GetChild(0).gameObject.tag == "madeira"))
            {
                SceneManager.LoadScene("RVMiniGameTutorial");
            }
            else
            {
                InfoCanvas.SetActive(true);
            }
         
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
    if (other.gameObject.tag == "mao")
    {
            InfoCanvas.SetActive(false);
        }
    }
}
