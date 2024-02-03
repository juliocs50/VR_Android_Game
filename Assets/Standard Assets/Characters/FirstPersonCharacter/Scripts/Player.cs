using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;


namespace Footsteps
{
    public class Player : MonoBehaviour
    {
        public bool pode = false;
        bool parouDeolhar= true;


        public int speed = 2;
        private Rigidbody rigid;
        public GameObject interruptor, painel;
        public GameObject camera;
        public GameObject ButtonCanvas;
        float v;
      //  public  bool PlayerPodeAndar = true;
        // Use this for initialization
        float w8time;
        public bool PodeAndar = true;
        float TempoDeEspera;
        public void FixedUpdate()
        {
           
        }

        void Start()
        {
           
            rigid = GetComponent<Rigidbody>();
            camera = transform.GetChild(0).gameObject;
        }
        float tempodesastivado=0.5f, tempoativado;
       public bool andaSom = false;

        void AndandoSom()
        {
            if (PodeAndar)
            {

           
            if (andaSom)
            {
                tempodesastivado = tempodesastivado - Time.deltaTime;
                if (tempodesastivado < 0)
                {
                    GetComponent<CharacterFootsteps>().changeDistanceCheck2();
                    tempodesastivado = 0.5f;
                }
                else
                {
                    GetComponent<CharacterFootsteps>().changeDistanceCheck();
                }

            }
         }


        }

        void Update()
        {
           
                 

            AndandoSom();
            if (parouDeolhar)
            { 

            
            if (!PodeAndar)
            {
                TempoDeEspera = TempoDeEspera - Time.deltaTime;
                if (TempoDeEspera < 0)
                {
                    PodeAndar = !PodeAndar;
                }

            }
            }

            if (PodeAndar)
            {
                if ((Mathf.Abs(Input.GetAxis("Vertical")) > 0))
                {
                    andaSom = true;


                }
                else
                {

                    andaSom = false;
                }

            }
            if (((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))) && (((Mathf.Abs(Input.GetAxis("Vertical")) == 0))))
            {
                if (PodeAndar)
                {
                    PodeAndar = false;
                    parouDeolhar = false;
                    TempoDeEspera = 2.5f;

                }
              
             
            }

            else if (((Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.JoystickButton0))))
            {
                parouDeolhar = true;

            }

            if (((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton3))) && (((Mathf.Abs(Input.GetAxis("Vertical")) == 0))))
            {
              
                if (PodeAndar)
                {                    
                    TempoDeEspera = 2.5f;
                    parouDeolhar = false;
                    PodeAndar = false;
                }




            }
            else if (((Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton3))))
            {
                parouDeolhar = true;
              
            }



        }


               


    }



}