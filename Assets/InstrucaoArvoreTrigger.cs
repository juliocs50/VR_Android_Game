using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrucaoArvoreTrigger : MonoBehaviour {

    public GameObject mao;
    public GameObject InfoCanvasComMaxado;
    public GameObject InfoCanvasSemMaxado;


    void Start()
    {
        InfoCanvasComMaxado.SetActive(false);
        InfoCanvasSemMaxado.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "mao")
        {
            //   if (mao.transform.childCount >= 0)
            //  {
            // InfoCanvas.SetActive(true);
            // }
            if ((mao.transform.childCount > 0) && (mao.transform.GetChild(0).gameObject.tag == "Maxado"))
            {
                InfoCanvasComMaxado.SetActive(true);
                InfoCanvasSemMaxado.SetActive(false);
            }
            else
            {
                InfoCanvasComMaxado.SetActive(false);
                InfoCanvasSemMaxado.SetActive(true);
            }


        }
    }





    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "mao")
        {
            InfoCanvasComMaxado.SetActive(false);
            InfoCanvasSemMaxado.SetActive(false);
        }
    }

}
