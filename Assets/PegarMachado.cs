using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegarMachado : MonoBehaviour {

    public GameObject mao;
    public GameObject canvasInfo;
   public bool pode=false;
    public float tempo=1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if ((mao!=null) && pode)
        {
            mao.transform.position = this.transform.position;
            mao.transform.rotation = this.transform.rotation;

        }
        if (!pode)
        {
            tempo = tempo - Time.deltaTime;
            if (tempo<0)
            {
                this.GetComponent<BoxCollider>().enabled = true;
                pode = true;
                
               
            }
        }

        if (((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))))
        {
           
            this.GetComponent<BoxCollider>().enabled = false;
            // mao.GetComponent<BoxCollider>().enabled = true;   
            if (mao!=null)
            {
                mao.GetComponent<Rigidbody>().useGravity = true;
                transform.GetChild(0).gameObject.transform.parent = null;
            }           
            
            pode = false;                        
            mao = null;
            tempo = 1.5f;
           
        }
      
	}


    private void OnTriggerEnter(Collider other)
    {
        if (mao == null)
        {
            if (other.CompareTag("Maxado"))
            {

                other.transform.parent = this.transform;
                mao = other.gameObject;
                other.GetComponent<Rigidbody>().useGravity = false;

                canvasInfo.GetComponent<TextoInformativoInicial>().tempoTexto = 6.0f;
                canvasInfo.GetComponent<TextoInformativoInicial>().text.fontStyle= FontStyle.Bold; 
                canvasInfo.GetComponent<TextoInformativoInicial>().text.text = "procure a arvore para conseguir \n madeira para o bote!";

                //  other.GetComponent<BoxCollider>().enabled=false;            

            }
        }
        if (mao==null)
        {
        
        if (other.CompareTag("madeira"))
        {
            other.transform.parent = this.transform;
            mao = other.gameObject;
            other.GetComponent<Rigidbody>().useGravity = false;

                canvasInfo.GetComponent<TextoInformativoInicial>().tempoTexto = 6.0f;
                canvasInfo.GetComponent<TextoInformativoInicial>().text.fontStyle = FontStyle.Bold;
                canvasInfo.GetComponent<TextoInformativoInicial>().text.text = "Leve a madeira ate o bote!";
                //  other.GetComponent<BoxCollider>().enabled=false;            

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
       // this.GetComponent<BoxCollider>().enabled = true;
    }

}
