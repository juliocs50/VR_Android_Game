using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPegarMaxado : MonoBehaviour {


    public GameObject InfoCanvasPegarMaxado;
    public GameObject canvasInfo;


    void Start()
    {
        InfoCanvasPegarMaxado.SetActive(false);

    }
  
	
	




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InfoCanvasPegarMaxado.SetActive(true);
            canvasInfo.GetComponent<TextoInformativoInicial>().textoInicial = false;
            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))){
               

               Destroy(this.gameObject);
                Destroy(InfoCanvasPegarMaxado.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InfoCanvasPegarMaxado.SetActive(false);
        }
    }

}
