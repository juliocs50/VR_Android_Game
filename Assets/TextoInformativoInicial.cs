using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoInformativoInicial : MonoBehaviour {
    public float tempoTexto = 20;
   public bool textoInicial = true;
    public TextMesh text;
	// Use this for initialization
	void Start () {
        text = GetComponent<TextMesh>();

    }
	
	// Update is called once per frame
	void Update () {
        if (tempoTexto>0)
        {
            tempoTexto = tempoTexto - Time.deltaTime;
            if ((tempoTexto < 13)&& textoInicial)
            {
                text.fontStyle = FontStyle.Bold;
                text.text =  "Encontre o machado!!";                
             

            }

            if ((tempoTexto < 7) && textoInicial)
            {
                text.fontStyle = FontStyle.Bold;
                text.text = "use a alavanca do controle \n para andar!";


            }



            if (tempoTexto < 0)
            {
                textoInicial=false;
                text.text = "";
            }

        }
      


	}


}
