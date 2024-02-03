using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DesligaPainel : MonoBehaviour {
   
        public GameObject[] PainelOn, PainelOff;

    public GameObject jogador;

        public bool on = true;
        bool ganhou=false;
    float Ti = 2.0f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        if (ganhou)
        {
            //ativa creditos
            Ti =Ti-Time.deltaTime ;
            if (Ti<0)
            {
                SceneManager.LoadScene("SampleSceneNormalLevel2");
            }
           
            jogador.transform.GetChild(2).gameObject.SetActive(true);
        }

        }
        public void swithlight()
        {
        if (!ganhou)
        {

     
            if (on)
            {
                for (int i = 0; i < PainelOn.Length; i++)
                {
                PainelOn[i].SetActive(false);

                }
                for (int i = 0; i < PainelOff.Length; i++)
                {

                PainelOff[i].SetActive(true);

                }

           

                on = !on;

             
                ganhou = true;
            }
            else
            {
                for (int i = 0; i < PainelOn.Length; i++)
                {
                PainelOn[i].SetActive(true);

                }
                for (int i = 0; i < PainelOff.Length; i++)
                {
                PainelOff[i].SetActive(false);

                }
               

                on = !on;
               
            }
        }
    }
    }